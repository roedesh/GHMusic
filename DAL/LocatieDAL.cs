// <copyright file="LocatieDAL.cs" company="RuudIT">
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
    /// Data Access Layer for Locatie
    /// </summary>
    public class LocatieDAL
    {
        /// <summary>
        /// Bussiness Access Layer for Locatie
        /// </summary>
        public LocatieDAL()
        {
        }

        /// <summary>
        /// Create location
        /// </summary>
        /// <param name="landID">Country ID</param>
        /// <param name="name">Name of location</param>
        /// <returns>A Datatable</returns>
        public int Insert(int countryID, string name)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Locatie (LocatieID, LandID, Naam) VALUES (LocatieID_SEQ.nextval, :countryID, :name)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("countryID", countryID));
                    cmd.Parameters.Add(new OracleParameter("name", name));
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
