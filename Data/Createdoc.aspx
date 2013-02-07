<%@ Page Title="Création de commentaire" Language="C#" AutoEventWireup="true" CodeBehind="Createdoc.aspx.cs" Inherits="ProjetCSharp.Account.Createdoc" MasterPageFile="~/Site.master"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Création de document</h2>

        <script type="text/javascript" src="../Scripts/tiny_mce.js"></script>
        <script type="text/javascript">
            tinyMCE.init({
                mode: "textareas",
                language: "fr"
            });
</script>
<style type="text/css">
.formulaire {
width: 100%;
}
</style>
<textarea name="content" class="formulaire" rows="40">Créer votre document</textarea>&nbsp;
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Enregister" />

</asp:Content>