// <copyright file="CreateTopic.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic.Topic
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    public partial class CreateTopic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AuthID"] == null || string.IsNullOrWhiteSpace(Request.QueryString["forumID"]))
            {
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                int forumID;
                bool isNumeric = int.TryParse(Request.QueryString["forumID"].ToString(), out forumID);
                if (!isNumeric)
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    ForumBAL fBal = new ForumBAL();
                    DataTable t = fBal.Load(forumID);
                    if (t.Rows.Count == 0)
                    {
                        Response.Redirect("~/Default.aspx", false);
                    }
                    else
                    {
                        this.lblForumName.Text = t.Rows[0]["Naam"].ToString();
                        this.ViewState["forumID"] = forumID;
                    }
                }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            TopicBAL tBal = new TopicBAL();
            BerichtBAL bBal = new BerichtBAL();

            Debug.WriteLine(ViewState["forumID"].ToString());

            try
            {
                Debug.WriteLine(ViewState["forumID"].ToString());
                int forumID;
                if (string.IsNullOrWhiteSpace(ViewState["forumID"].ToString()))
                {
                    forumID = 0;
                }
                else
                {
                    forumID = Convert.ToInt32(ViewState["forumID"].ToString());
                }

                Debug.WriteLine(forumID);

                // Create the account
                int intResult = tBal.Insert(forumID, Convert.ToInt32(Session["AuthID"].ToString()), tbTopicTitle.Text);

                Debug.WriteLine(intResult);

                int intResult2 = bBal.Insert(intResult, Convert.ToInt32(this.Session["AuthID"].ToString()), this.tbBody.Text);
                if (intResult2 > 0)
                {
                    Response.Redirect("/Default.aspx", false);
                    
                }
            }
            catch (Exception ee)
            {

                this.lblFormHandler.Text = ee.Message.ToString();

            }
            finally
            {

                tBal = null;

            }  
        }
    }
}