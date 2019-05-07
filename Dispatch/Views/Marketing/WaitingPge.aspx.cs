using System;
using System.Data;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dispatch.Helpers;

namespace Dispatch.Views.Marketing {
    public partial class WaitingPge : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if ((DataTable)Session["TableInit"] != null) {
                Preencher((DataTable)Session["TableInit"]);
            } else {
                Thread Tcarregar = new Thread(new ThreadStart(LoadLink));
                Tcarregar.Name = "TLoadLink";
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
            if(TableInit != null) {
                Row = Hlp.TableLoad((DataTable)Session["TableInit"]);
                tbl_waiting.Rows.AddRange(Row);
            }
        }

        public void LoadLink() {
            Hlp Hlp = new Hlp();
            DataTable Table;

            Int32 Count;
            String Nome;
            String Email;
            String Telefone;
            String WhatsLink;
            String Texto;
            
            try {
                Table = (DataTable)Session["Table"];
                Texto = (String)Session["Texto"];

                TableInit.Columns.Add("Nome");
                TableInit.Columns.Add("Email");
                TableInit.Columns.Add("Telefone");
                TableInit.Columns.Add("Link");

                for (Count = 0; Count < Table.Rows.Count; Count ++) {

                    if(Session["Thread-New"] == null) {
                        break;
                    }

                    Nome = Table.Rows[Count]["nome"].ToString();
                    Email = Table.Rows[Count]["email"].ToString();
                    Telefone = Hlp.TelFind(Table, "", Count);
                    Telefone = Hlp.TelFormat(Telefone);
                    
                    WhatsLink = Hlp.EncurtarLink(Hlp.WhatsLinkGenerator(Telefone, Hlp.WhatsMsgFormat(Texto, Nome)));
                    WhatsLink = @"<a style='color: white;' target='_blank' href='" + WhatsLink + @"'>" + WhatsLink + @"</a>";

                    if (!String.IsNullOrEmpty(Telefone)) {
                        TableInit.Rows.Add(Nome, Email, Telefone, WhatsLink);

                    } else {
                        TableInit.Rows.Add(Nome, Email, "Inválido", "Erro ao tentar gerar o Link");
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

