<%@ Page Title="Liste des utilisateurs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="ProjetCSharp.Data.AdminUsers" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    
     <h2>Utilisateurs<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Width="903px">
         <AlternatingRowStyle BackColor="#DCDCDC" />
         <Columns>
             <asp:BoundField DataField="UserName" HeaderText="Login" SortExpression="UserName" />
             <asp:BoundField DataField="RoleName" HeaderText="Role" SortExpression="RoleName" />
             <asp:BoundField DataField="LastActivityDate" HeaderText="Derniere connexion" SortExpression="LastActivityDate" />
             <asp:ButtonField ButtonType="Image" HeaderText="Modifier"  ImageUrl="~/Images/validation.jpg" />
             <asp:ButtonField ButtonType="Image" HeaderText="Supprimer" ImageUrl="~/Images/supression.jpg" />
         </Columns>
         <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
         <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
         <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
         <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F1F1F1" />
         <SortedAscendingHeaderStyle BackColor="#0000A9" />
         <SortedDescendingCellStyle BackColor="#CAC9C9" />
         <SortedDescendingHeaderStyle BackColor="#000065" />
         </asp:GridView>
         <asp:SqlDataSource 
             ID="SqlDataSource1" 
             runat="server"
             ConnectionString="<%$ ConnectionStrings:ConnectionString %>"  
             SelectCommand="SELECT aspnet_Users.UserName, aspnet_Roles.RoleName, aspnet_Users.LastActivityDate 
             FROM aspnet_Users,aspnet_Roles,aspnet_UsersInRoles
             WHERE aspnet_Users.UserId = aspnet_UsersInRoles.UserId
             AND aspnet_Roles.RoleId = aspnet_UsersInRoles.RoleId ">
             

         </asp:SqlDataSource>
     </h2>

      
    
</asp:Content>
