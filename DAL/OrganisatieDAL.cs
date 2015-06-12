// <copyright file="OrganisatieDAL.cs" company="RuudIT">
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
    /// Data Access Layer for Organisatie
    /// </summary>
    public class OrganisatieDAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public OrganisatieDAL()
        {
        }

        /// <summary>
        /// Create organisation
        /// </summary>
        /// <param name="name">Organisation name</param>
        /// <param name="url">Website URL</param>
        /// <returns>An integer</returns>
        public int Insert(string name, string url)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Organisatie (OrganisatieID, Naam, Website) VALUES (OrganisatieID_SEQ.nextval, :name, :website)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("name", name));
                    cmd.Parameters.Add(new OracleParameter("website", url));
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
        /// Delete organisation
        /// </summary>
        /// <param name="organisationID">OrganisationID</param>
        /// <returns>An integer</returns>
        public int Delete(int organisationID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Organisatie WHERE OrganisatieID = :organisationID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("organisationID", organisationID));
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
        /// Load organisation by ID
        /// </summary>
        /// <param name="organisationID">organisationID</param>
        /// <returns>A DataTable</returns>
        public DataTable Load(int organisationID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Organisatie WHERE OrganisatieID = :organisationID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("organisationID", organisationID));
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
        /// Load all organisations
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable LoadAll()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Organisatie";
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
        /// Method for printing Oracle exceptions
        /// </summary>
        /// <param name="ex">Oracle exception</param>
        /// <returns>Error string</returns>
        public string ErrorString(OracleException ex)
        {
            return "Code: " + ex.ErrorCode + "\n" + "Message: " + ex.Message;
        }
    }
}
