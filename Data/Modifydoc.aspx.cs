﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetCSharp.Account
{
    public partial class Modifydoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }
        protected void Page_Init(object sender, EventArgs e)
        {
           SqlDataSource1.SelectParameters["username"].DefaultValue = User.Identity.Name;
        }
    }
}