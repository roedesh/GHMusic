// <copyright file="EvenementBAL.cs" company="RuudIT">
//      Copyright (c) GHMusic. All rights reserved.
// </copyright>
// <author>Ruud Schroën</author>
namespace BAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DAL;

    /// <summary>
    /// Bussiness Access Layer for Evenement
    /// </summary>
    public class EvenementBAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public EvenementBAL()
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
            return new EvenementDAL().Insert(organisationID, locationID, name, date, time, days, website);
        }

        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="eventID">EventID</param>
        /// <returns>int</returns>
        public int Delete(int eventID)
        {
            return new EvenementDAL().Delete(eventID);
        }

        /// <summary>
        /// Load event by ID
        /// </summary>
        /// <param name="eventID">EventID</param>
        /// <returns>A DataTable</returns>
        public DataTable Load(int eventID)
        {
            return new EvenementDAL().Load(eventID);
        }

        /// <summary>
        /// Load all events
        /// </summary>
        /// <returns>A Datatable</returns>
        public DataTable LoadAll()
        {
            return new EvenementDAL().LoadAll();
        }
    }
}
