namespace Kassasysteem
{
    partial class AfrekenScherm
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
            this.clmProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPrijs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbTotaalPrijs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btAfrekenen = new System.Windows.Forms.Button();
            this.lbDatum = new System.Windows.Forms.Label();
            this.lbNaam = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbBonnen = new System.Windows.Forms.Label();
            this.cbIsLid = new System.Windows.Forms.CheckBox();
            this.btAfrekenenBonnen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvProducten);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 411);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producten";
            // 
            // lvProducten
            // 
            this.lvProducten.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmProduct,
            this.clmPrijs,
            this.columnHeader1});
            this.lvProducten.Location = new System.Drawing.Point(7, 19);
            this.lvProducten.Name = "lvProducten";
            this.lvProducten.Size = new System.Drawing.Size(302, 386);
            this.lvProducten.TabIndex = 0;
            this.lvProducten.UseCompatibleStateImageBehavior = false;
            this.lvProducten.View = System.Windows.Forms.View.Details;
            // 
            // clmProduct
            // 
            this.clmProduct.Text = "Product";
            this.clmProduct.Width = 130;
            // 
            // clmPrijs
            // 
            this.clmPrijs.Text = "Prijs";
            this.clmPrijs.Width = 84;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ledenprijs";
            this.columnHeader1.Width = 84;
            // 
            // lbTotaalPrijs
            // 
            this.lbTotaalPrijs.AutoSize = true;
            this.lbTotaalPrijs.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotaalPrijs.Location = new System.Drawing.Point(343, 121);
            this.lbTotaalPrijs.Name = "lbTotaalPrijs";
            this.lbTotaalPrijs.Size = new System.Drawing.Size(215, 76);
            this.lbTotaalPrijs.TabIndex = 1;
            this.lbTotaalPrijs.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(352, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Datum:";
            // 
            // btAfrekenen
            // 
            this.btAfrekenen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAfrekenen.Location = new System.Drawing.Point(334, 350);
            this.btAfrekenen.Name = "btAfrekenen";
            this.btAfrekenen.Size = new System.Drawing.Size(258, 74);
            this.btAfrekenen.TabIndex = 4;
            this.btAfrekenen.Text = "Afrekenen";
            this.btAfrekenen.UseVisualStyleBackColor = true;
            this.btAfrekenen.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbDatum
            // 
            this.lbDatum.AutoSize = true;
            this.lbDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatum.Location = new System.Drawing.Point(419, 254);
            this.lbDatum.Name = "lbDatum";
            this.lbDatum.Size = new System.Drawing.Size(51, 20);
            this.lbDatum.TabIndex = 5;
            this.lbDatum.Text = "label3";
            // 
            // lbNaam
            // 
            this.lbNaam.AutoSize = true;
            this.lbNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNaam.Location = new System.Drawing.Point(419, 220);
            this.lbNaam.Name = "lbNaam";
            this.lbNaam.Size = new System.Drawing.Size(51, 20);
            this.lbNaam.TabIndex = 6;
            this.lbNaam.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(352, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Totaal te betalen:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(646, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Aantal bonnen:";
            // 
            // lbBonnen
            // 
            this.lbBonnen.AutoSize = true;
            this.lbBonnen.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBonnen.Location = new System.Drawing.Point(637, 121);
            this.lbBonnen.Name = "lbBonnen";
            this.lbBonnen.Size = new System.Drawing.Size(215, 76);
            this.lbBonnen.TabIndex = 9;
            this.lbBonnen.Text = "label1";
            // 
            // cbIsLid
            // 
            this.cbIsLid.AutoSize = true;
            this.cbIsLid.Checked = true;
            this.cbIsLid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsLid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbIsLid.Location = new System.Drawing.Point(356, 32);
            this.cbIsLid.Name = "cbIsLid";
            this.cbIsLid.Size = new System.Drawing.Size(91, 24);
            this.cbIsLid.TabIndex = 12;
            this.cbIsLid.Text = "Is een lid";
            this.cbIsLid.UseVisualStyleBackColor = true;
            this.cbIsLid.CheckedChanged += new System.EventHandler(this.cbIsLid_CheckedChanged);
            // 
            // btAfrekenenBonnen
            // 
            this.btAfrekenenBonnen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAfrekenenBonnen.Location = new System.Drawing.Point(598, 350);
            this.btAfrekenenBonnen.Name = "btAfrekenenBonnen";
            this.btAfrekenenBonnen.Size = new System.Drawing.Size(268, 74);
            this.btAfrekenenBonnen.TabIndex = 13;
            this.btAfrekenenBonnen.Text = "Afrekenen met bonnen";
            this.btAfrekenenBonnen.UseVisualStyleBackColor = true;
            this.btAfrekenenBonnen.Click += new System.EventHandler(this.btAfrekenenBonnen_Click);
            // 
            // AfrekenScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 436);
            this.Controls.Add(this.btAfrekenenBonnen);
            this.Controls.Add(this.cbIsLid);
            this.Controls.Add(this.lbBonnen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbNaam);
            this.Controls.Add(this.lbDatum);
            this.Controls.Add(this.btAfrekenen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTotaalPrijs);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AfrekenScherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AfrekenScherm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTotaalPrijs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAfrekenen;
        private System.Windows.Forms.Label lbDatum;
        private System.Windows.Forms.Label lbNaam;
        private System.Windows.Forms.ListView lvProducten;
        private System.Windows.Forms.ColumnHeader clmProduct;
        private System.Windows.Forms.ColumnHeader clmPrijs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbBonnen;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox cbIsLid;
        private System.Windows.Forms.Button btAfrekenenBonnen;
    }
}