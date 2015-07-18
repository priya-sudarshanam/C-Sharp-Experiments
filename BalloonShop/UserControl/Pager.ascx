<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager.ascx.cs" Inherits="UserControl_Pager" %>

<p> Page of <asp:Label ID="currentPageLabel" runat="server" />
of
<asp:Label ID="howManyPagesLabel" runat="server" />
<asp:HyperLink ID="previousLink" runat="server">Previous</asp:HyperLink>
<asp:Repeater ID="pageRepeater" runat="server">
 <ItemTemplate>
   <asp:HyperLink ID="hyperlink" runat= "server" Text='<%# Eval("Page") %>' 
    NavigateUrl='<%# Eval("Url") %>'> </asp:HyperLink>
   
   </ItemTemplate>
 </asp:Repeater>
 <asp:HyperLink ID="nextLink" runat="server">Next</asp:HyperLink>
</p>