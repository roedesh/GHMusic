// <copyright file="Register.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using BAL;

    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = ConfigurationManager.AppSettings["PrependTitle"] + Page.Title;
        }

        protected void btSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            AccountBAL aBAL = new AccountBAL();
  
            try
            {
                // Create the account
                int intResult = aBAL.Insert(1, this.tbUsername.Text, this.tbPassword.Text, Convert.ToInt32(this.tbAge.Text), this.tbInterests.Text, this.tbSignature.Text);
                if (intResult > 0)
                {
                    // Login
                    DataTable t = aBAL.Load(tbUsername.Text, tbPassword.Text);
                    if (t.Rows.Count > 0)
                    {
                        this.Session["AuthID"] = t.Rows[0]["AccountID"].ToString();
                        this.Session["AuthUsername"] = t.Rows[0]["Gebruikersnaam"].ToString();
                    }
                    Response.Redirect("Default.aspx");
                }

            }
            catch (Exception ee)
            {

                this.lblFormHandler.Text = ee.Message.ToString();

            }
            finally
            {

                aBAL = null;

            }  
                    
        }

        protected void CheckUsername(object source, ServerValidateEventArgs args)
        {
            int intResult = new AccountBAL().CheckUsername(tbUsername.Text);
            if (intResult > 0)
            {
                args.IsValid = false;
            }
        }
    }
}