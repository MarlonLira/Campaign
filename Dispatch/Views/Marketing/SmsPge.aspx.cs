using System;
using System.Data;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dispatch.Helpers;

namespace Dispatch.Views.Marketing {
    public partial class SmsPge : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if ((DataTable)Session["TableInit"] != null) {
                Preencher((DataTable)Session["TableInit"]);
            } else if(Convert.ToBoolean(Session["IsSms"]) == true) {
                Thread Tcarregar = new Thread(new ThreadStart(SendSms));
                Tcarregar.Name = "TSendSms";
                Tcarregar.Start();
                Session["IsSms"] = false;
            }
            if (Session["ErroThread"] != null) {
                lbl_erro.Text = Convert.ToString(Session["ErroThread"]);
            }
        }
        public Boolean IsSendSms = false;

        DataTable TableInit = new DataTable();

        public void Preencher(DataTable Table = null) {
            Hlp Hlp = new Hlp();
            TableRow[] Row;
            // Row = Hlp.TableLoad((DataTable)Session["Table"]);

            Row = Hlp.TableLoad(TableInit);

            if (Table == null) {
                Session.Add("TableInit", TableInit);
            }
            if (TableInit != null) {
                Row = Hlp.TableLoad((DataTable)Session["TableInit"]);
                tbl_control.Rows.AddRange(Row);
            }
        }

        public void SendSms() {
            Hlp Hlp = new Hlp();
            SendSms SendSms = new SendSms();
            DataTable Table = null;

            String[] Operadores = new string[] { "Marlon|81983460962", "Ricardo|81999269773", "Newton|81998950017" };
            Int32 Count;
            String Nome;
            String Telefone;
            String Texto = "{comprimentoplus} ";
            Int32 QuantidadeSms = 0;
            Int32 Enviados = 0;
            Int32 Falhas = 0;

            try {
                IsSendSms = true;
                if (Session["quantidade_sms"] != null) {
                    QuantidadeSms = (Int32)Session["quantidade_sms"];
                }

                if (Session["Table"] != null) {
                    Table = (DataTable)Session["Table"];
                }

                if (Session["Texto"] != null) {
                    Texto += (String)Session["Texto"];
                }

                TableInit.Columns.Add("ALUNO");
                TableInit.Columns.Add("TELEFONE");
                TableInit.Columns.Add("CAMPANHA");
                TableInit.Columns.Add("STATUS");

                foreach (String Phone in Operadores) {
                    String[] Part = Phone.Split('|');
                    Nome = Part[0];
                    Telefone = Part[1];
                    String NewTexto = Hlp.WhatsMsgFormat(Texto, Nome);

                    SendSms.WebReq(Telefone, NewTexto, out String Campanha, out String Status);

                    TableInit.Rows.Add(Nome, Telefone, Campanha, Status);
                }

                if (Session["List"] != null && !String.IsNullOrEmpty((String)Session["List"])) {
                    tmr_carga.Enabled = false;
                    
                    String List = Convert.ToString(Session["List"]);
                    List.Replace("\n", "");
                    List.Replace("\r", "");
                    List.Replace(";\r\n", "");
                    List.Replace("=\r\n", "");
                    List.Replace("  ", " ");
                    List.Replace("\t", " ");
                    SendSms.WebReq(List, (String)Session["Texto"], out String Campanha, out String Status);
                    String[] CountList = Convert.ToString(Session["List"]).Split(';');

                    TableInit.Rows.Add("Lista", "Qtd. Tel: " + CountList.Length, Campanha, Status);

                   

                    Preencher();
                }
                if (Table != null && Table.Rows.Count > 0) {
                    for (Count = 0; Count < Table.Rows.Count; Count++) {

                        if (Session["Thread-New"] == null) {
                            break;
                        }

                        Nome = Table.Rows[Count]["nome"].ToString();
                        Telefone = Hlp.TelFind(Table, "", Count);
                        Telefone = Hlp.TelFormat(Telefone, false);
                        String NewTexto = Hlp.WhatsMsgFormat(Texto, Nome);

                        if (!String.IsNullOrEmpty(Telefone)) {
                            SendSms.WebReq(Telefone, NewTexto, out String Campanha, out String Status);
                            TableInit.Rows.Add(Nome, Telefone, Campanha, Status);
                          
                            Enviados++;
                           Session["Enviados"] = Enviados;

                        } else {
                            TableInit.Rows.Add(Nome, Telefone + " Inválido", "Erro ao tentar enviar sms, número não valido", "Falha");
                            Session["Falhas"] = Falhas++;
                        }

                        if (Count >= QuantidadeSms) {
                            break;
                        }

                        Preencher();
                        Hlp.ThreadWait();
                        Count++;
                    }
                }
            } catch (Exception Err) {
                Session.Add("ErroThread", Err.Message + " " + Err.InnerException);
            } finally {
                Session["List"] = null;
                Session["IsSms"] = false;
            }
        }
        
    }
}