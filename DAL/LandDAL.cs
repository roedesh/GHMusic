// <copyright file="LandDAL.cs" company="RuudIT">
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
    /// Data Access Layer for Land
    /// </summary>
    public class LandDAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public LandDAL()
        {
        }

        /// <summary>
        /// Create country
        /// </summary>
        /// <param name="name">Country name</param>
        /// <param name="landcode">Country code</param>
        /// <returns>int</returns>
        public int Insert(string name, string landcode)
        {
            using (OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO Land (LandID, Naam, Landcode) VALUES (LandID_SEQ.nextval, :name, :landcode)";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("name", name));
                    cmd.Parameters.Add(new OracleParameter("landcode", landcode));
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
