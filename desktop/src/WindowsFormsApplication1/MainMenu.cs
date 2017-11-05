using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn_UnLock_Click(object sender, EventArgs e) //Button for Only File Locker form open
        {
            this.Hide();
            form_FileLocker fl = new form_FileLocker();
            fl.ShowDialog();
            this.Close();
        }

        private void btn_Lock_Click(object sender, EventArgs e) //Button for Only Folder Locker Form Open
        {
            this.Hide();
            form_FolderLock fl = new form_FolderLock();
            fl.ShowDialog();
            this.Close();
        }

        private void btn_HighSecurity_Click(object sender, EventArgs e) //Button For High Level Sucurity Form Open
        {
            this.Hide();
            form_HighSecurity hs = new form_HighSecurity();
            hs.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e) // Button For Displaying the Locked Folders
        {
            this.Hide();
            DataDisplay dd = new DataDisplay();
            dd.ShowDialog();
            this.Close();
            
        }
        

        private void button3_Click(object sender, EventArgs e) // Button for Exit
        {
            this.Close();
        }

        //Password Changing!!
        private void button4_Click(object sender, EventArgs e) // Button for seting a new password
        {
            form_SetPassword sp = new form_SetPassword();
            sp.ShowDialog();
            
        }



        // Declare CspParmeters and RsaCryptoServiceProvider
        // objects with global scope of your Form class.
        CspParameters cspp = new CspParameters();
        RSACryptoServiceProvider Rsa;
        string privateKey;
        string publicKey;


        // Key container name for
        // private/public key value pair.
        const string keyName = "afnan afnan";

        private void btn_CreateAseKeys_Click(object sender, EventArgs e)
        {
            cspp.KeyContainerName = keyName;
            RSACryptoServiceProvider Rsa = new RSACryptoServiceProvider(1024, cspp);
            Rsa.PersistKeyInCsp = true;
            privateKey = Rsa.ToXmlString(true);
            publicKey = Rsa.ToXmlString(false);
            //txt_publicKey.Text = publicKey;
            //txt_privateKey.Text = privateKey;

            if (saveFile("Save Public/Private Keys As", "Public/Private Keys Document( *.kez )|*.kez", privateKey))
            {
                if (saveFile("Save Public Key As", "Public Key Document( *.pke )|*.pke", publicKey))
                    MessageBox.Show("Public Key & Private Key has been created.", "Succesful", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Public Key & Private Key has been created.", "Unsuccessful", MessageBoxButtons.OK);
            }
        }

        private bool saveFile(string title, string filterString, string outputString)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = title;
            save.Filter = filterString;
            save.FileName = "";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(save.FileName, false);
                    if (outputString != null)
                    { streamWriter.Write(outputString); }
                    streamWriter.Close();
                    return true;
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                    return false;
                }
            }
            return false;
        }

        private void btn_GetStarted_Click(object sender, EventArgs e)
        {
            this.Hide();
            RSAEncryption rsa = new RSAEncryption();
            rsa.ShowDialog();
            this.Close();

        }

        private void btn_click_passBank(object sender, EventArgs e)
        {
            this.Hide();
            PasswordBankLogin pb = new PasswordBankLogin();
            pb.ShowDialog();
            this.Close();
        }
    }
}
