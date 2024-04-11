using ClassLibraryForBinFile;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormGroups : Form
    {
        Groups G;
        List<Treners> T;
        public enum lev : byte
        {
            Новички, Лайт,
            Медиум, Хард,
            Профессионалы
        }

        public enum year : byte
        { Младшие, Средние, Старшие }

        public enum pol : byte
        { Женщины, Мужчины, Смешанные }

        public enum day : byte
        { Пн, Вт, Ср, Чт, Пт, Сб, Вс }

        public FormGroups()
        {
            InitializeComponent();
            if (FormAutoresations.rol == "operator")
            {
                this.Width = 581;
                toolStripTextBoxDelKids.Enabled = true;
                toolStripTextBoxDelAll.Enabled = true;
                toolStripTextBoxDelGroups.Enabled = true;
                toolStripTextBoxDelTrener.Enabled = true;
            }
            else
            {
                //ограничение длинны
                comboBoxSection.MaxLength = 20;
                //начальные параметры
                comboBoxLevel.Items.Add(string.Empty);
                comboBoxLevel.Items.AddRange(new object[] { (lev)0, (lev)1, (lev)2, (lev)3, (lev)4 });
                comboBoxPol.Items.Add(string.Empty);
                comboBoxPol.Items.AddRange(new object[] { (pol)0, (pol)1, (pol)2 });
                comboBoxYears.Items.Add(string.Empty);
                comboBoxYears.Items.AddRange(new object[] { (year)0, (year)1, (year)2 });
                comboBoxTrener.Items.Add(string.Empty);
                Treners.Vyvod(out List<Treners> T);
                this.T = T;
                foreach (Treners trener in T)
                    comboBoxTrener.Items.Add(trener.ToString());
            }

        }

        public static void StringTo(Groups g, out string s_gr)
        {
            s_gr = string.Join("_", g.Секция, (year)g.Возраст, (pol)g.Пол, (lev)g.Уровень);
        }

        private void FormGroups_Load(object sender, EventArgs e)
        {
            UpDate();//вывод файла
        }

        // метод нажатия на кнопку "Cохранить данные в файл"
        private void buttonSave_Click(object sender, EventArgs e)

        {
            try
            {
                //проверка на пустоту полей
                if ((comboBoxPol.Text == string.Empty) || (comboBoxLevel.Text == string.Empty)
                    || (comboBoxSection.Text == string.Empty) || (comboBoxYears.Text == string.Empty)
                     || (comboBoxTrener.Text == string.Empty) || (numericUpDownMax.Value == 0)||(
                     (!checkBox1.Checked)&&(!checkBox2.Checked)&&(!checkBox3.Checked)&&(!checkBox4.Checked)
                     &&(!checkBox5.Checked)&&(!checkBox6.Checked)&&(!checkBox7.Checked)))
                    throw new Exception("Поля записи не должны быть пустыми!");
                else
                {
                    if (G == null) G = new Groups(); // новая запись
                                                     // прочтём данные, вводимые пользователем
                    G.Max = Convert.ToDouble(numericUpDownMax.Value);
                    G.Стоимость = Convert.ToDouble(numericUpDownPrice.Value);
                    G.Секция = comboBoxSection.Text;
                    for (byte i = 0; i < 5; i++)
                    {
                        if (((lev)i).ToString() == comboBoxLevel.Text)
                        { G.Уровень = i; break; }
                    }
                    for (byte i = 0; i < 3; i++)
                    {
                        if (((pol)i).ToString() == comboBoxPol.Text)
                        { G.Пол = i; break; }

                    }
                    for (byte i = 0; i < 3; i++)
                    {
                        if (((year)i).ToString() == comboBoxYears.Text)
                        { G.Возраст = i; break; }
                    }
                    bool[] d = new bool[7];
                    d[0] = checkBox1.Checked;
                    d[1] = checkBox2.Checked;
                    d[2] = checkBox3.Checked;
                    d[3] = checkBox4.Checked;
                    d[4] = checkBox5.Checked;
                    d[5] = checkBox6.Checked;
                    d[6] = checkBox7.Checked;
                    G.Дни = d;
                    G.Тренер = T[comboBoxTrener.SelectedIndex - 1].ID;

                    if (G.ID == 0)
                    {
                        G.Add();
                        G = null;
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Вы уверены, что хотите " +
                            "изменить данные? ", "Предупреждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {
                            Groups.Search(G.ID, out long p, out Groups g);
                            G.Correcting(p);
                            G = null;
                        }
                    }
                    UpDate();
                    buttonClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        //обновление данных в форме относительно файла
        public void UpDate()
        {
            try
            {
                Groups.Vyvod(out List<Groups> groups);
                if (groups == null)
                {
                    dataGridViewGroups.Rows.Clear();
                    dataGridViewGroups.Columns.Clear();
                    statusStrip1.Items[1].Text = "0";
                }
                else
                {
                    // настройка вида таблицы
                    dataGridViewGroups.ColumnCount = 10;
                    dataGridViewGroups.Columns[0].Name = "ID";
                    dataGridViewGroups.Columns[1].Name = "Секция";
                    dataGridViewGroups.Columns[2].Name = "Уровень";
                    dataGridViewGroups.Columns[3].Name = "Дни занятий";
                    dataGridViewGroups.Columns[4].Name = "Возраст";
                    dataGridViewGroups.Columns[5].Name = "Пол";
                    dataGridViewGroups.Columns[6].Name = "id тренера";
                    dataGridViewGroups.Columns[7].Name = "Стоимость";
                    dataGridViewGroups.Columns[8].Name = "Макс_участников";
                    dataGridViewGroups.Columns[9].Name = "ID";
                    //dataGridViewTreners.Columns[0].Visible = false;
                    //dataGridViewTreners.Columns[9].Visible = false;

                    //очистка списка названий секций
                    comboBoxSection.Items.Clear();
                    comboBoxSection.Items.Add(string.Empty);

                    int k = groups.Count;
                    dataGridViewGroups.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < groups.Count; i++)
                    {
                        byte d = 1;
                        foreach (string sect in comboBoxSection.Items)
                        {
                            if (sect.Equals(groups[i].Секция))
                            { d = 0; break; }
                        }
                        if (d != 0)
                            comboBoxSection.Items.Add(groups[i].Секция);
                        dataGridViewGroups.Rows[i].Cells[0].Value = groups[i].ID;
                        dataGridViewGroups.Rows[i].Cells[1].Value = groups[i].Секция;
                        dataGridViewGroups.Rows[i].Cells[2].Value = ((lev)(groups[i].Уровень)).ToString();
                        //для того чтобы убрать дублирование при перезаписи
                        dataGridViewGroups.Rows[i].Cells[3].Value = null;
                        for (byte j = 0; j < 7; j++)
                        {
                            if (groups[i].Дни[j] == true)
                                dataGridViewGroups.Rows[i].Cells[3].Value += ((day)j).ToString() + " ";
                        }
                        dataGridViewGroups.Rows[i].Cells[4].Value = ((year)(groups[i].Возраст)).ToString();
                        dataGridViewGroups.Rows[i].Cells[5].Value = ((pol)(groups[i].Пол)).ToString();
                        Treners.Search(groups[i].Тренер, out long p, out Treners tr);
                        dataGridViewGroups.Rows[i].Cells[6].Value = tr.ToString();
                        dataGridViewGroups.Rows[i].Cells[7].Value = groups[i].Стоимость;
                        dataGridViewGroups.Rows[i].Cells[8].Value = groups[i].Max;
                        dataGridViewGroups.Rows[i].Cells[9].Value = tr.ID;
                    }
                    //кол-во строк
                    statusStrip1.Items[1].Text = groups.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        //нажатие на кнопку очистки полей записи
        private void buttonClear_Click(object sender, EventArgs e)
        {
            G = null;
            comboBoxSection.Text = comboBoxSection.Items[0].ToString();
            comboBoxLevel.Text = comboBoxLevel.Items[0].ToString();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            comboBoxPol.Text = comboBoxPol.Items[0].ToString();
            comboBoxTrener.Text = comboBoxTrener.Items[0].ToString();
            comboBoxYears.Text = comboBoxYears.Items[0].ToString();
            numericUpDownMax.Value = numericUpDownMax.Minimum;
            numericUpDownPrice.Value = numericUpDownPrice.Minimum;
            statusStrip1.Items[1].Text = "0";
        }

        //метод при нажатии на кнопку Секции в меню Перейти к ..
        private void toolStripTextBoxTreners_Click(object sender, EventArgs e)
        {
            Form ifrm = new FormTreners();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }
        //метод закрытия формы
        private void FormGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Close();//закрытие главной формы и всего приложения
        }
        //метод при нажатии на кнопку ребенок в меню Перейти к ..
        private void toolStripTextBoxKids_Click(object sender, EventArgs e)
        {
            FormKids ifrm = new FormKids();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        private void toolStripTextBoxS_Tr_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск секции по фамилии тренера");
            ifrm.StartPosition = FormStartPosition.CenterParent;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxG_Tr_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск группы по фамилии тренера");
            ifrm.StartPosition = FormStartPosition.CenterParent;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxS_SurnKid_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск секции по фамилии занимающегося");
            ifrm.StartPosition = FormStartPosition.CenterParent;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxG_NS_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск группы по названию секции");
            ifrm.StartPosition = FormStartPosition.CenterParent;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxG_LS_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск группы в секции по уровню подготовки");
            ifrm.StartPosition = FormStartPosition.CenterParent;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxS_Day_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск секции по дням занятий");
            ifrm.StartPosition = FormStartPosition.CenterParent;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }


        //контекстное меню
        private void dataGridViewGroups_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (FormAutoresations.rol == "admin")
            {
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                    // создаем элементы меню
                    ToolStripMenuItem upDateMenuItem = new ToolStripMenuItem("Изменить");
                    ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Удалить");
                    // добавляем элементы в меню
                    contextMenuStrip.Items.AddRange(new[] { upDateMenuItem, deleteMenuItem });
                    //привязка к объекту
                    dataGridViewGroups.ContextMenuStrip = contextMenuStrip;
                    G = new Groups();
                    G.ID = (long)dataGridViewGroups.Rows[e.RowIndex].Cells[0].Value;
                    G.Секция = (string)dataGridViewGroups.Rows[e.RowIndex].Cells[1].Value;
                    string[] s = ((string)dataGridViewGroups.Rows[e.RowIndex].Cells[3].Value).Split(' ');
                    bool[] d = new bool[7];
                    for (byte i = 0; i < 7; i++)
                    {
                        for (byte j = 0; j < s.Length - 1; j++)
                        {
                            if (s[j] == ((day)i).ToString())
                                d[i] = true;
                        }
                        if (!d[i]) d[i] = false;
                    }
                    G.Дни = d;
                    for (byte i = 0; i < 5; i++)
                    {
                        if ((string)dataGridViewGroups.Rows[e.RowIndex].Cells[2].Value == ((lev)i).ToString())
                        { G.Уровень = i; break; }
                    }
                    for (byte i = 0; i < 3; i++)
                    {
                        if ((string)dataGridViewGroups.Rows[e.RowIndex].Cells[4].Value == ((year)i).ToString())
                        { G.Возраст = i; break; }
                    }
                    for (byte i = 0; i < 3; i++)
                    {
                        if ((string)dataGridViewGroups.Rows[e.RowIndex].Cells[5].Value == ((pol)i).ToString())
                        { G.Пол = i; break; }
                    }
                    G.Стоимость = (double)dataGridViewGroups.Rows[e.RowIndex].Cells[7].Value;
                    G.Max = (double)dataGridViewGroups.Rows[e.RowIndex].Cells[8].Value;
                    G.Тренер = (long)dataGridViewGroups.Rows[e.RowIndex].Cells[9].Value;
                    // устанавливаем обработчики событий для меню
                    upDateMenuItem.Click += upDateMenuItem_Click;
                    deleteMenuItem.Click += deleteMenuItem_Click;

                }
            }
        }

        //метод при выборе из контекстного меню кнопки Удалить
        void deleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Groups.CheckKids(G.ID, out List<long> kids);//проверка на связные записи
                StringTo(G, out string s);
                Groups.Search(G.ID, out long pos, out Groups g);
                if ((kids == null) || (kids.Count == 0))
                {
                    DialogResult res = MessageBox.Show($"Группа {s} будет удалена." +
                        $"\n Вы уверены?", "Предупреждение",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);
                    if (res == DialogResult.Yes)
                    {

                        if (pos >= 0)
                        {
                            Groups.Delete(pos);
                            G = null;
                        }
                        UpDate();
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show($"Группа {s} и все кто " +
                        $"в ней состоят ({kids.Count} человек) "
                        + $"будут удалены.\n Вы уверены?", "Предупреждение",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);
                    if (res == DialogResult.Yes)
                    {
                        if (pos >= 0)
                        {
                            Groups.Delete(pos);
                            G = null;
                        }
                        foreach (long kid in kids)
                        {
                            Kids.Search(kid, out long p, out Kids k);
                            Kids.Delete(p);
                        }
                        UpDate();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        //метод при выборе из контекстного меню кнопки Изменить
        void upDateMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxSection.Text = G.Секция;
            comboBoxLevel.Text = ((lev)G.Уровень).ToString();
            checkBox1.Checked = G.Дни[0];
            checkBox2.Checked = G.Дни[1];
            checkBox3.Checked = G.Дни[2];
            checkBox4.Checked = G.Дни[3];
            checkBox5.Checked = G.Дни[4];
            checkBox6.Checked = G.Дни[5];
            checkBox7.Checked = G.Дни[6];
            comboBoxYears.Text = ((year)G.Возраст).ToString();
            comboBoxPol.Text = ((pol)G.Пол).ToString();
            Treners.Search(G.Тренер, out long p, out Treners tr);
            comboBoxTrener.Text = tr.ToString();
            numericUpDownPrice.Value = (decimal)G.Стоимость;
            numericUpDownMax.Value = (decimal)G.Max;
            Kids.Search(G.ID, out List<Kids> kids);
            if (kids != null )
            numericUpDownMax.Minimum = kids.Count;
        }

        private void toolStripTextBoxRol_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        private void toolStripTextBoxDelKids_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Все люди из таблицы Ученики" +
                 $" будут удалены.\n Вы уверены?", "Предупреждение",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {Kids.DeleteKids();}

        }

        private void toolStripTextBoxDelGroups_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Все группы и их участники" +
                $" будут удалены.\n Вы уверены?", "Предупреждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                Groups.DeleteGroups();
                G = null;
                UpDate();
            }
        }

        private void toolStripTextBoxDelTrener_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Все тренера, группы и их участники" +
                $" будут удалены.\n Вы уверены?", "Предупреждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                Treners.DeleteTreners();
                UpDate();
            }
        }

        private void toolStripTextBoxDelAll_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Вся база данных Спортивной школы" +
                $" будет удалена.\n Вы уверены?", "Предупреждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                Treners.DeleteTreners();
                UpDate();
            }
        }

        //ввод только букв и бакспайс
        private void comboBoxSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void toolStripTextBoxSpravka_Click(object sender, EventArgs e)
        {
            Sparavka ifrm = new Sparavka();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }
    }
}
