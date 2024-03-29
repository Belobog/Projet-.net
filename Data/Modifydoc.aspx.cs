﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetCSharp.Account
{
    public partial class Modifydoc : System.Web.UI.Page
    {
        private String docname;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            SqlDataSource1.SelectParameters["username"].DefaultValue = User.Identity.Name;
        }

        protected void suppbutton_Click(object sender, EventArgs e)
        {
            SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand nonqueryCommand = thisConnection.CreateCommand();
            try
            {
                // Open Connection
                thisConnection.Open();
                // Create DELETE statement with named parameters
                nonqueryCommand.CommandText = "Delete from aspnet_DocumentInUsers where DocumentId in (Select DocumentId From aspnet_Document where DocumentName = @DocName)";
                //Delete from aspnet_Document where  DocumentName = 'Memoire'";
                // Add Parameters to Command Parameters collection
                nonqueryCommand.Parameters.Add("@DocName", SqlDbType.VarChar, 50);
                Button clickedButton = (Button)sender;
                docname = clickedButton.Text.Substring(10);
                nonqueryCommand.Parameters["@DocName"].Value = docname;
                nonqueryCommand.ExecuteNonQuery();
                //Response.Write(e.Item.Controls.ToString);
            }
            catch (SqlException ex)
            {
                Response.Write("1ere commande "+ex.Message);
                // Display error
                //ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>alert('Erreur de suppression dans la BDD')</script>", "ModifyDoc.aspx"));
            }
            finally
            {
                // Close Connection
                thisConnection.Close();
            }
            SqlConnection thisConnection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            SqlCommand nonqueryCommand2 = thisConnection2.CreateCommand();
            try
            {
                // Open Connection
                thisConnection2.Open();
                // Create DELETE statement with named parameters
                nonqueryCommand2.CommandText = "Delete from aspnet_Document where DocumentName = @DocName";
                //Delete from aspnet_Document where  DocumentName = 'Memoire'";
                // Add Parameters to Command Parameters collection
                nonqueryCommand2.Parameters.Add("@DocName", SqlDbType.VarChar, 50);
                nonqueryCommand2.Parameters["@DocName"].Value = docname;
                nonqueryCommand2.ExecuteNonQuery();
                Response.Write("<script language='javascript'>window.location=window.location</script>");
            }
            catch (SqlException ex)
            {
                Response.Write("2eme commande " + ex.Message);
                // Display error
               // ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>alert('Erreur de suppression dans la BDD')</script>", "ModifyDoc.aspx"));
            }
            finally
            {
                // Close Connection
                thisConnection2.Close();
            }
        }
    }
}