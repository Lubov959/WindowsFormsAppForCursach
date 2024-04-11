using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            label1.Text = $"Вы вошли как {FormAutoresations.rol}!";
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            FormGroups ifrm = new FormGroups();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            FormTreners ifrm = new FormTreners();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        private void buttonK_Click(object sender, EventArgs e)
        {
            FormKids ifrm = new FormKids();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
            this.Hide(); // скрываем текущую
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Close();
        }
    }
}
