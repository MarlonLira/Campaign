using System;
using System.Data;
using System.Web.UI;
using Dispatch.Controller;
using Dispatch.Helpers;

namespace Dispatch.Views.Marketing {
    public partial class MessagePge : Page {
        public String Texto;
        protected void Page_Load(object sender, EventArgs e) {
            InitPage();
        }

        protected void btn_cancelar_Click(object sender, EventArgs e) {

            Response.Redirect("~/Views/Marketing/EmailPge.aspx", false);
        }

        public void InitPage() {

            if (Session["quantidade_sms"] != null) {
                if ((Int32)Session["quantidade_sms"] > 0) {
                    txt_quantidade_sms.Text = Convert.ToString(Session["quantidade_sms"]);
                }
            }

            if (
                (String)Session["User"] != "ADMIN" || 
                    (
                        !String.IsNullOrEmpty((String)Session["Category"]) &&
                        
                            (
                                (String)Session["Category"] == "SMS" || (String)Session["Category"] == "3")
                            )                          ||
                        
                    (
                        !String.IsNullOrEmpty((String)Session["Category"]) &&
                            (
                                (String)Session["Category"] == "WhatsApp" || (String)Session["Category"] == "2")
                            )

                ) 
            
            {
                /*pnl_control.Enabled = false;
                dd_category.SelectedValue = "2";*/
                lbl_title.Visible = false;
                txt_title.Visible = false;
                lbl_link.Visible = false;
                txt_link.Visible = false;
                lbl_img.Visible = false;
                txt_img.Visible = false;
                lbl_link.Visible = false;
                txt_link.Visible = false;
                txt_description.Attributes.Add("maxlength", "110");
            }

            if (!((String)Session["Category"] == "SMS" || (String)Session["Category"] == "3")) {
                pnl_number_sms.Visible = false;
                pnl_list.Visible = false;
                if (Session["Table"] == null) {
                    pnl_list.Visible = false;
                }
            }
        }

        protected void btn_visualizar_Click(object sender, EventArgs e) {
            MessageCtrl Message = new MessageCtrl();
            Hlp Hlp = new Hlp();

            //teste
            Texto = Hlp.MsgFormat(Message.CreateMsg, txt_img.Text, txt_link.Text, true);
            Texto = Hlp.MsgFormat(Texto, "Aluno", "contato@hiacademia.com.br");

            //adiciona item a sessão
           /* btn_visualizar.Attributes.Add("target", "_blank");
            btn_visualizar.Attributes.Add("onclick", "window.open('~/Views/Marketing/PrevizualizarPge.aspx');return false;");*/

            Session.Add("Texto", Texto);
            //Response.Redirect("~/Views/Marketing/PrevizualizarPge.aspx", false);
            Response.Write("<script> window.open( '~/Views/Marketing/PrevizualizarPge.aspx' ); </script>");
        }

        protected void btn_enviar_Click(object sender, EventArgs e) {
            SendMail Mail = new SendMail();
            MessageCtrl Message = new MessageCtrl();
            Hlp Hlp = new Hlp();
            DataTable Table = new DataTable();
            String Msg;
            String Category = (String)Session["Category"];
            try {

                Table = (DataTable)Session["Table"];

                if (Category.ToUpper() == "EMAIL" || Category.ToUpper() == "1") {
                    Msg = Hlp.MsgFormat(Message.CreateMsg, txt_img.Text, txt_link.Text, true);

                    Mail.Init(Table, Msg, txt_title.Text);
                }
                else if (Category.ToUpper() == "WHATSAPP" || Category.ToUpper() == "2") {
                    Session["Thread-New"] = true;
                    Session.Add("Texto", txt_description.Text);
                    Session["TableInit"] = null;
                    Response.Redirect("~/Views/Marketing/WaitingPge.aspx", false);
                }
                else if (Category.ToUpper() == "SMS" || Category.ToUpper() == "3") {
                    Session["Thread-New"] = true;
                    Session.Add("Texto", txt_description.Text);
                    Session["TableInit"] = null;
                    Session.Add("IsSms", true);
                    Session.Add("Enviados", 0);
                    Session.Add("Falhas", 0);
                    if (Session["Table"] != null) {
                        Session.Add("quantidade_sms", Convert.ToInt32(txt_quantidade_sms.Text));
                    }
                    if (txt_list.Text != null && !String.IsNullOrEmpty(txt_list.Text)) {
                        Session.Add("List", txt_list.Text);
                    }
                    Response.Redirect("~/Views/Marketing/SmsPge.aspx", false);
                }

            } catch (Exception Err) {
                lbl_erro.Text = Err.Message + ' ' + Err.InnerException;
            }
        }

    }
}