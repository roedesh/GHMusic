// <copyright file="Aanmaken.aspx.cs" company="GHMusic">
//     Copyright (c) GHMusic. All rights RESERVED.
// </copyright>
// <author>Ruud Schroën</author>
namespace GHMusic.Tracklist
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

            TracklistBAL tBal = new TracklistBAL();

            try
            {
                // Create the account
                int intResult = tBal.Insert(
                    Convert.ToInt32(this.ddArtistID.SelectedValue),
                    Convert.ToInt32(this.ddEventID.SelectedValue),
                    1,
                    this.tbEventName.Text,
                    this.dtpDate.SelectedDate
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

                tBal = null;

            }  
        }
    }
}