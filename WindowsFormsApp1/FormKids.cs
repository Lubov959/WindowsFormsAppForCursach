using ClassLibraryForBinFile;
using System;
using System.Collections.Generic;
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
                    comboBoxGroup.Items.Add(string.Empty);
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

        // метод нажатия на кнопку "Cохранить данные в файл"
        private void buttonSave_Click(object sender, EventArgs e)
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

                    Kids.Check(comboBoxName.Text, comboBoxSurname.Text, out long p);//проверка
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
                    dataGridViewKids.Columns[0].Name = "Фамилия";
                    dataGridViewKids.Columns[1].Name = "Имя";
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
                        byte d = 1;//проверка на дубли в списке фамилий
                        foreach(var item in comboBoxSurname.Items)
                        {
                            if (item.ToString() != kids[i].Фамилия)
                                d++;
                            else { d = 0; break; }
                        }
                        if (d!=0)
                            comboBoxSurname.Items.Add(kids[i].Фамилия);
                        dataGridViewKids.Rows[i].Cells[0].Value = kids[i].Фамилия;
                        dataGridViewKids.Rows[i].Cells[1].Value = kids[i].Имя;
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

        //очистка полей
        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxName.Items.Clear();
            textBoxPatronymic.Text = string.Empty;
            comboBoxGroup.Text = comboBoxGroup.Items[0].ToString();
            comboBoxSurname.Text = string.Empty;
            statusStrip1.Items[1].Text = "0";
        }
        //удаление
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //проверка на пустоту полей
                if ((comboBoxName.Text == string.Empty) && (comboBoxSurname.Text == string.Empty))
                    throw new Exception("Для удаления записи необходимы фамилия и имя занимающегося!");
                else 
                {
                    Kids.Check(comboBoxName.Text, comboBoxSurname.Text, out long p);//проверка
                    if (p < 0)//если такой записи нет, то записываем в конец
                    {
                        DialogResult res = MessageBox.Show("Такого человека нет", "Ошибка удаления",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show($"Человек {comboBoxSurname.Text} " +
                            $"{comboBoxName.Text} будет удален.\n Вы уверены?", "Предупреждение",
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

        //передвижение между формами
        private void toolStripTextBoxGroups_Click(object sender, EventArgs e)
        {
            FormGroups ifrm = new FormGroups();
            ifrm.StartPosition = FormStartPosition.CenterScreen; 
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }
        
        //закрытие
        private void FormKids_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Close();
        }
        
        //передвижение между формами
        private void toolStripTextBoxSections_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        //метод происходит после заполнения Фамилии
        //если дети с такой фамилией есть он их записывает в поле Имя
        private void comboBoxSurname_Leave(object sender, EventArgs e)
        {
            if (comboBoxSurname.Text != string.Empty)
            {
                Kids.Check(comboBoxSurname.Text, out List<string> list);
                if (list.Count > 1)
                {
                    comboBoxName.Items.Clear();
                    foreach (string s in list) { comboBoxName.Items.Add(s); }
                }
                else if (list.Count == 1)
                    comboBoxName.Text = list[0];
            }
        }
    }
}
