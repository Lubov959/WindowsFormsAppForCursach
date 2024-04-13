using ClassLibraryForBinFile;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static WindowsFormsApp1.FormGroups;//для перечисления уровней

namespace WindowsFormsApp1
{
    public partial class FormSearch : Form
    {
        public FormSearch(string s)
        {
            InitializeComponent();
            groupBoxSurname.Visible = false;
            groupBoxSName.Visible = false;
            groupBoxSL.Visible = false;
            groupBoxDays.Visible = false;
            groupBoxK_NG.Visible = false;
            if (s == null)
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            else
            {
                if ((s.Equals("Поиск секции по фамилии тренера"))
                    || (s.Equals("Поиск группы по фамилии тренера")))
                {
                    groupBoxSurname.Visible = true;
                    groupBoxSurname.Text = s;
                    comboBoxSearch.Items.Add(string.Empty);
                    comboBoxSearch.MaxLength = 20;
                    Treners.Vyvod(out List<Treners> T);
                    foreach (Treners trener in T)
                        comboBoxSearch.Items.Add(trener.ToString());
                }
                else if (s.Equals("Поиск секции по фамилии занимающегося"))
                {
                    groupBoxSurname.Visible = true;
                    groupBoxSurname.Text = s;
                    comboBoxSearch.Items.Add(string.Empty);
                    comboBoxSearch.MaxLength = 20;
                    Kids.Vyvod(out List<Kids> kids);
                    foreach (Kids kid in kids)
                        comboBoxSearch.Items.Add(kid.Фамилия);
                }
                else if (s.Equals("Поиск группы по названию секции"))
                {
                    groupBoxSName.Visible = true;
                    groupBoxSName.Text = s;
                    comboBoxSName.MaxLength = 15;
                    Groups.Sections(out List<string> sections);
                    if (sections != null)
                    {
                        comboBoxSName.Items.Add(string.Empty);
                        for (int i = 0; i < sections.Count; i++)
                            comboBoxSName.Items.Add(sections[i]);
                    }
                }
                else if (s.Equals("Поиск группы в секции по уровню подготовки"))
                {
                    groupBoxSL.Visible = true;
                    groupBoxSL.Text = s;
                    Groups.Sections(out List<string> sections);
                    if (sections != null)
                    {
                        comboBoxSection.Items.Add(string.Empty);
                        for (int i = 0; i < sections.Count; i++)
                            comboBoxSection.Items.Add(sections[i]);
                    }
                    comboBoxLevel.Items.Add(string.Empty);
                    comboBoxLevel.Items.AddRange(new object[] { (lev)0, (lev)1, (lev)2, (lev)3, (lev)4 });
                }
                else if (s.Equals("Поиск секции по дням занятий"))
                {
                    groupBoxDays.Visible = true;
                }
                else if (s.Equals("Поиск учеников в определенной группе"))
                {
                    groupBoxK_NG.Visible = true;
                    groupBoxK_NG.Text = s;
                    Groups.Sections(out List<string> sect);
                    if (sect != null)
                    {
                        comboBoxNS.Items.Clear();
                        comboBoxNS.Items.Add(string.Empty);
                        if (sect != null)
                        {
                            foreach (string s1 in sect)
                                comboBoxNS.Items.Add(s1);
                        }
                    }
                }
            }
        }

        //для заполнение таблицы Групп разными значенями
        public void UpDate(List<Groups> groups)
        {
            try
            {
                if ((groups == null) || (groups.Count == 0))
                {
                    dataGridViewSchool.Rows.Clear();
                    dataGridViewSchool.Columns.Clear();
                    statusStrip1.Items[1].Text = "0";
                    throw new Exception("Совпадений не найдено!");
                }
                else
                {
                    // настройка вида таблицы
                    dataGridViewSchool.ColumnCount = 8;
                    dataGridViewSchool.Columns[0].Name = "Секция";
                    dataGridViewSchool.Columns[1].Name = "Уровень";
                    dataGridViewSchool.Columns[2].Name = "Дни занятий";
                    dataGridViewSchool.Columns[3].Name = "Возраст";
                    dataGridViewSchool.Columns[4].Name = "Пол";
                    dataGridViewSchool.Columns[5].Name = "id тренера";
                    dataGridViewSchool.Columns[6].Name = "Стоимость";
                    dataGridViewSchool.Columns[7].Name = "Макс_участников";

                    //очистка списка названий секций
                    comboBoxSection.Items.Clear();
                    comboBoxSection.Items.Add(string.Empty);

                    int k = groups.Count;
                    dataGridViewSchool.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < groups.Count; i++)
                    {
                        dataGridViewSchool.Rows[i].Cells[0].Value = groups[i].Секция;
                        dataGridViewSchool.Rows[i].Cells[1].Value = ((lev)(groups[i].Уровень)).ToString();
                        //для того чтобы убрать дублирование при перезаписи
                        dataGridViewSchool.Rows[i].Cells[2].Value = null;
                        for (byte j = 0; j < 7; j++)
                        {
                            if (groups[i].Дни[j] == true)
                                dataGridViewSchool.Rows[i].Cells[2].Value += ((day)j).ToString() + " ";
                        }
                        dataGridViewSchool.Rows[i].Cells[3].Value = ((year)(groups[i].Возраст)).ToString();
                        dataGridViewSchool.Rows[i].Cells[4].Value = ((pol)(groups[i].Пол)).ToString();
                        Treners.Search(groups[i].Тренер, out long p, out Treners tr);
                        dataGridViewSchool.Rows[i].Cells[5].Value = tr.ToString();
                        dataGridViewSchool.Rows[i].Cells[6].Value = groups[i].Стоимость;
                        dataGridViewSchool.Rows[i].Cells[7].Value = groups[i].Max;
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
        //для заполнение таблицы Cекций разными значенями
        public void UpDate(List<string> sections)
        {
            try
            {
                if ((sections == null) || (sections.Count == 0))
                {
                    dataGridViewSchool.Rows.Clear();
                    dataGridViewSchool.Columns.Clear();
                    statusStrip1.Items[1].Text = "0";
                    throw new Exception("Совпадений не найдено!");
                }
                else
                {
                    // настройка вида таблицы
                    dataGridViewSchool.ColumnCount = 1;
                    dataGridViewSchool.Columns[0].Name = "Название секции";

                    int k = sections.Count;
                    dataGridViewSchool.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < sections.Count; i++)
                    {
                        dataGridViewSchool.Rows[i].Cells[0].Value = sections[i];
                    }
                    //кол-во строк
                    statusStrip1.Items[1].Text = sections.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
        //для заполнение таблицы Дети разными значенями
        public void UpDate(List<Kids> kids)
        {
            try
            {
                if ((kids == null) || (kids.Count == 0))
                {
                    dataGridViewSchool.Columns.Clear();
                    dataGridViewSchool.Rows.Clear();
                    statusStrip1.Items[1].Text = "0";
                    throw new Exception("Совпадений не найдено!");
                }
                else
                {
                    // настройка вида таблицы
                    dataGridViewSchool.ColumnCount = 4;
                    dataGridViewSchool.Columns[0].Name = "Фамилия";
                    dataGridViewSchool.Columns[1].Name = "Имя";
                    dataGridViewSchool.Columns[2].Name = "Отчество";
                    dataGridViewSchool.Columns[3].Name = "Группа";




                    int k = kids.Count;
                    dataGridViewSchool.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < kids.Count; i++)
                    {
                        dataGridViewSchool.Rows[i].Cells[0].Value = kids[i].Фамилия;
                        dataGridViewSchool.Rows[i].Cells[1].Value = kids[i].Имя;
                        dataGridViewSchool.Rows[i].Cells[2].Value = kids[i].Отчество;
                        Groups.Search(kids[i].Группа, out long p, out Groups g);
                        StringTo(g, out string s_gr);
                        dataGridViewSchool.Rows[i].Cells[3].Value = s_gr;
                    }
                    //кол-во строк
                    statusStrip1.Items[1].Text = kids.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        //очистка полей и таблицы
        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (groupBoxDays.Visible)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
            else if (groupBoxSL.Visible)
            {
                comboBoxSection.Text = comboBoxSection.Items[0].ToString();
                comboBoxLevel.Text = comboBoxLevel.Items[0].ToString();
            }
            else if (groupBoxSName.Visible)
                comboBoxSName.Text = comboBoxSName.Items[0].ToString();
            else if (groupBoxK_NG.Visible)
            {
                comboBoxSection.Text = comboBoxNS.Items[0].ToString();
                comboBoxLevel.Text = comboBoxNG.Items[0].ToString();
            }
            else
                comboBoxSearch.Text = comboBoxSearch.Items[0].ToString();
            dataGridViewSchool.Rows.Clear();
            dataGridViewSchool.Columns.Clear();
            statusStrip1.Items[1].Text = "0";
        }

        //метод при нажатии на кнопку Найти
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataGridViewSchool.Rows.Clear();
            dataGridViewSchool.Columns.Clear();
            try
            {
                if ((groupBoxDays.Visible) && ((checkBox1.Checked) || (checkBox2.Checked) ||
                    (checkBox4.Checked) || (checkBox5.Checked) ||
                    (checkBox6.Checked) || (checkBox3.Checked) || (checkBox7.Checked)))
                {
                    bool[] d = new bool[7];
                    d[0] = checkBox1.Checked;
                    d[1] = checkBox2.Checked;
                    d[2] = checkBox3.Checked;
                    d[3] = checkBox4.Checked;
                    d[4] = checkBox5.Checked;
                    d[5] = checkBox6.Checked;
                    d[6] = checkBox7.Checked;
                    Groups.Search(d, out List<string> sections);
                    UpDate(sections);
                }
                else if ((groupBoxSL.Visible) && (comboBoxSection.Text != string.Empty)
                    && (comboBoxLevel.Text != string.Empty))
                {
                    List<Groups> groups1 = new List<Groups>();
                    Groups.Search(comboBoxSection.Text, out List<Groups> groups);
                    foreach (Groups group in groups)
                    {
                        if (((lev)group.Уровень).ToString() == comboBoxLevel.Text)
                            groups1.Add(group);

                    }
                    if (groups1.Count == 0) throw new Exception("Совпадений не найдено!");
                    UpDate(groups1);
                }
                else if ((groupBoxSName.Visible) && (comboBoxSName.Text != string.Empty))
                {
                    Groups.Search(comboBoxSName.Text, out List<Groups> groups);
                    UpDate(groups);
                }
                else if ((groupBoxK_NG.Visible) && (comboBoxNS.Text != string.Empty)
                    && (comboBoxNG.Text != string.Empty))
                {
                    Groups.Search(comboBoxNS.Text, out List<Groups> groups);
                    foreach (Groups grp in groups)
                    {
                        StringTo(grp, out string s_gr);
                        if (s_gr.Equals(comboBoxNG.Text))
                        {
                            Kids.Search(grp.ID, out List<Kids> kid);
                            UpDate(kid);
                        }
                    }
                }
                else if (comboBoxSearch.Text != string.Empty)
                {
                    if (groupBoxSurname.Text.Equals("Поиск секции по фамилии тренера"))
                    {
                        Groups.SearchSurTr(comboBoxSearch.Text, out List<string> sections);
                        UpDate(sections);
                    }
                    else if (groupBoxSurname.Text.Equals("Поиск секции по фамилии занимающегося"))
                    {
                        Groups.SearchSur(comboBoxSearch.Text, out List<string> sections);
                        UpDate(sections);
                    }
                    else
                    {
                        Groups.SearchSurTr(comboBoxSearch.Text, out List<Groups> groups);
                        UpDate(groups);
                    }
                }
            }
            catch (Exception ex)
            {
                dataGridViewSchool.Rows.Clear();
                dataGridViewSchool.Columns.Clear();
                statusStrip1.Items[1].Text = "0";
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        //при вводе Секции
        private void comboBoxNS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                comboBoxNG.Items.Clear();
                Groups.Search(comboBoxNS.SelectedItem.ToString(), out List<Groups> groups);
                if (groups != null)
                {
                    comboBoxNG.Text = string.Empty;
                    comboBoxNG.Items.Add(string.Empty);
                    foreach (Groups grp in groups)
                    {
                        StringTo(grp, out string s_gr);
                        comboBoxNG.Items.Add(s_gr);
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
        private void comboBoxNS_Leave(object sender, EventArgs e)
        {
            if (comboBoxNS.Text != string.Empty)
            {
                try
                {
                    comboBoxNG.Items.Clear();
                    Groups.Search(comboBoxNS.Text, out List<Groups> groups);
                    if (groups != null)
                    {
                        comboBoxNG.Text = string.Empty;
                        comboBoxNG.Items.Add(string.Empty);
                        foreach (Groups grp in groups)
                        {
                            StringTo(grp, out string s_gr);
                            comboBoxNG.Items.Add(s_gr);
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
        }

        //чтобы можно было выбирать только один день для поиска
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox1.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox2.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
            }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox1.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox2.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
            }
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox1.Enabled = false;
                checkBox7.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox2.Enabled = true;
                checkBox7.Enabled = true;
            }
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox2.Enabled = true;
            }
        }



    }
}
