<%@ Page Title="Modification de commentaire" Language="C#" AutoEventWireup="true" CodeBehind="Modifycom.aspx.cs" Inherits="ProjetCSharp.Account.Modifycom" MasterPageFile="~/Site.master"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Modification de commentaire</h2>
    <p>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </p>
    <p>&nbsp;</p>

        
</asp:Content>