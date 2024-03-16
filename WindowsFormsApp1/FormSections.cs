using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibraryForBinFile;

namespace WindowsFormsApp1
{
    public partial class FormSections : System.Windows.Forms.Form
    {
        private string fn = "Sections";// имя файла

        //enum Col : byte
        //{//перечисление для выбора колонки поиска
        //    Название,
        //    Количество,
        //    Цена,
        //    Стоимость
        //}

        public FormSections()
        {
            InitializeComponent();

            //выбор колонки

            //comboBoxNameCol.Items.AddRange(new object[] { (Col)0, (Col)1, (Col)2, (Col)3 });
            ////ограничение длины вводимых величин
            //textBoxName.MaxLength = 15;
            //textBoxSearch.MaxLength = 20;
            //textBoxTrener.MaxLength = 20;
            //textBoxTrener.MaxLength = 8;//макс для целого положительного
        }

        private void buttonSave_Click(object sender, EventArgs e)
        // метод нажатия на кнопку "Cохранить данные в файл"
        {
            try
            {
                //File_path();//проверка не путь
                Sections N = new Sections(); // новая запись
                // прочтём данные, вводимые пользователем
                //N.Стоимость = Convert.ToDouble(numericUpDownPrice.Value);
                //N.Название = Convert.ToString(textBoxName.Text);
                //N.Тренер = Convert.ToString(textBoxTrener.Text);

                long p = N.Check(fn);//проверка
                if (p < 0)//если такой записи нет, то записываем в конец
                {
                    N.Add(fn);
                    DialogResult res = MessageBox.Show("Запись успешно добавлена в файл", "Сохранение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult res = MessageBox.Show("Такая дата уже есть в файле! Изменить данные? ", "Предупреждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
                    if (res == DialogResult.Yes)
                    {
                        N.Correcting(fn, p);
                        DialogResult res1 = MessageBox.Show("Запись в файле успешно изменена", "Изменение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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

        // метод нажатия на кнопку "Чтение данных"
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //File_path();//проверка на существование пути к файлу
                Sections.Vyvod(fn, out List<Sections> sections);
                if (sections == null) { throw new Exception("Файл пуст!"); }
                //Form2 about = new Form2(fn, sections);
                //about.StartPosition = FormStartPosition.CenterParent;
                //about.ShowDialog();
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
            string n = comboBoxNameCol.Text;//колонка
            try
            {
                //File_path();//проверка на существование пути к файлу
                //если пользователь выбрал поиск по Названию,
                //то выводится информация сразу в поле для редактирования
                //if (n == ((Col)0).ToString())
                //{
                //    string z = textBoxSearch.Text;//занчение поиска
                //    Product.Search(fn, z, out Product rez);

                //    textBoxName.Text = rez.Название;
                //    textBoxCost.Text = rez.Стоимость.ToString();
                //    textBoxPrice.Text = rez.Цена.ToString();
                //    textBoxTrener.Text = rez.Количество.ToString();
                //}
                //else//Обычныый поиск
                //{
                //    object z = textBoxSearch.Text;//значение поиска
                //    Product.Search(fn, n, z, out List<Product> rez);
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
    }
}
