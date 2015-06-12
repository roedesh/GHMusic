// <copyright file="EvenementDAL.cs" company="RuudIT">
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
    /// Data Access Layer for Evenement
    /// </summary>
    public class EvenementDAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public EvenementDAL()
        {
        }

        /// <summary>
        /// Create a new event
        /// </summary>
        /// <param name="organisationID">OrganisationID</param>
        /// <param name="locationID">LocationID</param>
        /// <param name="name">Event name</param>
        /// <param name="date">Event date</param>
        /// <param name="time">Hours per day</param>
        /// <param name="days">Days</param>
        /// <param name="website">Website URL</param>
        /// <returns>int</returns>
        public int Insert(int organisationID, int locationID, string name, DateTime date, int time, int days, string website)
        {
            Debug.WriteLine(organisationID);
            Debug.WriteLine(locationID);
            Debug.WriteLine(name);
            Debug.WriteLine(date.ToString("dd-MM-yyyy"));
            Debug.WriteLine(time);
            Debug.WriteLine(days);
            Debug.WriteLine(website);
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Evenement VALUES (EvenementID_SEQ.nextval, :organisationID, :locationID, :name, TO_DATE(:datum, 'dd/mm-yyyy'), :time, :days, :website)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("organisationID", organisationID));
                    cmd.Parameters.Add(new OracleParameter("locationID", locationID));
                    cmd.Parameters.Add(new OracleParameter("name", name));
                    cmd.Parameters.Add(new OracleParameter("datum", date.ToString("dd-MM-yyyy")));
                    cmd.Parameters.Add(new OracleParameter("time", time));
                    cmd.Parameters.Add(new OracleParameter("days", days));
                    cmd.Parameters.Add(new OracleParameter("website", website));
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
        /// Delete event
        /// </summary>
        /// <param name="eventID">EventID</param>
        /// <returns>int</returns>
        public int Delete(int eventID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM Evenement WHERE EvenementID = :eventID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("eventID", eventID));
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
        /// Load event by ID
        /// </summary>
        /// <param name="eventID">EventID</param>
        /// <returns>A DataTable</returns>
        public DataTable Load(int eventID)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Evenement WHERE EvenementID = :eventID";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    OracleDataAdapter a = new OracleDataAdapter(cmd);
                    DataTable t = new DataTable();
                    cmd.Parameters.Add(new OracleParameter("eventID", eventID));
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
        /// Load all events
        /// </summary>
        /// <returns>A Datatable</returns>
        public DataTable LoadAll()
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Evenement";
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
