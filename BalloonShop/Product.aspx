<%@ Page Title="" Language="C#" MasterPageFile="~/BalloonShop.Master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <p>
    <asp:Label CssClass="CatalogTitle" ID="titleLabel" runat="server" Text="Label"></asp:Label>
   </p>
   <p>
    <asp:Image ID="productImage" runat="server" />
  </p>
  <p>
    <asp:Label ID="descriptionLabel" runat="server" Text="Label"></asp:Label>
  </p>
  <p>
   <b>Price:</b> <asp:Label CssClass="ProductPrice" ID="priceLabel" runat="server" ext="Label"></asp:Label>
  <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
</asp:Content>

