using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DataAccess;

namespace WindowsFormsApplication1
{
    public partial class form_FolderLock : Form
    {
        public string path;
        public string status;
        public string arr;
        public form_FolderLock()
        {
            InitializeComponent();
            status = "";
            arr = ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
        }

         private void btn_Browse_Click(object sender, EventArgs e) // Button for Browsing the FolderPath
        {
            FolderBrowserDialog br = new FolderBrowserDialog();
            if (br.ShowDialog() == DialogResult.OK)
            {
                path = br.SelectedPath;
                if (path.LastIndexOf(".{") == -1) //if the folder is not locked
                     textFileName.Text = path;   
                else //if the folder is locked
                    textFileName.Text = path.Substring(0, path.LastIndexOf("."));

            }
        }
        
        
       

        private void btn_Lock_Click(object sender, EventArgs e) // button for Only Folder Locking
        {
            if (textFileName.Text.Length > 0) //if the textbox is not empty
            {
                try
                {
                    DataAccessClass dc = new DataAccessClass();
                    if (dc.PassKey(txtPassFolder.Text) && txtPassFolder.Text.Length > 0)
                    {

                        DirectoryInfo d = new DirectoryInfo(path);
                        
                        if (path.LastIndexOf(".{") == -1)
                        {
                            status = arr;
                            if (!d.Root.Equals(d.Parent.FullName)) // ******if root is not equal to Parent Fullname ******
                                d.MoveTo(d.Parent.FullName + "\\" + d.Name + status);
                            else                                   // ******if root = parent fullname  **********
                                d.MoveTo(d.Parent.FullName + d.Name + status);
                            //textBox1.Text = folderBrowserDialog1.SelectedPath;
                            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\lock.jpg"); // folder status by picture

                            dc.InsertFolderLockList(textFileName.Text); //Insert The FilePAth into Database
                            textFileName.Clear();
                            txtPassFolder.Clear();
                            MessageBox.Show("Folder has been Locked!", "Congratulations!", MessageBoxButtons.OK);
                        }
                    }
                    else
                        MessageBox.Show("Please Enter the Correct Password", "Wrong Password", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK);
                }
            }

            else
                MessageBox.Show("Please Browse the Folder First", "Invalid Input", MessageBoxButtons.OK); 
        }
        
        
        //-------------------------------------------------------------------------------------------------------
        private void btn_Unlock_Click(object sender, EventArgs e) //Button For Unlocking The Folder
        {
            try
            {
                if (textFileName.Text.Length > 0)
                {
                    DataAccessClass dac = new DataAccessClass();
                    bool s = dac.PassKey(txtPassFolder.Text);

                    if (s && txtPassFolder.Text.Length > 0)
                    {
                        DirectoryInfo d = new DirectoryInfo(path);
                        //string selectedpath = d.Parent.FullName + d.Name;


                        d.MoveTo(path.Substring(0, path.LastIndexOf("."))); // *****Move To A new Unlock FIlePath******
                        //txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf("."));
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\unlock.jpg");

 
                        dac.DeleteFolderLockList(textFileName.Text);        // *******Delete The FilePAth From Database*****
                        textFileName.Clear();
                        MessageBox.Show("Folder has been UnLocked!", "Congratulations!", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("Please Enter the Correct Password", "Wrong Password", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Please Browse the Folder First", "Invalid Input", MessageBoxButtons.OK);
                txtPassFolder.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu main = new MainMenu();
            main.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
       
    }
}
