<%@ Page Title="Liste des utilisateurs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="ProjetCSharp.Data.AdminUsers" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    
     <h2>Utilisateurs<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Width="903px">
         <AlternatingRowStyle BackColor="#DCDCDC" />
         <Columns>
             <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
             <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
             <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" SortExpression="LastActivityDate" />
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
             SelectCommand="SELECT aspnet_Users.UserId,aspnet_Users.UserName, aspnet_Users.LastActivityDate FROM aspnet_Users">
             

         </asp:SqlDataSource>
     </h2>

      
    
</asp:Content>
