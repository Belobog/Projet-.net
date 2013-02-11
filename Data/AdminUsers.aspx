<%@ Page Title="Liste des utilisateurs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="ProjetCSharp.Data.AdminUsers" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    
    <asp:GridView ID="ListeUtilisateurs" runat="server" Height="146px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="920px" AutoGenerateColumns="False">
        <Columns>
            <asp:CheckBoxField HeaderText="Name" />
            <asp:BoundField HeaderText="Role" />
        </Columns>
        
      
    </asp:GridView>
</asp:Content>
