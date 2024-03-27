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

namespace WindowsFormsApp1
{
    public partial class FormKids : Form
    {
        public FormKids()
        {
            InitializeComponent();
            comboBoxName.MaxLength = 15;
            comboBoxSurname.MaxLength = 20;
            textBoxPatronymic.MaxLength = 20;
            try
            {
                Groups.Vyvod(out List<Groups> groups);
                if (groups != null) 
                {
                    for (int i = 0; i < groups.Count; i++)
                        comboBoxGroup.Items.Add(groups[i].Название);
                }

            }
            catch (Exception ex)
            {
                DialogResult res = MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
        private void FormKids_Load(object sender, EventArgs e)
        {
            UpDate();//вывод файла
        }

        private void buttonSave_Click(object sender, EventArgs e)
        // метод нажатия на кнопку "Cохранить данные в файл"
        {
            try
            {
                //проверка на пустоту полей
                if ((comboBoxName.Text == string.Empty) || (comboBoxSurname.Text == string.Empty)
                    || (comboBoxGroup.Text == string.Empty))
                    throw new Exception("Поля записи не должны быть пустыми!");
                else
                {
                    Kids K = new Kids(); // новая запись
                                         // прочтём данные, вводимые пользователем
                    K.Имя = comboBoxName.Text;
                    K.Фамилия = comboBoxSurname.Text;
                    K.Отчество = textBoxPatronymic.Text;
                    K.Группа = comboBoxGroup.Text;

                    long p = Kids.Check(comboBoxName.Text, comboBoxSurname.Text);//проверка
                    if (p < 0)//если такой записи нет, то записываем в конец
                    { K.Add(); }
                    else
                    {
                        DialogResult res = MessageBox.Show("Такая человек уже есть! \nИзменить данные? ", "Предупреждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        { K.Correcting(p); }
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
                Kids.Vyvod(out List<Kids> kids);
                if (kids == null) { statusStrip1.Items[1].Text = "0"; }
                else
                {
                    // настройка вида таблицы
                    dataGridViewKids.ColumnCount = 4;
                    dataGridViewKids.Columns[0].Name = "Имя";
                    dataGridViewKids.Columns[1].Name = "Фамилия";
                    dataGridViewKids.Columns[2].Name = "Отчество";
                    dataGridViewKids.Columns[3].Name = "Группа";
                    //очистка списка 
                    comboBoxName.Items.Clear();
                    comboBoxSurname.Items.Clear();

                    int k = kids.Count;
                    dataGridViewKids.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < kids.Count; i++)
                    {
                        comboBoxName.Items.Add(kids[i].Имя);
                        comboBoxSurname.Items.Add(kids[i].Фамилия);
                        dataGridViewKids.Rows[i].Cells[0].Value = kids[i].Имя;
                        dataGridViewKids.Rows[i].Cells[1].Value = kids[i].Фамилия;
                        dataGridViewKids.Rows[i].Cells[2].Value = kids[i].Отчество;
                        dataGridViewKids.Rows[i].Cells[3].Value = kids[i].Группа;
                    }
                    //кол-во строк
                    statusStrip1.Items[1].Text = kids.Count.ToString();
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
            string n = comboBoxName.Text;//колонка
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxName.Text = string.Empty;
            textBoxPatronymic.Text = string.Empty;
            comboBoxGroup.Text = string.Empty;
            comboBoxSurname.Text = string.Empty;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //проверка на пустоту полей
                if ((comboBoxName.Text == string.Empty) || (comboBoxSurname.Text == string.Empty))
                    throw new Exception("Для удаления записи необходима фамилия занимающегося!");
                else
                {
                    Kids K = new Kids(); // новая запись
                                         // прочтём данные, вводимые пользователем
                    K.Имя = comboBoxName.Text;
                    K.Фамилия = comboBoxSurname.Text;

                    long p = Kids.Check(comboBoxName.Text, comboBoxSurname.Text);//проверка
                    if (p < 0)//если такой записи нет, то записываем в конец
                    {
                        DialogResult res = MessageBox.Show("Такого человека нет", "Ошибка удаления",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show($"Человек {K.Фамилия} {K.Имя} будет удален.\n Вы уверены?", "Предупреждение",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Exclamation,
                           MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        { Kids.Delete(p); }
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

        private void toolStripTextBoxGroups_Click(object sender, EventArgs e)
        {
            FormGroups ifrm = new FormGroups();
            ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        private void FormKids_FormClosed(object sender, FormClosedEventArgs e)
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

        private void toolStripTextBoxSections_Click(object sender, EventArgs e)
        {
            FormSections ifrm = new FormSections();
            ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }
    }
}
