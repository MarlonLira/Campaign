using Dispatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dispatch.Controller {
    public class MessageCtrl : MessageMdl{

        #region Email Body
        public String CreateMsg = "<center><span style=\"color: #000000; font-family: Verdana;" +
                                " font-size: xx-small;\"><span style=\"color: #000000; font-family: Verdana; " +
                                "font-size: xx-small;\">&nbsp;</span></span></center><center><span style=\"color: #000000;" +
                                " font-family: Verdana; font-size: xx-small;\"><span style=\"color: #000000; font-family: Verdana; " +
                                "font-size: xx-small;\">{NOME}, se está com dificuldade em&nbsp;visualizar esta mensagem no seu e-mail, " +
                                "<a style=\"color: #000000;\" href=\"{URL_IMG}\">acesse-a por este link</a>.</span></span><span style=\"font-family: Verdana; " +
                                "font-size: xx-small;\">&nbsp;</span>{TEXTO_ESPECIAL}</center><center><span style=\"color: #000000; " +
                                "font-family: Verdana; font-size: xx-small;\">&nbsp;</span></center><center>" +
                                "<a href=\"{URL_CAMPANHA}\"><img width=600px\" height=1049px\" src=\"{URL_IMG}\" alt=\"Imagem do e-mail\" /></a>" +
                                "<br /><br /><span style=\"color: #000000; font-family: Verdana; " +
                                "font-size: xx-small;\"> {TEXTO_LEGAL} Para garantir o recebimento da nossa comunica&ccedil;&atilde;o em sua caixa de entrada,<br />" +
                                "adicione o e-mail <strong><a href=\"mailto:marketing@hiacademia.com.br\">marketing@hiacademia.com.br</a></strong> ao seu cat&aacute;" +
                                "logo de endere&ccedil;os.<br /><br /> Esse e-mail &eacute; uma publica&ccedil;&atilde;o eletr&ocirc;nica e as respostas n&atilde;o s&atilde;" +
                                "o monitoradas.</span></center><center><span style=\"color: #000000; font-family: Verdana; font-size: xx-small;\">" +
                                "Se deseja entrar em contato conosco, responda ou envie sua mensagem para o e-mail <strong><a href=\"mailto:{RESPONDER_PARA}\"> {RESPONDER_PARA} </a>" +
                                "</strong>.<br /> Mas se n&atilde;o deseja receber outros e-mails de comunica&ccedil;&atilde;o semelhantes,&nbsp;clique neste " +
                                "<a href=\"http://www.hiportal.com.br/hiservice/webforms/unsubscribemailpge.aspx?mail={mail}\">link</a> para excluir seu e-mail&nbsp;da nossa lista.</span></center>";
        #endregion

    }
}