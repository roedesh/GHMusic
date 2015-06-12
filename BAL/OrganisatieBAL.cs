// <copyright file="OrganisatieBAL.cs" company="RuudIT">
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
    /// Bussiness Access Layer for Organisatie
    /// </summary>
    public class OrganisatieBAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public OrganisatieBAL()
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
            return new OrganisatieDAL().Insert(name, url);
        }

        /// <summary>
        /// Delete organisation
        /// </summary>
        /// <param name="organisationID">OrganisationID</param>
        /// <returns>An integer</returns>
        public int Delete(int organisationID)
        {
            return new OrganisatieDAL().Delete(organisationID);
        }

        /// <summary>
        /// Load organisation by ID
        /// </summary>
        /// <param name="organisationID">organisationID</param>
        /// <returns>A DataTable</returns>
        public DataTable Load(int organisationID)
        {
            return new OrganisatieDAL().Load(organisationID);
        }

        /// <summary>
        /// Load all organisations
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable LoadAll()
        {
            return new OrganisatieDAL().LoadAll();
        }
    }
}
