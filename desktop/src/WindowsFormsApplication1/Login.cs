using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccess;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        
        public  Boolean stat;
        public Login()
        {
            
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                DataAccessClass dac = new DataAccessClass();
                Boolean log = dac.LoginMethod(textBox2.Text, textBox1.Text);
                
                if (log)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    MainMenu fm = new MainMenu();
                    fm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btn_new_UserID_Click(object sender, EventArgs e)
        {
            this.Hide();
            form_SetLogin sl = new form_SetLogin();
            sl.ShowDialog();
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DataAccessClass dac = new DataAccessClass();
            
            Boolean stat = dac.GetLogin();
            if (stat == false)
            {
                this.Hide();
                form_FirstUserLogin ful = new form_FirstUserLogin();
                ful.ShowDialog();
                this.Close();
            }
        }

  
    }
}
