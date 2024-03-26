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
    public partial class FormGroups : Form
    {
        enum lev
        {
            Новички,
            Лайт,
            Медиум,
            Хард,
            Профессионалы
        }

        public FormGroups()
        {
            InitializeComponent();
            comboBoxNameG.MaxLength = 20;
            checkBox1.Checked = true;
            comboBoxLevel.Items.AddRange(new object[] { (lev)0, (lev)1, (lev)2, (lev)3, (lev)4 });
            try
            {
                Sections.Vyvod(out List<Sections> sections);
                if (sections == null) { throw new Exception("Файл пуст!"); }
                else
                {
                    for (int i = 0; i < sections.Count; i++)
                    {
                        comboBoxSection.Items.Add(sections[i].Название);
                    }
                }

            }
            catch (Exception ex)
            {
                DialogResult res1 = MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void FormSections_Load(object sender, EventArgs e)
        {
            UpDate();//вывод файла
        }

        private void buttonSave_Click(object sender, EventArgs e)
        // метод нажатия на кнопку "Cохранить данные в файл"
        {
            try
            {
                Groups G = new Groups(); // новая запись
                // прочтём данные, вводимые пользователем
                G.Название = comboBoxNameG.Text;
                G.Секция = textBoxTrener.Text;
                G.Уровень = Convert.ToDouble(numericUpDownPrice.Value);
                G.Дни = 

                long p = G.Check();//проверка
                if (p < 0)//если такой записи нет, то записываем в конец
                { G.Add(); }
                else
                {
                    DialogResult res = MessageBox.Show("Такая дата уже есть в файле! Изменить данные? ", "Предупреждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
                    if (res == DialogResult.Yes)
                    { G.Correcting(p); }
                }
                UpDate();
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
                //File_path();//проверка на существование пути к файлу
                Groups.Vyvod(out List<Groups> groups);
                if (groups == null) { throw new Exception("Файл пуст!"); }
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
                        dataGridViewGroups.Rows[i].Cells[2].Value = groups[i].Уровень;
                        dataGridViewGroups.Rows[i].Cells[3].Value = groups[i].Дни;
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxNameS.Text = string.Empty;
            textBoxTrener.Text = string.Empty;
            numericUpDownPrice.Value = numericUpDownPrice.Minimum;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Sections S = new Sections(); // новая запись
                // прочтём данные, вводимые пользователем
                S.Название = comboBoxNameS.Text;

                long p = S.Check();//проверка
                if (p < 0)//если такой записи нет, то записываем в конец
                {
                    DialogResult res = MessageBox.Show("Такой секции нет", "Ошибка удаления",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult res = MessageBox.Show($"Секция {S.Название} будет удалена.\n Вы уверены?", "Предупреждение",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);
                    if (res == DialogResult.Yes)
                    { S.Delete(p); }
                }
                UpDate();
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

        private void FormSections_FormClosed(object sender, FormClosedEventArgs e)
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
            FormGroups ifrm = new FormGroups();
            ifrm.Left = this.Left; // задаём открываемой форме позицию слева равную позиции текущей формы
            ifrm.Top = this.Top; // задаём открываемой форме позицию сверху равную позиции текущей формы
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }
    }
}
