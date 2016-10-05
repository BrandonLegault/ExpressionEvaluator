/*
    MIT License

    Copyright (c) 2016 BrandonLegault

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE. 
 */

using System.Drawing;

namespace BrandoSoft.CSharp.Evaluator.UI.Winforms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.ComponentModel;

    /// <summary>
    /// Exposes the Expression Evaluator as a console window.
    /// </summary>
    public sealed partial class ConsoleWindow
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
        
        /// <summary>
        /// A key combination of the keypress required to submit the text entry.
        /// </summary>
        private Keys _acceptKeys;

        /// <summary>
        /// Whether or not the mouse is physically hovering over the splitter.
        /// </summary>
        private bool _mouseOnSplitter;

        /// <summary>
        /// If we've clicked the mouse down.
        /// </summary>
        private bool _isMouseDown;

        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the text that appears in the output box of the console window
        /// </summary>
        [Browsable(true)]
        [Description("Gets or sets the text that appears in the output box of the console window")]
        public string OutputText
        {
            get { return this.txtConsoleOut.Text; }
            set { this.txtConsoleOut.Text = value; }
        }

        /// <summary>
        /// Gets or sets whether the input textbox of this control should be multiline.
        /// </summary>
        [Browsable(true)]
        [Description("Gets or sets whether the input textbox of this control should be multiline.")]
        public bool MultilineInput
        {
            get
            {
                return this.txtConsoleIn.Multiline;
            }
            set
            {
                this.txtConsoleIn.Multiline = value;

                if ( value )
                {
                    this.lblSplitter.Height = 2;
                    this.ResizeSplit(this.SplitterDistance);
                }
                else
                {
                    this.lblSplitter.Height = 0;

                    //We resize to this.Height to force the splitter and input box to draw at the lowest point on the control.
                    this.ResizeSplit(this.Height);
                }
            }
        }

        /// <summary>
        /// Gets or sets the distance in pixels of the splitter from the top of the control.
        /// </summary>
        [Browsable(true)]
        [Description("Gets or sets the distance in pixels of the splitter from the top of the control.")]
        public int SplitterDistance
        {
            get { return this.lblSplitter.Top; }
            set
            {
                var multilineResize = this.MultilineInput ? value : this.Height;
                this.ResizeSplit(multilineResize);
            }
        }
        
        /// <summary>
        /// Gets or sets the key (or key combination) that should be used to submit text to the expression evaluator. This is a flags field.
        /// </summary>
        [Browsable(true)]
        [Description("Gets or sets the key (or key combination) that should be used to submit text to the expression evaluator. This is a flags field.")]
        public Keys AcceptKey
        {
            get { return this._acceptKeys; }
            set
            {
                if (value.HasFlag(Keys.Up) || value.HasFlag(Keys.Down))
                {
                    throw new Exception("Up and down keys are reserved by the console.");
                }
                this._acceptKeys = value;
            }
        }

        /// <summary>
        /// Gets or sets the IExpressionEvaluator used to evaluate expressions on this console window.
        /// </summary>
        [Browsable(false)]
        public IExpressionEvaluator ExpressionEvaluator { get; set; }

        /// <summary>
        /// Gets a value indicating whether the control has input focus
        /// </summary>
        [Browsable(false)]
        public override bool Focused => this.txtConsoleIn.Focused || this.txtConsoleOut.Focused;

        #endregion


        #region Constructor
        
        public ConsoleWindow()
        {
            this.InitializeComponent();

            this._acceptKeys = Keys.Enter;
            this._previousDebugCommands = new List<string>();
            
            this.MultilineInput = true;
        }
        
        #endregion
        

        #region Methods

        /// <summary>
        /// Runs the evaluator's evaluate method with the text in the input box.
        /// </summary>
        public void SubmitCurrentCommand()
        {

            if ( this.ExpressionEvaluator == null )
            {
                throw new Exception("No Expression Evaluator has been assigned to the console window. The ExpressionEvaluator property must be set.");
            }

            //Just return the textbox doesn't have input focus or there's nothing in the textbox.
            if (!this.txtConsoleIn.Focused || string.IsNullOrEmpty(this.txtConsoleIn.Text)) return;

            this._previousDebugCommands.Add(this.txtConsoleIn.Text);
            this._debugCommandIndex = this._previousDebugCommands.Count;

            var output = this.ExpressionEvaluator.Evaluate(this.txtConsoleIn.Text);

            this.txtConsoleOut.AppendText($"\r\n{this.txtConsoleIn.Text}\r\n\t{output}");
            this.txtConsoleIn.Clear();

        }

        /// <summary>
        /// Sets input control to the input textbox
        /// </summary>
        public new bool Focus()
        {
            return this.txtConsoleIn.Focus();
        }

        private void ResizeSplit(int value)
        {
            int splitterTop = value;

            if (value < 20) splitterTop = 20;

            if (this.Height - value - this.lblSplitter.Height < 20)
            {
                splitterTop = this.Height - 20 - this.lblSplitter.Height;
            }

            var outHeight = splitterTop;
            var splitterBottom = splitterTop + this.lblSplitter.Height;

            var inHeight = this.Height - splitterBottom;


            this.lblSplitter.Top = splitterTop;
            this.txtConsoleIn.Top = splitterBottom;

            this.txtConsoleIn.Height = inHeight;
            this.txtConsoleOut.Height = outHeight;
        }

        private Point TranslateChildCoordinateToParent(Control child, Point childPoint)
        {
            var screenCoord = child.PointToScreen(childPoint);
            return this.PointToClient(screenCoord);

        }

        private MouseEventArgs TranslateChildMouseEventToParent(object sender, MouseEventArgs e)
        {
            var translatedChild = this.TranslateChildCoordinateToParent((Control)sender, e.Location);
            return new MouseEventArgs(e.Button, e.Clicks, translatedChild.X, translatedChild.Y, e.Delta);
        }



        #endregion
        #region Control Events

        private void txtConsoleIn_KeyUp(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Up )
            {
                this._debugCommandIndex = Math.Max(0, this._debugCommandIndex - 1);
                this.txtConsoleIn.Text = this._previousDebugCommands[this._debugCommandIndex];
                this.txtConsoleIn.Select(this.txtConsoleIn.TextLength + 1, 0);
            }
            else if ( e.KeyCode == Keys.Down )
            {
                this._debugCommandIndex = Math.Min(this._previousDebugCommands.Count, this._debugCommandIndex + 1);
                this.txtConsoleIn.Text = this._debugCommandIndex < this._previousDebugCommands.Count
                    ? this._previousDebugCommands[this._debugCommandIndex]
                    : string.Empty;
                this.txtConsoleIn.Select(this.txtConsoleIn.TextLength + 1, 0);
            }
            else if ( e.KeyCode == this._acceptKeys )
            {
                //This function checks whether or not we can submit the command before submitting
                this.SubmitCurrentCommand();
            }
        }

        private void lblSplitter_MouseDown(object sender, MouseEventArgs e)
        {
            this._isMouseDown = true;
            e = this.TranslateChildMouseEventToParent(sender, e);
            this.OnMouseDown(e);
        }

        private void lblSplitter_MouseUp(object sender, MouseEventArgs e)
        {
            this._isMouseDown = false;
            e = this.TranslateChildMouseEventToParent(sender, e);
            this.OnMouseUp(e);
        }

        private void lblSplitter_MouseEnter(object sender, EventArgs e)
        {
            this._mouseOnSplitter = true;
            this.Cursor = Cursors.HSplit;
            this.OnMouseEnter(e);

        }

        private void lblSplitter_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this._mouseOnSplitter = false;
            this.OnMouseLeave(e);
        }
        
        private void lblSplitter_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._mouseOnSplitter && this._isMouseDown)
            {
                this.ResizeSplit(this.SplitterDistance + e.Y);
            }

            e = this.TranslateChildMouseEventToParent(sender, e);
            this.OnMouseMove(e);
        }


        private void textboxes_MouseDown(object sender, MouseEventArgs e)
        {
            e = this.TranslateChildMouseEventToParent(sender, e);
            this.OnMouseDown(e);
        }

        private void textboxes_MouseUp(object sender, MouseEventArgs e)
        {
            e = this.TranslateChildMouseEventToParent(sender, e);
            this.OnMouseUp(e);
        }

        private void textboxes_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textboxes_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textboxes_MouseMove(object sender, MouseEventArgs e)
        {
            e = this.TranslateChildMouseEventToParent(sender, e);
            this.OnMouseMove(e);
        }

        private void textboxes_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }

        #endregion

    }
}
