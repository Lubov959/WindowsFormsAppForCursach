using ClassLibraryForBinFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class FormGroups : Form
    {
        enum lev:byte
        {
            Новички,Лайт,
            Медиум,Хард,
            Профессионалы
        }

        enum day : byte
        {
            Пн, Вт,Ср,Чт,Пт,Сб,Вс
        }

        public FormGroups()
        {
            InitializeComponent();
            //ограничение длинны
            comboBoxNameG.MaxLength = 20;
            //начальные параметры
            checkBox1.Checked = true;
            comboBoxLevel.Items.AddRange(new object[] { (lev)0, (lev)1, (lev)2, (lev)3, (lev)4 });
            try
            {
                Sections.Vyvod(out List<Sections> sections);
                if (sections != null) 
                {
                    for (int i = 0; i < sections.Count; i++)
                        comboBoxSection.Items.Add(sections[i].Название);
                }

            }
            catch (Exception ex)
            {
                DialogResult res = MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void FormGroups_Load(object sender, EventArgs e)
        {
            UpDate();//вывод файла
        }

        private void buttonSave_Click(object sender, EventArgs e)
        // метод нажатия на кнопку "Cохранить данные в файл"
        {
            try
            {
                //проверка на пустоту полей
                if ((comboBoxNameG.Text == string.Empty) || (comboBoxLevel.Text == string.Empty)
                    || (comboBoxSection.Text == string.Empty))
                    throw new Exception("Поля записи не должны быть пустыми!");
                else
                {
                    Groups G = new Groups(); // новая запись
                                             // прочтём данные, вводимые пользователем
                    G.Название = comboBoxNameG.Text;
                    G.Секция = comboBoxSection.Text;
                    for (byte i = 0; i < 5; i++)
                    {
                        if (((lev)i).ToString() == comboBoxLevel.Text)
                            G.Уровень = i;
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

                    long p = Groups.Check(comboBoxNameG.Text);//проверка
                    if (p < 0)//если такой записи нет, то записываем в конец
                    { G.Add(); }
                    else
                    {
                        DialogResult res = MessageBox.Show("Такая дата уже есть в файле! " +
                            "Изменить данные? ", "Предупреждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        { G.Correcting(p); }
                    }
                    UpDate();
                }
            }
            catch (Exception ex)
            {
                DialogResult res1 = MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        //метод проверки на существование пути к файлу
        //private void File_path()
        //{
        //    if (fn == string.Empty)//для выбора файла для записи
        //    {
        //        // отобразить диалог Открыть
        //        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //            fn = openFileDialog1.FileName;
        //        else
        //        { throw new Exception("Пустое имя пути не допускается"); }
        //    }
        //}

        //обновление данных в форме относительно файла
        private void UpDate()
        {
            try
            {
                Groups.Vyvod(out List<Groups> groups);
                if (groups == null) { statusStrip1.Items[1].Text = "0"; }
                else
                {
                    // настройка вида таблицы
                    dataGridViewGroups.ColumnCount = 4;
                    dataGridViewGroups.Columns[0].Name = "Название группы";
                    dataGridViewGroups.Columns[1].Name = "Секция";
                    dataGridViewGroups.Columns[2].Name = "Уровень";
                    dataGridViewGroups.Columns[3].Name = "Дни занятий";
                    //очистка списка названий секций
                    comboBoxNameG.Items.Clear();

                    int k = groups.Count;
                    dataGridViewGroups.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < groups.Count; i++)
                    {
                        comboBoxNameG.Items.Add(groups[i].Название);
                        dataGridViewGroups.Rows[i].Cells[0].Value = groups[i].Название;
                        dataGridViewGroups.Rows[i].Cells[1].Value = groups[i].Секция;
                        dataGridViewGroups.Rows[i].Cells[2].Value = ((lev)(groups[i].Уровень)).ToString();
                        //для того чтобы убрать дублирование при перезаписи
                        dataGridViewGroups.Rows[i].Cells[3].Value = null;
                        for (byte j =  0; j < 7; j++)
                        {
                            if (groups[i].Дни[j] == true)
                                dataGridViewGroups.Rows[i].Cells[3].Value += ((day)j).ToString()+" ";
                        }
                    }
                    //кол-во строк
                    statusStrip1.Items[1].Text = groups.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                DialogResult res1 = MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        //метод нажатия на кнопку Найти
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string n = comboBoxNameG.Text;//колонка
            try
            {
                //    //вывод результатов в форму 2
                //    Form2 about = new Form2(fn, rez);
                //    about.StartPosition = FormStartPosition.CenterParent;
                //    about.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                DialogResult res1 = MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        //ограничения ввода для числовых полей
        private void TextBoxNumder_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешает вводить только цифры от 0 до 10 и BackSpase и ,
            char number = e.KeyChar;
            TextBox textBox = (sender as TextBox);
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            { e.Handled = true; }
            if (textBox.Text.Contains(",") && e.KeyChar == ',') //Запрет нескольких запятых
                e.Handled = true;
        }
        //для Количества только цифры
        private void TextBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешает вводить только цифры от 0 до 10 и BackSpase 
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            { e.Handled = true; }
        }

        //нажатие на кнопку очистки полей записи
        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxNameG.Text = string.Empty;
            comboBoxSection.Text = string.Empty;
            comboBoxLevel.Text = string.Empty;
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        //удаление записей
        public void DeleteG_K(long p, string name)
        {
            
        }

        //метод при нажатии на кнопку Удалить
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //проверка на пустоту полей
                if (comboBoxNameG.Text == string.Empty)
                    throw new Exception("Для удаления записи необходимо нзвание группы!");
                else
                {
                    long p = Groups.Check(comboBoxNameG.Text);//проверка
                    if (p < 0)//если такой записи нет
                    {
                        DialogResult res = MessageBox.Show("Такой группы нет", "Ошибка удаления",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        Groups.CheckKids(comboBoxNameG.Text, out List<long> kids_pos);//проверка на связные записи
                        if (kids_pos.Count > 0)
                        {
                            DialogResult res = MessageBox.Show($"Группа {comboBoxNameG.Text} и все кто " +
                                $"в ней состоят ({kids_pos.Count} шт) "
                                + $"будут удалены.\n Вы уверены?", "Предупреждение",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button2);
                            if (res == DialogResult.Yes)
                            {
                                Groups.Delete(p);
                                foreach (long kid in kids_pos)
                                    Kids.Delete(kid);
                            }
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show($"Группа {comboBoxNameG.Text} будет удалена." +
                                $"\n Вы уверены?", "Предупреждение",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button2);
                            if (res == DialogResult.Yes)
                            {
                                Groups.Delete(p);
                                foreach (long kid in kids_pos)
                                    Kids.Delete(kid);
                            }
                        }
                    }
                    UpDate();
                }
            }
            catch (Exception ex)
            {
                DialogResult res1 = MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void toolStripTextBoxSections_Click(object sender, EventArgs e)
        {
            FormSections ifrm = new FormSections();
            ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        private void FormGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count > 0)
            {
                // вызываем главную форму, которая открыла текущую, главная форма всегда = 0 - [0]
                Form ifrm = Application.OpenForms[0];
                ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
                ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
                ifrm.Show(); // отображаем главную форму
            }
        }

        private void toolStripTextBoxKids_Click(object sender, EventArgs e)
        {
            FormKids ifrm = new FormKids();
            ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }
    }
}
