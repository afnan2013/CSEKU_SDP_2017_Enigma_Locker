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
    public partial class Password_Bank : Form
    {
        public Password_Bank()
        {
            InitializeComponent();
        }


        DataAccessClass dac = new DataAccessClass();

        private void btn_Show_ALL(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dac.DisplayAllPasswordBank();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.ShowDialog();
            this.Close();
        }

        private void btn_File_Show_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dac.DisplayFileLockPasswordBank();
        }

        private void btn_HighFolderPass_Show(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dac.DisplayHighFolderLockPasswordBank();
        }

        

        private void btn_save_click(object sender, EventArgs e)
        {
            dac.Save_Online_Info(txt_Username.Text, txt_password.Text, txt_type.Text, comboBox1.Text);
            txt_Username.Clear();
            txt_password.Clear();
            txt_type.Clear();
            txtPrimaryKey.Clear();
            
        }

        private void btn_Starred_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dac.DisplayStarInfo();
        }

        private void btn_Others_Show(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dac.DisplayOthersInfo();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_Username.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_password.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_type.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtPrimaryKey.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void txt_Delete_Click(object sender, EventArgs e)
        {
            dac.Delete_ID_Info(txt_Username.Text);
            txt_Username.Clear();
            txt_password.Clear();
            txt_type.Clear();
            txtPrimaryKey.Clear();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            dac.Update_User_Info(txtPrimaryKey.Text, txt_Username.Text, txt_password.Text, txt_type.Text, comboBox1.Text);
        }
    }
}
