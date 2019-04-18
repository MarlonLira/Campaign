using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dispatch.Controller;
using Dispatch.Helpers;

namespace Dispatch.Views.Marketing {
    public partial class EmailPge : Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public void LoadTable() {
            Hlp Hlp = new Hlp();
            DbHelper dbHelper = new DbHelper();
            TableRow[] Row;
            MessageCtrl messageCtrl = new MessageCtrl();
            String DataInicial = txt_data_inicial.Text;
            String DataFinal = txt_data_final.Text;
            String Destinatario = dd_destinatario.SelectedValue;

            try {

                String Part = dd_unidades.SelectedValue;
                String[] Empresa_id = Part.Split('-');
                String Script2 = messageCtrl.Pesquisar(Destinatario, Convert.ToInt32(Empresa_id[0]), DataInicial, DataFinal);

                DataTable Table = dbHelper.DisplayData(Script2);

                Row = Hlp.TableLoad(Table);
                tbl_control.Rows.AddRange(Row);
                Session.Add("Table", Table);

            } catch (Exception Err) {

            }
        }

        protected void btn_carregar_Click(object sender, EventArgs e) {
            LoadTable();
        }

        protected void btn_enviar_Click(object sender, EventArgs e) {
            try {
                Response.Redirect("~/Views/Marketing/MessagePge.aspx", false);
            } catch (Exception Err) {
                
            }
        }

    }
}