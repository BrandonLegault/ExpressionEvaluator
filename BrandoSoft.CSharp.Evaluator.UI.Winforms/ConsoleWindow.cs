namespace BrandoSoft.Evaluator.UI.Winforms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Exposes the Expression Evaluator as a console window.
    /// </summary>
    public partial class ConsoleWindow 
        : UserControl
    {
        #region Variables

        /// <summary>
        /// A list of our previously entered debug commands
        /// </summary>
        private readonly List<string> _previousDebugCommands;

        /// <summary>
        /// Keeps index so the user can press up or down to retrieve past commands
        /// </summary>
        private int _debugCommandIndex;
        #endregion


        #region Constructor

        public ConsoleWindow()
        {
            this.InitializeComponent();

            this._previousDebugCommands = new List<string>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the text that appears in the output box of the console window
        /// </summary>
        public string OutputText
        {
            get { return this.txtConsoleOut.Text; }
            set { this.txtConsoleOut.Text = value; }
        }

        /// <summary>
        /// True if the input textbox of this control should be multiline.
        /// </summary>
        public bool MultilineInput { get; set; }

        /// <summary>
        /// The key (or key combination) that should be used to submit text to the expression evaluator. This is a flags field.
        /// </summary>
        public Keys AcceptKey { get; set; }

        #endregion


        private void txtConsoleIn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this._debugCommandIndex = Math.Max(0, this._debugCommandIndex - 1);
                this.txtConsoleIn.Text = this._previousDebugCommands[this._debugCommandIndex];
                this.txtConsoleIn.Select(this.txtConsoleIn.TextLength + 1, 0);
            }
            else if (e.KeyCode == Keys.Down)
            {
                this._debugCommandIndex = Math.Min(this._previousDebugCommands.Count, this._debugCommandIndex + 1);
                this.txtConsoleIn.Text = this._debugCommandIndex < this._previousDebugCommands.Count
                                       ? this._previousDebugCommands[this._debugCommandIndex]
                                       : string.Empty;
                this.txtConsoleIn.Select(this.txtConsoleIn.TextLength + 1, 0);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                //This function checks whether or not we can submit the command before submitting
                this.SubmitConsoleCommand();
            }
        }

        
        private void SubmitConsoleCommand()
        {
            
            //Just return if the console isn't up, the textbox doesn't have input focus 
            //or there's nothing in the textbox.
            if (!this.txtConsoleIn.Focused || string.IsNullOrEmpty(this.txtConsoleIn.Text)) return;

            this._previousDebugCommands.Add(this.txtConsoleIn.Text);
            this._debugCommandIndex = this._previousDebugCommands.Count;

            var output = this._expressionEvaluator.Evaluate(this.txtConsoleIn.Text);

            this.txtConsoleOut.AppendText($"\r\n{this.txtConsoleIn.Text}\r\n\t{output}");
            this.txtConsoleIn.Clear();

        }

        private void ConsoleWindow_Resize(object sender, EventArgs e)
        {

        }
    }
}
