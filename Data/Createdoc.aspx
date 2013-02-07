<%@ Page Title="Création de commentaire" Language="C#" AutoEventWireup="true" CodeBehind="Createdoc.aspx.cs" Inherits="ProjetCSharp.Account.Createdoc" MasterPageFile="~/Site.master" ValidateRequest="false"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Création de document</h2>

        <script type="text/javascript" src="../Scripts/tiny_mce.js"></script>
        <script language="javascript" type="text/javascript">
            tinyMCE.init({
                mode: "textareas",
                theme: "advanced",
                language: "fr"
            });
</script>

        <asp:TextBox ID="MyTextBox" runat="server" Rows="42" TextMode="MultiLine" Height="267px" CssClass="formulaire"></asp:TextBox>

<style type="text/css">
.formulaire {
width: 100%;
}
</style>

    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click"
        Text="Télécharger" />
    <br />


</asp:Content>