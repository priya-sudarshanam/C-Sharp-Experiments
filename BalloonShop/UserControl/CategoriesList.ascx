<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoriesList.ascx.cs" Inherits="UserControl_CategoriesList"  %>
<asp:DataList ID="list" runat="server" CssClass="CategoriesList" Width="200px">
    <HeaderStyle CssClass="CategoriesListHead" />
    <HeaderTemplate>
        Choose a Category
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" Runat="server"
                   NavigateUrl='<%# Link.ToCategory(Request.QueryString["DepartmentID"],Eval("CategoryID").ToString()) %>'
                    Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'
                    ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>'
                    CssClass='<%# Eval("CategoryID").ToString() == Request.QueryString["CategoryID"] ? "CategorySelected" : "CategoryUnselected" %>'>>
              </asp:HyperLink>

    </ItemTemplate>
</asp:DataList>

