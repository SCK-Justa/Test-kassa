namespace Kassasysteem
{
    partial class NieuweGebruikerScherm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMachtiging = new System.Windows.Forms.CheckBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOpslaan = new System.Windows.Forms.Button();
            this.tbVolledigenaam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbWachtwoord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGebruikersnaam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvGebruikers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMachtiging);
            this.groupBox1.Controls.Add(this.btCancel);
            this.groupBox1.Controls.Add(this.btOpslaan);
            this.groupBox1.Controls.Add(this.tbVolledigenaam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbWachtwoord);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbGebruikersnaam);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(490, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 277);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nieuwe gebruiker";
            // 
            // cbMachtiging
            // 
            this.cbMachtiging.AutoSize = true;
            this.cbMachtiging.Location = new System.Drawing.Point(10, 202);
            this.cbMachtiging.Name = "cbMachtiging";
            this.cbMachtiging.Size = new System.Drawing.Size(115, 17);
            this.cbMachtiging.TabIndex = 8;
            this.cbMachtiging.Text = "Machtigingfuncties";
            this.cbMachtiging.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(140, 244);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(102, 27);
            this.btCancel.TabIndex = 7;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOpslaan
            // 
            this.btOpslaan.Location = new System.Drawing.Point(6, 244);
            this.btOpslaan.Name = "btOpslaan";
            this.btOpslaan.Size = new System.Drawing.Size(102, 27);
            this.btOpslaan.TabIndex = 6;
            this.btOpslaan.Text = "Opslaan";
            this.btOpslaan.UseVisualStyleBackColor = true;
            this.btOpslaan.Click += new System.EventHandler(this.btOpslaan_Click);
            // 
            // tbVolledigenaam
            // 
            this.tbVolledigenaam.Location = new System.Drawing.Point(7, 161);
            this.tbVolledigenaam.Name = "tbVolledigenaam";
            this.tbVolledigenaam.Size = new System.Drawing.Size(235, 20);
            this.tbVolledigenaam.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Volledige naam:";
            // 
            // tbWachtwoord
            // 
            this.tbWachtwoord.Location = new System.Drawing.Point(7, 97);
            this.tbWachtwoord.Name = "tbWachtwoord";
            this.tbWachtwoord.Size = new System.Drawing.Size(235, 20);
            this.tbWachtwoord.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wachtwoord:";
            // 
            // tbGebruikersnaam
            // 
            this.tbGebruikersnaam.Location = new System.Drawing.Point(7, 36);
            this.tbGebruikersnaam.Name = "tbGebruikersnaam";
            this.tbGebruikersnaam.Size = new System.Drawing.Size(235, 20);
            this.tbGebruikersnaam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gebruikersnaam:";
            // 
            // lvGebruikers
            // 
            this.lvGebruikers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvGebruikers.Location = new System.Drawing.Point(12, 12);
            this.lvGebruikers.Name = "lvGebruikers";
            this.lvGebruikers.Size = new System.Drawing.Size(472, 277);
            this.lvGebruikers.TabIndex = 1;
            this.lvGebruikers.UseCompatibleStateImageBehavior = false;
            this.lvGebruikers.View = System.Windows.Forms.View.Details;
            this.lvGebruikers.Click += new System.EventHandler(this.lvGebruikers_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 34;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Gebruikersnaam";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Wachtwoord";
            this.columnHeader3.Width = 78;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Volledige naam";
            this.columnHeader4.Width = 162;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Gemachtigd";
            this.columnHeader5.Width = 80;
            // 
            // NieuweGebruikerScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 301);
            this.Controls.Add(this.lvGebruikers);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NieuweGebruikerScherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nieuwe gebruiker toevoegen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOpslaan;
        private System.Windows.Forms.TextBox tbVolledigenaam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbWachtwoord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGebruikersnaam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbMachtiging;
        private System.Windows.Forms.ListView lvGebruikers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}