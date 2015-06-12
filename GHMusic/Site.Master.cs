// <copyright file="Site.Master.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Site : System.Web.UI.MasterPage
    {
        public string AuthUsername
        {
            get;
            set;
        }

        public int AuthID
        {
            get;
            set;
        }

        public bool IsAdmin
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.IsAdmin = false;

            if (this.Session["AuthUsername"] != null && this.Session["AuthID"] != null)
            {
                this.AuthUsername = this.Session["AuthUsername"].ToString();
                this.AuthID = Convert.ToInt32(this.Session["AuthID"]);
                if (this.AuthID == null)
                {
                    this.AuthID = 0;
                }
                if (this.Session["AuthRole"].ToString() == "Admin")
                {
                    this.IsAdmin = true;
                }
            }
            
        }

        public bool CheckAccess()
        {
            return this.IsAdmin;
        }

        public int GetAuthID()
        {
            return this.AuthID;
        }
    }
}