namespace Kassasysteem
{
    partial class BtsScherm
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
            this.lvOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPaidOrders = new System.Windows.Forms.CheckBox();
            this.cbUnpaidOrders = new System.Windows.Forms.CheckBox();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtBeginDate = new System.Windows.Forms.DateTimePicker();
            this.cbBetweenDates = new System.Windows.Forms.CheckBox();
            this.cbAllOrders = new System.Windows.Forms.CheckBox();
            this.cbByBestuur = new System.Windows.Forms.CheckBox();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvOrders);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 666);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bestellingen";
            // 
            // lvOrders
            // 
            this.lvOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader6});
            this.lvOrders.GridLines = true;
            this.lvOrders.Location = new System.Drawing.Point(7, 19);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(770, 640);
            this.lvOrders.TabIndex = 0;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            this.lvOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "BId";
            this.columnHeader1.Width = 47;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Naam";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "LidId";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Aanmaakdatum";
            this.columnHeader4.Width = 96;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Is Betaald?";
            this.columnHeader5.Width = 68;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Datum Betaald";
            this.columnHeader7.Width = 92;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Bonnenbetaling?";
            this.columnHeader8.Width = 99;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Betaald bedrag";
            this.columnHeader9.Width = 91;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Bestuurbetaling?";
            this.columnHeader10.Width = 99;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Opmerking";
            this.columnHeader6.Width = 327;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(6, 215);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(117, 37);
            this.btSearch.TabIndex = 2;
            this.btSearch.Text = "Zoeken";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btSearch);
            this.groupBox2.Controls.Add(this.cbPaidOrders);
            this.groupBox2.Controls.Add(this.cbUnpaidOrders);
            this.groupBox2.Controls.Add(this.dtEndDate);
            this.groupBox2.Controls.Add(this.dtBeginDate);
            this.groupBox2.Controls.Add(this.cbBetweenDates);
            this.groupBox2.Controls.Add(this.cbAllOrders);
            this.groupBox2.Controls.Add(this.cbByBestuur);
            this.groupBox2.Location = new System.Drawing.Point(802, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 258);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zoeken";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "en";
            // 
            // cbPaidOrders
            // 
            this.cbPaidOrders.AutoSize = true;
            this.cbPaidOrders.Location = new System.Drawing.Point(6, 19);
            this.cbPaidOrders.Name = "cbPaidOrders";
            this.cbPaidOrders.Size = new System.Drawing.Size(127, 17);
            this.cbPaidOrders.TabIndex = 1;
            this.cbPaidOrders.Text = "Betaalde bestellingen";
            this.cbPaidOrders.UseVisualStyleBackColor = true;
            this.cbPaidOrders.CheckedChanged += new System.EventHandler(this.cbPaidOrders_CheckedChanged);
            // 
            // cbUnpaidOrders
            // 
            this.cbUnpaidOrders.AutoSize = true;
            this.cbUnpaidOrders.Location = new System.Drawing.Point(6, 42);
            this.cbUnpaidOrders.Name = "cbUnpaidOrders";
            this.cbUnpaidOrders.Size = new System.Drawing.Size(140, 17);
            this.cbUnpaidOrders.TabIndex = 2;
            this.cbUnpaidOrders.Text = "Onbetaalde bestellingen";
            this.cbUnpaidOrders.UseVisualStyleBackColor = true;
            this.cbUnpaidOrders.CheckedChanged += new System.EventHandler(this.cbUnpaidOrders_CheckedChanged);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(6, 151);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(166, 20);
            this.dtEndDate.TabIndex = 6;
            // 
            // dtBeginDate
            // 
            this.dtBeginDate.Location = new System.Drawing.Point(6, 112);
            this.dtBeginDate.Name = "dtBeginDate";
            this.dtBeginDate.Size = new System.Drawing.Size(166, 20);
            this.dtBeginDate.TabIndex = 5;
            // 
            // cbBetweenDates
            // 
            this.cbBetweenDates.AutoSize = true;
            this.cbBetweenDates.Location = new System.Drawing.Point(6, 88);
            this.cbBetweenDates.Name = "cbBetweenDates";
            this.cbBetweenDates.Size = new System.Drawing.Size(120, 17);
            this.cbBetweenDates.TabIndex = 4;
            this.cbBetweenDates.Text = "Bestellingen tussen:";
            this.cbBetweenDates.UseVisualStyleBackColor = true;
            this.cbBetweenDates.CheckedChanged += new System.EventHandler(this.cbBetweenDates_CheckedChanged);
            // 
            // cbAllOrders
            // 
            this.cbAllOrders.AutoSize = true;
            this.cbAllOrders.Location = new System.Drawing.Point(6, 187);
            this.cbAllOrders.Name = "cbAllOrders";
            this.cbAllOrders.Size = new System.Drawing.Size(102, 17);
            this.cbAllOrders.TabIndex = 3;
            this.cbAllOrders.Text = "Alle bestellingen";
            this.cbAllOrders.UseVisualStyleBackColor = true;
            this.cbAllOrders.CheckedChanged += new System.EventHandler(this.cbAllOrders_CheckedChanged);
            // 
            // cbByBestuur
            // 
            this.cbByBestuur.AutoSize = true;
            this.cbByBestuur.Location = new System.Drawing.Point(6, 65);
            this.cbByBestuur.Name = "cbByBestuur";
            this.cbByBestuur.Size = new System.Drawing.Size(145, 17);
            this.cbByBestuur.TabIndex = 0;
            this.cbByBestuur.Text = "Bestellingen door bestuur";
            this.cbByBestuur.UseVisualStyleBackColor = true;
            this.cbByBestuur.CheckedChanged += new System.EventHandler(this.cbByBestuur_CheckedChanged);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(801, 655);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(178, 23);
            this.pBar.TabIndex = 5;
            // 
            // BtsScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 690);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BtsScherm";
            this.Text = "BtsScherm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbAllOrders;
        private System.Windows.Forms.CheckBox cbUnpaidOrders;
        private System.Windows.Forms.CheckBox cbPaidOrders;
        private System.Windows.Forms.CheckBox cbByBestuur;
        private System.Windows.Forms.CheckBox cbBetweenDates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.DateTimePicker dtBeginDate;
        private System.Windows.Forms.ProgressBar pBar;
    }
}