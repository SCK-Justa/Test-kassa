namespace Kassasysteem
{
    partial class BestelgeschiedenisScherm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvAfgerekendeBestellingen = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lvAfgerekendeBestellingen);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(711, 452);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Afgerekende bestellingen";
            // 
            // lvAfgerekendeBestellingen
            // 
            this.lvAfgerekendeBestellingen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader1});
            this.lvAfgerekendeBestellingen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAfgerekendeBestellingen.Location = new System.Drawing.Point(6, 19);
            this.lvAfgerekendeBestellingen.Name = "lvAfgerekendeBestellingen";
            this.lvAfgerekendeBestellingen.Size = new System.Drawing.Size(699, 424);
            this.lvAfgerekendeBestellingen.TabIndex = 0;
            this.lvAfgerekendeBestellingen.UseCompatibleStateImageBehavior = false;
            this.lvAfgerekendeBestellingen.View = System.Windows.Forms.View.Details;
            this.lvAfgerekendeBestellingen.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAfgerekendeBestellingen_ColumnClick);
            this.lvAfgerekendeBestellingen.Click += new System.EventHandler(this.lvAfgerekendeBestellingen_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Klantnaam";
            this.columnHeader3.Width = 221;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Totaalprijs";
            this.columnHeader4.Width = 87;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Datum/tijd";
            this.columnHeader5.Width = 189;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Betaald met munten";
            this.columnHeader1.Width = 196;
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btCancel.Location = new System.Drawing.Point(607, 470);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(110, 34);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // BestelgeschiedenisScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 513);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BestelgeschiedenisScherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvAfgerekendeBestellingen;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}