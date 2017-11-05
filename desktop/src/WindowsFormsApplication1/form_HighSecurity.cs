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
using BusinessLogic;

namespace WindowsFormsApplication1
{
    public partial class form_HighSecurity : Form
    {
        public string fpath;
        public string Status;
        public string arr;
        public form_HighSecurity()
        {
            InitializeComponent();
            Status = "";
            arr = ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog br = new FolderBrowserDialog();
            if (br.ShowDialog() == DialogResult.OK)
            {
                fpath = br.SelectedPath;
                if (fpath.LastIndexOf(".{") == -1)
                    txt_FolderPath.Text = fpath;
                else
                    txt_FolderPath.Text = fpath.Substring(0, fpath.LastIndexOf("."));

            }
        }
        
        //Button for Locking -------------------------------------------------------------------------------------------------------
        private void btn_Lock_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessClass dac = new DataAccessClass();
                Boolean bl = dac.PassKey(txt_Pass.Text);
       
                if (bl)
                {
                    if (txtEcryptPass.Text.Length == 8)
                    {
                        string[] files = Directory.GetFiles(txt_FolderPath.Text, "*.*", SearchOption.AllDirectories);
                        //Console.WriteLine("The number of directories starting with p is {0}.", folders.Length);
                        MessageBox.Show("There Are " + files.Length + " files in the diretory....", "Nice!!", MessageBoxButtons.OK);
                        int count = 0;
                        foreach (string file in files)
                        {
                            LogicClass lgCs = new LogicClass();
                            Boolean s = lgCs.EncryptingMethod(file, txtEcryptPass.Text);
                            if (s)
                                count++;
                        }
                        if (count == files.Length)
                            MessageBox.Show(count + " Files Have been Locked!!", "Congratzz!!", MessageBoxButtons.OK);
                        else
                            MessageBox.Show("The Folder Has not Locked Properly!", "Error", MessageBoxButtons.OK);

                        DirectoryInfo d = new DirectoryInfo(fpath);
                        //string selectedpath = d.Parent.FullName + d.Name;
                        if (fpath.LastIndexOf(".{") == -1)
                        {
                            //if (checkBox1.Checked)
                            //setpassword(folderBrowserDialog1.SelectedPath);
                            Status = arr;
                            if (!d.Root.Equals(d.Parent.FullName))
                                d.MoveTo(d.Parent.FullName + "\\" + d.Name + Status);
                            else d.MoveTo(d.Parent.FullName + d.Name + Status);
                            //textBox1.Text = folderBrowserDialog1.SelectedPath;
                            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\lock.jpg");


                            dac.InsertHighFolder(txt_FolderPath.Text);
                            dac.InsertHighFolderPassword(txt_FolderPath.Text, txtEcryptPass.Text);
                            MessageBox.Show("The Folder has been successfully Locked!", "Congratulations!", MessageBoxButtons.OK);
                            MessageBox.Show("Data Inserted into Password Bank","DONE!!", MessageBoxButtons.OK);
                            txt_FolderPath.Clear();
                            
                        }
                    }

                    else
                    {
                        if (txtEcryptPass.Text.Length < 8)
                            MessageBox.Show("Password is too short. Password must be a 8-character key.", "Invalid Input!", MessageBoxButtons.OK);
                        else
                            MessageBox.Show("Password is too large. Password must be a 8-character key.", "Invalid Input!", MessageBoxButtons.OK);
                    }

                }
                else
                    MessageBox.Show("Locker password is wrong! Please enter the correct one.", "Wrong Password!", MessageBoxButtons.OK);
                
                txt_Pass.Clear();
                txtEcryptPass.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK);
            }
        }

        //Button for Unlocking ---------------------------------------------------------------------------------------------
        private void btn_UnLock_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessClass dac = new DataAccessClass();
                //Boolean bl = dac.PassKey(txt_Pass.Text);
                Boolean bl = true;
                if (bl)
                {
                    if (txtEcryptPass.Text.Length == 8)
                    {
                        DirectoryInfo d = new DirectoryInfo(fpath);
                        //string selectedpath = d.Parent.FullName + d.Name;
                        if (fpath.LastIndexOf(".{") == -1)
                            MessageBox.Show("Folder IS Already Unlocked", "NO NEED", MessageBoxButtons.OK);
                        else
                            d.MoveTo(fpath.Substring(0, fpath.LastIndexOf(".")));
                        //string filename = fpath.ToString();
                        //txtFilePath.Text = txtFilePath.Text.Substring(0, txtFilePath.Text.LastIndexOf("."));
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\unlock.jpg");

                        MessageBox.Show("Folder has been UnLocked!", "Congratulations!", MessageBoxButtons.OK);

                        string[] files = Directory.GetFiles(txt_FolderPath.Text, "*.*", SearchOption.AllDirectories);
                        //Console.WriteLine("The number of directories starting with p is {0}.", folders.Length);
                        MessageBox.Show("There Are " + files.Length + " files in the diretory....", "Nice!!", MessageBoxButtons.OK);
                        int count = 0;
                        foreach (string file in files)
                        {
                            LogicClass lgCs = new LogicClass();
                            Boolean s = lgCs.DecryptingMethod(file, txtEcryptPass.Text);
                            if (s)
                                count++;
                        }
                        if (count == files.Length)
                        {
                            MessageBox.Show(count + " Files Have been Unlocked!!", "Congratzz!!", MessageBoxButtons.OK);
                            //DataAccessClass ndc = new DataAccessClass();
                            dac.DeleteHighFolder(txt_FolderPath.Text);
                            dac.DeleteHighFolderPassword(txt_FolderPath.Text);
                            txt_FolderPath.Clear();
                        }
                        else
                            MessageBox.Show("The Folder Has not Unlocked Properly!", "Error", MessageBoxButtons.OK);

                        

                        
                    }
                    else
                    {
                        if (txtEcryptPass.Text.Length < 8)
                            MessageBox.Show("Password is too short. Password must be a 8-character key.", "Invalid Input!", MessageBoxButtons.OK);
                        else
                            MessageBox.Show("Password is too large. Password must be a 8-character key.", "Invalid Input!", MessageBoxButtons.OK);
                    }
                }

                else
                    MessageBox.Show("Locker password is wrong! Please enter the correct one.", "Wrong Password!", MessageBoxButtons.OK);

                txt_Pass.Clear();
                txtEcryptPass.Clear();
                
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu hs = new MainMenu();
            hs.ShowDialog();
            this.Close();
        }

       
       
    }
}
