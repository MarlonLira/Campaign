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
                        Session.Add("User", "ADMIN");
                    } else {
                        IsUser = false;
                    }
                } else {
                    IsUser = false;
                }

                if (txt_user.Text.ToUpper() == "HI") {
                    //TAMARINEIRA
                    if (txt_pass.Text == "Root1501") {
                        IsUser = true;
                        Session.Add("User", "1");
                    }
                    //ESPINHEIRO
                    if (txt_pass.Text == "Root1505") {
                        IsUser = true;
                        Session.Add("User", "5");
                    }
                    //BV2
                    if (txt_pass.Text == "Root1506") {
                        IsUser = true;
                        Session.Add("User", "6");
                    }
                    //BV3
                    if (txt_pass.Text == "Root1510") {
                        IsUser = true;
                        Session.Add("User", "10");
                    }
                    //ENCRUZILHADA
                    if (txt_pass.Text == "Root1531") {
                        IsUser = true;
                        Session.Add("User", "31");
                    }
                }else if (txt_user.Text.ToUpper() == "HIX") {
                    //ESPINHEIRO
                    if (txt_pass.Text == "Root1508") {
                        IsUser = true;
                        Session.Add("User", "8");
                    }
                    //PIEDADE
                    if (txt_pass.Text == "Root1509") {
                        IsUser = true;
                        Session.Add("User", "9");
                    }
                    //OLINDA
                    if (txt_pass.Text == "Root1511") {
                        IsUser = true;
                        Session.Add("User", "11");
                    }
                    //SETUBAL
                    if (txt_pass.Text == "Root1512") {
                        IsUser = true;
                        Session.Add("User", "12");
                    }
                    //IMBIRIBEIRA
                    if (txt_pass.Text == "Root1513") {
                        IsUser = true;
                        Session.Add("User", "13");
                    }
                    //IPSEP
                    if (txt_pass.Text == "Root1519") {
                        IsUser = true;
                        Session.Add("User", "19");
                    }
                    //ARRUDA
                    if (txt_pass.Text == "Root1524") {
                        IsUser = true;
                        Session.Add("User", "24");
                    }
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