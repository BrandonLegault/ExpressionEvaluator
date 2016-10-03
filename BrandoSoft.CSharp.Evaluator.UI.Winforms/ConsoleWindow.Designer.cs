namespace BrandoSoft.Evaluator.UI.Winforms
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
            this.splContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splContainer)).BeginInit();
            this.splContainer.Panel1.SuspendLayout();
            this.splContainer.Panel2.SuspendLayout();
            this.splContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsoleIn
            // 
            this.txtConsoleIn.BackColor = System.Drawing.Color.Black;
            this.txtConsoleIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsoleIn.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsoleIn.ForeColor = System.Drawing.Color.White;
            this.txtConsoleIn.Location = new System.Drawing.Point(0, 0);
            this.txtConsoleIn.Margin = new System.Windows.Forms.Padding(0);
            this.txtConsoleIn.Name = "txtConsoleIn";
            this.txtConsoleIn.Size = new System.Drawing.Size(855, 20);
            this.txtConsoleIn.TabIndex = 1;
            this.txtConsoleIn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConsoleIn_KeyUp);
            // 
            // txtConsoleOut
            // 
            this.txtConsoleOut.BackColor = System.Drawing.Color.Black;
            this.txtConsoleOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsoleOut.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsoleOut.ForeColor = System.Drawing.Color.White;
            this.txtConsoleOut.Location = new System.Drawing.Point(0, 0);
            this.txtConsoleOut.Margin = new System.Windows.Forms.Padding(0);
            this.txtConsoleOut.Multiline = true;
            this.txtConsoleOut.Name = "txtConsoleOut";
            this.txtConsoleOut.ReadOnly = true;
            this.txtConsoleOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsoleOut.Size = new System.Drawing.Size(855, 643);
            this.txtConsoleOut.TabIndex = 0;
            // 
            // splContainer
            // 
            this.splContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splContainer.Location = new System.Drawing.Point(0, 0);
            this.splContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splContainer.Name = "splContainer";
            this.splContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splContainer.Panel1
            // 
            this.splContainer.Panel1.Controls.Add(this.txtConsoleOut);
            // 
            // splContainer.Panel2
            // 
            this.splContainer.Panel2.Controls.Add(this.txtConsoleIn);
            this.splContainer.Panel2MinSize = 0;
            this.splContainer.Size = new System.Drawing.Size(855, 672);
            this.splContainer.SplitterDistance = 643;
            this.splContainer.SplitterWidth = 1;
            this.splContainer.TabIndex = 2;
            // 
            // ConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splContainer);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConsoleWindow";
            this.Size = new System.Drawing.Size(855, 672);
            this.Resize += new System.EventHandler(this.ConsoleWindow_Resize);
            this.splContainer.Panel1.ResumeLayout(false);
            this.splContainer.Panel1.PerformLayout();
            this.splContainer.Panel2.ResumeLayout(false);
            this.splContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splContainer)).EndInit();
            this.splContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtConsoleOut;
        private System.Windows.Forms.TextBox txtConsoleIn;
        private System.Windows.Forms.SplitContainer splContainer;
    }
}
