namespace Kassasysteem
{
    partial class GebruikerScherm
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
            this.btSluiten = new System.Windows.Forms.Button();
            this.btSaveChanges = new System.Windows.Forms.Button();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbGebruikersnaam = new System.Windows.Forms.Label();
            this.lbVolledigeNaam = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btWijzigProducten = new System.Windows.Forms.Button();
            this.btResetBestellingen = new System.Windows.Forms.Button();
            this.btWijzigGebruikers = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSluiten);
            this.groupBox1.Controls.Add(this.btSaveChanges);
            this.groupBox1.Controls.Add(this.tbFullName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbConfirmPassword);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(338, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 283);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Verander gegevens";
            // 
            // btSluiten
            // 
            this.btSluiten.Location = new System.Drawing.Point(204, 249);
            this.btSluiten.Name = "btSluiten";
            this.btSluiten.Size = new System.Drawing.Size(100, 28);
            this.btSluiten.TabIndex = 9;
            this.btSluiten.Text = "Sluiten";
            this.btSluiten.UseVisualStyleBackColor = true;
            this.btSluiten.Click += new System.EventHandler(this.btSluiten_Click);
            // 
            // btSaveChanges
            // 
            this.btSaveChanges.Location = new System.Drawing.Point(6, 249);
            this.btSaveChanges.Name = "btSaveChanges";
            this.btSaveChanges.Size = new System.Drawing.Size(100, 28);
            this.btSaveChanges.TabIndex = 8;
            this.btSaveChanges.Text = "Save";
            this.btSaveChanges.UseVisualStyleBackColor = true;
            this.btSaveChanges.Click += new System.EventHandler(this.btSaveChanges_Click);
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(6, 206);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(298, 20);
            this.tbFullName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(7, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Volledige naam:";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(6, 147);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(298, 20);
            this.tbConfirmPassword.TabIndex = 5;
            this.tbConfirmPassword.UseSystemPasswordChar = true;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(6, 92);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(298, 20);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(6, 38);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(298, 20);
            this.tbUsername.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(7, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bevestig wachtwoord:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wachtwoord:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gebruikersnaam:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbGebruikersnaam);
            this.groupBox2.Controls.Add(this.lbVolledigeNaam);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(13, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gegevens";
            // 
            // lbGebruikersnaam
            // 
            this.lbGebruikersnaam.AutoSize = true;
            this.lbGebruikersnaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbGebruikersnaam.Location = new System.Drawing.Point(6, 39);
            this.lbGebruikersnaam.Name = "lbGebruikersnaam";
            this.lbGebruikersnaam.Size = new System.Drawing.Size(41, 15);
            this.lbGebruikersnaam.TabIndex = 12;
            this.lbGebruikersnaam.Text = "label1";
            // 
            // lbVolledigeNaam
            // 
            this.lbVolledigeNaam.AutoSize = true;
            this.lbVolledigeNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbVolledigeNaam.Location = new System.Drawing.Point(6, 93);
            this.lbVolledigeNaam.Name = "lbVolledigeNaam";
            this.lbVolledigeNaam.Size = new System.Drawing.Size(41, 15);
            this.lbVolledigeNaam.TabIndex = 11;
            this.lbVolledigeNaam.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Volledige naam:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Gebruikersnaam:";
            // 
            // btWijzigProducten
            // 
            this.btWijzigProducten.Location = new System.Drawing.Point(118, 141);
            this.btWijzigProducten.Name = "btWijzigProducten";
            this.btWijzigProducten.Size = new System.Drawing.Size(100, 38);
            this.btWijzigProducten.TabIndex = 15;
            this.btWijzigProducten.Text = "Wijzig producten";
            this.btWijzigProducten.UseVisualStyleBackColor = true;
            this.btWijzigProducten.Click += new System.EventHandler(this.btWijzigProducten_Click);
            // 
            // btResetBestellingen
            // 
            this.btResetBestellingen.Location = new System.Drawing.Point(12, 141);
            this.btResetBestellingen.Name = "btResetBestellingen";
            this.btResetBestellingen.Size = new System.Drawing.Size(100, 38);
            this.btResetBestellingen.TabIndex = 14;
            this.btResetBestellingen.Text = "Reset bestellingen";
            this.btResetBestellingen.UseVisualStyleBackColor = true;
            this.btResetBestellingen.Click += new System.EventHandler(this.btResetBestellingen_Click);
            // 
            // btWijzigGebruikers
            // 
            this.btWijzigGebruikers.Location = new System.Drawing.Point(224, 141);
            this.btWijzigGebruikers.Name = "btWijzigGebruikers";
            this.btWijzigGebruikers.Size = new System.Drawing.Size(100, 38);
            this.btWijzigGebruikers.TabIndex = 16;
            this.btWijzigGebruikers.Text = "Wijzig gebruikers";
            this.btWijzigGebruikers.UseVisualStyleBackColor = true;
            this.btWijzigGebruikers.Click += new System.EventHandler(this.btWijzigGebruikers_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(14, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 92);
            this.label7.TabIndex = 17;
            this.label7.Text = "Under \r\nconstruction!";
            // 
            // GebruikerScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 305);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btWijzigGebruikers);
            this.Controls.Add(this.btWijzigProducten);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btResetBestellingen);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GebruikerScherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gebruikergegevens";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSaveChanges;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbGebruikersnaam;
        private System.Windows.Forms.Label lbVolledigeNaam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btWijzigProducten;
        private System.Windows.Forms.Button btResetBestellingen;
        private System.Windows.Forms.Button btWijzigGebruikers;
        private System.Windows.Forms.Button btSluiten;
        private System.Windows.Forms.Label label7;
    }
}