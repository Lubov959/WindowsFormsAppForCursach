using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibraryForBinFile;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FormTreners : Form
    {
        public FormTreners()
        {
            InitializeComponent();
            //ограничение длинны
            textBoxName.MaxLength = 15;
            textBoxSurname.MaxLength = 20;
            textBoxPatronymic.MaxLength = 20;
        }
        private void FormSections_Load(object sender, EventArgs e)
        {
            UpDate();//вывод файла
        }
        
        // метод нажатия на кнопку "Cохранить данные в файл"
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                //проверка на пустоту полей
                if ( (textBoxName.Text == string.Empty)
                    || (textBoxSurname.Text == string.Empty) || (textBoxPatronymic.Text == string.Empty))
                    throw new Exception("Поля записи не должны быть пустыми!");
                else
                {
                    if (textBoxID.Text == string.Empty)
                    {
                        Treners T = new Treners(); // новая запись
                                             // прочтём данные, вводимые пользователем
                        T.Имя = textBoxName.Text;
                        T.Фамилия = textBoxSurname.Text;
                        T.Отчество = textBoxPatronymic.Text;

                        Treners.Check(T.ID, out long p);
                        if(p<0)
                        { T.Add(); }
                        else
                        {
                            DialogResult res = MessageBox.Show("Такая человек уже есть! \nИзменить данные? ", "Предупреждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
                            if (res == DialogResult.Yes)
                            {
                                textBoxID.Text = T.ID;
                                T.Correcting(p);
                            }
                        }
                    }
                    else
                    {

                        DialogResult res = MessageBox.Show("Такая человек уже есть! \nИзменить данные? ", "Предупреждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {
                            Treners.Check(textBoxID.Text, out long p, out Treners t);
                            t.Correcting(p);
                        }
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
        public void UpDate() 
        {
            try
            {
                Treners.Vyvod(out List<Treners> treners);
                if (treners == null)
                {
                    dataGridViewTreners.Columns.Clear();
                    dataGridViewTreners.Rows.Clear();
                    statusStrip1.Items[1].Text = "0";
                }
                else
                {
                    // настройка вида таблицы
                    dataGridViewTreners.ColumnCount = 5;
                    dataGridViewTreners.Columns[0].Name = "Id";
                    dataGridViewTreners.Columns[1].Name = "Фамилия";
                    dataGridViewTreners.Columns[2].Name = "Имя";
                    dataGridViewTreners.Columns[3].Name = "Отчество";
                    dataGridViewTreners.Columns[4].Name = "Стаж (года)";
                    //dataGridViewTreners.Columns[0].Visible = false;





                    int k = treners.Count;
                    dataGridViewTreners.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < treners.Count; i++)
                    {
                        dataGridViewTreners.Rows[i].Cells[0].Value = treners[i].ID;
                        dataGridViewTreners.Rows[i].Cells[1].Value = treners[i].Фамилия;
                        dataGridViewTreners.Rows[i].Cells[2].Value = treners[i].Имя;
                        dataGridViewTreners.Rows[i].Cells[3].Value = treners[i].Отчество;
                        dataGridViewTreners.Rows[i].Cells[4].Value = treners[i].Стаж;
                    }
                    //кол-во строк
                    statusStrip1.Items[1].Text = treners.Count.ToString();
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
            textBoxSurname.Text = string.Empty;
            textBoxPatronymic.Text = string.Empty;
            numericUpDown1.Value = numericUpDown1.Minimum;
            textBoxID.Text = string.Empty;
        }

        string[] currentRow = new string[5];
        private void dataGridViewTreners_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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
                dataGridViewTreners.ContextMenuStrip = contextMenuStrip;
                for (int i = 0; i < dataGridViewTreners.ColumnCount; i++)
                {
                    currentRow[i] = dataGridViewTreners.Rows[e.RowIndex].Cells[i].Value.ToString();
                }
                // устанавливаем обработчики событий для меню
                upDateMenuItem.Click += upDateMenuItem_Click;
                deleteMenuItem.Click += deleteMenuItem_Click;

            }
        }

        //
        void deleteMenuItem_Click(object sender, EventArgs e)
        {
            //проверка на связные записи
            Treners.CheckKidsAndGroups(comboBoxNameS.Text, out List<long> groups_pos,
                out List<long> kids_pos);
            if ((groups_pos == null) || (groups_pos.Count == 0))
            {
                DialogResult res = MessageBox.Show($"Секция {comboBoxNameS.Text} будет удалена." +
                    $"\n Вы уверены?", "Предупреждение",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    Treners.Delete(p);
                }
            }
            else
            {
                if ((groups_pos.Count > 0) && (kids_pos.Count > 0))
                {
                    DialogResult res = MessageBox.Show($"Секциия {comboBoxNameS.Text}, а также " +
                        $"связанные с ней записи" +
                        $" (Группы - {groups_pos.Count} и Занимающиеся - {kids_pos.Count})"
                        + $" будут удалены.\n Вы уверены?", "Предупреждение",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);
                    if (res == DialogResult.Yes)
                    {
                        Sections.Delete(p);
                        foreach (long gr in groups_pos)
                            Groups.Delete(gr);
                        foreach (long kid in kids_pos)
                            Kids.Delete(kid);
                    }
                }
                else if (groups_pos.Count > 0)
                {
                    DialogResult res = MessageBox.Show($"Секциия {comboBoxNameS.Text}, а также " +
                        $"связанные с ней записи Группы - {groups_pos.Count} шт "
                        + $"будут удалены.\n Вы уверены?", "Предупреждение",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);
                    if (res == DialogResult.Yes)
                    {
                        Sections.Delete(p);
                        foreach (long gr in groups_pos)
                            Groups.Delete(gr);
                    }
                }
            }
                Treners.Check(currentRow[0].ToString(), out long pos);
            if (pos > 0)
                Treners.Delete(pos);
            UpDate();
        }
        // 
        void upDateMenuItem_Click(object sender, EventArgs e)
        {
            textBoxID.Text = currentRow[0].ToString();
            textBoxName.Text = currentRow[2].ToString();
            textBoxPatronymic.Text = currentRow[3].ToString();
            textBoxSurname.Text = currentRow[1].ToString();
            numericUpDown1.Value = Convert.ToUInt16( currentRow[4]);
        }

        //метод при нажатии на кнопку Удалить
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (comboBoxNameS.Text == string.Empty)
            //        throw new Exception("Для удаления записи необходимо ввести нaзвание секции!");
            //    else
            //    {
            //        Sections.Check(comboBoxNameS.Text, out long p);//проверка
            //        if (p < 0)//если такой записи нет, то записываем в конец
            //        {
            //            MessageBox.Show("Такой секции нет", "Ошибка удаления",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //        }
            //        else
            //        {//проверка на связные записи
            //            Sections.CheckKidsAndGroups(comboBoxNameS.Text, out List<long> groups_pos,
            //                out List<long> kids_pos);
            //            if ((groups_pos == null) || (groups_pos.Count == 0))
            //            {
            //                DialogResult res = MessageBox.Show($"Секция {comboBoxNameS.Text} будет удалена." +
            //                    $"\n Вы уверены?", "Предупреждение",
            //                   MessageBoxButtons.YesNo,
            //                   MessageBoxIcon.Exclamation,
            //                   MessageBoxDefaultButton.Button2);
            //                if (res == DialogResult.Yes)
            //                {
            //                    Sections.Delete(p);
            //                }
            //            }
            //            else
            //            {
            //                if ((groups_pos.Count > 0) && (kids_pos.Count > 0))
            //                {
            //                    DialogResult res = MessageBox.Show($"Секциия {comboBoxNameS.Text}, а также " +
            //                        $"связанные с ней записи" +
            //                        $" (Группы - {groups_pos.Count} и Занимающиеся - {kids_pos.Count})"
            //                        + $" будут удалены.\n Вы уверены?", "Предупреждение",
            //                       MessageBoxButtons.YesNo,
            //                       MessageBoxIcon.Exclamation,
            //                       MessageBoxDefaultButton.Button2);
            //                    if (res == DialogResult.Yes)
            //                    {
            //                        Sections.Delete(p);
            //                        foreach (long gr in groups_pos)
            //                            Groups.Delete(gr);
            //                        foreach (long kid in kids_pos)
            //                            Kids.Delete(kid);
            //                    }
            //                }
            //                else if (groups_pos.Count > 0)
            //                {
            //                    DialogResult res = MessageBox.Show($"Секциия {comboBoxNameS.Text}, а также " +
            //                        $"связанные с ней записи Группы - {groups_pos.Count} шт "
            //                        + $"будут удалены.\n Вы уверены?", "Предупреждение",
            //                       MessageBoxButtons.YesNo,
            //                       MessageBoxIcon.Exclamation,
            //                       MessageBoxDefaultButton.Button2);
            //                    if (res == DialogResult.Yes)
            //                    {
            //                        Sections.Delete(p);
            //                        foreach (long gr in groups_pos)
            //                            Groups.Delete(gr);
            //                    }
            //                }
            //            }
            //        }
            //        UpDate();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    DialogResult res1 = MessageBox.Show(ex.Message, "Ошибка",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //}
        }

        //перемещение между формами
        private void toolStripTextBoxGroups_Click(object sender, EventArgs e)
        {
            FormGroups ifrm = new FormGroups();
            ifrm.StartPosition = FormStartPosition.CenterParent;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        //перемещение между формами
        private void toolStripTextBoxKids_Click(object sender, EventArgs e)
        {
            FormKids ifrm = new FormKids();
            ifrm.StartPosition = FormStartPosition.CenterParent; 
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

        
    }
}
