<%@ Page Title="Création de documents" Language="C#" AutoEventWireup="true" CodeBehind="Createdoc.aspx.cs" Inherits="ProjetCSharp.Account.Createdoc" MasterPageFile="~/Site.master" ValidateRequest="false"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>Création de document</h2>
    <p>&nbsp;&nbsp;Nom du document :&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" ToolTip="Nom du document"></asp:TextBox>
    </p>

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
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Enregistrer" />
    <br />


</asp:Content>