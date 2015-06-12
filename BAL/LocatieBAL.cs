// <copyright file="LocatieBAL.cs" company="RuudIT">
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
    /// Bussiness Access Layer for Locatie
    /// </summary>
    public class LocatieBAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public LocatieBAL()
        {
        }

        /// <summary>
        /// Create location
        /// </summary>
        /// <param name="landID">Country ID</param>
        /// <param name="name">Name of location</param>
        /// <returns>A Datatable</returns>
        public int Insert(int landID, string name)
        {
            return new LocatieDAL().Insert(landID, name);
        }
    }
}
