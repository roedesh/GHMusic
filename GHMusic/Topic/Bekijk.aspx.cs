// <copyright file="Bekijk.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic.Topic
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
            if (string.IsNullOrWhiteSpace(Request.QueryString["topicID"])){
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                int topicID;
                bool isNumeric = int.TryParse(Request.QueryString["topicID"].ToString(), out topicID);
                if (!isNumeric)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    TopicBAL tBal = new TopicBAL();
                    DataTable t = tBal.Load(topicID);
                    if (t.Rows.Count == 0){
                        Response.Redirect("~/Default.aspx", false);
                    }
                    else {
                        BerichtBAL bBal = new BerichtBAL();
                        DataTable t2 = bBal.LoadFromTopic(topicID);
                        this.Repeater1.DataSource = t2;
                        this.Repeater1.DataBind();
                        this.lblTopicTitle.Text = t.Rows[0]["Titel"].ToString();
                    }
                    
                }

            }
            
        }
    }
}