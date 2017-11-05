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
    public partial class form_SetLogin : Form
    {
        public form_SetLogin()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_CreateID_Click(object sender, EventArgs e)
        {
            DataAccessClass dac = new DataAccessClass();
            Boolean st = dac.UserPassCheck(txt_main_Pass.Text);
            if (st)
            {
                dac.DeleteUserId(txt_main_Pass.Text);
                dac.InsertNewUserId(txt_Username.Text, txt_Password.Text);
                MessageBox.Show("UserID Changed!!", "Congratzz!!", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Wrong Password!!", "Error!", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.ShowDialog();
            this.Close();
        }
    }
}
