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
    public partial class form_SetPassword : Form
    {
        public form_SetPassword()
        {
            InitializeComponent();
        }

        private void txtOldPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_BackPage(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu fl = new MainMenu();
            fl.ShowDialog();
            this.Close();
        }

        private void btn_Set_Password(object sender, EventArgs e)
        {
            if (txtNewPass.Text.Length > 0 && txtOldPass.Text.Length > 0)
            {
                DataAccessClass dac = new DataAccessClass();
                if (dac.PassKey(txtOldPass.Text))
                {
                    dac.PasswordInserting(txtNewPass.Text);

                    dac.PasswordDelete(txtOldPass.Text);
                    MessageBox.Show("Password Changed!!", "Congratulations", MessageBoxButtons.OK);
                    txtNewPass.Clear();
                    txtOldPass.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter the correct Password", "Wrong Password", MessageBoxButtons.OK);
                }

            }
            else
                MessageBox.Show("Fill the Boxes with Old & Future Password", "Ivalid Input", MessageBoxButtons.OK);
        }
        }

}
