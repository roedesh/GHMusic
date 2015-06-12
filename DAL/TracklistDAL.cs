// <copyright file="TracklistDAL.cs" company="RuudIT">
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
    /// Data Access Layer for Tracklist
    /// </summary>
    public class TracklistDAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public TracklistDAL()
        {
        }

        /// <summary>
        /// Create tracklist
        /// </summary>
        /// <param name="artistID">ArtistID</param>
        /// <param name="eventID">EventID</param>
        /// <param name="accountID">AccountID</param>
        /// <param name="name">Name</param>
        /// <param name="date">Date</param>
        /// <returns>int</returns>
        public int Insert(int artistID, int eventID, int accountID, string name, DateTime date)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Tracklist (TracklistID, ArtiestID, EvenementID, AccountID, Naam, Datum) VALUES (TracklistID_SEQ.nextval, :artistID, :eventID, :accountID, :name, TO_DATE(:datum, 'dd/mm-yyyy'))";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("artistID", artistID));
                    cmd.Parameters.Add(new OracleParameter("eventID", eventID));
                    cmd.Parameters.Add(new OracleParameter("accountID", accountID));
                    cmd.Parameters.Add(new OracleParameter("name", name));
                    cmd.Parameters.Add(new OracleParameter("datum", date.ToString("dd-MM-yyyy")));
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
        /// Load tracklist by ID
        /// </summary>
        /// <param name="tracklistID">TracklistID</param>
        /// <returns>DataTable</returns>
        public DataTable Load(int tracklistID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tracklist WHERE TracklistID = :tracklistID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("tracklistID", tracklistID));
                    try
                    {
                        a.Fill(t);
                        return t;
                    }
                    catch (OracleException ex)
                    {
                        Debug.WriteLine(this.ErrorString(ex));
                        return t;
                    }
                }
            }
        }

        /// <summary>
        /// Load all tracklists
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable LoadAll()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tracklist";
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
