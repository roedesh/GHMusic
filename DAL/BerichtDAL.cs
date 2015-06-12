// <copyright file="BerichtDAL.cs" company="RuudIT">
//      Copyright (c) GHMusic. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess.Client;

    /// <summary>
    /// Data Access Layer for Bericht 
    /// </summary>
    public class BerichtDAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public BerichtDAL()
        {
        }

        /// <summary>
        /// Create a post
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <param name="accountID">AccountID</param>
        /// <param name="body">The content of the post</param>
        /// <returns>An integer</returns>
        public int Insert(int topicID, int accountID, string body)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Bericht (BerichtID, TopicID, AccountID, Tekst) VALUES (Bericht_SEQ.nextval, :topicID, :accountID, :body)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("topicID", topicID));
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    cmd.Parameters.Add(new OracleParameter("body", body));
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

        /// <summary>
        /// Update a post
        /// </summary>
        /// <param name="postID">Post to be updated</param>
        /// <param name="forumID">TopicID</param>
        /// <param name="accountID">AccountID</param>
        /// <param name="body">The content of the post</param>
        /// <returns>An integer</returns>
        public int Update(int postID, int forumID, int accountID, string body)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Bericht SET TopicID = :topicID, Tekst = :body WHERE BerichtID = :postID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("postID", postID));
                    cmd.Parameters.Add(new OracleParameter("forumID", forumID));
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    cmd.Parameters.Add(new OracleParameter("body", body));
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

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="postID">PostID</param>
        /// <returns>An integer</returns>
        public int Delete(int postID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Bericht WHERE BerichtID = :postID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("postID", postID));
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

        /// <summary>
        /// Load post by ID
        /// </summary>
        /// <param name="postID">PostID</param>
        /// <returns>A DataTable</returns>
        public DataTable Load(int postID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Bericht WHERE BerichtID = :postID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("postID", postID));
                    try
                    {
                        a.Fill(t);
                        return t;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
                        return t;
                    }
                }
            }
        }

        /// <summary>
        /// Load all posts
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable LoadAll()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Bericht";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    try
                    {
                        a.Fill(t);
                        return t;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
                        return t;
                    }
                }
            }
        }

        /// <summary>
        /// Load posts from topic
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <returns>A DataTable</returns>
        public DataTable LoadFromTopic(int topicID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Bericht WHERE TopicID = :topicID ORDER BY BerichtID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("topicID", topicID));
                    try
                    {
                        a.Fill(t);
                        return t;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
                        return t;
                    }
                }
            }
        }

        /// <summary>
        /// Load posts from account
        /// </summary>
        /// <param name="accountID">AccountID</param>
        /// <returns>A DataTable</returns>
        public DataTable LoadFromAccount(int accountID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Bericht WHERE AccountID = :accountID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    try
                    {
                        a.Fill(t);
                        return t;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message.ToString());
                        return t;
                    }
                }
            }
        }

        /// <summary>
        /// Method for printing Oracle errors
        /// </summary>
        /// <param name="ex">Oracle exception</param>
        /// <returns>Error string</returns>
        public string ErrorString(OracleException ex)
        {
            return "Code: " + ex.ErrorCode + "\n" + "Message: " + ex.Message;
        }
    }
}
