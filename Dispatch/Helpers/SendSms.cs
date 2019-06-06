using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Dispatch.Helpers {
    public class SendSms {

        public readonly Encoding HTTP_ENCODING = Encoding.UTF8;
        private const String URL_PLATFORM = @"http://app.smsfast.com.br/api.ashx?";
        private const String Login = "81999269773";
        private const String Pass = "820475";

        public String WebReq(String Tel, String Msg, out String Campanha, out String ResultStatus) {
            var Result = "";
            Hlp Hlp;
            String ApiUrl = URL_PLATFORM;
            String Status = "";

            //WhatsAppSendPST Send;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (WebClient WebPost = new WebClient()) {
                NameValueCollection WebFields = null;
                Byte[] WebResponse = null;

                try {
                    Hlp = new Hlp();                    
                    WebFields = new NameValueCollection();
                    
                    WebFields["action"] = "sendsms";
                    WebFields["lgn"] = Login;
                    WebFields["pwd"] = Pass;
                    WebFields["content"] = Msg;
                    WebFields["numbers"] = Tel;
                    WebFields["type_service"] = "LONGCODE";
                    //WebFields["url_callback"] = "URL DE RETORNO";
                    
                    WebResponse = WebPost.UploadValues(ApiUrl, "POST", WebFields);
                    Result = HTTP_ENCODING.GetString(WebResponse);

                    //String[] Part = Result.Split(':');

                    dynamic Json = JValue.Parse(Result);
                    Status = Json.status;
                    Campanha = Json.data;
                    ResultStatus = Json.msg;

                } catch (Exception Err) {
                    throw new Exception(Err.Message);
                } finally {
                    WebFields = null;
                    WebResponse = null;
                }
                return Result;
            }
        }
    }
}