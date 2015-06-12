// <copyright file="Reageer.aspx.cs" company="GHMusic">
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

    public partial class Reageer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["AuthID"] == null || string.IsNullOrWhiteSpace(Request.QueryString["topicID"]))
            {
                Response.Redirect("/Default.aspx", false);
            }
            else
            {
                int topicID;
                string s = Request.QueryString["topicID"].ToString();
                int.TryParse(s, out topicID);

                TopicBAL tBal = new TopicBAL();
                DataTable t = tBal.Load(topicID);
                if (t.Rows.Count == 0)
                {
                    Response.Redirect("/Default.aspx", false);
                }
                else
                {
                    this.lblTopicName.Text = t.Rows[0]["Titel"].ToString();
                    this.ViewState["topicID"] = topicID;
                }
                
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            BerichtBAL bBal = new BerichtBAL();

            try
            {
                int topicID;
                topicID = Convert.ToInt32(ViewState["topicID"].ToString());

                // Create the account
                int intResult = bBal.Insert(topicID, Convert.ToInt32(Session["AuthID"].ToString()), this.tbBody.Text);
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

                bBal = null;

            }  
        }
    }
}