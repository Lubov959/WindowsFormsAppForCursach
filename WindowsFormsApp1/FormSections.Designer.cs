namespace WindowsFormsApp1
{
    partial class FormSections
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.comboBoxNameS = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.textBoxTrener = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewSections = new System.Windows.Forms.DataGridView();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxGroups = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxKids = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxS_Tr = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxS_Day = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxS_SurnKid = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxG_NS = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxG_Tr = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxG_LS = new System.Windows.Forms.ToolStripTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSections)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.dataGridViewSections);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 493);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.buttonClear);
            this.panel2.Controls.Add(this.comboBoxNameS);
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.numericUpDownPrice);
            this.panel2.Controls.Add(this.textBoxTrener);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(16, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 199);
            this.panel2.TabIndex = 24;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Silver;
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.buttonClear.Location = new System.Drawing.Point(167, 157);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(125, 27);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboBoxNameS
            // 
            this.comboBoxNameS.FormattingEnabled = true;
            this.comboBoxNameS.Location = new System.Drawing.Point(163, 20);
            this.comboBoxNameS.Name = "comboBoxNameS";
            this.comboBoxNameS.Size = new System.Drawing.Size(286, 21);
            this.comboBoxNameS.TabIndex = 1;
            this.comboBoxNameS.Leave += new System.EventHandler(this.comboBoxNameS_Leave);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.LightCoral;
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.buttonDelete.Location = new System.Drawing.Point(16, 157);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(119, 27);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.MediumPurple;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.buttonSave.Location = new System.Drawing.Point(324, 157);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(125, 27);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Записать";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.DecimalPlaces = 2;
            this.numericUpDownPrice.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownPrice.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownPrice.Location = new System.Drawing.Point(163, 107);
            this.numericUpDownPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(158, 22);
            this.numericUpDownPrice.TabIndex = 3;
            this.numericUpDownPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxTrener
            // 
            this.textBoxTrener.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTrener.Location = new System.Drawing.Point(163, 62);
            this.textBoxTrener.Name = "textBoxTrener";
            this.textBoxTrener.Size = new System.Drawing.Size(286, 22);
            this.textBoxTrener.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Стоимость, руб (за месяц)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Фамилия тренера";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Название секции";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.PaleGreen;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(495, 22);
            this.statusStrip1.TabIndex = 23;
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
            // dataGridViewSections
            // 
            this.dataGridViewSections.AllowUserToAddRows = false;
            this.dataGridViewSections.AllowUserToDeleteRows = false;
            this.dataGridViewSections.AllowUserToResizeRows = false;
            this.dataGridViewSections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSections.Location = new System.Drawing.Point(16, 34);
            this.dataGridViewSections.MaximumSize = new System.Drawing.Size(380, 300);
            this.dataGridViewSections.MinimumSize = new System.Drawing.Size(465, 200);
            this.dataGridViewSections.MultiSelect = false;
            this.dataGridViewSections.Name = "dataGridViewSections";
            this.dataGridViewSections.ReadOnly = true;
            this.dataGridViewSections.RowHeadersVisible = false;
            this.dataGridViewSections.Size = new System.Drawing.Size(465, 200);
            this.dataGridViewSections.TabIndex = 22;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoSize = false;
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.Violet;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.toolStripTextBoxGroups,
            this.toolStripSeparator1,
            this.toolStripTextBoxKids});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(162, 20);
            this.toolStripMenuItem1.Text = "Перейти к...";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripTextBoxGroups
            // 
            this.toolStripTextBoxGroups.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.toolStripTextBoxGroups.Name = "toolStripTextBoxGroups";
            this.toolStripTextBoxGroups.Size = new System.Drawing.Size(100, 22);
            this.toolStripTextBoxGroups.Text = "Группы";
            this.toolStripTextBoxGroups.Click += new System.EventHandler(this.toolStripTextBoxGroups_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripTextBoxKids
            // 
            this.toolStripTextBoxKids.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.toolStripTextBoxKids.Name = "toolStripTextBoxKids";
            this.toolStripTextBoxKids.Size = new System.Drawing.Size(100, 22);
            this.toolStripTextBoxKids.Text = "Занимающиеся";
            this.toolStripTextBoxKids.Click += new System.EventHandler(this.toolStripTextBoxKids_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(16, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(499, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.AutoSize = false;
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripSeparator9,
            this.toolStripMenuItem2});
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(162, 20);
            this.toolStripMenuItem3.Text = "Поиск";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxS_Tr,
            this.toolStripSeparator7,
            this.toolStripTextBoxS_Day,
            this.toolStripSeparator8,
            this.toolStripTextBoxS_SurnKid});
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem4.Text = "Секции по...";
            // 
            // toolStripTextBoxS_Tr
            // 
            this.toolStripTextBoxS_Tr.AutoSize = false;
            this.toolStripTextBoxS_Tr.Font = new System.Drawing.Font("Bahnschrift", 9.25F);
            this.toolStripTextBoxS_Tr.Name = "toolStripTextBoxS_Tr";
            this.toolStripTextBoxS_Tr.Size = new System.Drawing.Size(111, 22);
            this.toolStripTextBoxS_Tr.Text = "фамилии тренера";
            this.toolStripTextBoxS_Tr.Click += new System.EventHandler(this.toolStripTextBoxS_Tr_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(210, 6);
            // 
            // toolStripTextBoxS_Day
            // 
            this.toolStripTextBoxS_Day.Font = new System.Drawing.Font("Bahnschrift", 9.25F);
            this.toolStripTextBoxS_Day.Name = "toolStripTextBoxS_Day";
            this.toolStripTextBoxS_Day.Size = new System.Drawing.Size(100, 22);
            this.toolStripTextBoxS_Day.Text = "дням занятий";
            this.toolStripTextBoxS_Day.Click += new System.EventHandler(this.toolStripTextBoxS_Day_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(210, 6);
            // 
            // toolStripTextBoxS_SurnKid
            // 
            this.toolStripTextBoxS_SurnKid.AutoSize = false;
            this.toolStripTextBoxS_SurnKid.Font = new System.Drawing.Font("Bahnschrift", 9.25F);
            this.toolStripTextBoxS_SurnKid.Name = "toolStripTextBoxS_SurnKid";
            this.toolStripTextBoxS_SurnKid.Size = new System.Drawing.Size(153, 22);
            this.toolStripTextBoxS_SurnKid.Text = "фамилии занимающегося";
            this.toolStripTextBoxS_SurnKid.Click += new System.EventHandler(this.toolStripTextBoxS_SurnKid_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(138, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxG_NS,
            this.toolStripSeparator10,
            this.toolStripTextBoxG_Tr,
            this.toolStripSeparator11,
            this.toolStripTextBoxG_LS});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem2.Text = "Группы по...";
            // 
            // toolStripTextBoxG_NS
            // 
            this.toolStripTextBoxG_NS.AutoSize = false;
            this.toolStripTextBoxG_NS.Font = new System.Drawing.Font("Bahnschrift", 9.25F);
            this.toolStripTextBoxG_NS.Name = "toolStripTextBoxG_NS";
            this.toolStripTextBoxG_NS.Size = new System.Drawing.Size(111, 22);
            this.toolStripTextBoxG_NS.Text = "названию секции";
            this.toolStripTextBoxG_NS.Click += new System.EventHandler(this.toolStripTextBoxG_NS_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripTextBoxG_Tr
            // 
            this.toolStripTextBoxG_Tr.AutoSize = false;
            this.toolStripTextBoxG_Tr.Font = new System.Drawing.Font("Bahnschrift", 9.25F);
            this.toolStripTextBoxG_Tr.Name = "toolStripTextBoxG_Tr";
            this.toolStripTextBoxG_Tr.Size = new System.Drawing.Size(111, 22);
            this.toolStripTextBoxG_Tr.Text = "фамилии тренера";
            this.toolStripTextBoxG_Tr.Click += new System.EventHandler(this.toolStripTextBoxG_Tr_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripTextBoxG_LS
            // 
            this.toolStripTextBoxG_LS.AutoSize = false;
            this.toolStripTextBoxG_LS.Font = new System.Drawing.Font("Bahnschrift", 9.25F);
            this.toolStripTextBoxG_LS.Name = "toolStripTextBoxG_LS";
            this.toolStripTextBoxG_LS.Size = new System.Drawing.Size(120, 22);
            this.toolStripTextBoxG_LS.Text = "по уровню в секции";
            this.toolStripTextBoxG_LS.Click += new System.EventHandler(this.toolStripTextBoxG_LS_Click);
            // 
            // FormSections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 493);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSections";
            this.Text = "Секции";
            this.Load += new System.EventHandler(this.FormSections_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSections)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewSections;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.TextBox textBoxTrener;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxGroups;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxKids;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox comboBoxNameS;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxS_Tr;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxS_Day;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxS_SurnKid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxG_NS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxG_Tr;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxG_LS;
    }
}

