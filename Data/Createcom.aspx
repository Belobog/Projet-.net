<%@ Page Title="Liste de documents" Language="C#" AutoEventWireup="true" CodeBehind="Createcom.aspx.cs" Inherits="ProjetCSharp.Account.Createcom" MasterPageFile="~/Site.master"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Documents à disposition</h2>
        Choisir le document à visualiser
    <br />
    <br />
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate><%# Eval("UserName") %> : 
                <a href='<%# string.Concat("~/Data/Modifycom.aspx?docname=",Eval("DocumentName"))%>' ID="l1" runat="server"><%# Eval("DocumentName") %></a>
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
            SelectCommand="
                            SELECT aspnet_Document.DocumentName, aspnet_Users.UserName 
                            FROM aspnet_Document,aspnet_DocumentInUsers,aspnet_Users
                            Where aspnet_Document.DocumentId = aspnet_DocumentInUsers.DocumentId
                            AND aspnet_DocumentInUsers.UsersId = aspnet_Users.UserId
                            ">
                        </asp:SqlDataSource>
        
    </asp:Content>
