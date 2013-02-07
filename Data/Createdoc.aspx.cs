using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

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
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>alert('Veuillez donner un nom au document !')</script>", "CreateDoc.aspx"));
            }
        }
    }
}