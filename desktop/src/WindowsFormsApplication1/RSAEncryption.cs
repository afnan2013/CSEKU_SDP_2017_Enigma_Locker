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
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class RSAEncryption : Form
    {
        public RSAEncryption()
        {
            InitializeComponent();
        }


        CspParameters cspp = new CspParameters();
        RSACryptoServiceProvider Rsa;

        const string keyName = "afnan afnan";

        private void RSAEncryption_Load(object sender, EventArgs e)
        {

        }

        private void btn_importPublicKey_click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open Public Key File";
            open.Filter = "Public Key Document( *.pke )|*.pke|All files(*.*)|*.*";
            open.FileName = "";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(open.FileName);
                    cspp.KeyContainerName = keyName;
                    Rsa = new RSACryptoServiceProvider(cspp);
                    string keytxt = sr.ReadToEnd();
                    //txt_publicKey.Text = keytxt;
                    Rsa.FromXmlString(keytxt);
                    Rsa.PersistKeyInCsp = true;
                    if (Rsa.PublicOnly == true)
                        label1.Text = "Key: " + cspp.KeyContainerName + " - Public Only";
                    else
                        label1.Text = "Key: " + cspp.KeyContainerName + " - Full Key Pair";
                    sr.Close();

                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }

        private void btn_EncryptFile_click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Browse";
            open.Filter = "All Files (*.*)|*.*|Text File (*.txt)|*.txt|JPEG File (*.jpg)|*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string filename = open.FileName;
                if (filename != null)
                {
                    if (Rsa == null)
                        MessageBox.Show("Looks like You havenot import a PUBLIC KEY file...", "Import Error", MessageBoxButtons.OK);
                    else
                        EncryptFile(filename);
                }
            }
        }




        private void EncryptFile(string inFile)
        {

            // Create instance of Rijndael for
            // symetric encryption of the data.
            RijndaelManaged rjndl = new RijndaelManaged();
            rjndl.KeySize = 256;
            rjndl.BlockSize = 256;
            rjndl.Mode = CipherMode.CBC;
            ICryptoTransform transform = rjndl.CreateEncryptor();

            // Use RSACryptoServiceProvider to
            // enrypt the Rijndael key.
            // rsa is previously instantiated: 
            //    rsa = new RSACryptoServiceProvider(cspp);
            byte[] keyEncrypted = Rsa.Encrypt(rjndl.Key, false);

            // Create byte arrays to contain
            // the length values of the key and IV.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            int lKey = keyEncrypted.Length;
            LenK = BitConverter.GetBytes(lKey);
            int lIV = rjndl.IV.Length;
            LenIV = BitConverter.GetBytes(lIV);

            // Write the following to the FileStream
            // for the encrypted file (outFs):
            // - length of the key
            // - length of the IV
            // - ecrypted key
            // - the IV
            // - the encrypted cipher content

            //int startFileName = inFile.LastIndexOf("\\") + 1;
            // Change the file's extension to ".enc"
            string outFile = inFile + ".enc";

            using (FileStream outFs = new FileStream(outFile, FileMode.Create))
            {

                outFs.Write(LenK, 0, 4);
                outFs.Write(LenIV, 0, 4);
                outFs.Write(keyEncrypted, 0, lKey);
                outFs.Write(rjndl.IV, 0, lIV);

                // Now write the cipher text using
                // a CryptoStream for encrypting.
                using (CryptoStream outStreamEncrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                {
                    using (FileStream inFs = new FileStream(inFile, FileMode.Open))
                    {
                        int data;
                        while ((data = inFs.ReadByte()) != -1)      //until the main file have byte 
                            outStreamEncrypted.WriteByte((byte)data);               //*****Write Every Byte to the the file With CryptoStrem*** 
                    }

                    outStreamEncrypted.Close();
                    File.Delete(inFile);
                }
                outFs.Close();
            }

        }

        private void btn_DecryptFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Browse";
            open.Filter = "All Files (*.*)|*.*|Text File (*.txt)|*.txt|JPEG File (*.jpg)|*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string filename = open.FileName;
                if (filename != null)
                {
                    if (Rsa == null)
                        MessageBox.Show("Looks like You havenot import a PRIVATE KEY file...", "Import Error", MessageBoxButtons.OK);
                    else
                        DecryptFile(filename);
                }
            }
        }


        private void DecryptFile(string inFile)
        {

            // Create instance of Rijndael for
            // symetric decryption of the data.
            RijndaelManaged rjndl = new RijndaelManaged();
            rjndl.KeySize = 256;
            rjndl.BlockSize = 256;
            rjndl.Mode = CipherMode.CBC;

            // Create byte arrays to get the length of
            // the encrypted key and IV.
            // These values were stored as 4 bytes each
            // at the beginning of the encrypted package.
            byte[] LenK = new byte[4];
            byte[] LenIV = new byte[4];

            // Consruct the file name for the decrypted file.
            string outFile = inFile.Substring(0, inFile.Length - 4);

            // Use FileStream objects to read the encrypted
            // file (inFs) and save the decrypted file (outFs).
            using (FileStream inFs = new FileStream(inFile, FileMode.Open))
            {

                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Seek(0, SeekOrigin.Begin);
                inFs.Read(LenK, 0, 3);
                inFs.Seek(4, SeekOrigin.Begin);
                inFs.Read(LenIV, 0, 3);

                // Convert the lengths to integer values.
                int lenK = BitConverter.ToInt32(LenK, 0);
                int lenIV = BitConverter.ToInt32(LenIV, 0);

                // Determine the start postition of
                // the ciphter text (startC)
                // and its length(lenC).
                int startC = lenK + lenIV + 8;
                int lenC = (int)inFs.Length - startC;

                // Create the byte arrays for
                // the encrypted Rijndael key,
                // the IV, and the cipher text.
                byte[] KeyEncrypted = new byte[lenK];
                byte[] IV = new byte[lenIV];

                // Extract the key and IV
                // starting from index 8
                // after the length values.
                inFs.Seek(8, SeekOrigin.Begin);
                inFs.Read(KeyEncrypted, 0, lenK);
                inFs.Seek(8 + lenK, SeekOrigin.Begin);
                inFs.Read(IV, 0, lenIV);

                // Use RSACryptoServiceProvider
                // to decrypt the Rijndael key.
                byte[] KeyDecrypted = Rsa.Decrypt(KeyEncrypted, false);

                // Decrypt the key.
                ICryptoTransform transform = rjndl.CreateDecryptor(KeyDecrypted, IV);

                // Decrypt the cipher text from
                // from the FileSteam of the encrypted
                // file (inFs) into the FileStream
                // for the decrypted file (outFs).
                using (FileStream outFs = new FileStream(outFile, FileMode.Create))
                {


                    inFs.Seek(startC, SeekOrigin.Begin);
                    using (CryptoStream outStreamDecrypted = new CryptoStream(outFs, transform, CryptoStreamMode.Write))
                    {
                        int data;
                        while ((data = inFs.ReadByte()) != -1)
                            outStreamDecrypted.WriteByte((byte)data);

                        outStreamDecrypted.Close();
                    }
                    outFs.Close();

                }
                inFs.Close();
                File.Delete(inFile);
            }

        }


        private void btn_importPrivateKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open Private Key File";
            open.Filter = "Private Key Document( *.kez )|*.kez|All files(*.*)|*.*";
            open.FileName = "";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(open.FileName);
                    cspp.KeyContainerName = keyName;
                    Rsa = new RSACryptoServiceProvider(cspp);
                    string keytxt = sr.ReadToEnd();
                    //txt_privateKey.Text = keytxt;
                    Rsa.FromXmlString(keytxt);
                    Rsa.PersistKeyInCsp = true;
                    if (Rsa.PublicOnly == true)
                        label1.Text = "Key: " + cspp.KeyContainerName + " - Public Only";
                    else
                        label1.Text = "Key: " + cspp.KeyContainerName + " - Full Key Pair";
                    sr.Close();

                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.ShowDialog();
            this.Close();
        }

        
    }
}
