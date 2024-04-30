using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTW2024
{
    public partial class Login : Form
    {
        int i;
        public Login()
        {
            i = 0;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (i==0)
            {
                tbPassword.PasswordChar = '*';
                btnHide.Image = LTW2024.Properties.Resources.hide;
                i++;
            }
            else 
            {
                tbPassword.PasswordChar = '\0';
                btnHide.Image = LTW2024.Properties.Resources.view;
                i--;
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Exit();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
