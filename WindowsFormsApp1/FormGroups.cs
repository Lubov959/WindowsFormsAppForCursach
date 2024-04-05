using ClassLibraryForBinFile;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormGroups : Form
    {
        public enum lev:byte
        {
            Новички,Лайт,
            Медиум,Хард,
            Профессионалы
        }

        public enum year : byte
        {Младшие, Средние,Старшие}

        public enum pol : byte
        { Женщины, Мужчины, Смешанные }

        public enum day : byte
        {Пн, Вт,Ср,Чт,Пт,Сб,Вс}

        public FormGroups()
        {
            InitializeComponent();
            //ограничение длинны
            comboBoxNameG.MaxLength = 20;
            comboBoxSection.MaxLength = 20;
            //начальные параметры
            comboBoxLevel.Items.Add(string.Empty);
            comboBoxLevel.Items.AddRange(new object[] { (lev)0, (lev)1, (lev)2, (lev)3, (lev)4 });
            comboBoxPol.Items.Add(string.Empty);
            comboBoxPol.Items.AddRange(new object[] { (pol)0, (pol)1, (pol)2});
            comboBoxYears.Items.Add(string.Empty);
            comboBoxYears.Items.AddRange(new object[] { (year)0, (year)1, (year)2 });
            
        }

        private void FormGroups_Load(object sender, EventArgs e) 
        { 
            UpDate();//вывод файла
        }

        // метод нажатия на кнопку "Cохранить данные в файл"
        private void buttonSave_Click(object sender, EventArgs e)
        
        {
            //try
            //{
            //    //проверка на пустоту полей
            //    if ((comboBoxNameG.Text == string.Empty) || (comboBoxLevel.Text == string.Empty)
            //        || (comboBoxSection.Text == string.Empty))
            //        throw new Exception("Поля записи не должны быть пустыми!");
            //    else
            //    {
            //        Groups G = new Groups(); // новая запись
            //                                 // прочтём данные, вводимые пользователем
            //        G.Название = comboBoxNameG.Text;
            //        G.Секция = comboBoxSection.Text;
            //        for (byte i = 0; i < 5; i++)
            //        {
            //            if (((lev)i).ToString() == comboBoxLevel.Text)
            //                G.Уровень = i;
            //        }
            //        bool[] d = new bool[7];
            //        d[0] = checkBox1.Checked;
            //        d[1] = checkBox2.Checked;
            //        d[2] = checkBox3.Checked;
            //        d[3] = checkBox4.Checked;
            //        d[4] = checkBox5.Checked;
            //        d[5] = checkBox6.Checked;
            //        d[6] = checkBox7.Checked;
            //        G.Дни = d;

            //        Groups.Check(comboBoxNameG.Text, out long p);//проверка
            //        if (p < 0)//если такой записи нет, то записываем в конец
            //        { G.Add(); }
            //        else
            //        {
            //            DialogResult res = MessageBox.Show("Такая дата уже есть в файле! " +
            //                "Изменить данные? ", "Предупреждение",
            //                MessageBoxButtons.YesNo,
            //                MessageBoxIcon.Exclamation,
            //                MessageBoxDefaultButton.Button2);
            //            if (res == DialogResult.Yes)
            //            { G.Correcting(p); }
            //        }
            //        Groups.Vyvod(out List<Groups> groups);

            //        UpDate();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //}
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
                    dataGridViewGroups.ColumnCount = 9;
                    dataGridViewGroups.Columns[0].Name = "ID";
                    dataGridViewGroups.Columns[1].Name = "Секция";
                    dataGridViewGroups.Columns[2].Name = "Уровень";
                    dataGridViewGroups.Columns[3].Name = "Дни занятий";
                    dataGridViewGroups.Columns[4].Name = "Возраст";
                    dataGridViewGroups.Columns[5].Name = "Пол";
                    dataGridViewGroups.Columns[6].Name = "id тренера";
                    dataGridViewGroups.Columns[7].Name = "Стоимость";
                    dataGridViewGroups.Columns[8].Name = "Макс_участников";
                    //очистка списка названий секций
                    comboBoxNameG.Items.Clear();
                    comboBoxSection.Items.Clear();

                    int k = groups.Count;
                    dataGridViewGroups.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < groups.Count; i++)
                    {
                        byte d = 1;
                        foreach(string sect in comboBoxSection.Items)
                        {
                            if (sect.Equals(groups[i].Секция))
                            { d=0; break;}
                        }
                        if (d != 0)
                            comboBoxSection.Items.Add(groups[i].Секция);
                        d = 1;
                        foreach (string sect in comboBoxNameG.Items)
                        {
                            if (sect.Equals(groups[i].Секция))
                            { d = 0; break; }
                        }
                        if (d != 0)
                            comboBoxNameG.Items.Add(groups[i].ID);
                        comboBoxNameG.Items.Add(groups[i].ID);
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
                        dataGridViewGroups.Rows[i].Cells[6].Value = groups[i].Тренер;
                        dataGridViewGroups.Rows[i].Cells[7].Value = groups[i].Стоимость;
                        dataGridViewGroups.Rows[i].Cells[8].Value = groups[i].Max;

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
            comboBoxNameG.Text = string.Empty;
            comboBoxSection.Text = comboBoxSection.Items[0].ToString();
            comboBoxLevel.Text = comboBoxLevel.Items[0].ToString();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            statusStrip1.Items[1].Text = "0";
        }

        //метод при нажатии на кнопку Удалить
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //проверка на пустоту полей
            //    if (comboBoxNameG.Text == string.Empty)
            //        throw new Exception("Для удаления записи необходимо нзвание группы!");
            //    else
            //    {
            //        Groups.Check(comboBoxNameG.Text, out long p);//проверка
            //        if (p < 0)//если такой записи нет
            //        {
            //            MessageBox.Show("Такой группы нет", "Ошибка удаления",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //        }
            //        else
            //        {
            //            Groups.CheckKids(comboBoxNameG.Text, out List<long> kids_pos);//проверка на связные записи
            //            if ((kids_pos == null) || (kids_pos.Count == 0))
            //            {
            //                DialogResult res = MessageBox.Show($"Группа {comboBoxNameG.Text} будет удалена." +
            //                    $"\n Вы уверены?", "Предупреждение",
            //                   MessageBoxButtons.YesNo,
            //                   MessageBoxIcon.Exclamation,
            //                   MessageBoxDefaultButton.Button2);
            //                if (res == DialogResult.Yes)
            //                {
            //                    Groups.Delete(p);
            //                }
            //            }
            //            else
            //            {
            //                DialogResult res = MessageBox.Show($"Группа {comboBoxNameG.Text} и все кто " +
            //                    $"в ней состоят ({kids_pos.Count} шт) "
            //                    + $"будут удалены.\n Вы уверены?", "Предупреждение",
            //                   MessageBoxButtons.YesNo,
            //                   MessageBoxIcon.Exclamation,
            //                   MessageBoxDefaultButton.Button2);
            //                if (res == DialogResult.Yes)
            //                {
            //                    Groups.Delete(p);
            //                    foreach (long kid in kids_pos)
            //                        Kids.Delete(kid);
            //                }
            //            }
            //        }
            //        UpDate();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //}
        }

        //метод при нажатии на кнопку Секции в меню Перейти к ..
        private void toolStripTextBoxSections_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
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

        //метод для автозаполнения полей при выборе уже существующей группы
        private void comboBoxNameG_Leave(object sender, EventArgs e)
        {
            //if (comboBoxNameG.Text != string.Empty)
            //{
            //    Groups.Check(comboBoxNameG.Text, out Groups g);
            //    if (g != null)
            //    {
            //        comboBoxSection.Text = g.Секция;
            //        comboBoxLevel.Text = ((lev)g.Уровень).ToString();
            //        checkBox1.Checked = g.Дни[0];
            //        checkBox2.Checked = g.Дни[1];
            //        checkBox3.Checked = g.Дни[2];
            //        checkBox4.Checked = g.Дни[3];
            //        checkBox5.Checked = g.Дни[4];
            //        checkBox6.Checked = g.Дни[5];
            //        checkBox7.Checked = g.Дни[6];
            //    }
            //}
        }
    }
}
