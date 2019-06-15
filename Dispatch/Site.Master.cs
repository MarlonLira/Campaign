using System;
using System.Web.UI;

namespace Dispatch {
    public partial class SiteMaster : MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            /*if (Convert.ToBoolean(Session["IsUser"]) != true) {
                if (Request.Url.AbsoluteUri.IndexOf("LoginPge", StringComparison.InvariantCultureIgnoreCase) < 0) {
                    Response.Redirect("~/LoginPge.aspx", false);
                }
            }*/
        }

        protected void lb_email_Click(object sender, EventArgs e) {
            Response.Redirect("~/Views/Marketing/EmailPge.aspx", false);
        }

        protected void lb_perfil_Click(object sender, EventArgs e) {
            Response.Redirect("~/LoginPge.aspx", false);
        }

        protected void lbtn_sair_Click(object sender, EventArgs e) {
            Session.Abandon();
            Response.Redirect("~/LoginPge.aspx", false);
        }
    }
}