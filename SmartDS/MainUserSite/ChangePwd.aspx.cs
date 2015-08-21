using mds.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MainUserSite
{
    public partial class ChangePwd : System.Web.UI.Page
    {
        protected Webuser _user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSession"] != null)
                {
                    _user = (Webuser)Session["UserSession"];
                    
                }
            }
        }
    }
}