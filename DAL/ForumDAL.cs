// <copyright file="ForumDAL.cs" company="RuudIT">
//      Copyright (c) GHMusic. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess.Client;

    /// <summary>
    /// Data Access Layer for Forum
    /// </summary>
    public class ForumDAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public ForumDAL()
        {
        }

        /// <summary>
        /// Create forum
        /// </summary>
        /// <param name="parentForumID">ID of parent forum</param>
        /// <param name="forumName">Forumname</param>
        /// <returns>int</returns>
        public int Insert(int parentForumID, string forumName)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Forum (ForumID, ParentForumID, Naam) VALUES (ForumID_SEQ.nextval, :parentForumID, :forumName)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    if (parentForumID == 0)
                    {
                        cmd.Parameters.Add(new OracleParameter("parentForumID", System.DBNull.Value));
                    }
                    else
                    {
                        cmd.Parameters.Add(new OracleParameter("parentForumID", parentForumID));
                    }

                    cmd.Parameters.Add(new OracleParameter("forumName", forumName));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Update forum
        /// </summary>
        /// <param name="forumID">Forum to be updated</param>
        /// <param name="parentForumID">ID of parent forum</param>
        /// <param name="forumName">Forumname</param>
        /// <returns>int</returns>
        public int Update(int forumID, int parentForumID, string forumName)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                Debug.WriteLine(forumID);
                Debug.WriteLine(parentForumID);
                Debug.WriteLine(forumName);
                conn.Open();
                string query = "UPDATE Forum SET Naam = :forumName WHERE ForumID = :forumID";
                if (parentForumID > 0)
                {
                    Debug.WriteLine("No parent");
                    query = "UPDATE Forum SET ParentForumID = :parentForumID, Naam = :forumName WHERE ForumID = :forumID";
                }
                
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    if (parentForumID > 0)
                    {
                        cmd.Parameters.Add(new OracleParameter("parentForumID", Convert.ToInt32(parentForumID)));
                    }

                    cmd.Parameters.Add(new OracleParameter("forumName", forumName.ToString()));
                    cmd.Parameters.Add(new OracleParameter("forumID", Convert.ToInt32(forumID)));
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (OracleException ex)
                    {
                        Debug.WriteLine(this.ErrorString(ex));
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// Delete forum
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>int</returns>
        public int Delete(int forumID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Forum WHERE ForumID = :forumID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("forumID", forumID));
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
        /// Load forum by ID
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>DataTable</returns>
        public DataTable Load(int forumID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Forum WHERE ForumID = :forumID";
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
        /// Load forums
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LoadAll()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Forum";
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
        /// Load child forums from forum
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>DataTable</returns>
        public DataTable LoadChildsFromForum(int forumID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Forum WHERE ParentForumID = :forumID";
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
        /// Check if forum exists
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>int</returns>
        public int Exists(int forumID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string checkUser = "SELECT COUNT(*) FROM dual WHERE EXISTS(SELECT ForumID FROM Forum WHERE ForumID = :forumID)";
                using (OracleCommand cmd = new OracleCommand(checkUser, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("forumID", forumID));
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
