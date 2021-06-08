using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;

namespace Watch_list
{
    class DBConnection
    {

        
        public static OleDbConnection GetConnection()
        {

            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=D:\Skill_test_Projects\C#_projects\Watch_list\Watch_list\Watch_list.accdb";

            return new OleDbConnection(connStr);
        }

        public static List<GenreList> LoadGenre()
        {
            List<GenreList> genres = new List<GenreList>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM Genre";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    GenreList g = new GenreList(
                        int.Parse(myReader["ID"].ToString()),
                        myReader["Genre"].ToString());
                    genres.Add(g);
                }
                return genres;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<TVList> LoadTV()
        {
            List<TVList> TV = new List<TVList>();

            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM TV";

            OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    TVList TVL = new TVList(
                        myReader["Title"].ToString(),
                        int.Parse(myReader["Episode count"].ToString()),
                        myReader["Average run time"].ToString());
                    TV.Add(TVL);

                }
                return TV;
            }
            catch (Exception ca)
            {
                Console.WriteLine("Exception in DataBaseHandler", ca);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<Multi_Genre_Link> TV_Linked_Genre()
        {
            List<Multi_Genre_Link> Linked = new List<Multi_Genre_Link>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM Genre_TV";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Multi_Genre_Link MGL = new Multi_Genre_Link(
                        int.Parse(myReader["TV_ID"].ToString()),
                        int.Parse(myReader["GID"].ToString()));
                    Linked.Add(MGL);
                }
                return Linked;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<TVList> Genre_Filtered_List(int gid)
        {
            List<TVList> TVF = new List<TVList>();

            OleDbConnection myConnection = GetConnection();

            var Gid = gid;

            string myQuery = "SELECT * FROM TV" +
                " INNER JOIN Genre_TV ON TV.ID = Genre_TV.TV_ID" +
                " WHERE Genre_TV.GID LIKE '" + Gid + "'";

            OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    TVList TVL = new TVList(
                        myReader["Title"].ToString(),
                        int.Parse(myReader["Episode count"].ToString()),
                        myReader["Average run time"].ToString());
                    TVF.Add(TVL);

                }
                return TVF;
            }
            catch (Exception ca)
            {
                System.Windows.Forms.MessageBox.Show("Exception in DataBaseHandler" + ca.ToString());
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void CreateAccount(string userN, string FN, string LN, int age, string email, string pass)
        {



            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO Users(Username, Firstname, Lastname, Age, Email, active, [Password]) VALUES (@UN, @FN, @LN, @Age, @Email, @AC,@pass)";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            myCommand.Parameters.Add("@UN", OleDbType.VarChar).Value = userN;
            myCommand.Parameters.Add("@FN", OleDbType.VarChar).Value = FN;
            myCommand.Parameters.Add("@LN", OleDbType.VarChar).Value = LN;
            myCommand.Parameters.Add("@Age", OleDbType.VarChar).Value = age;
            myCommand.Parameters.Add("@Email", OleDbType.VarChar).Value = email;
            myCommand.Parameters.Add("@AC", OleDbType.VarChar).Value = "NO";
            myCommand.Parameters.Add("@pass", OleDbType.VarChar).Value = pass;

            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception EC)
            {
                Console.WriteLine("Exception in DBHandler", EC);
            }
            finally
            {
                myConnection.Close();
            }


        }

        public static void verification(int UID, string code, DateTime cd)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO Verification(UID,Verification_code,Code_date) VALUES (@UID,@code,@cd)";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@UID", OleDbType.VarChar).Value = UID;
            myCommand.Parameters.Add("@code", OleDbType.VarChar).Value = code;
            myCommand.Parameters.Add("@cd", OleDbType.DBDate).Value = cd;
            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception EC)
            {
                Console.WriteLine("Exception in DBHandler", EC);
            }
            finally
            {
                myConnection.Close();
            }


        }

        public static void verification_cleanup()
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "DELETE FROM Verification WHERE Code_date <= Now -5";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();

            }
            catch (Exception EC)
            {
                Console.WriteLine("Exception in DBHandler", EC);
            }
        }

        public static bool Login_email_check(string UN, string Pass)
        {
            string UNUP = UN.ToUpper();
            List<Users> user = new List<Users>();
            OleDbConnection myConnection = GetConnection();
            try
            {

                string myQuery = "SELECT * FROM Users WHERE UCASE(Username) ='" + UNUP + "' AND [Password] = '" + Pass + "'";
                OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    Users URS = new Users(
                        int.Parse(myReader["ID"].ToString()),
                        myReader["Username"].ToString(),
                        myReader["Firstname"].ToString(),
                        myReader["active"].ToString(),
                        myReader["Email"].ToString());
                    user.Add(URS);
                }

                //string check = user.First(s => s.userN == UNUP).userN;
                //if (check != "")
                //{
                    return true;
               // }
                //else
                //{
                //    return false;
//}



            }
            catch (Exception ca)
            {

                System.Windows.Forms.MessageBox.Show("Exception in DataBaseHandler" + ca.ToString());
                return false;


            }
            finally
            {
                myConnection.Close();
            }
        }
        public static List<Users> getUSER(string un, string pass)
        {

            string UNUP = un.ToUpper();
            List<Users> user = new List<Users>();
            OleDbConnection myConnection = GetConnection();
            try
            {

                string myQuery = "SELECT * FROM Users WHERE UCASE(Username) ='" + UNUP + "' AND [Password] = '" + pass + "'";
                OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    Users URS = new Users(
                        int.Parse(myReader["ID"].ToString()),
                        myReader["Username"].ToString(),
                        myReader["Firstname"].ToString(),
                        myReader["active"].ToString(),
                        myReader["Email"].ToString());
                    user.Add(URS);
                }

              
                    return user;
                
                



            }
            catch (Exception ca)
            {

                System.Windows.Forms.MessageBox.Show("Exception in DataBaseHandler" + ca.ToString());
                return null;


            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<TVDetailsPull> Movie_Details(string show)
        {
            List<TVDetailsPull> TVF = new List<TVDetailsPull>();

            OleDbConnection myConnection = GetConnection();



            string myQuery = "SELECT * FROM TV WHERE Title = '" + show + "'";

            OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    TVDetailsPull TVL = new TVDetailsPull(
                        int.Parse(myReader["ID"].ToString()),
                        myReader["Title"].ToString(),
                        myReader["Description"].ToString(),
                        int.Parse(myReader["Episode count"].ToString()),
                        myReader["Average run time"].ToString(),
                        int.Parse(myReader["TypeID"].ToString()),
                        int.Parse(myReader["RatingID"].ToString()));
                    TVF.Add(TVL);

                }
                return TVF;
            }
            catch (Exception ca)
            {
                System.Windows.Forms.MessageBox.Show("Exception in DataBaseHandler" + ca.ToString());
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<GenreList> MovieDetails_G(int SID)
        {
            List<GenreList> genres = new List<GenreList>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM Genre " +
                "INNER JOIN Genre_TV as GTV ON GTV.GID = Genre.ID WHERE GTV.TV_ID LIKE " + SID + "";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    GenreList g = new GenreList(
                        int.Parse(myReader["Genre.ID"].ToString()),
                        myReader["Genre"].ToString());
                    genres.Add(g);
                }
                return genres;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<WatchStatus> watchstat(int SID)
        {
            List<WatchStatus> WS = new List<WatchStatus>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM List_watch as LW " +
                "INNER JOIN Viewtype as VT ON VT.ID = LW.Watched_ID WHERE LW.ShowID LIKE " + SID;
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    WatchStatus WLS = new WatchStatus(
                        int.Parse(myReader["UserID"].ToString()),
                        int.Parse(myReader["ShowID"].ToString()),
                        myReader["view_type"].ToString());
                    WS.Add(WLS);
                }
                return WS;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }


        }
        public static List<WSList> WSL()
        {
            List<WSList> WSL = new List<WSList>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM Viewtype";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    WSList WLS = new WSList(
                        
                        int.Parse(myReader["ID"].ToString()),
                        myReader["view_type"].ToString());
                    WSL.Add(WLS);
                }
                return WSL;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }


        }
        public static bool  watchstatbool(int SID)
        {
            List<WatchStatus> WS = new List<WatchStatus>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM List_watch as LW " +
                "INNER JOIN Viewtype as VT ON VT.ID = LW.Watched_ID WHERE LW.ShowID =" + SID + " AND UserID = " + Common.uID;
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    WatchStatus WLS = new WatchStatus(
                        int.Parse(myReader["UserID"].ToString()),
                        int.Parse(myReader["ShowID"].ToString()),
                        myReader["view_type"].ToString());
                    WS.Add(WLS);
                }
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Exception in DBHandler", ex);
                return false;
            }
            finally
            {
                myConnection.Close();
            }


        }
        public static bool verify(int ID, string ver)
        {
            List<VerificationList> verify = new List<VerificationList>();
            OleDbConnection myConnection = GetConnection();
            try
            {

                string myQuery = "SELECT * FROM Verification WHERE UID LIKE '" + ID + "' AND Verification_code = '" + ver + "'";
                OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    VerificationList V = new VerificationList(
                        int.Parse(myReader["UID"].ToString()),
                        myReader["Verification_code"].ToString());
                    verify.Add(V);
                }
                int ID_Check = 0;
                ID_Check = verify.Find(i => i.UserID == ID).UserID;
                if (ID_Check > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ca)
            {

                System.Windows.Forms.MessageBox.Show("Exception in DataBaseHandler" + ca.ToString());
                return false;


            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void Verification_confirm(int UID)
        {
            OleDbConnection myConnection = GetConnection();

            string myQuery = "DELTE FROM Verification WHERE UID LIKE " + UID + " ";
            string myQuery2 = "UPDATE Users SET active = @yes WHERE ID = " + UID + " ";
            OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);
            OleDbCommand mycommand2 = new OleDbCommand(myQuery2, myConnection);
            mycommand2.Parameters.Add("@yes", OleDbType.VarChar).Value = "YES";

            try
            {
                myConnection.Open();

                mycommand.ExecuteNonQuery();

            }
            catch (Exception EC)
            {
                Console.WriteLine("Exception in DBHandler", EC);
            }

            try
            {
                if (mycommand2.ExecuteNonQuery() == 0)
                {
                    Console.WriteLine("User not found not found!!");
                }
            }
            catch (Exception EC)
            {
                Console.WriteLine(EC);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static bool Active_Account_check(string UN, string Pass)
        {
            /*
            This section of code is responsable for checking if a users account is activated or not by using the users username and password to pull the 
            users account details to find if the account reads as active 
             */
            string UNUP = UN.ToUpper();
            List<Users> user = new List<Users>();
            OleDbConnection myConnection = GetConnection();
            try
            {

                string myQuery = "SELECT * FROM Users WHERE UCASE(Username) ='" + UNUP + "' AND [Password] = '" + Pass + "'";
                OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    Users URS = new Users(
                        int.Parse(myReader["ID"].ToString()),
                        myReader["Username"].ToString(),
                        myReader["Firstname"].ToString(),
                        myReader["active"].ToString(),
                        myReader["Email"].ToString());
                        
                    user.Add(URS);
                }

                string active = user.Find(i => i.userN.ToUpper() == UN.ToUpper()).Active;

                if (active.ToUpper() == "NO".ToUpper())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ca)
            {

                //System.Windows.Forms.MessageBox.Show("Exception in DataBaseHandler" + ca.ToString());
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }


        public static bool verify_code_check(int ID)
        {

            /*
             This section of the code is responsable for checking if an acount has a verification code already to be used by checking the users ID to see if any
            verification code is assigned to it returening true if there is one visable or if no code is found false is returned.
             */


            List<VerificationList> verify = new List<VerificationList>();
            OleDbConnection myConnection = GetConnection();
            try
            {

                string myQuery = "SELECT * FROM Verification WHERE UID LIKE '" + ID +"'";
                OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    VerificationList V = new VerificationList(
                        int.Parse(myReader["UID"].ToString()),
                        myReader["Verification_code"].ToString());
                    verify.Add(V);
                }
                int ID_Check = 0;
                ID_Check = verify.Find(i => i.UserID == ID).UserID;
                if (ID_Check > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ca)
            {

               // System.Windows.Forms.MessageBox.Show("Exception in DataBaseHandler" + ca.ToString());
                return false;


            }
            finally
            {
                myConnection.Close();
            }
        }


        public static List<TVList> type_Filtered_List(int Tid)
        {
            List<TVList> TVF = new List<TVList>();

            OleDbConnection myConnection = GetConnection();

            var tid = Tid;

            string myQuery = "SELECT * FROM TV" +
                " INNER JOIN Show_type ON TV.TypeID = Show_type.ID" +
                " WHERE TV.TypeID LIKE '" + tid + "'";

            OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    TVList TVL = new TVList(
                        myReader["Title"].ToString(),
                        int.Parse(myReader["Episode count"].ToString()),
                        myReader["Average run time"].ToString());
                    TVF.Add(TVL);

                }
                return TVF;
            }
            catch (Exception ca)
            {
                System.Windows.Forms.MessageBox.Show("Exception in DataBaseHandler" + ca.ToString());
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }
        public static List<TVList> type_Genre_Filtered_List(int gid,int tid)
        {
            List<TVList> TVF = new List<TVList>();

            OleDbConnection myConnection = GetConnection();

            var Gid = gid;

            string myQuery = "SELECT * FROM TV" +
                " INNER JOIN Genre_TV ON TV.ID = Genre_TV.TV_ID" +
                " INNER JOIN Show_type ON TV.TypeID = Show_type.ID" +
                "WHERE Genre_TV.GID LIKE '" + Gid + "' & " +
                "WHERE TV.TypeID LIKE '" + tid + "' ";

            OleDbCommand mycommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();

                OleDbDataReader myReader = mycommand.ExecuteReader();

                while (myReader.Read())
                {
                    TVList TVL = new TVList(
                        myReader["Title"].ToString(),
                        int.Parse(myReader["Episode count"].ToString()),
                        myReader["Average run time"].ToString());
                    TVF.Add(TVL);

                }
                return TVF;
            }
            catch (Exception ca)
            {
                System.Windows.Forms.MessageBox.Show("Exception in DataBaseHandler" + ca.ToString());
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static List<ShowType> LoadType()
        {
            List<ShowType> SType = new List<ShowType>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM Show_type";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    ShowType ST = new ShowType(
                        int.Parse(myReader["ID"].ToString()),
                        myReader["Show type"].ToString());
                    SType.Add(ST);
                }
                return SType;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

    }
}

