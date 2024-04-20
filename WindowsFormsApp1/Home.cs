using System;
using System.Linq;
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

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Close();
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            Groups();
            this.Hide(); // скрываем текущую
        }
        private void buttonT_Click(object sender, EventArgs e)
        {
            Treners();
            this.Hide(); // скрываем текущую
        }
        private void buttonK_Click(object sender, EventArgs e)
        {
            Kids();
            this.Hide(); // скрываем текущую
        }
        //private void buttonS_Click(object sender, EventArgs e)
        //{
        //    Sections(); this.Hide(); // скрываем текущую
        //}

        //методы перехода к другой таблице
        public static void Groups()
        {
            if (Application.OpenForms.Cast<Form>().Any(f => f.Name == "FormGroups"))
                Application.OpenForms["FormGroups"].Dispose();
            FormGroups ifrm = new FormGroups();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
        }
        public static void Treners()
        {
            if (Application.OpenForms.Cast<Form>().Any(f => f.Name == "FormTreners"))
                Application.OpenForms["FormTreners"].Dispose();
            FormTreners ifrm = new FormTreners();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
        }
        public static void Kids()
        {
            if (Application.OpenForms.Cast<Form>().Any(f => f.Name == "FormKids"))
                Application.OpenForms["FormKids"].Dispose();
            FormKids ifrm = new FormKids();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
        }
        public static void Sections()
        {
            if (Application.OpenForms.Cast<Form>().Any(f => f.Name == "FormSections"))
                Application.OpenForms["FormSections"].Dispose();
            FormSections ifrm = new FormSections();
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
        }

        //метод открытия поиска
        public static void Search(string s)
        {
            if (Application.OpenForms.Cast<Form>().Any(f => f.Name == "FormSearch"))
                Application.OpenForms["FormSearch"].Dispose();
            FormSearch ifrm = new FormSearch(s);
            ifrm.StartPosition = FormStartPosition.CenterParent;
            ifrm.Show(); // отображаем новую форму диалога
        }

        //закрытие программы
        public new static void Close()
        {
            if (Application.OpenForms.Cast<Form>().Any(f => f.Name == "Home"))
                Application.OpenForms["Home"].Show();
        }

        //смена роли
        public static void Rol()
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.StartPosition = FormStartPosition.CenterScreen;
            ifrm.Show(); // отображаем новую форму
        }
    }
}
