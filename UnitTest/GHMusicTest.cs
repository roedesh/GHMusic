using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GHMusic;
using Oracle.DataAccess.Client;
using BAL;
using DAL;

namespace UnitTest
{
    [TestClass]
    public class GHMusicTest
    {
        [TestMethod]
        public void CreateAccount()
        {
            // arrange
            int rankID = 1;
            string username = "ruudje";
            string password = "ww";
            int age = 21;
            string interests = "Mijn interesses";
            string signature = "Mijn handtekening";
            // act
            int actual = this.CreateAccount(rankID, username, password, age, interests, signature);

            // assert
            Assert.AreEqual<int>(1, actual);
        }
        public int CreateAccount(int rankID, string username, string password, int age, string interests, string signature)
        {
            using (OracleConnection conn = new OracleConnection("DATA SOURCE=192.168.15.50:1521/fhictora;USER ID=dbi288322;Password=ATh2UZf41A;"))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Account (AccountID, RangID, Gebruikersnaam, Wachtwoord, Leeftijd, Interesses, Handtekening) 
                VALUES (AccountID_SEQ.nextval, :rankID, :username, :password, :age, :interests, :signature)";
                using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("rankID", rankID));
                    cmd.Parameters.Add(new OracleParameter("username", username));
                    cmd.Parameters.Add(new OracleParameter("password", password));
                    cmd.Parameters.Add(new OracleParameter("age", age));
                    cmd.Parameters.Add(new OracleParameter("interests", interests));
                    cmd.Parameters.Add(new OracleParameter("signature", signature));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
                        return 0;
                    }
                }
            }
        }
    }
}
