using Dispatch.Controller;
using Dispatch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dispatch.Views.Marketing {
    public partial class MessagePge : Page {
        public String Texto;
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btn_cancelar_Click(object sender, EventArgs e) {

            Response.Redirect("~/Views/Marketing/EmailPge.aspx", false);
        }

        protected void btn_enviar_Click(object sender, EventArgs e) {
            MessageCtrl Message = new MessageCtrl();
            Hlp Hlp = new Hlp();

            //teste
            Texto =  Hlp.MsgFormat(Message.CreateMsg, "https://i.imgur.com/6ifBI3c.jpg", "http://ofertas.yesfitacademia.com.br/", "marlonlira2@gmail.com");

            //adiciona item a sessão
            Session.Add("Texto", Texto);
            Response.Redirect("~/Views/Marketing/PrevizualizarPge.aspx", false);
            
        }

    }
}