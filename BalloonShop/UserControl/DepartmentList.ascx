<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentList.ascx.cs" Inherits="UserControl_DepartmentList" %>
<asp:DataList ID="list" runat="server" CssClass="DepartmentsList" Width="200px">
    <HeaderStyle CssClass="DepartmentsListHead" />
    <HeaderTemplate>
        Choose a Department
    </HeaderTemplate>
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" Runat="server"
            NavigateUrl='<%# Link.ToDepartment(Eval("DepartmentID").ToString())%>'
            Text='<%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %>'
            ToolTip='<%# HttpUtility.HtmlEncode(Eval("Description").ToString()) %>'
            CssClass='<%# Eval("DepartmentID").ToString() ==
                            Request.QueryString["DepartmentID"] ? "DepartmentSelected" :
                            "DepartmentUnselected" %>'>
        </asp:HyperLink>
    </ItemTemplate>
</asp:DataList>

