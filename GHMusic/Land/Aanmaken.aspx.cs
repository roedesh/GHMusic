// <copyright file="Aanmaken.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic.Land
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using BAL;

    public partial class Aanmaken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            LandBAL lBal = new LandBAL();

            // Create the account
            int intResult = lBal.Insert(
                this.tbCountryName.Text,
                this.tbCountryCode.Text
            );

            if (intResult > 0)
            {
                Response.Redirect("/Default.aspx", false);
            }
        }
    }
}