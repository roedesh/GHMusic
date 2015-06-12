// <copyright file="TopicDAL.cs" company="RuudIT">
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
    using Oracle.DataAccess.Types;

    /// <summary>
    /// Data Access Layer for Topic
    /// </summary>
    public class TopicDAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public TopicDAL()
        {
        }

        /// <summary>
        /// Create topic
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <param name="accountID">AccountID</param>
        /// <param name="topicTitle">Title of topic</param>
        /// <returns>An integer</returns>
        public int Insert(int forumID, int accountID, string topicTitle)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Topic (TopicID, ForumID, AccountID, Titel) VALUES (TopicID_SEQ.nextval, :forumID, :accountID, :topicTitle) RETURNING TopicID INTO :newID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("forumID", forumID));
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    cmd.Parameters.Add(new OracleParameter("topicTitle", topicTitle));
                    OracleParameter p1 = new OracleParameter("newID", OracleDbType.Int32);
                    p1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(p1);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return Convert.ToInt32(p1.Value.ToString());
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
        /// Create Topic 
        /// </summary>
        /// <param name="topicID">Topic to be edited</param>
        /// <param name="forumID">ForumID</param>
        /// <param name="accountID">AccountID</param>
        /// <param name="topicTitle">Title of topic</param>
        /// <returns>An integer</returns>
        public int Update(int topicID, int forumID, int accountID, string topicTitle)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "UPDATE Topic SET ForumID = :forumID, Titel = :topicTitle WHERE TopicID = :topicID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("topicID", topicID));
                    cmd.Parameters.Add(new OracleParameter("forumID", forumID));
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    cmd.Parameters.Add(new OracleParameter("topicTitle", topicTitle));
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
        /// Delete topic
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <returns>an integer</returns>
        public int Delete(int topicID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Topic WHERE TopicID = :topicID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("topicID", topicID));
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
        /// Load topic by ID
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <returns>A DataTable</returns>
        public DataTable Load(int topicID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Topic WHERE TopicID = :topicID";
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
        /// Load all topics
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable LoadAll()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Topic";
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
        /// Load topics from forum
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>A DataTable</returns>
        public DataTable LoadFromForum(int forumID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Topic WHERE ForumID = :forumID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("forumID", forumID));
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
        /// Load topics from account
        /// </summary>
        /// <param name="accountID">AccountID</param>
        /// <returns>A DataTable</returns>
        public DataTable LoadFromAccount(int accountID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Topic WHERE AccountID = :accountID";
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
        /// Check if topic exists
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <returns>An integer</returns>
        public int Exists(int topicID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string checkUser = "SELECT COUNT(*) FROM dual WHERE EXISTS(SELECT TopicID FROM Topic WHERE TopicID = :topicID)";
                using (OracleCommand cmd = new OracleCommand(checkUser, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("topicID", topicID));
                    try
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine(this.ErrorString(ex));
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Load all tracklists
        /// </summary>
        /// <returns>A DataTable</returns>
        public string ErrorString(OracleException ex)
        {
            return "Code: " + ex.ErrorCode + "\n" + "Message: " + ex.Message;
        }
    }
}
