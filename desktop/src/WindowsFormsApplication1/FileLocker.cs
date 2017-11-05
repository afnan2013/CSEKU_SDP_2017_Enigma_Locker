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
    public partial class form_FileLocker : Form
    {
        public form_FileLocker()
        {
            InitializeComponent();
        }

       
        //Go to the File Locking Window Or Encryption Window
        private void button_lock_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Encyption f2 = new Form_Encyption();
            f2.ShowDialog();
            this.Close();
        }

        

        //Go back to the mainmenu
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.ShowDialog();
            this.Close();
        }

       
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
    }
}
