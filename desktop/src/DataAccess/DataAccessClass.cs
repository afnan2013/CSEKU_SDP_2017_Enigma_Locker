using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;

namespace DataAccess
{
    public class DataAccessClass
    {
        public SQLiteConnection myconnection;

        public DataAccessClass()
        {
            myconnection = new SQLiteConnection("Data Source=database.sqlite3");

            if (!File.Exists("./database.sqlite3"))
            {

                SQLiteConnection.CreateFile("database.sqlite3");
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = myconnection;
                    myconnection.Open();

                    SQLiteHelper sh = new SQLiteHelper(cmd);

                    SQLiteTable tb = new SQLiteTable("tbl_login");

                    tb.Columns.Add(new SQLiteColumn("id", true));
                    tb.Columns.Add(new SQLiteColumn("Username"));
                    tb.Columns.Add(new SQLiteColumn("Password"));
                    sh.CreateTable(tb);

                    SQLiteTable tb2 = new SQLiteTable("tbl_pass");

                    tb2.Columns.Add(new SQLiteColumn("id", true));
                    tb2.Columns.Add(new SQLiteColumn("Password"));
                    sh.CreateTable(tb2);

                    SQLiteTable tb3 = new SQLiteTable("tbl_locklist");

                    tb3.Columns.Add(new SQLiteColumn("id", true));
                    tb3.Columns.Add(new SQLiteColumn("FolderLockList"));
                    tb3.Columns.Add(new SQLiteColumn("FileLockList"));
                    tb3.Columns.Add(new SQLiteColumn("HighFolderLockList"));

                    sh.CreateTable(tb3);

                    SQLiteTable tb4 = new SQLiteTable("tbl_passwordBank");

                    tb4.Columns.Add(new SQLiteColumn("id", true));
                    tb4.Columns.Add(new SQLiteColumn("IDName"));
                    tb4.Columns.Add(new SQLiteColumn("password"));
                    tb4.Columns.Add(new SQLiteColumn("type"));
                    tb4.Columns.Add(new SQLiteColumn("Priority"));

                    sh.CreateTable(tb4);

                    myconnection.Close();
                }
                
                
                
            }
            
        }



        public void openConnection()
        {
            if (myconnection.State != ConnectionState.Open)
            {
                myconnection.Open();
            }
        }



        public void closeConnection()
        {
            if (myconnection.State != ConnectionState.Closed)
            {
                myconnection.Close();
            }
        }

        


        public Boolean LoginMethod(string key, string key2)
        {
            //Create SqlConnection
            string query = "SELECT * FROM tbl_login WHERE Username = '" + key + "'and Password ='" + key2 + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            openConnection();
            SQLiteDataReader dbr;
            
            dbr = cmd.ExecuteReader();
            
            int count = 0;
            //int count = ds.Tables[0].Rows.Count;
            //If count is equal to 1, than show frmMain form
            while (dbr.Read())
            {
                count++;
                break;

            }
            closeConnection();
            if (count == 1)
                return true;
            else
                return false;
        }




        public Boolean GetLogin()
        {
            //Create SqlConnection
            string query = "SELECT * FROM tbl_login";

            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);

            openConnection();
            SQLiteDataReader dbr;
            dbr = cmd.ExecuteReader();
            

            int count = 0;
            //int count = ds.Tables[0].Rows.Count;
            //If count is equal to 1, than show frmMain form
            while (dbr.Read())
            {
                count++;
                break;

            }
            closeConnection();
            if (count == 1)
                return true;
            else
                return false;
        }
        



        public Boolean PassKey(string key) //method for Checking the Locking Password as Folder, File, High Security
        {
            //Create SqlConnection
            string query = "Select * from tbl_pass where Password='"+key+"'";
            
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);

            openConnection();
            SQLiteDataReader dbr;
            dbr = cmd.ExecuteReader();
            

            int count = 0;
            //If count is equal to 1, than show frmMain form
            while (dbr.Read())
            {
                count++;
                break;

            }
           
            if (count == 1)
                return true;
            else
                return false;
        }





        public void PasswordInserting(string key)
        {
            string query = "INSERT INTO tbl_pass (Password) VALUES ('" + key + "')";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            cmd.CommandType = CommandType.Text;
            openConnection();
            cmd.ExecuteNonQuery();
           
        }

        public void PasswordDelete(string pass)
        {
            string query = "DELETE FROM tbl_pass WHERE Password='" + pass + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            cmd.CommandType = CommandType.Text;
            openConnection();
            cmd.ExecuteNonQuery();
            closeConnection();
        }





        public void InsertFolderLockList(string key)
        {
            string query = "INSERT INTO tbl_locklist (FolderLockList) VALUES ('" + key+"')";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            cmd.CommandType = CommandType.Text;
            openConnection();
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public void DeleteFolderLockList(string key)
        {
            openConnection();
            string query = "DELETE FROM tbl_locklist WHERE FolderLockList='"+key+"'";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            sda.SelectCommand.ExecuteNonQuery();
            closeConnection();
        }


        public void InsertFileLockList(string key)
        {
            string query = "INSERT INTO tbl_locklist (FileLockList) VALUES ('" + key + "')";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            cmd.CommandType = CommandType.Text;
            openConnection();
            cmd.ExecuteNonQuery();
        }

        public void DeleteFileLockList(string key)
        {
            string path = key.Substring(0, key.Length - 1);
            string query = "DELETE FROM tbl_locklist WHERE FileLockList='" + path + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            cmd.CommandType = CommandType.Text;
            openConnection();
            cmd.ExecuteNonQuery();
            
        }




        public void InsertHighFolder(string key)
        {
            string query = "INSERT INTO tbl_locklist (HighFolderLockList) VALUES ('" + key + "')";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            cmd.CommandType = CommandType.Text;
            openConnection();
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public void DeleteHighFolder(string key)
        {
            string query = "DELETE FROM tbl_locklist WHERE HighFolderLockList='" + key + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            cmd.CommandType = CommandType.Text;
            openConnection();
            cmd.ExecuteNonQuery();
            closeConnection();
        }





        



        public void InsertNewUserId(string username, string password)
        {
            string query = "INSERT INTO tbl_login (Username, Password) VALUES ('" + username + "','" + password + "')";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            cmd.CommandType = CommandType.Text;
            openConnection();
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public void DeleteUserId(string password)
        {
            string query = "DELETE FROM tbl_login WHERE Password='" + password + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            cmd.CommandType = CommandType.Text;
            openConnection();
            cmd.ExecuteNonQuery();
            closeConnection();
        }




        public Boolean UserPassCheck(string key)
        {
            //Create SQLiteConnection
            string query = "Select * from tbl_login where Password='"+key+"'";
            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            openConnection();
            SQLiteDataAdapter adapt = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            closeConnection();
            int count = dt.Rows.Count;
            //If count is equal to 1, than show frmMain form
            if (count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }






        public DataTable DisplayFolderLockList()
        {
            string query = "SELECT FolderLockList FROM tbl_locklist WHERE FolderLockList is not NULL";

            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            openConnection();

            SQLiteDataAdapter adapt = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            return dt;
        }

        public DataTable DisplayFileLockList()
        {
            string query = "SELECT FileLockList FROM tbl_locklist WHERE FileLockList is not NULL";

            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            openConnection();

            SQLiteDataAdapter adapt = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            return dt;
        }

        public DataTable DisplayHighFolderLockList()
        {
            string query = "SELECT HighFolderLockList FROM tbl_locklist WHERE HighFolderLockList is not NULL";

            SQLiteCommand cmd = new SQLiteCommand(query, myconnection);
            openConnection();

            SQLiteDataAdapter adapt = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            return dt;
        }

        
        
        /////Password Bank Insert
        /////Password Bank Delete
        /////Password Bank Display

        public void InsertFileLockPassword(string fileName, string key)
        {
            openConnection();
            string query = "INSERT INTO tbl_passwordBank (IDName,password,type) VALUES('" + fileName + "','" + key + "','File')";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            sda.SelectCommand.ExecuteNonQuery();
            closeConnection();
        }

        public void DeleteFileLockPassword(string fileName)
        {
            string path = fileName.Substring(0, fileName.Length - 1);
            openConnection();
            string query = "DELETE FROM tbl_passwordBank WHERE IDName='" + path + "'";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            sda.SelectCommand.ExecuteNonQuery();
            closeConnection();
        }




        public void InsertHighFolderPassword(string folderName,string key)
        {
            openConnection();
            string query = "INSERT INTO tbl_passwordBank (IDName,password,type) VALUES('" + folderName + "','" + key + "','High Folder')";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            sda.SelectCommand.ExecuteNonQuery();
            closeConnection();
        }


        public void DeleteHighFolderPassword(string folderName)
        {
            openConnection();
            string query = "DELETE FROM tbl_passwordBank WHERE IDName='" + folderName + "'";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            sda.SelectCommand.ExecuteNonQuery();
            closeConnection();
        }


        public void Save_Online_Info(string name, string key, string idtype, string prior)
        {
            openConnection();
            string query = "INSERT INTO tbl_passwordBank (IDName, password, type, Priority) VALUES('" + name + "','" + key + "','" + idtype + "','" + prior + "')";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            sda.SelectCommand.ExecuteNonQuery();
            closeConnection();
        }

        public void Update_User_Info(string pk, string name, string key, string idtype, string prior)
        {
            openConnection();
            string query = "UPDATE tbl_passwordBank SET IDName='" + name + "', password='" + key + "', type='" + idtype + "', Priority='" + prior + "' WHERE id='" + pk + "'";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            sda.SelectCommand.ExecuteNonQuery();
            closeConnection();
        }


        public void Delete_ID_Info(string name)
        {
            openConnection();
            string query = "DELETE FROM tbl_passwordBank WHERE IDName='" + name + "'";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            sda.SelectCommand.ExecuteNonQuery();
            closeConnection();
        }
        
        public DataTable DisplayAllPasswordBank()
        {
            openConnection();
            string query = "SELECT * FROM tbl_passwordBank";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            closeConnection();

            return dt;
        }

        public DataTable DisplayFileLockPasswordBank()
        {
            openConnection();
            string query = "SELECT * FROM tbl_passwordBank WHERE type='File'";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            closeConnection();

            return dt;
        }

        public DataTable DisplayHighFolderLockPasswordBank()
        {
            openConnection();
            string query = "SELECT * FROM tbl_passwordBank WHERE type='High Folder'";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            closeConnection();

            return dt;
        }

        public DataTable DisplayStarInfo()
        {
            openConnection();
            string query = "SELECT * FROM tbl_passwordBank WHERE Priority is not null";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            closeConnection();

            return dt;
        }

        public DataTable DisplayOthersInfo()
        {
            openConnection();
            string query = "SELECT * FROM tbl_passwordBank WHERE Priority is not null";
            SQLiteDataAdapter sda = new SQLiteDataAdapter(query, myconnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            closeConnection();

            return dt;
        }

    }
}
