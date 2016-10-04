namespace BrandoSoft.CSharp.Evaluator.UI.Winforms
{
    partial class ConsoleWindow
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtConsoleIn = new System.Windows.Forms.TextBox();
            this.txtConsoleOut = new System.Windows.Forms.TextBox();
            this.lblSplitter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtConsoleIn
            // 
            this.txtConsoleIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsoleIn.BackColor = System.Drawing.Color.Black;
            this.txtConsoleIn.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsoleIn.ForeColor = System.Drawing.Color.White;
            this.txtConsoleIn.Location = new System.Drawing.Point(0, 98);
            this.txtConsoleIn.Margin = new System.Windows.Forms.Padding(0);
            this.txtConsoleIn.MinimumSize = new System.Drawing.Size(4, 20);
            this.txtConsoleIn.Multiline = true;
            this.txtConsoleIn.Name = "txtConsoleIn";
            this.txtConsoleIn.Size = new System.Drawing.Size(433, 20);
            this.txtConsoleIn.TabIndex = 3;
            // 
            // txtConsoleOut
            // 
            this.txtConsoleOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsoleOut.BackColor = System.Drawing.Color.Black;
            this.txtConsoleOut.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsoleOut.ForeColor = System.Drawing.Color.White;
            this.txtConsoleOut.Location = new System.Drawing.Point(0, 0);
            this.txtConsoleOut.Margin = new System.Windows.Forms.Padding(0);
            this.txtConsoleOut.Multiline = true;
            this.txtConsoleOut.Name = "txtConsoleOut";
            this.txtConsoleOut.ReadOnly = true;
            this.txtConsoleOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsoleOut.Size = new System.Drawing.Size(433, 96);
            this.txtConsoleOut.TabIndex = 2;
            // 
            // lblSplitter
            // 
            this.lblSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSplitter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSplitter.Location = new System.Drawing.Point(0, 96);
            this.lblSplitter.Name = "lblSplitter";
            this.lblSplitter.Size = new System.Drawing.Size(433, 2);
            this.lblSplitter.TabIndex = 4;
            this.lblSplitter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblSplitter_MouseDown);
            this.lblSplitter.MouseEnter += new System.EventHandler(this.lblSplitter_MouseEnter);
            this.lblSplitter.MouseLeave += new System.EventHandler(this.lblSplitter_MouseLeave);
            this.lblSplitter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSplitter_MouseMove);
            this.lblSplitter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblSplitter_MouseUp);
            // 
            // ConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.lblSplitter);
            this.Controls.Add(this.txtConsoleIn);
            this.Controls.Add(this.txtConsoleOut);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(20, 46);
            this.Name = "ConsoleWindow";
            this.Size = new System.Drawing.Size(433, 118);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblSplitter_MouseDown);
            this.MouseEnter += new System.EventHandler(this.lblSplitter_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.lblSplitter_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSplitter_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblSplitter_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsoleIn;
        private System.Windows.Forms.TextBox txtConsoleOut;
        private System.Windows.Forms.Label lblSplitter;
    }
}
