<%@ Page Title="" Language="C#" MasterPageFile="~/BalloonShop.Master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<%@ Register src="UserControl/ProductsList.ascx" tagname="ProductsList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label ID="titleLabel"  CssClass="CatalogTitle" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="descriptionLabel" CssClass="CatalogDescription" runat="server" Text=""></asp:Label><br />


    <uc1:ProductsList ID="ProductsList1" runat="server" />


    <br />


</asp:Content>

