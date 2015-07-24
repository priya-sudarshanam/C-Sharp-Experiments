<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchBox.ascx.cs" Inherits="UserControl_SearchBox" %>
<table class="SearchBox">
 <tr>
   <td class="SearchBoxHead">Search the Catalog</td>
 </tr>
 <tr>
   <td class="SearchBoxContent">
     <asp:TextBox ID="searchTextBox" runat="server" Width="97px" MaxLength="100" />&nbsp;
     <asp:Button ID="submit" runat="server" Text="Submit" Width="57px" 
           onclick="submit_Click" /> <br />

     <asp:CheckBox ID="allWordsCheckBox" runat="server" Text="Search For All Words" />
   
   </td>
 </tr>
 </table>