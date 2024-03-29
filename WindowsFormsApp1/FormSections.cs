using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibraryForBinFile;

namespace WindowsFormsApp1
{
    public partial class FormSections : Form
    {
        public FormSections()
        {
            InitializeComponent();
            this.StartPosition= FormStartPosition.CenterScreen;
            //ограничение длинны
            comboBoxNameS.MaxLength = 15;
            textBoxTrener.MaxLength = 20;
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
                if((comboBoxNameS.Text == string.Empty)||(textBoxTrener.Text==string.Empty) )
                    throw new Exception("Поля записи не должны быть пустыми!");
                {
                    Sections S = new Sections(); // новая запись
                                                 // прочтём данные, вводимые пользователем
                    S.Название = comboBoxNameS.Text;
                    S.Тренер = textBoxTrener.Text;
                    S.Стоимость = Convert.ToDouble(numericUpDownPrice.Value);

                    long p = Sections.Check(comboBoxNameS.Text);//проверка
                    if (p < 0)//если такой записи нет, то записываем в конец
                    { S.Add(); }
                    else
                    {
                        DialogResult res = MessageBox.Show("Такая секция уже есть! \nИзменить данные? ", "Предупреждение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        { S.Correcting(p); }
                    }
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

        //обновление данных в форме относительно файла
        private void UpDate()
        {
            try
            {
                //File_path();//проверка на существование пути к файлу
                Sections.Vyvod(out List<Sections> sections);
                if (sections == null) { statusStrip1.Items[1].Text = "0"; }
                else
                { 
                    // настройка вида таблицы
                    dataGridViewSections.ColumnCount = 3;
                    dataGridViewSections.Columns[0].Name = "Название секции";
                    dataGridViewSections.Columns[1].Name = "Фамилия тренера";
                    dataGridViewSections.Columns[2].Name = "Стоимость, руб";
                    //очистка списка названий секций
                    comboBoxNameS.Items.Clear();

                    int k = sections.Count;
                    dataGridViewSections.RowCount = k;
                    // цикл для вывода данных из массива в таблицу на форме
                    for (int i = 0; i < sections.Count; i++)
                    {
                        comboBoxNameS.Items.Add(sections[i].Название);
                        dataGridViewSections.Rows[i].Cells[0].Value = sections[i].Название;
                        dataGridViewSections.Rows[i].Cells[1].Value = sections[i].Тренер;
                        dataGridViewSections.Rows[i].Cells[2].Value = sections[i].Стоимость;
                    }
                     //кол-во строк
                    statusStrip1.Items[1].Text = sections.Count.ToString();
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
            comboBoxNameS.Text = string.Empty;
            textBoxTrener.Text = string.Empty;
            numericUpDownPrice.Value = numericUpDownPrice.Minimum;
        }

        //метод при нажатии на кнопку Удалить
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxNameS.Text == string.Empty)
                    throw new Exception("Для удаления записи необходимо нзвание секции!");
                else
                {
                    long p = Sections.Check(comboBoxNameS.Text);//проверка
                    if (p < 0)//если такой записи нет, то записываем в конец
                    {
                        DialogResult res = MessageBox.Show("Такой секции нет", "Ошибка удаления",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {//проверка на связные записи
                        Sections.CheckKidsAndGroups(comboBoxNameS.Text, out List<long> groups_pos,
                            out List<long> kids_pos);
                        if ((groups_pos.Count > 0) && (kids_pos.Count > 0))
                        {
                            DialogResult res = MessageBox.Show($"Секциия {comboBoxNameS.Text}, а также " +
                                $"связанные с ней записи" +
                                $" (Группы - {groups_pos.Count} и Занимающиеся - {kids_pos.Count})"
                                + $"будут удалены.\n Вы уверены?", "Предупреждение",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button2);
                            if (res == DialogResult.Yes)
                            {
                                Groups.Delete(p);
                                foreach (long gr in groups_pos)
                                    Groups.Delete(gr);
                                foreach (long kid in groups_pos)
                                    Kids.Delete(kid);
                            }
                        }
                        else
                        {
                            DialogResult res = MessageBox.Show($"Секция {comboBoxNameS.Text} будет удалена." +
                                $"\n Вы уверены?", "Предупреждение",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button2);
                            if (res == DialogResult.Yes)
                            {
                                Groups.Delete(p);
                                foreach (long kid in groups_pos)
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
    }
}
