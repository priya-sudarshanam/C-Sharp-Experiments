using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            string searchString = Request.QueryString["Search"];
            titleLabel.Text = "Product Search";
            descriptionLabel.Text = "You search for \"" + searchString + "\"";

            this.Title = BalloonShopConfiguration.SiteName + " : Product Search : " + searchString;
        }
     }
}