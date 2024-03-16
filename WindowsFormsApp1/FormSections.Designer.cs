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
            this.dataGridViewShop = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxNameCol = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxGroups = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxKids = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBoxSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShop)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.dataGridViewShop);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 416);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewShop
            // 
            this.dataGridViewShop.AllowUserToAddRows = false;
            this.dataGridViewShop.AllowUserToDeleteRows = false;
            this.dataGridViewShop.AllowUserToResizeRows = false;
            this.dataGridViewShop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewShop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShop.Location = new System.Drawing.Point(24, 169);
            this.dataGridViewShop.MaximumSize = new System.Drawing.Size(380, 300);
            this.dataGridViewShop.MinimumSize = new System.Drawing.Size(440, 200);
            this.dataGridViewShop.Name = "dataGridViewShop";
            this.dataGridViewShop.RowHeadersVisible = false;
            this.dataGridViewShop.Size = new System.Drawing.Size(440, 200);
            this.dataGridViewShop.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.comboBoxNameCol);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 112);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Silver;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.buttonSearch.Location = new System.Drawing.Point(191, 79);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 27);
            this.buttonSearch.TabIndex = 20;
            this.buttonSearch.Text = "Найти";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // comboBoxNameCol
            // 
            this.comboBoxNameCol.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxNameCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNameCol.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxNameCol.FormattingEnabled = true;
            this.comboBoxNameCol.Location = new System.Drawing.Point(36, 43);
            this.comboBoxNameCol.Name = "comboBoxNameCol";
            this.comboBoxNameCol.Size = new System.Drawing.Size(121, 22);
            this.comboBoxNameCol.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.label6.Location = new System.Drawing.Point(279, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Значение";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.textBoxSearch.Location = new System.Drawing.Point(171, 44);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(286, 22);
            this.textBoxSearch.TabIndex = 16;
            this.textBoxSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.label5.Location = new System.Drawing.Point(69, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Столбец";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(16, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripTextBoxSave,
            this.toolStripTextBoxDelete,
            this.toolStripTextBoxPrint});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(493, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoSize = false;
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxGroups,
            this.toolStripSeparator1,
            this.toolStripTextBoxKids});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 20);
            this.toolStripMenuItem1.Text = "Перейти к...";
            // 
            // toolStripTextBoxGroups
            // 
            this.toolStripTextBoxGroups.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxGroups.Name = "toolStripTextBoxGroups";
            this.toolStripTextBoxGroups.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxGroups.Text = "Группы";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // toolStripTextBoxKids
            // 
            this.toolStripTextBoxKids.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxKids.Name = "toolStripTextBoxKids";
            this.toolStripTextBoxKids.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxKids.Text = "Дети";
            // 
            // toolStripTextBoxSave
            // 
            this.toolStripTextBoxSave.AutoSize = false;
            this.toolStripTextBoxSave.BackColor = System.Drawing.Color.MediumPurple;
            this.toolStripTextBoxSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripTextBoxSave.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.toolStripTextBoxSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripTextBoxSave.Name = "toolStripTextBoxSave";
            this.toolStripTextBoxSave.ShortcutKeyDisplayString = "Ctrl+s";
            this.toolStripTextBoxSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripTextBoxSave.Size = new System.Drawing.Size(120, 20);
            this.toolStripTextBoxSave.Text = "Записать";
            // 
            // toolStripTextBoxDelete
            // 
            this.toolStripTextBoxDelete.AutoSize = false;
            this.toolStripTextBoxDelete.BackColor = System.Drawing.Color.LightCoral;
            this.toolStripTextBoxDelete.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.toolStripTextBoxDelete.Name = "toolStripTextBoxDelete";
            this.toolStripTextBoxDelete.Size = new System.Drawing.Size(120, 20);
            this.toolStripTextBoxDelete.Text = "Удалить";
            // 
            // toolStripTextBoxPrint
            // 
            this.toolStripTextBoxPrint.AutoSize = false;
            this.toolStripTextBoxPrint.BackColor = System.Drawing.Color.Orchid;
            this.toolStripTextBoxPrint.Font = new System.Drawing.Font("Bahnschrift", 9.5F);
            this.toolStripTextBoxPrint.Name = "toolStripTextBoxPrint";
            this.toolStripTextBoxPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.toolStripTextBoxPrint.Size = new System.Drawing.Size(120, 20);
            this.toolStripTextBoxPrint.Text = "Посмотреть";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 416);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form";
            this.Text = "Секции";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShop)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxGroups;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxKids;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBoxSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBoxDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBoxPrint;
        private System.Windows.Forms.DataGridView dataGridViewShop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxNameCol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label5;
    }
}

