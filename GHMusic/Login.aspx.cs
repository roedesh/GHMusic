// <copyright file="Login.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic
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

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            AccountBAL aBAL = new AccountBAL();

            try
            {
                // Login
                DataTable t = aBAL.Load(this.tbUsername.Text, this.tbPassword.Text);
                if (t.Rows.Count > 0)
                {
                    this.Session["AuthID"] = t.Rows[0]["AccountID"].ToString();
                    this.Session["AuthUsername"] = t.Rows[0]["Gebruikersnaam"].ToString();
                    this.Session["AuthRole"] = t.Rows[0]["Rol"].ToString();
                }
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.Message);
            }
            finally
            {

                aBAL = null;

            }  
        }
    }
}