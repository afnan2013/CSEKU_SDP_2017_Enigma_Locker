using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace WindowsFormsApplication1
{
    public partial class PasswordBankLogin : Form
    {
        public PasswordBankLogin()
        {
            InitializeComponent();
        }

        DataAccessClass dac = new DataAccessClass();

        private void btn_PassBank_Login(object sender, EventArgs e)
        {
            bool s = dac.PassKey(txt_MasterPass.Text);
            if(s==true)
            {
                MessageBox.Show("Login Successful...Safe & Secure...","Enjoy!",MessageBoxButtons.OK);
                this.Hide();
                Password_Bank pb = new Password_Bank();
                pb.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Looks Like You have entered a wrong password.","Try Again", MessageBoxButtons.OK);
                
        }

        private void btn_back_click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.ShowDialog();
            this.Close();
        }
    }
}
