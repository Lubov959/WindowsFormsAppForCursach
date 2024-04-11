namespace WindowsFormsApp1
{
    partial class FormSearch
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
            this.groupBoxSL = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSection = new System.Windows.Forms.ComboBox();
            this.groupBoxSName = new System.Windows.Forms.GroupBox();
            this.comboBoxSName = new System.Windows.Forms.ComboBox();
            this.groupBoxDays = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBoxSurname = new System.Windows.Forms.GroupBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewSchool = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBoxSL.SuspendLayout();
            this.groupBoxSName.SuspendLayout();
            this.groupBoxDays.SuspendLayout();
            this.groupBoxSurname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchool)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.groupBoxSL);
            this.groupBox1.Controls.Add(this.groupBoxSName);
            this.groupBox1.Controls.Add(this.groupBoxDays);
            this.groupBox1.Controls.Add(this.groupBoxSurname);
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.groupBox1.Location = new System.Drawing.Point(35, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 146);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // groupBoxSL
            // 
            this.groupBoxSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBoxSL.Controls.Add(this.label3);
            this.groupBoxSL.Controls.Add(this.comboBoxLevel);
            this.groupBoxSL.Controls.Add(this.label2);
            this.groupBoxSL.Controls.Add(this.comboBoxSection);
            this.groupBoxSL.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.groupBoxSL.Location = new System.Drawing.Point(0, 14);
            this.groupBoxSL.Name = "groupBoxSL";
            this.groupBoxSL.Size = new System.Drawing.Size(421, 92);
            this.groupBoxSL.TabIndex = 26;
            this.groupBoxSL.TabStop = false;
            this.groupBoxSL.Text = "Поиск группы в секции по уровню подготовки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(286, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Уровень";
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(228, 52);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(178, 22);
            this.comboBoxLevel.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(76, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Секции";
            // 
            // comboBoxSection
            // 
            this.comboBoxSection.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSection.FormattingEnabled = true;
            this.comboBoxSection.Location = new System.Drawing.Point(18, 52);
            this.comboBoxSection.Name = "comboBoxSection";
            this.comboBoxSection.Size = new System.Drawing.Size(174, 22);
            this.comboBoxSection.TabIndex = 27;
            // 
            // groupBoxSName
            // 
            this.groupBoxSName.Controls.Add(this.comboBoxSName);
            this.groupBoxSName.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.groupBoxSName.Location = new System.Drawing.Point(0, 14);
            this.groupBoxSName.Name = "groupBoxSName";
            this.groupBoxSName.Size = new System.Drawing.Size(421, 90);
            this.groupBoxSName.TabIndex = 24;
            this.groupBoxSName.TabStop = false;
            this.groupBoxSName.Text = "Поиск группы по названию секции";
            // 
            // comboBoxSName
            // 
            this.comboBoxSName.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSName.FormattingEnabled = true;
            this.comboBoxSName.Location = new System.Drawing.Point(71, 40);
            this.comboBoxSName.Name = "comboBoxSName";
            this.comboBoxSName.Size = new System.Drawing.Size(269, 22);
            this.comboBoxSName.TabIndex = 28;
            // 
            // groupBoxDays
            // 
            this.groupBoxDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBoxDays.Controls.Add(this.checkBox7);
            this.groupBoxDays.Controls.Add(this.checkBox6);
            this.groupBoxDays.Controls.Add(this.checkBox5);
            this.groupBoxDays.Controls.Add(this.checkBox4);
            this.groupBoxDays.Controls.Add(this.checkBox3);
            this.groupBoxDays.Controls.Add(this.checkBox2);
            this.groupBoxDays.Controls.Add(this.checkBox1);
            this.groupBoxDays.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.groupBoxDays.Location = new System.Drawing.Point(0, 18);
            this.groupBoxDays.Name = "groupBoxDays";
            this.groupBoxDays.Size = new System.Drawing.Size(421, 86);
            this.groupBoxDays.TabIndex = 29;
            this.groupBoxDays.TabStop = false;
            this.groupBoxDays.Text = "Поиск секции по дням занятий";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox7.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 11F);
            this.checkBox7.Location = new System.Drawing.Point(279, 34);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(24, 36);
            this.checkBox7.TabIndex = 41;
            this.checkBox7.Text = "Вс";
            this.checkBox7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox6.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 11F);
            this.checkBox6.Location = new System.Drawing.Point(249, 34);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(24, 36);
            this.checkBox6.TabIndex = 40;
            this.checkBox6.Text = "Сб";
            this.checkBox6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox5.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 11F);
            this.checkBox5.Location = new System.Drawing.Point(219, 34);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(23, 36);
            this.checkBox5.TabIndex = 39;
            this.checkBox5.Text = "Пт";
            this.checkBox5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox4.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 11F);
            this.checkBox4.Location = new System.Drawing.Point(189, 34);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(23, 36);
            this.checkBox4.TabIndex = 38;
            this.checkBox4.Text = "Чт";
            this.checkBox4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox3.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 11F);
            this.checkBox3.Location = new System.Drawing.Point(159, 34);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(24, 36);
            this.checkBox3.TabIndex = 37;
            this.checkBox3.Text = "Ср";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 11F);
            this.checkBox2.Location = new System.Drawing.Point(130, 34);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(23, 36);
            this.checkBox2.TabIndex = 36;
            this.checkBox2.Text = "Вт";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 11F);
            this.checkBox1.Location = new System.Drawing.Point(99, 34);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(24, 36);
            this.checkBox1.TabIndex = 35;
            this.checkBox1.Text = "Пн";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBoxSurname
            // 
            this.groupBoxSurname.Controls.Add(this.textBoxSearch);
            this.groupBoxSurname.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.groupBoxSurname.Location = new System.Drawing.Point(0, 18);
            this.groupBoxSurname.Name = "groupBoxSurname";
            this.groupBoxSurname.Size = new System.Drawing.Size(421, 87);
            this.groupBoxSurname.TabIndex = 23;
            this.groupBoxSurname.TabStop = false;
            this.groupBoxSurname.Text = "Поиск секции по фамилии тренера";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.textBoxSearch.Location = new System.Drawing.Point(65, 35);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(286, 22);
            this.textBoxSearch.TabIndex = 16;
            this.textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.LightGray;
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.buttonClear.Location = new System.Drawing.Point(226, 111);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 25);
            this.buttonClear.TabIndex = 21;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Silver;
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.buttonSearch.Location = new System.Drawing.Point(110, 111);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 25);
            this.buttonSearch.TabIndex = 20;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridViewSchool
            // 
            this.dataGridViewSchool.AllowUserToAddRows = false;
            this.dataGridViewSchool.AllowUserToDeleteRows = false;
            this.dataGridViewSchool.AllowUserToResizeRows = false;
            this.dataGridViewSchool.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSchool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchool.Location = new System.Drawing.Point(12, 168);
            this.dataGridViewSchool.MaximumSize = new System.Drawing.Size(380, 300);
            this.dataGridViewSchool.MinimumSize = new System.Drawing.Size(465, 200);
            this.dataGridViewSchool.Name = "dataGridViewSchool";
            this.dataGridViewSchool.ReadOnly = true;
            this.dataGridViewSchool.RowHeadersVisible = false;
            this.dataGridViewSchool.Size = new System.Drawing.Size(465, 200);
            this.dataGridViewSchool.TabIndex = 24;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.PaleGreen;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(490, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel1.Text = "Количество строк:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel2.Text = "0";
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(490, 398);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridViewSchool);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск";
            this.groupBox1.ResumeLayout(false);
            this.groupBoxSL.ResumeLayout(false);
            this.groupBoxSL.PerformLayout();
            this.groupBoxSName.ResumeLayout(false);
            this.groupBoxDays.ResumeLayout(false);
            this.groupBoxDays.PerformLayout();
            this.groupBoxSurname.ResumeLayout(false);
            this.groupBoxSurname.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchool)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewSchool;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.GroupBox groupBoxSurname;
        private System.Windows.Forms.GroupBox groupBoxSName;
        private System.Windows.Forms.GroupBox groupBoxSL;
        private System.Windows.Forms.ComboBox comboBoxSection;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxDays;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBoxSName;
    }
}