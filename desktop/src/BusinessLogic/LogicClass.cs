using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace BusinessLogic
{
    public class LogicClass
    {
        
        public Boolean EncryptingMethod(string fileloc, string password)
        {
            try
            {
                string encryptPath =  fileloc+"e";

                //string password = @"myKey123"; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                //encrypted empty File creation -------------------------------------------------------
                String cryptFile = encryptPath;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create); //empty File Creation 

                //Encryption Method--------------------------------------------------------------------
                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write); //(The File u want to EnCrypt, Create Encryptor with key, Mode is write) means fscrypt file will be encrypted or written with password

                FileStream fsIn = new FileStream(fileloc, FileMode.Open); //THe main file opening

                int data;
                while ((data = fsIn.ReadByte()) != -1)      //until the main file have byte 
                    cs.WriteByte((byte)data);               //*****Write Every Byte to the the file With CryptoStrem*** 

                fsIn.Close();
                cs.Close();
                fsCrypt.Close();

                File.Delete(fileloc);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
                
            
        }

        public Boolean DecryptingMethod(string enfilePath, string password)
        {
            try
            {

                string filepath = enfilePath.Substring(0, enfilePath.Length-1);
                //string password = @"myKey123"; // Your Key Here


                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(enfilePath, FileMode.Open);  //Opening the Encrypted File For Decrypting

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read); // The method can read the encrypted File with DEcryptor Key

                FileStream fsOut = new FileStream(filepath, FileMode.Create); // Creating The MAin File

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);  

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
                File.Delete(enfilePath);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
