// <copyright file="BerichtBAL.cs" company="RuudIT">
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
    /// Bussiness Access Layer for Bericht 
    /// </summary>
    public class BerichtBAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public BerichtBAL()
        {        
        }

        /// <summary>
        /// Create a post
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <param name="accountID">AccountID</param>
        /// <param name="body">The content of the post</param>
        /// <returns>An integer</returns>
        public int Insert(int topicID, int accountID, string body)
        {
            return new BerichtDAL().Insert(topicID, accountID, body);
        }

        /// <summary>
        /// Update a post
        /// </summary>
        /// <param name="postID">Post to be updated</param>
        /// <param name="topicID">TopicID</param>
        /// <param name="accountID">AccountID</param>
        /// <param name="body">The content of the post</param>
        /// <returns>An integer</returns>
        public int Update(int postID, int topicID, int accountID, string body)
        {
            return new BerichtDAL().Update(postID, topicID, accountID, body);
        }

        /// <summary>
        /// Delete a post
        /// </summary>
        /// <param name="postID">PostID</param>
        /// <returns>An integer</returns>
        public int Delete(int postID)
        {
            return new BerichtDAL().Delete(postID);
        }

        /// <summary>
        /// Load post by ID
        /// </summary>
        /// <param name="postID">PostID</param>
        /// <returns>A DataTable</returns>
        public DataTable Load(int postID)
        {
            return new BerichtDAL().Load(postID);
        }

        /// <summary>
        /// Load all posts
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable LoadAll()
        {
            return new BerichtDAL().LoadAll();
        }

        /// <summary>
        /// Load posts from topic
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <returns>A DataTable</returns>
        public DataTable LoadFromTopic(int topicID)
        {
            return new BerichtDAL().LoadFromTopic(topicID);
        }

        /// <summary>
        /// Load posts from account
        /// </summary>
        /// <param name="accountID">AccountID</param>
        /// <returns>A DataTable</returns>
        public DataTable LoadFromAccount(int accountID)
        {
            return new BerichtDAL().LoadFromAccount(accountID);
        }
    }
}
