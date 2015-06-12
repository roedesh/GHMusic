// <copyright file="Aanmaken.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic.Locatie
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

            LocatieBAL lBal = new LocatieBAL();

            // Create the account
            int intResult = lBal.Insert(
                Convert.ToInt32(this.ddLandID.SelectedItem.Value),
                this.tbLocationName.Text
            );

            if (intResult > 0)
            {
                Response.Redirect("/Default.aspx", false);
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}