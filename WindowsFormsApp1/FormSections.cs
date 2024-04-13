using ClassLibraryForBinFile;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormSections : Form
    {
        public FormSections()
        {
            InitializeComponent();
            if (FormAutoresations.rol == "operator")
            {
                toolStripTextBoxDelKids.Enabled = false;
                toolStripTextBoxDelAll.Enabled = false;
                toolStripTextBoxDelGroups.Enabled = false;
                toolStripTextBoxDelTrener.Enabled = false;
            }
            UpDate();
        }

        public void UpDate()
        {
            try
            {
                Groups.Sections(out List<string> sections);
                if (sections == null)
                {
                    dataGridViewSections.Columns.Clear();
                    dataGridViewSections.Rows.Clear();
                    statusStrip1.Items[1].Text = "0";
                }
                else
                {
                    // настройка вида таблицы
                    dataGridViewSections.ColumnCount = 1;
                    dataGridViewSections.Columns[0].Name = "Назввание секции";
                    
                    int k = sections.Count;
                    dataGridViewSections.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < sections.Count; i++)
                    {
                        dataGridViewSections.Rows[i].Cells[0].Value = sections[i];
                    }
                    //кол-во строк
                    statusStrip1.Items[1].Text = sections.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
        }

        private void FormSections_FormClosed(object sender, FormClosedEventArgs e)
        {
            Home.Close();
        }

        //метод при нажатии на кнопку Секции в меню Перейти к ..
        private void toolStripTextBoxTreners_Click(object sender, EventArgs e)
        {
            Home.Treners();
            this.Hide(); // скрываем текущую
        }
        private void toolStripTextBoxKids_Click(object sender, EventArgs e)
        {
            Home.Kids();
            this.Hide(); // скрываем текущую
        }
        private void toolStripTextBoxGroups_Click(object sender, EventArgs e)
        {
            Home.Groups();
            this.Hide(); // скрываем текущую
        }

        //поиск
        private void toolStripTextBoxS_Tr_Click(object sender, EventArgs e)
        {Home.Search("Поиск секции по фамилии тренера");}
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
    }
}
