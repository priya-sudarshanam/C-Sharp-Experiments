using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_CategoriesList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string departmentId = Request.QueryString["DepartmentID"];
        if (departmentId != null)
        {
            list.DataSource = CatalogAccess.GetCategoriesInDepartment(departmentId);
            list.DataBind();
        }
    }
}