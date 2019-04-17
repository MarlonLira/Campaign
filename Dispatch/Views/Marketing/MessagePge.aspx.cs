﻿using System;
using System.Data;
using System.Web.UI;
using Dispatch.Controller;
using Dispatch.Helpers;

namespace Dispatch.Views.Marketing {
    public partial class MessagePge : Page {
        public String Texto;
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btn_cancelar_Click(object sender, EventArgs e) {

            Response.Redirect("~/Views/Marketing/EmailPge.aspx", false);
        }

        protected void btn_visualizar_Click(object sender, EventArgs e) {
            MessageCtrl Message = new MessageCtrl();
            Hlp Hlp = new Hlp();

            //teste
            Texto = Hlp.MsgFormat(Message.CreateMsg, txt_img.Text, txt_link.Text, true);
            Texto = Hlp.MsgFormat(Texto, "Aluno", "contato@hiacademia.com.br");

            //adiciona item a sessão
            Session.Add("Texto", Texto);
            Response.Redirect("~/Views/Marketing/PrevizualizarPge.aspx", false);
        }

        protected void btn_enviar_Click(object sender, EventArgs e) {
            SendMail Mail = new SendMail();
            MessageCtrl Message = new MessageCtrl();
            Hlp Hlp = new Hlp();
            DataTable Table = new DataTable();
            String Msg;
            try {
                Table = (DataTable)Session["Table"];
                Msg = Hlp.MsgFormat(Message.CreateMsg, txt_img.Text, txt_link.Text, true);

                Mail.Init(Table, Msg, txt_title.Text);

                Response.Redirect("~/Views/Marketing/WaitingPge.aspx", false);
            } catch (Exception Err) {

            }
        }

    }
}