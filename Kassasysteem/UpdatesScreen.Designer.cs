namespace Kassasysteem
{
    partial class UpdatesScreen
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
            this.tbUpdates = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbUpdates
            // 
            this.tbUpdates.BackColor = System.Drawing.Color.White;
            this.tbUpdates.Enabled = false;
            this.tbUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbUpdates.Location = new System.Drawing.Point(12, 12);
            this.tbUpdates.Multiline = true;
            this.tbUpdates.Name = "tbUpdates";
            this.tbUpdates.Size = new System.Drawing.Size(968, 666);
            this.tbUpdates.TabIndex = 0;
            // 
            // UpdatesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 690);
            this.Controls.Add(this.tbUpdates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdatesScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUpdates;
    }
}