using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_SearchBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
         /*   searchTextBox.Focus();*/
            string allWords = Request.QueryString["AllWords"];
            string searchString = Request.QueryString["Search"];
            if (allWords != null)
                allWordsCheckBox.Checked = (allWords.ToUpper() == "TRUE");
            if (searchString != null)
                searchTextBox.Text = searchString;
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        ExecuteSearch();
    }

    private void ExecuteSearch()
    {
        string searchText = searchTextBox.Text;
        bool allWords = allWordsCheckBox.Checked;

        if (searchTextBox.Text.Trim() != "")
            Response.Redirect(Link.ToSearch(searchText,allWords,"1"));
    }
}