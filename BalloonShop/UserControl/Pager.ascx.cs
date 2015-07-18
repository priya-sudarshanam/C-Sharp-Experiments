using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_Pager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public struct PageUrl
    {
        private string page;
        private string url;

        public string Page
        {
            get
            {
                return page;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
        }

        public PageUrl(string page, string url)
        {
            this.page = page;
            this.url = url;
        }
    }
        public void Show(int currentPage, int howManyPages, string firstPageUrl,
                      string pageUrlFormat, bool showPages)
        {
            if(howManyPages > 1){
                this.Visible = true;
                currentPageLabel.Text = currentPage.ToString();
                howManyPagesLabel.Text = howManyPages.ToString();
                if (currentPage == 1) {
                    previousLink.Enabled = false;

                } else {
                    previousLink.NavigateUrl = (currentPage == 2) ? 
                    firstPageUrl : string.Format(pageUrlFormat,currentPage-1);
                }

                if (currentPage == howManyPages)
                {
                    nextLink.Enabled = false;
                }
                else
                {
                    nextLink.NavigateUrl = string.Format(pageUrlFormat,currentPage + 1);

                }

                if (showPages){
                    PageUrl[] pages = new PageUrl[howManyPages];
                    pages[0] = new PageUrl("1",firstPageUrl);
                    for(int i=2; i <howManyPages; i++){
                        pages[i-1] = new PageUrl(i.ToString(), string.Format(pageUrlFormat,i));
                    }
                    pages[currentPage -1] = new PageUrl((currentPage).ToString(),"");
                    pageRepeater.DataSource = pages;
                    pageRepeater.DataBind();

                }
        }

    }
}