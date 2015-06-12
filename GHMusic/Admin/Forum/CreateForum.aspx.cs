// <copyright file="CreateForum.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    public partial class CreateForum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Master.CheckAccess())
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            ForumBAL fBal = new ForumBAL();

            try
            {
                int parentForumID;
                if (string.IsNullOrWhiteSpace(this.ddParentForumID.SelectedItem.Value))
                {
                    parentForumID = 0;
                }
                else
                {
                    parentForumID = Convert.ToInt32(this.ddParentForumID.SelectedItem.Value);
                }

                // Create the account
                int intResult = fBal.Insert(parentForumID, tbForumName.Text);
                if (intResult > 0)
                {

                    Response.Redirect("/Default.aspx");
                }

            }
            catch (Exception ee)
            {

                this.lblFormHandler.Text = ee.Message.ToString();

            }
            finally
            {

                fBal = null;

            }  
        }
    }
}