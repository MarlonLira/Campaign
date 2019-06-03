using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace Dispatch.Helpers {
    public class Hlp {

        public TableRow[] TableLoad(DataTable Table) {
            Table WebTable;
            TableCell WebCell;
            TableRow WebRow;
            TableRow[] WebRow2;
            DbHelper dbHelper;
            
            try {

                WebTable = new Table();
                dbHelper = new DbHelper();
                WebRow = new TableRow();
               
                WebRow2 = new TableRow[Table.Rows.Count];
                int count = 0;
                foreach (DataRow Rows in Table.Rows) {

                    foreach (object Cells in Rows.ItemArray) {
                        WebCell = new TableCell();
                        WebCell.Text = Cells.ToString();

                        WebRow.Cells.Add(WebCell);
                    }

                    WebTable.Rows.Add(WebRow);
                    WebRow2[count] = WebRow;
                    WebRow = new TableRow();
                    count++;
                }
            } catch (Exception Err) {
                WebTable = null;
                WebRow2 = null;
            }

            return WebRow2;
        }

        public String[] EmpresaFind(Table Table) {
            Table WebTable;
            TableRow WebRow;
            String[] WebRow2;
            DbHelper dbHelper;

            try {

                WebTable = new Table();
                dbHelper = new DbHelper();
                WebRow = new TableRow();

                WebRow2 = new String[Table.Rows.Count];
                int count = 0;
                foreach (TableRow Rows in Table.Rows) {
                    foreach (TableCell Cells in Rows.Cells) {
                            WebRow2[count] = Cells.Text;
                            count++;
                    }
                }


            } catch (Exception Err) {
                WebTable = null;
                WebRow2 = null;
            }

            return WebRow2;
        }

        //Corrigir
        public String MsgFormat(String CreateMsg, String UrlImg, String UrlCampanha, Boolean Init) {
            String Msg = CreateMsg;
            try {
                Msg = Msg.Replace("{URL_IMG}", UrlImg);
                Msg = Msg.Replace("{URL_CAMPANHA}", UrlCampanha);
                Msg = Msg.Replace("{TEXTO_ESPECIAL}", "");
                Msg = Msg.Replace("{TEXTO_LEGAL}", "");

            } catch (Exception e) {
                
            }
            return Msg;
        }

        public String MsgFormat(String CreateMsg, String nome, String Email) {
            String Msg = CreateMsg;
            try {
                String[] Nome = nome.Split(' ');
                String SelectName = Nome[0];
                Msg = Msg.Replace("{NOME}", RandomTalk(SelectName));
                Msg = Msg.Replace("{RESPONDER_PARA}", Email);

            } catch (Exception e) {

            }
            return Msg;
        }

        public String WhatsMsgFormat(String Texto, String Nome) {

            String TextFormat = "";

            String[] NomeFormat = Nome.Split(' ');
            TextFormat = Texto.Replace("{nome}", NomeFormat[0]);

            TextFormat = TextFormat.Replace("{hix}", "Texto fixo Hix");
            TextFormat = TextFormat.Replace("{hi}", "Texto fixo Hi");
            TextFormat = TextFormat.Replace("{comprimento}", RandomTalk(Nome));
            TextFormat = TextFormat.Replace("{comprimentoplus}", RandomTalk(NomeFormat[0]));

            return TextFormat;
        }

        public String RandomTalk(String Nome) {
            String Talk = "";
            Int32 Num = RandomNumber(1, 13);

            switch (Num) {
                case 1: {
                        Talk = "Bom dia " + Nome + " Tudo bem com você ?";
                        break;
                }
                case 2: {
                        Talk = "Olá tudo bem? " + Nome;
                        break;
                }
                case 3: {
                        Talk = "Como vai? " + Nome;
                        break;
                }
                case 4: {
                        Talk = "Olá " + Nome;
                        break;
                }
                case 5: {
                        Talk = "Oi tudo bem? " + Nome;
                        break;
                }
                case 6: {
                        Talk = "Olá, Como vai? " + Nome;
                        break;
                }
                case 7: {
                        Talk = "Bom dia, Como vai? " + Nome;
                        break;
                }
                case 8: {
                        Talk = "Tudo Bem? " + Nome;
                        break;
                }
                case 9: {
                        Talk = "Olá " + Nome + " Como vai?";
                        break;
                }
                case 10: {
                        Talk = "Olá " + Nome + " Tudo bem?";
                        break;
                }
                case 11: {
                        Talk = Nome + " Como vai?";
                        break;
                }
                case 12: {
                        Talk = "Olá " + Nome + " Tudo Bem com você?";
                        break;
                }
                case 13: {
                        Talk = "Bom dia " + Nome + " Como vai? ";
                        break;
                }

            }

            return Talk;
        }

        public int RandomNumber(int min, int max) {
            Random random = new Random();
            return random.Next(min, max);
        }

        public Int32 WaitTime(Int32 Contador) {

            Int32 Time = 0;

            if (Contador <= 50) {
                Time = 60000;

            } else {
                Contador = 0;
                Time = 1200000;
            }

            return Time;
        }

        public String WhatsLinkGenerator(String Number, String Text) {
            String WhatsLink = "https://api.whatsapp.com/send?phone=" + Number + "&text=" + Text;

            return WhatsLink;
        }

        //checar
        public String TelFormat(String Telefone) {
            String Tel = "";

            if (Telefone.Length == 11 && Int32.Parse(Telefone.Substring(0, 1)) == 8 && Int32.Parse(Telefone.Substring(1, 1)) == 1) {
                Tel = "55" + Telefone;
            } else if (Telefone.Length == 10 && Int32.Parse(Telefone.Substring(0, 1)) == 1) {
                Tel = "558" + Telefone;
            } else if (Telefone.Length == 9 && Int32.Parse(Telefone.Substring(0, 1)) == 9) {
                Tel = "5581" + Telefone;
            } else if (Telefone.Length == 8 && Int32.Parse(Telefone.Substring(0, 1)) == 9 || Int32.Parse(Telefone.Substring(0, 1)) == 8) {
                Tel = "55819" + Telefone;
            } else if ((Telefone.Length == 9) && (Int32.Parse(Telefone.Substring(0, 1)) == 1 && Int32.Parse(Telefone.Substring(1, 1)) == 9 || Int32.Parse(Telefone.Substring(1, 1)) == 8)) {
                for (int x = 0; x <= 8; x++) {
                    if (x == 0) { Tel = "55819"; } else { Tel += Telefone[x]; }
                }
            } else if ((Telefone.Length == 10) && (Int32.Parse(Telefone.Substring(0, 1)) == 8 && Int32.Parse(Telefone.Substring(1, 1)) == 1 && (Int32.Parse(Telefone.Substring(2, 1)) == 8 || Int32.Parse(Telefone.Substring(2, 1)) == 9))) {
                for (int x = 0; x <= 9; x++) {
                    if (x == 0 || x == 1) { Tel = "55819"; } else { Tel += Telefone[x]; }
                }
            } else {
                Tel = "";
            }

            if (Tel.Length > 13 || Tel.Length < 13) { Tel = ""; }

            return Tel;
        }

        public String TelFormat(String Telefone, Boolean IsCountryCode) {
            String Tel = "";

            if (!IsCountryCode) {
                if (Telefone.Length == 11 && Int32.Parse(Telefone.Substring(0, 1)) == 8 && Int32.Parse(Telefone.Substring(1, 1)) == 1) {
                    Tel = Telefone;
                } else if (Telefone.Length == 10 && Int32.Parse(Telefone.Substring(0, 1)) == 1) {
                    Tel = "8" + Telefone;
                } else if (Telefone.Length == 9 && Int32.Parse(Telefone.Substring(0, 1)) == 9) {
                    Tel = "81" + Telefone;
                } else if (Telefone.Length == 8 && Int32.Parse(Telefone.Substring(0, 1)) == 9 || Int32.Parse(Telefone.Substring(0, 1)) == 8) {
                    Tel = "819" + Telefone;
                } else if ((Telefone.Length == 9) && (Int32.Parse(Telefone.Substring(0, 1)) == 1 && Int32.Parse(Telefone.Substring(1, 1)) == 9 || Int32.Parse(Telefone.Substring(1, 1)) == 8)) {
                    for (int x = 0; x <= 8; x++) {
                        if (x == 0) { Tel = "819"; } else { Tel += Telefone[x]; }
                    }
                } else if ((Telefone.Length == 10) && (Int32.Parse(Telefone.Substring(0, 1)) == 8 && Int32.Parse(Telefone.Substring(1, 1)) == 1 && (Int32.Parse(Telefone.Substring(2, 1)) == 8 || Int32.Parse(Telefone.Substring(2, 1)) == 9))) {
                    for (int x = 0; x <= 9; x++) {
                        if (x == 0 || x == 1) { Tel = "819"; } else { Tel += Telefone[x]; }
                    }
                } else {
                    Tel = "";
                }

                if (Tel.Length > 13 || Tel.Length < 13) { Tel = ""; }
            }

            return Tel;
        }

        public String TelFind(DataTable Table, String Tabela, Int32 Cont) {
            String TelFound = "";

            if (Tabela == "ALUNO") {
                if (!String.IsNullOrEmpty(Table.Rows[Cont]["tel_celular"].ToString())) {
                    TelFound = Table.Rows[Cont]["tel_celular"].ToString();
                } /*else if (!String.IsNullOrEmpty(Table.Rows[Cont]["tel_recado"].ToString())) {
                    TelFound = Table.Rows[Cont]["tel_recado"].ToString();
                } else if (!String.IsNullOrEmpty(Table.Rows[Cont]["tel_residencia"].ToString())) {
                    TelFound = Table.Rows[Cont]["tel_residencia"].ToString();
                } else if (!String.IsNullOrEmpty(Table.Rows[Cont]["tel_emergencia"].ToString())) {
                    TelFound = Table.Rows[Cont]["tel_emergencia"].ToString();
                } else if (!String.IsNullOrEmpty(Table.Rows[Cont]["tel_responsavel"].ToString())) {
                    TelFound = Table.Rows[Cont]["tel_responsavel"].ToString();
                } else if (!String.IsNullOrEmpty(Table.Rows[Cont]["tel_celular_responsavel"].ToString())) {
                    TelFound = Table.Rows[Cont]["tel_celular_responsavel"].ToString();
                }*/ else {
                    TelFound = "";
                }
            } else {
                if (!String.IsNullOrEmpty(Table.Rows[Cont]["tel_celular"].ToString())) {
                    TelFound = Table.Rows[Cont]["tel_celular"].ToString();
                } /*else if (!String.IsNullOrEmpty(Table.Rows[Cont]["tel_recado"].ToString())) {
                    TelFound = Table.Rows[Cont]["tel_recado"].ToString();
                } else if (!String.IsNullOrEmpty(Table.Rows[Cont]["tel_residencia"].ToString())) {
                    TelFound = Table.Rows[Cont]["tel_residencia"].ToString();
                }*/ else {
                    TelFound = "";
                }

            }

            return TelFound;
        }

        public String DateFormat(String DateAnt) {
            String Date = "";
            String[] DatePart;

            DatePart = DateAnt.Split('/');
            Date = DatePart[2] + "-" + DatePart[1] + "-" + DatePart[0];

            return Date;
        }

        public Boolean EmailCheck(String Email) {
            Regex Reg = new Regex(@"^[a-zA-Z0-9_+-]+[a-zA-Z0-9._+-]*[a-zA-Z0-9_+-]+@[a-zA-Z0-9_+-]+[a-zA-Z0-9._+-]*[.]{1,1}[a-zA-Z]{2,}$");

            return Reg.IsMatch(Email);
        }

        public DataTable CreateWaitingTable() {
            DbHelper DbHlp = new DbHelper();
            DataTable TableInit = new DataTable();
            DataTable Table = new DataTable();
            /*
            TableInit = DbHlp.DataWarden();

            Table.Rows.Add(Send.Destinatario.Nome, "FALHA", Send.Destinatario.Email + " ERRO", "EMAIL INVALIDO");*/

            return Table;
        }

        public void ThreadWait() {
            Thread.Sleep(20000);
        }


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

        public String RandomIdGenerator() {
            String Id = "";
            String Rd = "";

            try {
                Rd = Guid.NewGuid().ToString();

                Id = "msg-" + RandomNumber(0, 99) + "-" + Rd;

                return Id;
            } finally {
                Id = "";
                Rd = "";
            }
        }

    }

}