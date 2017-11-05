using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using DataAccess;

namespace WindowsFormsApplication1
{
    public partial class DataDisplay : Form
    {
        
        public DataDisplay()
        {
            
            InitializeComponent();
            
        }

        DataAccessClass dac = new DataAccessClass();

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = dac.DisplayFolderLockList();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dac.DisplayFileLockList();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.ShowDialog();
            this.Close();
        }

        private void btn_high_Secured_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dac.DisplayHighFolderLockList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
