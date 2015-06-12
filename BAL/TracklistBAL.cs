// <copyright file="TracklistBAL.cs" company="RuudIT">
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
    /// Bussiness Access Layer for Tracklist
    /// </summary>
    public class TracklistBAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public TracklistBAL()
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
            return new TracklistDAL().Insert(artistID, eventID, accountID, name, date);
        }

        /// <summary>
        /// Load tracklist by ID
        /// </summary>
        /// <param name="tracklistID">TracklistID</param>
        /// <returns>DataTable</returns>
        public DataTable Load(int tracklistID)
        {
            return new TracklistDAL().Load(tracklistID);
        }

        /// <summary>
        /// Load all tracklists
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable LoadAll()
        {
            return new TracklistDAL().LoadAll();
        }
    }
}
