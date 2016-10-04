namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.consoleWindow1 = new BrandoSoft.CSharp.Evaluator.UI.Winforms.ConsoleWindow();
            this.SuspendLayout();
            // 
            // consoleWindow1
            // 
            this.consoleWindow1.AcceptKey = System.Windows.Forms.Keys.Return;
            this.consoleWindow1.BackColor = System.Drawing.Color.Red;
            this.consoleWindow1.Location = new System.Drawing.Point(100, 127);
            this.consoleWindow1.Margin = new System.Windows.Forms.Padding(0);
            this.consoleWindow1.MinimumSize = new System.Drawing.Size(20, 46);
            this.consoleWindow1.MultilineInput = false;
            this.consoleWindow1.Name = "consoleWindow1";
            this.consoleWindow1.OutputText = "";
            this.consoleWindow1.Size = new System.Drawing.Size(433, 199);
            this.consoleWindow1.SplitterDistance = 179;
            this.consoleWindow1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.consoleWindow1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private BrandoSoft.CSharp.Evaluator.UI.Winforms.ConsoleWindow consoleWindow1;
    }
}

