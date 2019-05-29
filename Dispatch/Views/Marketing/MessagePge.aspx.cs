using System;
using System.Data;
using System.Threading;
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
            if ((String)Session["User"] != "ADMIN") {
                pnl_control.Enabled = false;
                dd_category.SelectedValue = "2";
                lbl_title.Visible = false;
                txt_title.Visible = false;
                lbl_link.Visible = false;
                txt_link.Visible = false;
                lbl_img.Visible = false;
                txt_img.Visible = false;
                lbl_link.Visible = false;
                txt_link.Visible = false;
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

        public void OpenWindows() {

        }

        protected void btn_enviar_Click(object sender, EventArgs e) {
            SendMail Mail = new SendMail();
            MessageCtrl Message = new MessageCtrl();
            Hlp Hlp = new Hlp();
            DataTable Table = new DataTable();
            String Msg;
            try {

                Table = (DataTable)Session["Table"];

                if (dd_category.Text.ToUpper() == "EMAIL" || dd_category.Text.ToUpper() == "1") {
                    Msg = Hlp.MsgFormat(Message.CreateMsg, txt_img.Text, txt_link.Text, true);

                    Mail.Init(Table, Msg, txt_title.Text);
                }
                else if (dd_category.Text.ToUpper() == "WHATSAPP" || dd_category.Text.ToUpper() == "2") {
                    Session["Thread-New"] = true;
                    Session.Add("Texto", txt_description.Text);
                    Session["TableInit"] = null;
                    Response.Redirect("~/Views/Marketing/WaitingPge.aspx", false);
                }

            } catch (Exception Err) {
                lbl_erro.Text = Err.Message + ' ' + Err.InnerException;
            }
        }

    }
}