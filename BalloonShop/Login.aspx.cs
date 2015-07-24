using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox userNameTextBox = (TextBox)LoginControl.FindControl("UserName");
        userNameTextBox.Focus();

        this.Title = BalloonShopConfiguration.SiteName + " : Login";
    }
}
