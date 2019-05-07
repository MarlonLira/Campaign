using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace Dispatch.Helpers {
    public class SendWhats {


        #region Constantes
        public readonly Encoding HTTP_ENCODING = Encoding.UTF8;
        //private const String URL_PLATFORM = "https://www.waboxapp.com/api/send/chat?";
        private const String TOKEN = "b1eb8ddec2f3b81f048672d3c05fcaea5c505838db298";
        private const String SUCCESS = "{\"success\"";
        private const String REMETENTE = "558198950156";
        private const String TESTE_DESTINATARIO = "558199269773";
        private const String NiceToken = "+UhjvRV5OEyV61jUFnLvs21hcmxvbl9kb3RfbGlyYV9hdF9oaWFjYWRlbWlhX2RvdF9jb21fZG90X2Jy";

        #endregion

        #region Variaveis
        Hlp Hlp;
        public String Texto;
        public String Img;
        public String Img_Titulo;
        public String Img_Descricao;
        public String Remetente;
        public String Token;
        #endregion

        #region Metodos
        public String GetTokenDefault() {
            return TOKEN;
        }

        public String GetRemetenteDefault() {
            return REMETENTE;
        }

        public String GetTesteDestinatario() {
            return TESTE_DESTINATARIO;
        }
        /*
        public String WebReq(String ApiUrl, String Tel, String Nome) {
            String Result = "";

            //WhatsAppSendPST Send;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (WebClient WebPost = new WebClient()) {
                NameValueCollection WebFields = null;
                Byte[] WebResponse = null;
                String TypeSend;

                try {
                    Hlp = new Hlp();
                    Send = new WhatsAppSendPST();
                    WebFields = new NameValueCollection();
                    TypeSend = "chat";
                    Send.Texto = Hlp.WhatsMsgFormat(Texto, Nome);

                    if (!String.IsNullOrEmpty(Img)) {
                        TypeSend = "image";
                        Send.UrlImg = Img;
                    }

                    //Waboxapp
                    //WebFields["Send"] = Send.Cmd;

                    if (!String.IsNullOrEmpty(Token)) {
                        WebFields["token"] = Token;
                    } else {
                        WebFields["token"] = TOKEN;
                    }

                    if (!String.IsNullOrEmpty(Remetente)) {
                        WebFields["uid"] = Remetente;
                    } else {
                        WebFields["uid"] = REMETENTE;
                    }

                    WebFields["to"] = Tel;
                    WebFields["custom_uid"] = Hlp.RandomIdGenerator();
                    WebFields["text"] = Send.Texto;

                    if (!String.IsNullOrEmpty(Img)) {
                        WebFields["url"] = Send.UrlImg;
                        WebFields["caption"] = Send.Titulo;
                        WebFields["description"] = Send.Descricao;
                    }

                    /*
                    //Winzap
                    WebFields["token"] = TOKEN;
                    WebFields["cmd"] = Send.Cmd;
                    WebFields["id"] = Hlp.RandomIdGenerator();
                    WebFields["de"] = "5581" + txt_remetente.Text;
                    WebFields["para"] = Tel;
                    WebFields["msg"] = Send.Texto;
                    if (!String.IsNullOrEmpty(txt_img.Text)) {
                        WebFields["link"] = Send.UrlImg;
                    }*/

                    //MessageBox.Show(Send.Texto);*/
                    /*
                    ApiUrl += TypeSend;
                    WebResponse = WebPost.UploadValues(ApiUrl, "POST", WebFields);
                    Result = HTTP_ENCODING.GetString(WebResponse);
                    //Result = "{\"success\":0";

                    String[] Part = Result.Split(':');

                    if (Part[0] == SUCCESS) {
                        Result = "success";
                    }
                } catch (Exception e) {
                    
                } finally {
                    WebFields = null;
                    WebResponse = null;
                }

                return Result;
            }
        }
        */

        public String EncurtarLink(String urlOriginal) {

            XmlDocument xmlDoc = new XmlDocument();        // O documento XML que será usado para tratar a reposta do servidor

            //Faz uma solicitação ao bitly
            WebRequest request = WebRequest.Create("http://api.bitly.com/v3/shorten");
            //passa os dados do usuário, a chave da API e a url original
            byte[] data = Encoding.UTF8.GetBytes(string.Format("login={0}&apiKey={1}&longUrl={2}&format={3}",
                "hiacademia",                                     // seu nome de usuário na bitly
                "R_0aeffa67b9c747eeb20fde762001cee7",                // sua chave para usar a API (API key)
                HttpUtility.UrlEncode(urlOriginal),                 // Aplicar Encode na url que vamos encurtar
                "xml"));                                            // O formato da resposta que desejamos que o servidor responda
                                                                    //envia os dados via POST 
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (Stream ds = request.GetRequestStream()) {
                ds.Write(data, 0, data.Length);
            }

            //lê o arquivo XML obtido so servidor
            String Result = "";
            using (WebResponse response = request.GetResponse()) {
                using (StreamReader sr = new StreamReader(response.GetResponseStream())) {
                    xmlDoc.LoadXml(sr.ReadToEnd());
                    Result = xmlDoc.GetElementsByTagName("url")[0].InnerText;
                }
            }

            return Result;

        }

        // api -https://niceapi.net/HowToUse
        public String NiceApp() {

            string yourId = "+UhjvRV5OEyV61jUFnLvs21hcmxvbl9kb3RfbGlyYV9hdF9oaWFjYWRlbWlhX2RvdF9jb21fZG90X2Jy";
            string yourMobile = "+5581983460962";
            string yourMessage = "Testando";

            try {
                string url = "https://NiceApi.net/API";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("X-APIId", yourId);
                request.Headers.Add("X-APIMobile", yourMobile);
                using (StreamWriter streamOut = new StreamWriter(request.GetRequestStream())) {
                    streamOut.Write(yourMessage);
                }
                using (StreamReader streamIn = new StreamReader(request.GetResponse().GetResponseStream())) {
                    Console.WriteLine(streamIn.ReadToEnd());
                }
            } catch (SystemException se) {
                Console.WriteLine(se.Message);
            }
            Console.ReadLine();

            return "a";
        }


        #endregion
    }
}