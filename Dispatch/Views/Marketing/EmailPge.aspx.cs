using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dispatch.Controller;
using Dispatch.Helpers;

namespace Dispatch.Views.Marketing {
    public partial class EmailPge : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Convert.ToBoolean(Session["IsUser"]) != true) {
                Response.Redirect("~/LoginPge.aspx", false);
            }

            InitPage();
        }

        public void LoadTable() {
            Hlp Hlp = new Hlp();
            DbHelper dbHelper = new DbHelper();
            TableRow[] Row;
            DataTable Table = null;
            MessageCtrl messageCtrl = new MessageCtrl();

            String DataInicial = txt_data_inicial.Text;
            String DataFinal = txt_data_final.Text;
            String Destinatario = dd_destinatario.SelectedValue;
            
            try {

                String Part = dd_unidades.SelectedValue;
                String[] Empresa_id = Part.Split('-');
                if (!String.IsNullOrEmpty(DataInicial) && !String.IsNullOrEmpty(DataFinal)) {
                    String Script2 = messageCtrl.Pesquisar(Destinatario, Convert.ToInt32(Empresa_id[0]), DataInicial, DataFinal);
                    Table = dbHelper.DisplayData(Script2);
                }

                Row = Hlp.TableLoad(Table);
                tbl_control.Rows.AddRange(Row);
                Session.Add("Table", Table);

            } catch (Exception Err) {

            }
        }

        protected void btn_carregar_Click(object sender, EventArgs e) {

            try {
                Session["Thread-New"] = null;
                LoadTable();
            } catch (Exception Err) {

            }
        }

        public void InitPage() {
            if ((String)Session["User"] != "ADMIN") {
                pnl_control.Enabled = false;
                dd_unidades.SelectedValue = (String)Session["User"];
            }
        }

        protected void btn_enviar_Click(object sender, EventArgs e) {
            try {

                if (Session["Table"] != null) {
                    Response.Redirect("~/Views/Marketing/MessagePge.aspx", false);
                } else {

                }
                
            } catch (Exception Err) {
                
            }
        }

    }
}