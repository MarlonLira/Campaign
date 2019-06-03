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
            } else {
                Thread Tcarregar = new Thread(new ThreadStart(SendSms));
                Tcarregar.Name = "TSendSms";
                Tcarregar.Start();
            }
            if (Session["ErroThread"] != null) {
                lbl_erro.Text = Convert.ToString(Session["ErroThread"]);
            }
        }

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
            DataTable Table;

            Int32 Count;
            String Nome;
            String Telefone;
            String Texto = "{comprimentoplus} ";
            Int32 QuantidadeSms = (Int32)Session["quantidade_sms"];

            try {
                Table = (DataTable)Session["Table"];
                Texto += (String)Session["Texto"];

                TableInit.Columns.Add("ALUNO");
                TableInit.Columns.Add("TELEFONE");
                TableInit.Columns.Add("CAMPANHA");
                TableInit.Columns.Add("STATUS");

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

                    } else {
                        TableInit.Rows.Add(Nome, Telefone + " Inválido", "Erro ao tentar enviar sms, número não valido" , "Falha");
                    }

                    if (Count >= QuantidadeSms) {
                        break;
                    }

                    Preencher();
                    Hlp.ThreadWait();
                    Count++;
                }
            } catch (Exception Err) {
                Session.Add("ErroThread", Err.Message + " " + Err.InnerException);
            }

        }
    }
}