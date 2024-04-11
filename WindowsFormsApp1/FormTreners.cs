using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibraryForBinFile;

namespace WindowsFormsApp1
{
    public partial class FormTreners : Form
    {
        Treners T;
        public FormTreners()
        {
            InitializeComponent();
            if (FormAutoresations.rol == "operator")
            {
                this.Width = 511;
                toolStripTextBoxDelKids.Enabled = true;
                toolStripTextBoxDelAll.Enabled = true;
                toolStripTextBoxDelGroups.Enabled = true;
                toolStripTextBoxDelTrener.Enabled = true;
            }
            else
            {
                //ограничение длинны
                textBoxName.MaxLength = 15;
                textBoxSurname.MaxLength = 20;
                textBoxPatronymic.MaxLength = 20;
            }
        }
        private void FormSections_Load(object sender, EventArgs e)
        {
            UpDate();//вывод файла
        }

        // метод записи в файл
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                //проверка на пустоту полей
                if ((textBoxName.Text == string.Empty)
                    || (textBoxSurname.Text == string.Empty) || (textBoxPatronymic.Text == string.Empty))
                    throw new Exception("Поля записи не должны быть пустыми!");
                else
                {
                    if (T == null) { T = new Treners(); }
                    // прочтём данные, вводимые пользователем
                    T.Имя = textBoxName.Text;
                    T.Фамилия = textBoxSurname.Text;
                    T.Отчество = textBoxPatronymic.Text;
                    T.Стаж = Convert.ToDouble(numericUpDown1.Value);
                    if (T.ID == 0)
                    {
                        T.Add();
                        T = null;
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Вы уверены, что хотите " +
                            "\nизменить данные? ", "Предупреждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {
                            Treners.Search(T.ID, out long p, out Treners t);
                            T.Correcting(p);
                            T = null;
                        }
                    }
                    UpDate();
                    buttonClear_Click(sender, e);
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
            T = null;
            textBoxName.Text = string.Empty;
            textBoxSurname.Text = string.Empty;
            textBoxPatronymic.Text = string.Empty;
            numericUpDown1.Value = numericUpDown1.Minimum;
        }

        //контекстное меню
        private void dataGridViewTreners_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (FormAutoresations.rol == "admin")
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
                    T = new Treners();
                    T.ID = (long)dataGridViewTreners.Rows[e.RowIndex].Cells[0].Value;
                    T.Фамилия = (string)dataGridViewTreners.Rows[e.RowIndex].Cells[1].Value;
                    T.Имя = (string)dataGridViewTreners.Rows[e.RowIndex].Cells[2].Value;
                    T.Отчество = (string)dataGridViewTreners.Rows[e.RowIndex].Cells[3].Value;
                    T.Стаж = (double)dataGridViewTreners.Rows[e.RowIndex].Cells[4].Value;
                    // устанавливаем обработчики событий для меню
                    upDateMenuItem.Click += upDateMenuItem_Click;
                    deleteMenuItem.Click += deleteMenuItem_Click;

                }
            }
        }

        //метод при выборе из контекстного меню кнопки Удалить
        void deleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                //проверка на связные записи
                Treners.CheckKidsAndGroups(T.ID, out List<long> groups_pos,
                    out List<long> kids_pos);
                Treners.Search(T.ID, out long pos, out Treners t);
                if ((groups_pos == null) || (groups_pos.Count == 0))
                {
                    DialogResult res = MessageBox.Show($"Человек { T.Фамилия}"
                        + $" {T.Имя} будет удален.\n Вы уверены?", "Предупреждение",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);
                    if (res == DialogResult.Yes)
                    {
                        if (pos >= 0)
                        { Treners.Delete(pos); T = null; }
                        UpDate();
                    }
                }
                else
                {
                    if ((groups_pos.Count > 0) && (kids_pos.Count > 0))
                    {
                        DialogResult res = MessageBox.Show($"Человек { T.Фамилия} "
                        + $"{T.Имя}, а также " + $"связанные с ней записи" +
                            $" (Группы - {groups_pos.Count} и Занимающиеся - {kids_pos.Count})"
                            + $" будут удалены.\n Вы уверены?", "Предупреждение",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Exclamation,
                           MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {
                            if (pos >= 0)
                            { Treners.Delete(pos); T = null; }
                            foreach (long gr in groups_pos)
                            { Groups.Search(gr, out long p, out Groups g); Groups.Delete(p); }
                            foreach (long kid in kids_pos)
                            { Kids.Search(kid, out long p, out Kids k); Kids.Delete(p); }
                            UpDate();
                        }
                    }
                    else if (groups_pos.Count > 0)
                    {
                        DialogResult res = MessageBox.Show($"Человек { T.Фамилия} "
                        + $"{T.Имя}, а также " +
                            $"связанные с ней записи Группы - {groups_pos.Count} шт "
                            + $"будут удалены.\n Вы уверены?", "Предупреждение",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Exclamation,
                           MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {
                            if (pos >= 0)
                            { Treners.Delete(pos); T = null; }
                            foreach (long gr in groups_pos)
                            { Groups.Search(gr, out long p, out Groups g); Groups.Delete(p); }
                        }
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

        //метод при выборе из контекстного меню кнопки Изменить
        void upDateMenuItem_Click(object sender, EventArgs e)
        {
            textBoxName.Text = T.Имя;
            textBoxPatronymic.Text = T.Отчество;
            textBoxSurname.Text = T.Фамилия;
            numericUpDown1.Value = (decimal)T.Стаж;
        }



        //перемещение между формами
        private void toolStripTextBoxGroups_Click(object sender, EventArgs e)
        {
            FormGroups ifrm = new FormGroups();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }
        private void toolStripTextBoxKids_Click(object sender, EventArgs e)
        {
            FormKids ifrm = new FormKids();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        //закрытие формы
        private void FormTreners_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Close();
        }

        //поиск
        private void toolStripTextBoxS_Tr_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск секции по фамилии тренера");
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxG_Tr_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск группы по фамилии тренера");
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxS_SurnKid_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск секции по фамилии занимающегося");
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxG_NS_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск группы по названию секции");
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxG_LS_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск группы в секции по уровню подготовки");
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        private void toolStripTextBoxS_Day_Click(object sender, EventArgs e)
        {
            FormSearch ifrm = new FormSearch("Поиск секции по дням занятий");
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        //доп действия
        private void toolStripTextBoxRol_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }
        private void toolStripTextBoxDelKids_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Все люди из таблицы Ученики" +
                 $" будут удалены.\n Вы уверены?", "Предупреждение",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            { Kids.DeleteKids(); }

        }
        private void toolStripTextBoxDelGroups_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Все группы и их участники" +
                $" будут удалены.\n Вы уверены?", "Предупреждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {Groups.DeleteGroups();}
        }
        private void toolStripTextBoxDelTrener_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Все тренера, группы и их участники" +
                $" будут удалены.\n Вы уверены?", "Предупреждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                Treners.DeleteTreners();
                T = null;
                UpDate();
            }
        }
        private void toolStripTextBoxDelAll_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Вся база данных Спортивной школы" +
                $" будет удалена.\n Вы уверены?", "Предупреждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                Treners.DeleteTreners();
                T = null;
                UpDate();
            }
        }
        private void toolStripTextBoxSpravka_Click(object sender, EventArgs e)
        {
            Sparavka ifrm = new Sparavka();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.ShowDialog(); // отображаем новую форму диалога
        }

        //ввод только букв и бакспайс
        private void textBoxSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void textBoxPatronymic_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        
    }
}
