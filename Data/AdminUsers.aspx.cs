using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetCSharp.Data
{
    public partial class AdminUsers : System.Web.UI.Page
    {
        /***if (!Page.IsPostBack)
        {
            BindData();
        }*/

        



        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void CustomersGridView_RowDeleting
        (Object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = GridView1.Rows[e.RowIndex].Cells[1];
            if (cell.Text.ToString().ToLower() == "admin")
            {
                e.Cancel = true;
                Message.Text = "Vous ne pouvez pas supprimer un admin";
            }
            else
            {
            
                Message.Text = GridView1.Rows[e.RowIndex].Cells[0].Text + " supprimé avec succès";
                
            }
        }


        public void CustomersGridView_RowUpdating(Object sender, GridViewUpdateEventArgs e)
        {

            TableCell cell = GridView1.Rows[e.RowIndex].Cells[1];
            if (cell.Text.ToString().ToLower() == "admin")
            {
                e.Cancel = true;
                Message.Text = "Vous ne pouvez pas supprimer un admin";
            }
            else
            {

                Message.Text = GridView1.Rows[e.RowIndex].Cells[0].Text + " supprimé avec succès";

            }
        }

        public void Update()
        {
            Message.Text = "test";
        }
        protected void UpdateRow_Click(object sender, EventArgs e)
        {


            Button btn = sender as Button;
            GridViewRow grow = (GridViewRow)btn.NamingContainer;
            
            string login = ((Label)grow.FindControl("UserName")).Text;
            string role = ((TextBox)grow.FindControl("RoleName")).Text;

            SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);

            SqlCommand nonqueryCommand = thisConnection.CreateCommand();
            try
            {
                // Open Connection
                thisConnection.Open();
                // Create INSERT statement with named parameters
                //nonqueryCommand.CommandText = "INSERT  INTO vw_aspnet_Document (DocumentName,ApplicationId,DocumentId,DocumentPath) VALUES (@DocName, '3a2df03b-ca95-4a39-b0a4-e41c6b963edf',NEWID(),@DocPath );";
                // Add Parameters to Command Parameters collection
                //nonqueryCommand.CommandText = "Update aspnet_UsersInRoles Set aspnet_UsersInRoles.RoleId = (Select aspnet_Roles.RoleId from aspnet_Roles where aspnet_Roles.RoleName = @RoleName)WHERE aspnet_UsersInRoles.UserId In (Select aspnet_Users.UserId from aspnet_Users Where aspnet_Users.UserName = @UserName)";
                nonqueryCommand.CommandText = "Update aspnet_UsersInRoles Set aspnet_UsersInRoles.RoleId = (Select aspnet_Roles.RoleId from aspnet_Roles where aspnet_Roles.RoleName like @RoleName)WHERE aspnet_UsersInRoles.UserId In (Select aspnet_Users.UserId from aspnet_Users Where aspnet_Users.UserName = @UserName)";
                nonqueryCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                nonqueryCommand.Parameters.Add("@RoleName", SqlDbType.VarChar, 150);
                nonqueryCommand.Parameters["@UserName"].Value = login;
                nonqueryCommand.Parameters["@RoleName"].Value = role;
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

        protected void NouveauRole_TextChanged(object sender, EventArgs e)
        {
            DropDownList c1 = (DropDownList)sender;
            Message.Text = "NouveauRole : "+c1.SelectedValue.ToString();
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }


       
    }
}