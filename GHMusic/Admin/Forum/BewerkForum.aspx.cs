// <copyright file="BewerkForum.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic.Admin.Forum
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
    public partial class BewerkForum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request.QueryString["forumID"]))
            {
                Response.Redirect("/Default.aspx", false);
            }
            else
            {
                int forumID;
                string s = Request.QueryString["forumID"].ToString();
                int.TryParse(s, out forumID);

                ForumBAL fBal = new ForumBAL();
                DataTable t = fBal.Load(forumID);
                if (t.Rows.Count == 0)
                {
                    Response.Redirect("/Default.aspx", false);
                }
                else
                {
                    this.lblForumName.Text = t.Rows[0]["Naam"].ToString();
                    this.ViewState["forumID"] = forumID;
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            ForumBAL fBal = new ForumBAL();

            try
            {
                int forumID;
                forumID = Convert.ToInt32(ViewState["forumID"].ToString());
                Debug.WriteLine(forumID);

                // Create the account
                int intResult = fBal.Update(forumID, Convert.ToInt32(this.ddParentForumID.SelectedItem.Value), this.tbForumName.Text);
                Debug.WriteLine(intResult);

                if (intResult > 0)
                {

                    Response.Redirect("/Default.aspx", false);
                }
            }
            catch (Exception ee)
            {

                Debug.WriteLine(ee.Message.ToString());

            }
            finally
            {

                fBal = null;

            }  
        }

    }
}