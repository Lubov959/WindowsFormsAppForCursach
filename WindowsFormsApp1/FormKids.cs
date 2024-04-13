using ClassLibraryForBinFile;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormKids : Form
    {
        Kids K;
        public FormKids()
        {
            InitializeComponent();
            if (FormAutoresations.rol == "operator")
            {
                toolStripTextBoxDelKids.Enabled = false;
                toolStripTextBoxDelAll.Enabled = false;
                toolStripTextBoxDelGroups.Enabled = false;
                toolStripTextBoxDelTrener.Enabled = false;
            }
            textBoxName.MaxLength = 15;
            textBoxSurname.MaxLength = 20;
            textBoxPatronymic.MaxLength = 20;
            Groups.Sections(out List<string> sect);
            if (sect != null)
            {
                comboBoxNameS.Items.Clear();
                comboBoxNameS.Items.Add(string.Empty);
                if (sect != null)
                {
                    foreach (string s in sect)
                        comboBoxNameS.Items.Add(s);
                }
            }

        }
        private void FormKids_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(comboBoxGroup, "Здесь отображаются только группы для записи\n " +
                "Полный список групп можно посмотреть в таблице \"Группы\" или поиске");
            UpDate();//вывод файла
        }

        // метод записи в файл
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
                    if (K == null) K = new Kids(); // новая запись
                                                   // прочтём данные, вводимые пользователем
                    K.Имя = textBoxName.Text;
                    K.Фамилия = textBoxSurname.Text;
                    K.Отчество = textBoxPatronymic.Text;
                    Groups.Vyvod(out List<Groups> groups);
                    if (groups != null)
                    {
                        foreach (Groups grp in groups)
                        {
                            FormGroups.StringTo(grp, out string s_gr);
                            if (comboBoxGroup.Text == s_gr)
                                K.Группа = grp.ID;
                        }

                    }
                    if (K.ID == 0)
                    {
                        K.Add();
                        K = null;
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
                            Kids.Search(K.ID, out long p, out Kids k);
                            K.Correcting(p);
                            K = null;
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
        private void UpDate()
        {
            try
            {
                Kids.Vyvod(out List<Kids> kids);
                if ((kids == null) || (kids.Count == 0))
                {
                    dataGridViewKids.Columns.Clear();
                    dataGridViewKids.Rows.Clear();
                    statusStrip1.Items[1].Text = "0";
                }
                else
                {
                    // настройка вида таблицы
                    dataGridViewKids.ColumnCount = 5;
                    dataGridViewKids.Columns[0].Name = "Id";
                    dataGridViewKids.Columns[1].Name = "Фамилия";
                    dataGridViewKids.Columns[2].Name = "Имя";
                    dataGridViewKids.Columns[3].Name = "Отчество";
                    dataGridViewKids.Columns[4].Name = "Группа";
                    dataGridViewKids.Columns[0].Visible = false;




                    int k = kids.Count;
                    dataGridViewKids.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < kids.Count; i++)
                    {
                        dataGridViewKids.Rows[i].Cells[0].Value = kids[i].ID;
                        dataGridViewKids.Rows[i].Cells[1].Value = kids[i].Фамилия;
                        dataGridViewKids.Rows[i].Cells[2].Value = kids[i].Имя;
                        dataGridViewKids.Rows[i].Cells[3].Value = kids[i].Отчество;
                        Groups.Search(kids[i].Группа, out long p, out Groups g);
                        FormGroups.StringTo(g, out string s_gr);
                        dataGridViewKids.Rows[i].Cells[4].Value = s_gr;
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
            K = null;
            textBoxName.Text = string.Empty;
            textBoxPatronymic.Text = string.Empty;
            comboBoxGroup.Items.Clear();
            comboBoxGroup.Items.Add(string.Empty);
            comboBoxGroup.Text = comboBoxGroup.Items[0].ToString();
            comboBoxNameS.Text = comboBoxNameS.Items[0].ToString();
            textBoxSurname.Text = string.Empty;
        }


        //передвижение между формами
        private void toolStripTextBoxTreners_Click(object sender, EventArgs e)
        {
            Home.Treners();
            this.Hide(); // скрываем текущую
        }
        private void toolStripTextBoxGroups_Click(object sender, EventArgs e)
        {
            Home.Groups();
            this.Hide(); // скрываем текущую
        }
        private void toolStripTextBoxSections_Click(object sender, EventArgs e)
        {
            Home.Sections();
            this.Hide(); // скрываем текущую
        }

        //закрытие
        private void FormKids_FormClosed(object sender, FormClosedEventArgs e)
        {
            Home.Close();
        }

        //поиск
        private void toolStripTextBoxS_Tr_Click(object sender, EventArgs e)
        { Home.Search("Поиск секции по фамилии тренера"); }
        private void toolStripTextBoxG_Tr_Click(object sender, EventArgs e)
        {
            Home.Search("Поиск группы по фамилии тренера");
        }
        private void toolStripTextBoxS_SurnKid_Click(object sender, EventArgs e)
        {
            Home.Search("Поиск секции по фамилии занимающегося");
        }
        private void toolStripTextBoxG_NS_Click(object sender, EventArgs e)
        {
            Home.Search("Поиск группы по названию секции");
        }
        private void toolStripTextBoxG_LS_Click(object sender, EventArgs e)
        {
            Home.Search("Поиск группы в секции по уровню подготовки");
        }
        private void toolStripTextBoxS_Day_Click(object sender, EventArgs e)
        {
            Home.Search("Поиск секции по дням занятий");
        }
        private void toolStripTextBoxK_NG_Click(object sender, EventArgs e)
        {
            Home.Search("Поиск учеников в определенной группе");
        }

        //событие при выборе Секции из выпадающего списка
        private void comboBoxNameS_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                comboBoxGroup.Items.Clear();
                Groups.Search(comboBoxNameS.SelectedItem.ToString(), out List<Groups> groups);
                if (groups != null)
                {
                    comboBoxGroup.Text = string.Empty;
                    comboBoxGroup.Items.Add(string.Empty);
                    foreach (Groups grp in groups)
                    {
                        Kids.Search(grp.ID, out List<Kids> kid);
                        if (K != null)
                        {
                            if ((grp.Max > kid.Count) || (grp.ID == K.Группа))
                            {
                                FormGroups.StringTo(grp, out string s_gr);
                                comboBoxGroup.Items.Add(s_gr);
                            }
                        }
                        else
                        {
                            if (grp.Max > kid.Count)
                            {
                                FormGroups.StringTo(grp, out string s_gr);
                                comboBoxGroup.Items.Add(s_gr);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }
        private void comboBoxNameS_Leave(object sender, EventArgs e)
        {
            if (comboBoxNameS.Text != string.Empty)
            {
                try
                {
                    comboBoxGroup.Items.Clear();
                    Groups.Search(comboBoxNameS.Text, out List<Groups> groups);
                    if (groups != null)
                    {
                        comboBoxGroup.Text = string.Empty;
                        comboBoxGroup.Items.Add(string.Empty);
                        foreach (Groups grp in groups)
                        {
                            Kids.Search(grp.ID, out List<Kids> kid);
                            if (K != null)
                            {
                                if ((grp.Max > kid.Count) || (grp.ID == K.Группа))
                                {
                                    FormGroups.StringTo(grp, out string s_gr);
                                    comboBoxGroup.Items.Add(s_gr);
                                }
                            }
                            else
                            {
                                if (grp.Max > kid.Count)
                                {
                                    FormGroups.StringTo(grp, out string s_gr);
                                    comboBoxGroup.Items.Add(s_gr);
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
            }
        }

        //контекстное меню
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
                K = new Kids();
                K.ID = (long)dataGridViewKids.Rows[e.RowIndex].Cells[0].Value;
                K.Фамилия = (string)dataGridViewKids.Rows[e.RowIndex].Cells[1].Value;
                K.Имя = (string)dataGridViewKids.Rows[e.RowIndex].Cells[2].Value;
                K.Отчество = (string)dataGridViewKids.Rows[e.RowIndex].Cells[3].Value;
                Groups.Vyvod(out List<Groups> groups);
                if (groups != null)
                {
                    foreach (Groups grp in groups)
                    {
                        FormGroups.StringTo(grp, out string s_gr);
                        if (dataGridViewKids.Rows[e.RowIndex].Cells[4].Value.ToString() == s_gr)
                            K.Группа = grp.ID;
                    }

                }
                // устанавливаем обработчики событий для меню
                upDateMenuItem.Click += upDateMenuItem_Click;
                deleteMenuItem.Click += deleteMenuItem_Click;

            }
        }

        //Удаление
        void deleteMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Человек {K.Фамилия} " +
            $"{K.Имя} будет удален.\n Вы уверены?", "Предупреждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                Kids.Search(K.ID, out long pos, out Kids k);
                if (pos >= 0)
                { Kids.Delete(pos); K = null; }
                UpDate();
            }

        }

        // Корректировка записи
        void upDateMenuItem_Click(object sender, EventArgs e)
        {
            textBoxName.Text = K.Имя;
            textBoxPatronymic.Text = K.Отчество;
            textBoxSurname.Text = K.Фамилия;
            Groups.Search(K.Группа, out long p, out Groups g);
            FormGroups.StringTo(g, out string s_group);
            comboBoxNameS.Text = g.Секция;
            Groups.Search(g.Секция, out List<Groups> groups);
            if (groups != null)
            {
                comboBoxGroup.Items.Clear();
                comboBoxGroup.Text = string.Empty;
                comboBoxGroup.Items.Add(string.Empty);
                foreach (Groups grp in groups)
                {
                    Kids.Search(grp.ID, out List<Kids> kid);
                    if ((grp.Max > kid.Count) || (grp.ID == g.ID))
                    {
                        FormGroups.StringTo(grp, out string s_gr);
                        comboBoxGroup.Items.Add(s_gr);
                    }
                }
            }
            comboBoxGroup.Text = s_group;
        }

        //доп действия
        private void toolStripTextBoxRol_Click(object sender, EventArgs e)
        {
            Home.Rol();
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
            {
                Kids.DeleteKids();
                K = null;
                UpDate();
            }

        }
        private void toolStripTextBoxDelGroups_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"Все группы и их участники" +
                $" будут удалены.\n Вы уверены?", "Предупреждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                Groups.DeleteGroups();
                UpDate();
            }
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
                UpDate();
            }
        }
        private void toolStripTextBoxSpravka_Click(object sender, EventArgs e)
        {
            Sparavka ifrm = new Sparavka();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
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
