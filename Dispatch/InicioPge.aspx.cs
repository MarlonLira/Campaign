using System;

namespace Dispatch {
    public partial class InicioPge : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Convert.ToBoolean(Session["IsUser"]) != true) {
                Response.Redirect("~/LoginPge.aspx", false);
            }

            if (Session["Err"] != null) {
                lbl_erro.Text = (String)Session["Err"];
            }
        }
    }
}