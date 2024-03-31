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
            if (s== null) {
                MessageBox.Show("Что-то пошло не так!", "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);}
            else 
            { 
                if ((s.Equals("Поиск секции по фамилии тренера"))||(s.Equals("Поиск группы по фамилии тренера"))
                    ||(s.Equals( "Поиск секции по фамилии занимающегося")))
                {
                    groupBoxSurname.Visible = true;
                    groupBoxSurname.Text = s;
                    textBoxSearch.MaxLength = 20;
                } 
                else if (s.Equals("Поиск группы по названию секции"))
                {
                    groupBoxSName.Visible= true;
                    groupBoxSName.Text = s;
                    comboBoxSName.MaxLength = 15;
                    Sections.Vyvod(out List<Sections> sections);
                    if (sections != null)
                    {
                        comboBoxSName.Items.Add(string.Empty);
                        for (int i = 0; i < sections.Count; i++)
                            comboBoxSName.Items.Add(sections[i].Название);
                    }
                }
                else if (s.Equals("Поиск группы в секции по уровню подготовки"))
                {
                    groupBoxSL.Visible= true;
                    groupBoxSL.Text = s;
                    Sections.Vyvod(out List<Sections> sections);
                    if (sections != null)
                    {
                        comboBoxSection.Items.Add(string.Empty);
                        for (int i = 0; i < sections.Count; i++)
                            comboBoxSection.Items.Add(sections[i].Название);
                    }
                    comboBoxLevel.Items.Add(string.Empty);
                    comboBoxLevel.Items.AddRange(new object[] { (lev)0, (lev)1, (lev)2, (lev)3, (lev)4 });
                }
                else if (s.Equals("Поиск секции по дням занятий"))
                {
                    groupBoxDays.Visible= true;
                }
            }
        }

        //для заполнение таблицы Групп разными значенями
        public void UpDate(List<Groups> groups)
        {
            try
            {
                if (groups.Count<0) { statusStrip1.Items[1].Text = "0"; }
                else
                {
                    // настройка вида таблицы
                    dataGridViewSchool.ColumnCount = 4;
                    dataGridViewSchool.Columns[0].Name = "Название группы";
                    dataGridViewSchool.Columns[1].Name = "Секция";
                    dataGridViewSchool.Columns[2].Name = "Уровень";
                    dataGridViewSchool.Columns[3].Name = "Дни занятий";

                    int k = groups.Count;
                    dataGridViewSchool.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < groups.Count; i++)
                    {
                        dataGridViewSchool.Rows[i].Cells[0].Value = groups[i].Название;
                        dataGridViewSchool.Rows[i].Cells[1].Value = groups[i].Секция;
                        dataGridViewSchool.Rows[i].Cells[2].Value = ((lev)(groups[i].Уровень)).ToString();
                        //для того чтобы убрать дублирование при перезаписи
                        dataGridViewSchool.Rows[i].Cells[3].Value = null;
                        for (byte j = 0; j < 7; j++)
                        {
                            if (groups[i].Дни[j] == true)
                                dataGridViewSchool.Rows[i].Cells[3].Value += ((day)j).ToString() + " ";
                        }
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
        public void UpDate(List<Sections> sections)
        {
            try
            {
                if (sections.Count < 0) { statusStrip1.Items[1].Text = "0"; }
                else
                {
                    // настройка вида таблицы
                    dataGridViewSchool.ColumnCount = 3;
                    dataGridViewSchool.Columns[0].Name = "Название секции";
                    dataGridViewSchool.Columns[1].Name = "Фамилия тренера";
                    dataGridViewSchool.Columns[2].Name = "Стоимость, руб";

                    int k = sections.Count;
                    dataGridViewSchool.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < sections.Count; i++)
                    {
                        dataGridViewSchool.Rows[i].Cells[0].Value = sections[i].Название;
                        dataGridViewSchool.Rows[i].Cells[1].Value = sections[i].Тренер;
                        dataGridViewSchool.Rows[i].Cells[2].Value = sections[i].Стоимость;
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
            else if(groupBoxSName.Visible)
                comboBoxSName.Text = comboBoxSName.Items[0].ToString();
            else 
                textBoxSearch.Text = string.Empty;
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
                if ((groupBoxDays.Visible)&&((checkBox1.Checked)|| (checkBox2.Checked) ||
                    (checkBox4.Checked) ||(checkBox5.Checked) ||
                    (checkBox6.Checked) ||(checkBox3.Checked) ||(checkBox7.Checked)))
                {
                    bool[] d = new bool[7];
                    d[0] = checkBox1.Checked;
                    d[1] = checkBox2.Checked;
                    d[2] = checkBox3.Checked;
                    d[3] = checkBox4.Checked;
                    d[4] = checkBox5.Checked;
                    d[5] = checkBox6.Checked;
                    d[6] = checkBox7.Checked;
                    Sections.Search(d, out List<Sections> sections);
                    UpDate(sections);
                }
                else if ((groupBoxSL.Visible)&&(comboBoxSection.Text!=string.Empty)
                    &&(comboBoxLevel.Text!=string.Empty))
                {
                    List<Groups> groups1 = new List<Groups>();
                    Groups.Search(comboBoxSection.Text, out List<Groups> groups);
                    foreach (Groups group in groups)
                    {
                        if(((lev)group.Уровень).ToString() == comboBoxLevel.Text)
                            groups1.Add(group);

                    }
                    if (groups1.Count == 0) throw new Exception("Совпадений не найдено!");
                    UpDate(groups1);
                }
                else if ((groupBoxSName.Visible)&&(comboBoxSName.Text!=string.Empty))
                {
                    Groups.Search(comboBoxSName.Text, out List<Groups> groups);
                    UpDate(groups);
                }
                else if(textBoxSearch.Text!=string.Empty) 
                {
                    if (groupBoxSurname.Text.Equals("Поиск секции по фамилии тренера"))
                    {
                        Sections.Search(textBoxSearch.Text, out List<Sections> sections);
                        UpDate(sections);
                    }
                    else if(groupBoxSurname.Text.Equals("Поиск секции по фамилии занимающегося"))
                    {
                        Sections.Search3(textBoxSearch.Text, out List<Sections> sections);
                        UpDate(sections);
                    }
                    else
                    {
                        Groups.SearchSur(textBoxSearch.Text, out List<Groups> groups);
                        UpDate(groups);
                    }
                }
            }
            catch (Exception ex) {
                statusStrip1.Items[1].Text = "0";
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
    }
}
