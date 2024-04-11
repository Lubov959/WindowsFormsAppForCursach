﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormAutoresations : Form
    {
        public static string rol = string.Empty;
        public FormAutoresations()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            if ((textBoxLogin.Text != string.Empty) && (textBoxPassword.Text != string.Empty))
            {
                if (textBoxLogin.Text == "admin")
                {
                    if (textBoxPassword.Text == "123")
                    {
                        rol = "admin";
                        Form ifrm = new Home();
                        ifrm.StartPosition = FormStartPosition.CenterScreen;
                        ifrm.Show(); // отображаем новую форму
                        this.Hide(); // скрываем текущую
                    }
                    else s = "Неверные пароль!";

                }
                else if (textBoxLogin.Text == "operator")
                {
                    if (textBoxPassword.Text == "1")
                    {
                        rol = "operator";
                        Form ifrm = new Home();
                        ifrm.StartPosition = FormStartPosition.CenterScreen;
                        ifrm.Show(); // отображаем новую форму
                        this.Hide(); // скрываем текущую
                    }
                    else s = "Неверные пароль!";
                }
                else s = "Такого пользователя не существует!";

            }
            else s = "Введите логин и пароль!";
            if(s!=string.Empty)
            MessageBox.Show(s, "Сообщение",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Asterisk);
            textBoxLogin.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
        }

        private void FormAutoresations_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Close();
        }
    }
}
