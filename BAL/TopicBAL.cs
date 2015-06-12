// <copyright file="TopicBAL.cs" company="RuudIT">
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
    /// Bussiness Access Layer for Topic
    /// </summary>
    public class TopicBAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public TopicBAL()
        {
        }

        /// <summary>
        /// Create topic
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <param name="accountID">AccountID</param>
        /// <param name="topicTitle">Title of topic</param>
        /// <returns>An integer</returns>
        public int Insert(int forumID, int accountID, string topicTitle)
        {
            return new TopicDAL().Insert(forumID, accountID, topicTitle);
        }

        /// <summary>
        /// Create Topic 
        /// </summary>
        /// <param name="topicID">Topic to be edited</param>
        /// <param name="forumID">ForumID</param>
        /// <param name="accountID">AccountID</param>
        /// <param name="topicTitle">Title of topic</param>
        /// <returns>An integer</returns>
        public int Update(int topicID, int forumID, int accountID, string topicTitle)
        {
            return new TopicDAL().Update(topicID, forumID, accountID, topicTitle);
        }

        /// <summary>
        /// Delete topic
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <returns>an integer</returns>
        public int Delete(int topicID)
        {
            return new TopicDAL().Delete(topicID);
        }

        /// <summary>
        /// Load topic by ID
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <returns>A DataTable</returns>
        public DataTable Load(int topicID)
        {
            return new TopicDAL().Load(topicID);
        }

        /// <summary>
        /// Load all topics
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable LoadAll()
        {
            return new TopicDAL().LoadAll();
        }

        /// <summary>
        /// Load topics from forum
        /// </summary>
        /// <param name="forumID">ForumID</param>
        /// <returns>A DataTable</returns>
        public DataTable LoadFromForum(int forumID)
        {
            return new TopicDAL().LoadFromForum(forumID);
        }

        /// <summary>
        /// Load topics from account
        /// </summary>
        /// <param name="accountID">AccountID</param>
        /// <returns>A DataTable</returns>
        public DataTable LoadFromAccount(int accountID)
        {
            return new TopicDAL().LoadFromAccount(accountID);
        }

        /// <summary>
        /// Check if topic exists
        /// </summary>
        /// <param name="topicID">TopicID</param>
        /// <returns>An integer</returns>
        public int Exists(int topicID)
        {
            return new TopicDAL().Exists(topicID);
        }
    }
}
