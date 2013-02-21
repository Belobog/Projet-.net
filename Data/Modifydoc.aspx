<%@ Page Title="Modification de document" Language="C#" AutoEventWireup="true" CodeBehind="Modifydoc.aspx.cs" Inherits="ProjetCSharp.Account.Modifydoc" MasterPageFile="~/Site.master"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Modification de document</h2>
    <p>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <a href='<%# string.Concat("~/Data/Createdoc.aspx?docname=",Eval("DocumentName"))%>' ID="l1" runat="server"><%# Eval("DocumentName") %></a>
                <br />
<br />
                <asp:Button ID="button" runat="server" OnClick="suppbutton_Click" Text='<%# string.Concat("Supprimer ",Eval("DocumentName"))%>' />
            </ItemTemplate>
        </asp:DataList>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
            SelectCommand="SELECT aspnet_Document.DocumentName FROM aspnet_Document,aspnet_DocumentInUsers,aspnet_Users WHERE (aspnet_Users.UserName = @username)AND (aspnet_Users.UserId = aspnet_DocumentInUsers.UsersId)AND (aspnet_DocumentInUsers.DocumentId=aspnet_Document.DocumentId)">
                            <SelectParameters>
                                <asp:Parameter Name="username" Type="String" DefaultValue="Anonymous" />
                            </SelectParameters> 
                        </asp:SqlDataSource>
        
    </p>

        
</asp:Content>