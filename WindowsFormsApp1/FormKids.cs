using ClassLibraryForBinFile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FormKids : Form
    {
        public FormKids()
        {
            InitializeComponent();
            textBoxName.MaxLength = 15;
            textBoxSurname.MaxLength = 20;
            textBoxPatronymic.MaxLength = 20;
            try
            {
                Groups.Sections(out List<string> sect);
                if (sect != null ) 
                { 
                    comboBoxNameS.Items.Clear();
                    foreach(string s in sect)
                        comboBoxNameS.Items.Add(s);
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
        private void FormKids_Load(object sender, EventArgs e)
        {
            UpDate();//вывод файла
            Groups.Sections(out List<string> sect);
            if (sect != null)
            {
                comboBoxNameS.Items.Clear();
                foreach (string s in sect)
                    comboBoxNameS.Items.Add(s);
            }
        }

        // метод нажатия на кнопку "Cохранить данные в файл"
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                //проверка на пустоту полей
                if ((comboBoxGroup.Text == string.Empty) || (textBoxName.Text == string.Empty)
                    || (textBoxSurname.Text == string.Empty) || (textBoxPatronymic.Text == string.Empty))
                    throw new Exception("Поля записи не должны быть пустыми!");
                else
                {
                    if (textBoxID.Text == string.Empty)
                    {
                        Kids K = new Kids(); // новая запись
                                             // прочтём данные, вводимые пользователем
                        K.Имя = textBoxName.Text;
                        K.Фамилия = textBoxSurname.Text;
                        K.Отчество = textBoxPatronymic.Text;
                        Groups.Search(comboBoxNameS.SelectedItem.ToString(), out List<Groups> groups);
                        if (groups != null)
                        {
                            K.Группа = groups[comboBoxGroup.SelectedIndex].ID;
                        }

                      
                        { K.Add(); }
                    }
                    else
                    {
                       
                        DialogResult res = MessageBox.Show("Такая человек уже есть! \nИзменить данные? ", "Предупреждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {  Kids.Check(textBoxID.Text, out long p, out Kids k);
                            k.Correcting(p); }
                    }
                    UpDate();
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
        private void UpDate()
        {
            try
            {
                Kids.Vyvod(out List<Kids> kids);
                if (kids == null) { 
                    dataGridViewKids.Columns.Clear();
                    dataGridViewKids.Rows.Clear();
                    statusStrip1.Items[1].Text = "0"; }
                else
                {
                    // настройка вида таблицы
                    dataGridViewKids.ColumnCount = 5;
                    dataGridViewKids.Columns[0].Name = "Id";
                    dataGridViewKids.Columns[1].Name = "Фамилия";
                    dataGridViewKids.Columns[2].Name = "Имя";
                    dataGridViewKids.Columns[3].Name = "Отчество";
                    dataGridViewKids.Columns[4].Name = "Id группы";
                    dataGridViewKids.Columns[0].Visible = false;
                    //очистка списка 
                    comboBoxNameS.Items.Clear();
                    comboBoxGroup.Items.Clear();

                    Groups.Sections(out List<string> sect);
                    if (sect != null)
                    {
                        comboBoxNameS.Items.Clear();
                        if (sect != null)
                        {
                            foreach (string s in sect)
                                comboBoxNameS.Items.Add(s);
                        }
                    }

                    int k = kids.Count;
                    dataGridViewKids.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < kids.Count; i++)
                    {
                        dataGridViewKids.Rows[i].Cells[0].Value = kids[i].ID;
                        dataGridViewKids.Rows[i].Cells[1].Value = kids[i].Фамилия;
                        dataGridViewKids.Rows[i].Cells[2].Value = kids[i].Имя;
                        dataGridViewKids.Rows[i].Cells[3].Value = kids[i].Отчество;
                        dataGridViewKids.Rows[i].Cells[4].Value = kids[i].Группа;
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

        //очистка полей
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = string.Empty;
            textBoxPatronymic.Text = string.Empty;
            comboBoxGroup.Text = comboBoxGroup.Items[0].ToString();
            comboBoxNameS.Text = comboBoxNameS.Items[0].ToString();
            textBoxSurname.Text = string.Empty;
            statusStrip1.Items[1].Text = "0";
        }
        //удаление
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //проверка на пустоту полей
                if ((textBoxName.Text == string.Empty) && (textBoxSurname.Text == string.Empty))
                    throw new Exception("Для удаления записи необходимо заполнить все поля!");
                else 
                {
                    Kids.Check(textBoxName.Text, textBoxSurname.Text, out long p);//проверка
                    if (p < 0)//если такой записи нет, то записываем в конец
                    {
                        DialogResult res = MessageBox.Show("Такого человека нет", "Ошибка удаления",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show($"Человек {textBoxSurname.Text} " +
                            $"{textBoxName.Text} будет удален.\n Вы уверены?", "Предупреждение",
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
                MessageBox.Show(ex.Message, "Ошибка",
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

        //метод для автозаполнения полей при выборе фамилии
        private void comboBoxSurname_Leave(object sender, EventArgs e)
        {
            //if (comboBoxSurname.Text != string.Empty)
            //{
            //    Kids.Check(comboBoxSurname.Text, out List<string> list);
            //    if (list != null)
            //    {
            //        if (list.Count > 1)//уточнение имени
            //        {
            //            comboBoxName.Items.Clear();
            //            foreach (string s in list) { comboBoxName.Items.Add(s); }
            //        }
            //        else if (list.Count == 1)//автозаполнение
            //        {
            //            comboBoxName.Text = list[0];
            //            Kids.Check(comboBoxName.Text, comboBoxSurname.Text, out Kids k);
            //            textBoxPatronymic.Text = k.Отчество;
            //            comboBoxGroup.Text = k.Группа;
            //        }
            //    }
                    
            //}
        }

        //метод для автозаполнения полей при выборе имени и фамилии
        private void comboBoxName_Leave(object sender, EventArgs e)
        {
            if ((textBoxSurname.Text != string.Empty) && (textBoxSurname.Text != string.Empty))
            {
                //Kids.Check(comboBoxName.Text, comboBoxSurname.Text, out Kids k);
                //if (k != null)
                //{
                //    textBoxPatronymic.Text = k.Отчество;
                //    comboBoxGroup.Text = k.Группа;
                //}
            }
        }
        //поиск
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

        private void comboBoxNameS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Groups.Search(comboBoxNameS.SelectedItem.ToString(), out List<Groups> groups);
                if (groups != null)
                { 
                    comboBoxGroup.Items.Add(string.Empty);
                    foreach (Groups grp in groups)
                        comboBoxGroup.Items.Add(grp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void dataGridViewKids_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        string[] currentRow;
        private void dataGridViewKids_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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
                dataGridViewKids.ContextMenuStrip = contextMenuStrip;
                int id = e.RowIndex;
                currentRow = new string[dataGridViewKids.ColumnCount];
                for (int i = 0; i < dataGridViewKids.ColumnCount; i++)
                {
                    currentRow[i]= dataGridViewKids.Rows[e.RowIndex].Cells[i].Value.ToString();
                }
                // устанавливаем обработчики событий для меню
                upDateMenuItem.Click += upDateMenuItem_Click;
                deleteMenuItem.Click += deleteMenuItem_Click;
                
            }
        }

        //
        void deleteMenuItem_Click(object sender, EventArgs e)
        {
            Kids.Check(currentRow[0].ToString(), out long pos);
            if (pos>0)
                Kids.Delete(pos);
            
        }
        // 
        void upDateMenuItem_Click(object sender, EventArgs e)
        {
            textBoxID.Text = currentRow[0].ToString();
            textBoxName.Text = currentRow[2].ToString();
            textBoxPatronymic.Text = currentRow[3].ToString();
            //comboBoxGroup.Text = currentRow[4].ToString();
            //comboBoxNameS.Text = comboBoxNameS.Items[0].ToString();
            textBoxSurname.Text = currentRow[1].ToString();
            Groups.Search(currentRow[4].ToString(), out Groups g);
            comboBoxNameS.Text = g.Секция;
            comboBoxGroup.Text = g.ToString();
        }

    }
}
