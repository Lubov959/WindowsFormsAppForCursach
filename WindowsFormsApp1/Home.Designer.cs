namespace WindowsFormsApp1
{
    partial class Home
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonK = new System.Windows.Forms.Button();
            this.buttonT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonG = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonK);
            this.panel1.Controls.Add(this.buttonT);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonG);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 222);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(137, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 22);
            this.label2.TabIndex = 27;
            this.label2.Text = "Выберите таблицу для работы";
            // 
            // buttonK
            // 
            this.buttonK.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonK.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.buttonK.Location = new System.Drawing.Point(181, 149);
            this.buttonK.Name = "buttonK";
            this.buttonK.Size = new System.Drawing.Size(93, 46);
            this.buttonK.TabIndex = 26;
            this.buttonK.Text = "Ученики";
            this.buttonK.UseVisualStyleBackColor = false;
            this.buttonK.Click += new System.EventHandler(this.buttonK_Click);
            // 
            // buttonT
            // 
            this.buttonT.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonT.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.buttonT.Location = new System.Drawing.Point(345, 71);
            this.buttonT.Name = "buttonT";
            this.buttonT.Size = new System.Drawing.Size(93, 46);
            this.buttonT.TabIndex = 25;
            this.buttonT.Text = "Тренера";
            this.buttonT.UseVisualStyleBackColor = false;
            this.buttonT.Click += new System.EventHandler(this.buttonT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(159, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "Вы вошли как";
            // 
            // buttonG
            // 
            this.buttonG.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonG.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.buttonG.Location = new System.Drawing.Point(18, 71);
            this.buttonG.Name = "buttonG";
            this.buttonG.Size = new System.Drawing.Size(93, 46);
            this.buttonG.TabIndex = 22;
            this.buttonG.Text = "Группы";
            this.buttonG.UseVisualStyleBackColor = false;
            this.buttonG.Click += new System.EventHandler(this.buttonG_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 222);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Home_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonK;
        private System.Windows.Forms.Button buttonT;
        private System.Windows.Forms.Label label2;
    }
}