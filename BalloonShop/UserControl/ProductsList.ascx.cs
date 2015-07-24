using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserControl_ProductsList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateControls();
    }

    private void PopulateControls()
    {
        string departmentId = Request.QueryString["DepartmentID"];
        string categoryId = Request.QueryString["CategoryID"];
        string page = Request.QueryString["Page"];
        string searchString = Request.QueryString["Search"];

        if (page == null) page = "1";
        int howManyPages = 1;
        string firstPageUrl = "";
        string pagerFormat = "";

        if (searchString != null) {
            string allWords = Request.QueryString["AllWords"];
            list.DataSource = CatalogAccess.Search(searchString,allWords,page,out howManyPages);
            list.DataBind();

            firstPageUrl = Link.ToSearch(searchString,allWords.ToUpper() =="TRUE","1");
            pagerFormat = Link.ToSearch(searchString,allWords.ToUpper() =="TRUE","{0}");

        }
        else if (categoryId != null) {
            list.DataSource = CatalogAccess.GetProductsInCategory(categoryId,page, 
                out howManyPages);
            list.DataBind();
            firstPageUrl = Link.ToCategory(departmentId,categoryId,"1");
            pagerFormat = Link.ToCategory(departmentId,categoryId,"{0}");
        } else if (departmentId != null) {
            list.DataSource = CatalogAccess.GetProductsOnDeptPromo(departmentId, page, out howManyPages);
            list.DataBind();
            firstPageUrl = Link.ToDepartment(departmentId,"1");
            pagerFormat = Link.ToDepartment(departmentId,"{0}");
        } else {
            list.DataSource = CatalogAccess.GetProductsOnFrontPromo(page, out howManyPages);
            list.DataBind();
            int currentPage = Int32.Parse(page);
        }

        topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, false);
        bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
       

    }
    protected void list_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataRowView dataRow = (DataRowView)e.Item.DataItem;
        string productId = dataRow["ProductID"].ToString();
        DataTable attrTable = CatalogAccess.GetProductAttributes(productId);

        string prevAttributeName = "";
        string attributeName, attributeValue, attributeValueId;
        Label attributeNameLabel;
        PlaceHolder attrPlaceHolder = (PlaceHolder)e.Item.FindControl("attrPlaceHolder");
        DropDownList attributeValuesDropDown = new DropDownList();

        foreach (DataRow r in attrTable.Rows)
        {
            attributeName = r["AttributeName"].ToString();
            attributeValue = r["AttributeValue"].ToString();
            attributeValueId = r["AttributeValueID"].ToString();

            if (attributeName != prevAttributeName)
            {
                prevAttributeName = attributeName;
                attributeNameLabel = new Label();
                attributeNameLabel.Text = attributeName + ": ";
                attributeValuesDropDown = new DropDownList();
                attrPlaceHolder.Controls.Add(attributeNameLabel);
                attrPlaceHolder.Controls.Add(attributeValuesDropDown);
            }

            attributeValuesDropDown.Items.Add(new ListItem(attributeValue, attributeValueId));
        }
    }
}