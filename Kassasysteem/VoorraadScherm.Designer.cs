namespace Kassasysteem
{
    partial class VoorraadScherm
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
            this.lvProducten = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btOpslaan = new System.Windows.Forms.Button();
            this.nudLedenprijs = new System.Windows.Forms.NumericUpDown();
            this.nudPrijs = new System.Windows.Forms.NumericUpDown();
            this.nudVoorraad = new System.Windows.Forms.NumericUpDown();
            this.tbSoort = new System.Windows.Forms.TextBox();
            this.tbNaam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btSluiten = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btNOpslaan = new System.Windows.Forms.Button();
            this.nudNLedenprijs = new System.Windows.Forms.NumericUpDown();
            this.nudNPrijs = new System.Windows.Forms.NumericUpDown();
            this.nudNVoorraad = new System.Windows.Forms.NumericUpDown();
            this.tbNSoort = new System.Windows.Forms.TextBox();
            this.tbNProductnaam = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLedenprijs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrijs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVoorraad)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNLedenprijs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNPrijs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNVoorraad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvProducten);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 542);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producten";
            // 
            // lvProducten
            // 
            this.lvProducten.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader3});
            this.lvProducten.GridLines = true;
            this.lvProducten.Location = new System.Drawing.Point(7, 19);
            this.lvProducten.Name = "lvProducten";
            this.lvProducten.Size = new System.Drawing.Size(393, 517);
            this.lvProducten.TabIndex = 0;
            this.lvProducten.UseCompatibleStateImageBehavior = false;
            this.lvProducten.View = System.Windows.Forms.View.Details;
            this.lvProducten.Click += new System.EventHandler(this.lvProducten_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 36;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Naam";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Soort";
            this.columnHeader4.Width = 82;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Voorraad";
            this.columnHeader7.Width = 58;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Prijs";
            this.columnHeader8.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ledenprijs";
            this.columnHeader3.Width = 61;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btOpslaan);
            this.groupBox2.Controls.Add(this.nudLedenprijs);
            this.groupBox2.Controls.Add(this.nudPrijs);
            this.groupBox2.Controls.Add(this.nudVoorraad);
            this.groupBox2.Controls.Add(this.tbSoort);
            this.groupBox2.Controls.Add(this.tbNaam);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(426, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 268);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productinformatie";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(138, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 17);
            this.label12.TabIndex = 14;
            this.label12.Text = "€";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(6, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = "€";
            // 
            // btOpslaan
            // 
            this.btOpslaan.Location = new System.Drawing.Point(6, 235);
            this.btOpslaan.Name = "btOpslaan";
            this.btOpslaan.Size = new System.Drawing.Size(98, 27);
            this.btOpslaan.TabIndex = 12;
            this.btOpslaan.Text = "Opslaan";
            this.btOpslaan.UseVisualStyleBackColor = true;
            this.btOpslaan.Click += new System.EventHandler(this.btOpslaan_Click);
            // 
            // nudLedenprijs
            // 
            this.nudLedenprijs.DecimalPlaces = 2;
            this.nudLedenprijs.Location = new System.Drawing.Point(154, 196);
            this.nudLedenprijs.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudLedenprijs.Name = "nudLedenprijs";
            this.nudLedenprijs.Size = new System.Drawing.Size(112, 20);
            this.nudLedenprijs.TabIndex = 11;
            // 
            // nudPrijs
            // 
            this.nudPrijs.DecimalPlaces = 2;
            this.nudPrijs.Location = new System.Drawing.Point(22, 196);
            this.nudPrijs.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPrijs.Name = "nudPrijs";
            this.nudPrijs.Size = new System.Drawing.Size(96, 20);
            this.nudPrijs.TabIndex = 10;
            // 
            // nudVoorraad
            // 
            this.nudVoorraad.Location = new System.Drawing.Point(7, 138);
            this.nudVoorraad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudVoorraad.Name = "nudVoorraad";
            this.nudVoorraad.Size = new System.Drawing.Size(259, 20);
            this.nudVoorraad.TabIndex = 9;
            // 
            // tbSoort
            // 
            this.tbSoort.Location = new System.Drawing.Point(6, 84);
            this.tbSoort.Name = "tbSoort";
            this.tbSoort.Size = new System.Drawing.Size(260, 20);
            this.tbSoort.TabIndex = 8;
            // 
            // tbNaam
            // 
            this.tbNaam.Location = new System.Drawing.Point(6, 39);
            this.tbNaam.Name = "tbNaam";
            this.tbNaam.Size = new System.Drawing.Size(260, 20);
            this.tbNaam.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(140, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ledenprijs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(6, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Prijs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Voorraad hoeveelheid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Soort";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Productnaam";
            // 
            // btSluiten
            // 
            this.btSluiten.Location = new System.Drawing.Point(168, 235);
            this.btSluiten.Name = "btSluiten";
            this.btSluiten.Size = new System.Drawing.Size(98, 27);
            this.btSluiten.TabIndex = 13;
            this.btSluiten.Text = "Sluiten";
            this.btSluiten.UseVisualStyleBackColor = true;
            this.btSluiten.Click += new System.EventHandler(this.btSluiten_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.btSluiten);
            this.groupBox3.Controls.Add(this.btNOpslaan);
            this.groupBox3.Controls.Add(this.nudNLedenprijs);
            this.groupBox3.Controls.Add(this.nudNPrijs);
            this.groupBox3.Controls.Add(this.nudNVoorraad);
            this.groupBox3.Controls.Add(this.tbNSoort);
            this.groupBox3.Controls.Add(this.tbNProductnaam);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(426, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 268);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Voeg een nieuw product toe";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(138, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 17);
            this.label14.TabIndex = 15;
            this.label14.Text = "€";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(6, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "€";
            // 
            // btNOpslaan
            // 
            this.btNOpslaan.Location = new System.Drawing.Point(6, 235);
            this.btNOpslaan.Name = "btNOpslaan";
            this.btNOpslaan.Size = new System.Drawing.Size(98, 27);
            this.btNOpslaan.TabIndex = 12;
            this.btNOpslaan.Text = "Opslaan";
            this.btNOpslaan.UseVisualStyleBackColor = true;
            this.btNOpslaan.Click += new System.EventHandler(this.btNOpslaan_Click);
            // 
            // nudNLedenprijs
            // 
            this.nudNLedenprijs.DecimalPlaces = 2;
            this.nudNLedenprijs.Location = new System.Drawing.Point(154, 196);
            this.nudNLedenprijs.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNLedenprijs.Name = "nudNLedenprijs";
            this.nudNLedenprijs.Size = new System.Drawing.Size(112, 20);
            this.nudNLedenprijs.TabIndex = 11;
            // 
            // nudNPrijs
            // 
            this.nudNPrijs.DecimalPlaces = 2;
            this.nudNPrijs.Location = new System.Drawing.Point(22, 196);
            this.nudNPrijs.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNPrijs.Name = "nudNPrijs";
            this.nudNPrijs.Size = new System.Drawing.Size(96, 20);
            this.nudNPrijs.TabIndex = 10;
            // 
            // nudNVoorraad
            // 
            this.nudNVoorraad.Location = new System.Drawing.Point(7, 138);
            this.nudNVoorraad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNVoorraad.Name = "nudNVoorraad";
            this.nudNVoorraad.Size = new System.Drawing.Size(259, 20);
            this.nudNVoorraad.TabIndex = 9;
            // 
            // tbNSoort
            // 
            this.tbNSoort.Location = new System.Drawing.Point(6, 84);
            this.tbNSoort.Name = "tbNSoort";
            this.tbNSoort.Size = new System.Drawing.Size(260, 20);
            this.tbNSoort.TabIndex = 8;
            // 
            // tbNProductnaam
            // 
            this.tbNProductnaam.Location = new System.Drawing.Point(6, 39);
            this.tbNProductnaam.Name = "tbNProductnaam";
            this.tbNProductnaam.Size = new System.Drawing.Size(260, 20);
            this.tbNProductnaam.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(140, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ledenprijs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(6, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Prijs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(6, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Voorraad hoeveelheid";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(6, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Soort";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Productnaam";
            // 
            // VoorraadScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 563);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "VoorraadScherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voorraad";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLedenprijs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrijs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVoorraad)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNLedenprijs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNPrijs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNVoorraad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvProducten;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudLedenprijs;
        private System.Windows.Forms.NumericUpDown nudPrijs;
        private System.Windows.Forms.NumericUpDown nudVoorraad;
        private System.Windows.Forms.TextBox tbSoort;
        private System.Windows.Forms.TextBox tbNaam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btOpslaan;
        private System.Windows.Forms.Button btSluiten;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btNOpslaan;
        private System.Windows.Forms.NumericUpDown nudNLedenprijs;
        private System.Windows.Forms.NumericUpDown nudNPrijs;
        private System.Windows.Forms.NumericUpDown nudNVoorraad;
        private System.Windows.Forms.TextBox tbNSoort;
        private System.Windows.Forms.TextBox tbNProductnaam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}