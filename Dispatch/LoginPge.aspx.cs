using System;
using System.Web.UI;

namespace Dispatch {
    public partial class LoginPge : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Convert.ToBoolean(Session["IsUser"]) != false) {
                Response.Redirect("~/InicioPge.aspx", false);
            }
        }

        public void CheckLogin() {
            Boolean IsUser;
            try {
                if (txt_user.Text.ToUpper() == "ADMIN") {
                    if (txt_pass.Text == "Root1526") {
                        IsUser = true;
                    } else {
                        IsUser = false;
                    }
                } else {
                    IsUser = false;
                }

                if (IsUser == true) {

                    Session.Add("IsUser", IsUser);

                    Response.Redirect("~/InicioPge.aspx", false);
                } else {

                }
            } catch (Exception Err) {

            }
        }

        protected void btn_confirmar_Click(object sender, EventArgs e) {
            CheckLogin();
        }
    }
}