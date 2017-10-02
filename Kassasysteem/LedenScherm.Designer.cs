namespace Kassasysteem
{
    partial class LedenScherm
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
            this.lvLeden = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btToevoegen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvLeden
            // 
            this.lvLeden.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.lvLeden.Location = new System.Drawing.Point(12, 57);
            this.lvLeden.Name = "lvLeden";
            this.lvLeden.Size = new System.Drawing.Size(968, 621);
            this.lvLeden.TabIndex = 0;
            this.lvLeden.UseCompatibleStateImageBehavior = false;
            this.lvLeden.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Bondsnummer";
            this.columnHeader1.Width = 61;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Voornaam";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tussenvoegsel";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Achternaam";
            this.columnHeader4.Width = 77;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Emailadres";
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Adres";
            this.columnHeader6.Width = 48;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Postcode";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Woonplaats";
            this.columnHeader8.Width = 56;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Telefoonnummer";
            this.columnHeader9.Width = 66;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Mobielnummer";
            this.columnHeader10.Width = 57;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Lid vanaf";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Functie";
            this.columnHeader12.Width = 51;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Geboortedatum";
            this.columnHeader13.Width = 68;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "NHBKlasse";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "VerKlasse";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Geslacht";
            this.columnHeader16.Width = 48;
            // 
            // btToevoegen
            // 
            this.btToevoegen.Location = new System.Drawing.Point(12, 12);
            this.btToevoegen.Name = "btToevoegen";
            this.btToevoegen.Size = new System.Drawing.Size(123, 39);
            this.btToevoegen.TabIndex = 1;
            this.btToevoegen.Text = "Toevoegen";
            this.btToevoegen.UseVisualStyleBackColor = true;
            this.btToevoegen.Click += new System.EventHandler(this.btToevoegen_Click);
            // 
            // LedenScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 690);
            this.Controls.Add(this.btToevoegen);
            this.Controls.Add(this.lvLeden);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LedenScherm";
            this.Text = "Ledenlijst";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvLeden;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Button btToevoegen;
    }
}