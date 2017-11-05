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
    public partial class form_FirstUserLogin : Form
    {
        public form_FirstUserLogin()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            DataAccessClass dac = new DataAccessClass();
            dac.InsertNewUserId(txt_username.Text, txt_pass.Text);
            dac.PasswordInserting(txt_Lpass.Text);
            MessageBox.Show("Your UserID has been created. Feel free to Lock File & Folders.Enjoy Yourself.....", "Congratulations!", MessageBoxButtons.OK);
            this.Hide();
            MainMenu mn = new MainMenu();
            mn.ShowDialog();
            this.Close();
        }
    }
}
