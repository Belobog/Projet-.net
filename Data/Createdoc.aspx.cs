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
        protected void Page_Load(object sender, EventArgs e)
        {
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
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>alert('Fichier enregistré !')</script>", "CreateDoc.aspx"));

                SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString4"].ConnectionString);
        //Create Command object

        SqlCommand nonqueryCommand = thisConnection.CreateCommand();
        try
        {
            // Open Connection
            thisConnection.Open();
           // Create INSERT statement with named parameters
            nonqueryCommand.CommandText = "INSERT  INTO aspnet_Document (DocumentName) VALUES (@DocName)";
            // Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@DocName", SqlDbType.VarChar, 10);
            nonqueryCommand.Parameters["@DocName"].Value = path;
            nonqueryCommand.ExecuteNonQuery();
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
        }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>alert('Veuillez donner un nom au document !')</script>", "CreateDoc.aspx"));
            }
        }
    }
}