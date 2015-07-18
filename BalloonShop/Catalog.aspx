<%@ Page Title="BalloonShop: Catalog" Language="C#" MasterPageFile="~/BalloonShop.Master" AutoEventWireup="true" CodeFile="Catalog.aspx.cs" Inherits="Catalog" %>

<%@ Register src="UserControl/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>
  <asp:Label ID="catalogTitleLabel" CssClass="CatalogTitle" runat="server" />
 </h1>
 <h2>
   <asp:Label ID="CatalogDescriptionLabel" CssClass="CatalogDescription" runat="server" />
 </h2>
    <uc1:ProductsList ID="ProductsList1" runat="server" />
    <br />
&nbsp;
</asp:Content>

