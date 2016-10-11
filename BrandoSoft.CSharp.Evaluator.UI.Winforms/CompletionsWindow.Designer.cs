namespace BrandoSoft.CSharp.Evaluator.UI.Winforms
{
    partial class CompletionsWindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.pnlBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpContainer
            // 
            this.flpContainer.BackColor = System.Drawing.SystemColors.Control;
            this.flpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContainer.Location = new System.Drawing.Point(1, 1);
            this.flpContainer.Margin = new System.Windows.Forms.Padding(0);
            this.flpContainer.Name = "flpContainer";
            this.flpContainer.Size = new System.Drawing.Size(165, 21);
            this.flpContainer.TabIndex = 0;
            // 
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.Color.White;
            this.pnlBorder.Controls.Add(this.flpContainer);
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBorder.Size = new System.Drawing.Size(167, 23);
            this.pnlBorder.TabIndex = 0;
            // 
            // CompletionsWindow
            // 
            this.Controls.Add(this.pnlBorder);
            this.MinimumSize = new System.Drawing.Size(150, 0);
            this.Name = "CompletionsWindow";
            this.Size = new System.Drawing.Size(167, 23);
            this.Resize += new System.EventHandler(this.CompletionsWindow_Resize);
            this.pnlBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpContainer;
        private System.Windows.Forms.Panel pnlBorder;
    }
}
