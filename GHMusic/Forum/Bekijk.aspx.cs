// <copyright file="Bekijk.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic.Admin.Forum
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;
    public partial class Bekijk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request.QueryString["forumID"]))
            {
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                int forumID;
                bool isNumeric = int.TryParse(Request.QueryString["forumID"].ToString(), out forumID);
                if (!isNumeric)
                {
                    Response.Redirect("~/Default.aspx");
                }

                ForumBAL fBal = new ForumBAL();
                DataTable t = fBal.LoadChildsFromForum(forumID);
                this.Repeater1.DataSource = t;
                this.Repeater1.DataBind();

                TopicBAL tBal = new TopicBAL();
                DataTable t2 = tBal.LoadFromForum(forumID);
                this.Repeater2.DataSource = t2;
                this.Repeater2.DataBind();
            }
          
        }
    }
}