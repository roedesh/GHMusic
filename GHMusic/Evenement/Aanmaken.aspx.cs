// <copyright file="Aanmaken.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic.Evenement
{
    using System;
    using System.Collections.Generic;
    using System.Data;
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

            EvenementBAL eBal = new EvenementBAL();

            try
            {
                // Create the account
                int intResult = eBal.Insert(
                    Convert.ToInt32(this.ddOrganisationID.SelectedValue),
                    Convert.ToInt32(this.ddLocationID.SelectedValue),
                    this.tbEventName.Text.ToString(),
                    this.dtpDate.SelectedDate,
                    Convert.ToInt32(this.tbTime.Text),
                    Convert.ToInt32(this.tbDays.Text),
                    this.tbWebsite.Text.ToString()
                );

                if (intResult > 0)
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

                eBal = null;

            }  
        }
    }
}