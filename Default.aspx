<%@ Page Title="Page d'accueil" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ProjetCSharp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Accueil</h2>
    <p>
        Bienvenue sur l&#39;application de gestion documentaire <asp:LoginName ID="login" runat="server" /> !!!!</p>
 <asp:LoginView id="LoginView1" runat="server">
                <RoleGroups>
                    <asp:RoleGroup Roles="Eleve">
                        <ContentTemplate>
                            <ul>
                                <li>[ <a href="~/Data/Createcom.aspx" ID="l1" runat="server">Créer un commentaire</a> ]</li>
                                <li>[ <a href="~/Account/Modifycom.aspx" ID="l2" runat="server">Modifier un commentaire</a> ]</li>
                            </ul>
                        </ContentTemplate>
                    </asp:RoleGroup>
                    <asp:RoleGroup Roles="Professeur">
                        <ContentTemplate>
                            <ul>
                                <li>[ <a href="~/Data/CreateDoc.aspx" ID="l3" runat="server">Créer un document</a> ]</li>
                                <li>[ <a href="~/Data/ModifyDoc.aspx" ID="l4" runat="server">Modifier un document</a> ]</li>
                            </ul>
                        </ContentTemplate>
                    </asp:RoleGroup>
                </RoleGroups>
            </asp:LoginView>
</asp:Content>
