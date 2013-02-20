<%@ Page Title="Modification de document" Language="C#" AutoEventWireup="true" CodeBehind="Modifydoc.aspx.cs" Inherits="ProjetCSharp.Account.Modifydoc" MasterPageFile="~/Site.master"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Modification de document</h2>
    <p>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" OnDeleteCommand="DataList1_DeleteCommand">
            <ItemTemplate>
                <asp:Label ID="DocumentNameLabel" runat="server" 
                    Text='<%# Eval("DocumentName") %>' />
                <br />
<br />
                <asp:Button ID="buttondelete" runat="server" CommandName="delete" Text="Supprimer" />
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