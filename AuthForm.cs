using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace organizer
{
    public partial class AuthForm : Form
    {
        const String login = "admin";
        const String password = "admin";
        public AuthForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tmpLogin = textBox1.Text.Trim();
            String tmpPassword = textBox2.Text.Trim();

            if (!tmpLogin.Equals(login) || !tmpPassword.Equals(password))
                MessageBox.Show("Данные аккаунта не верны!");
            else
            {
                MessageBox.Show("Все верно!");
                OrganizerForm organizerForm = new OrganizerForm();
                organizerForm.Show();

                this.Hide();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Пока", " ", MessageBoxButtons.OK) ==DialogResult.OK) ;
            {
                Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    } 
}
