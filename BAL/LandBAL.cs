// <copyright file="LandBAL.cs" company="RuudIT">
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
    /// Bussiness Access Layer for Land
    /// </summary>
    public class LandBAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public LandBAL()
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
            return new LandDAL().Insert(name, landcode);
        }
    }
}
