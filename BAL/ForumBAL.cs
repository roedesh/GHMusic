// <copyright file="ForumBAL.cs" company="RuudIT">
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
    /// Bussiness Access Layer for Forum
    /// </summary>
    public class ForumBAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public ForumBAL()
        {
        }

        /// <summary>
        /// Create forum
        /// </summary>
        /// <param name="parentForumID">ID of parent forum</param>
        /// <param name="forumName">Forumname</param>
        /// <returns>int</returns>
        public int Insert(int parentForumID, string forumName)
        {
            return new ForumDAL().Insert(parentForumID, forumName);
        }

        /// <summary>
        /// Update forum
        /// </summary>
        /// <param name="forumID">Forum to be updated</param>
        /// <param name="parentForumID">ID of parent forum</param>
        /// <param name="forumName">Forumname</param>
        /// <returns>int</returns>
        public int Update(int forumID, int parentForumID, string forumName)
        {
            return new ForumDAL().Update(forumID, parentForumID, forumName);
        }

        /// <summary>
        /// Delete forum
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>int</returns>
        public int Delete(int forumID)
        {
            return new ForumDAL().Delete(forumID);
        }

        /// <summary>
        /// Load forum by ID
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>DataTable</returns>
        public DataTable Load(int forumID)
        {
            return new ForumDAL().Load(forumID);
        }

        /// <summary>
        /// Load forums
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LoadAll()
        {
            return new ForumDAL().LoadAll();
        }

        /// <summary>
        /// Load child forums from forum
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>DataTable</returns>
        public DataTable LoadChildsFromForum(int forumID)
        {
            return new ForumDAL().LoadChildsFromForum(forumID);
        }

        /// <summary>
        /// Check if forum exists
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>int</returns>
        public int Exists(int forumID)
        {
            return new ForumDAL().Exists(forumID);
        }
    }
}
