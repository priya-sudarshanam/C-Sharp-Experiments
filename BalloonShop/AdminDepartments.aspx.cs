using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDepartments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
        }

    }

    private void BindGrid()
    {
        grid.DataSource = CatalogAccess.GetDepartments();
        grid.DataBind();
    }


    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid.EditIndex = e.NewEditIndex;
        statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
        BindGrid();
    }
    protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid.EditIndex = -1;
        statusLabel.Text = "Editing canceled";
        BindGrid();
    }
    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        string name = ((TextBox)grid.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
        string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("descriptionTextBox")).Text;
        bool success = CatalogAccess.UpdateDepartment(id, name, description);
        grid.EditIndex = -1;
        statusLabel.Text = success ? "Update Successful" : "Update Failed";
        BindGrid();
    }



    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        bool success = CatalogAccess.DeleteDepartment(id);
        grid.EditIndex = -1;
        statusLabel.Text = success ? "Delete Successful" : "Delete Failed";
        BindGrid();
    }
    protected void createDepartment_Click(object sender, EventArgs e)
    {
        bool success = CatalogAccess.AddDepartment(newName.Text, newDescription.Text);
        statusLabel.Text = success ? "Insert Successful" : "Insert Failed";
        BindGrid();
        newName.Text = string.Empty;
        newDescription.Text = string.Empty;
    }
}