// <copyright file="AccountBAL.cs" company="RuudIT">
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
    /// Bussiness Access Layer for Account
    /// </summary>
    public class AccountBAL
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public AccountBAL()
        {
        }
        
        /// <summary>
        /// Create account
        /// </summary>
        /// <param name="rankID">Rank ID</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="age">Age as number</param>
        /// <param name="interests">Interests</param>
        /// <param name="signature">Signature</param>
        /// <returns>An integer</returns>
        public int Insert(int rankID, string username, string password, int age, string interests, string signature)
        {
            return new AccountDAL().Insert(rankID, username, password, age, interests, signature);
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="accountID">Account ID to be edited</param>
        /// <param name="rankID">Rank ID</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="age">Age as number</param>
        /// <param name="interests">Interests</param>
        /// <param name="signature">Signature</param>
        /// <returns>An integer</returns>
        public int Update(int accountID, int rankID, string username, string password, int age, string interests, string signature)
        {
            return new AccountDAL().Update(accountID, rankID, username, password, age, interests, signature);
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="accountID">Account to be deleted</param>
        /// <returns>An integer</returns>
        public int Delete(int accountID)
        {
            return new AccountDAL().Delete(accountID);
        }

        /// <summary>
        /// Load account by ID
        /// </summary>
        /// <param name="accountID">AccountID</param>
        /// <returns>A Datatable</returns>
        public DataTable Load(int accountID)
        {
            return new AccountDAL().Load(accountID);
        }

        /// <summary>
        /// Load account by username and password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>A Datatable</returns>
        public DataTable Load(string username, string password)
        {
            return new AccountDAL().Load(username, password);
        }

        /// <summary>
        /// Load all accounts
        /// </summary>
        /// <returns>A DataTable</returns>
        public DataTable LoadAll()
        {
            return new AccountDAL().LoadAll();
        }

        /// <summary>
        /// Login by username and password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>An integer</returns>
        public int Login(string username, string password)
        {
            return new AccountDAL().Login(username, password);
        }

        /// <summary>
        /// Check if username exists
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>An integer</returns>
        public int CheckUsername(string username)
        {
            return new AccountDAL().CheckUsername(username);
        }
    }
}