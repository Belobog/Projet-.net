using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProjetCSharp.Account
{
    public partial class Createdoc : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (TextBox1.Text=="")
            {
 
                String path = Server.MapPath("./") + Request.QueryString["docname"] + ".html";
                TextBox1.Text = Request.QueryString["docname"];
                try
                {
                    StreamReader monStreamReader = new StreamReader(path);

                    MyTextBox.Text = monStreamReader.ReadToEnd();
                    monStreamReader.Close();
                }
                catch (FileNotFoundException e1)
                {
                    Response.Write("<script>alert('Nouveau fichier')</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != String.Empty)
            {
                String path = Server.MapPath("./") + TextBox1.Text+".html";
                StreamWriter monStreamWriter = new StreamWriter(path);
                monStreamWriter.Write(MyTextBox.Text);
                monStreamWriter.Close();
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                Page.Response.Clear();
                Page.Response.AppendHeader("Content-Disposition", "attachment; FileName=" + file.Name);
                Page.Response.AppendHeader("Content-Length", file.Length.ToString());
                Page.Response.ContentType = "application/xhtml+xml";
                Page.Response.WriteFile(file.FullName);
                Page.Response.End();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>alert('Veuillez donner un nom au document !')</script>", "CreateDoc.aspx"));
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != String.Empty)
            {
                String path = Server.MapPath("./") + TextBox1.Text + ".html";
                StreamWriter monStreamWriter = new StreamWriter(path);
                monStreamWriter.Write(MyTextBox.Text);
                monStreamWriter.Close();
 

                SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
                SqlConnection thisConnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

                //Create Command object

        SqlCommand nonqueryCommand = thisConnection.CreateCommand();
        try
        {
            // Open Connection
            thisConnection.Open();
           // Create INSERT statement with named parameters
            nonqueryCommand.CommandText = "INSERT  INTO vw_aspnet_Document (DocumentName,ApplicationId,DocumentId,DocumentPath) VALUES (@DocName, '3a2df03b-ca95-4a39-b0a4-e41c6b963edf',NEWID(),@DocPath );";
            // Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@DocName", SqlDbType.VarChar, 50);
            nonqueryCommand.Parameters.Add("@DocPath", SqlDbType.VarChar, 150);
            nonqueryCommand.Parameters["@DocName"].Value = TextBox1.Text;
            nonqueryCommand.Parameters["@DocPath"].Value = path;
            nonqueryCommand.ExecuteNonQuery();
            
            SqlCommand nonqueryCommand2 = thisConnection2.CreateCommand();
            thisConnection2.Open();
            // Create INSERT statement with named parameters
            nonqueryCommand2.CommandText = "INSERT INTO vw_aspnet_DocumentInUsers(DocumentId, UsersId) VALUES((SELECT DocumentID FROM vw_aspnet_Document WHERE vw_aspnet_Document.DocumentName=@DocName), (SELECT UserId FROM vw_aspnet_Users WHERE vw_aspnet_Users.UserName=@UserName))";
            // Add Parameters to Command Parameters collection
            nonqueryCommand2.Parameters.Add("@DocName", SqlDbType.VarChar, 50);
            nonqueryCommand2.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
            nonqueryCommand2.Parameters["@DocName"].Value = TextBox1.Text;
            nonqueryCommand2.Parameters["@UserName"].Value = User.Identity.Name;
            nonqueryCommand2.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            // Display error
             ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>alert('Erreur d'enregistrement dans la BDD')</script>", "CreateDoc.aspx"));
        }
        finally
        {
            // Close Connection
            thisConnection.Close();
            thisConnection2.Close();
            Response.Write("<script>alert('Fichier enregistré !')</script>");
        }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>alert('Veuillez donner un nom au document !')</script>", "CreateDoc.aspx"));
            }
        }
    }
}