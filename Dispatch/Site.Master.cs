using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dispatch {
    public partial class SiteMaster : MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Convert.ToBoolean(Session["IsUser"]) != true) {
                if (Request.Url.AbsoluteUri.IndexOf("LoginPge", StringComparison.InvariantCultureIgnoreCase) < 0) {
                    Response.Redirect("~/LoginPge.aspx", false);
                }
            }
        }

        protected void lb_email_Click(object sender, EventArgs e) {
            Response.Redirect("~/Views/Marketing/EmailPge.aspx", false);
        }

        protected void lb_perfil_Click(object sender, EventArgs e) {
            Response.Redirect("~/LoginPge.aspx", false);
        }
    }
}