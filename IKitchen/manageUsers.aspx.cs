using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKitchen
{
    public partial class manageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectUsers = "select * " +
                                 "from users";
            usersDataSource.SelectCommand = selectUsers;
            usersDataSource.DataBind();
        }
    }
}