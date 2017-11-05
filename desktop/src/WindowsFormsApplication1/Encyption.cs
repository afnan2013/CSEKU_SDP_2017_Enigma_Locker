using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccess;
using BusinessLogic;
namespace WindowsFormsApplication1
{
    public partial class Form_Encyption : Form
    {
        public Form_Encyption()
        {
            InitializeComponent();
        }

        //Browse the file which to be encrypted
        private void btn_Browse1Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Browse";
            open.Filter = "All Files (*.*)|*.*|Text File (*.txt)|*.txt|JPEG File (*.jpg)|*.jpg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox_fLocation.Text = open.FileName;
            }
        }

      
       
        //Does The Encryption
       private void button_LockEncr_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessClass dt = new DataAccessClass();
                //DataAccessClass dt = new DataAccessClass();
                //DataAccessClass dt2 = new DataAccessClass();
                Boolean s = dt.PassKey(textBox_key.Text);
               
                if (s == true)
                {
                    if (textBox_rKey.Text.Length == 8)
                    {
                        LogicClass lc = new LogicClass();
                        Boolean stat = lc.EncryptingMethod(textBox_fLocation.Text, textBox_rKey.Text);
                        if (stat)
                        {
                            MessageBox.Show("Encryption Succesful!", "Encryption", MessageBoxButtons.OK);    
                            dt.InsertFileLockList(textBox_fLocation.Text);
                            dt.InsertFileLockPassword(textBox_fLocation.Text, textBox_rKey.Text);
                            MessageBox.Show("Data Inserted into Password Bank", "Done!", MessageBoxButtons.OK);
                            textBox_fLocation.Clear();

                        }
                        else
                            MessageBox.Show("Encryption Error....", "Error!", MessageBoxButtons.OK);
                    }

                    else
                    {
                        if (textBox_rKey.Text.Length < 8)
                            MessageBox.Show("Password is too short. Password must be a 8-character key.", "Invalid Input!", MessageBoxButtons.OK);
                        else
                            MessageBox.Show("Password is too large. Password must be a 8-character key.", "Invalid Input!", MessageBoxButtons.OK);
                    }

                }

                else
                    MessageBox.Show("Locker password is wrong! Please enter the correct one.", "Wrong Password", MessageBoxButtons.OK);
                
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error!!", MessageBoxButtons.OK);
            }
            
            
            textBox_key.Clear();
            textBox_rKey.Clear();
        }

       // To decrypt the file 
       private void btn_unlock_click(object sender, EventArgs e)
       {
           try
           {
               DataAccessClass dac = new DataAccessClass();
               Boolean s = dac.PassKey(textBox_key.Text);
               if (s == true)
               {
                   LogicClass lc1 = new LogicClass();
                   Boolean stat = lc1.DecryptingMethod(textBox_fLocation.Text, textBox_rKey.Text);
                   if (stat)
                   {
                       MessageBox.Show("Decryption Succesful!", "Decryption", MessageBoxButtons.OK);
                       
                       dac.DeleteFileLockList(textBox_fLocation.Text);
                      
                       dac.DeleteFileLockPassword(textBox_fLocation.Text);
                       MessageBox.Show("Data Inserted into Password Bank.", "DONE", MessageBoxButtons.OK);
                       textBox_fLocation.Clear();
                   }
                   else
                       MessageBox.Show("Decryption Error!", "Error", MessageBoxButtons.OK);


               }
               else
                   MessageBox.Show("Wrong Password!", "Error", MessageBoxButtons.OK);
           }

           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
           }

           
           
           textBox_key.Clear();
           textBox_rKey.Clear();
       }



        //Get to the File Locking Window
       private void button2_Click(object sender, EventArgs e)
       {
           this.Hide();
           MainMenu fl = new MainMenu();
           fl.ShowDialog();
           this.Close();
       }

       private void label3_Click(object sender, EventArgs e)
       {

       }
    }
}
