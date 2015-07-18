using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Catalog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateControls();
    }

    private void PopulateControls()
    {
        string departmentID = Request.QueryString["DepartmentID"];
        string categoryID = Request.QueryString["CategoryID"];
        if (categoryID != null){
            CategoryDetails cd = CatalogAccess.GetCategoryDetails(categoryID);
            catalogTitleLabel.Text = HttpUtility.HtmlEncode(cd.Name);
            DepartmentDetails dd = CatalogAccess.GetDepartmentDetails(departmentID);
            CatalogDescriptionLabel.Text = HttpUtility.HtmlEncode(cd.Description);
            this.Title = HttpUtility.HtmlEncode(BalloonShopConfiguration.SiteName + 
                ": " + dd.Name + " : " + cd.Name);
        }
        else if (departmentID != null) {
            DepartmentDetails dd = CatalogAccess.GetDepartmentDetails(departmentID);
            catalogTitleLabel.Text = HttpUtility.HtmlEncode(dd.Name);
            CatalogDescriptionLabel.Text = HttpUtility.HtmlEncode(dd.Description);
            this.Title = HttpUtility.HtmlEncode(BalloonShopConfiguration.SiteName + 
                ": " + dd.Name);
        }

    }
}
