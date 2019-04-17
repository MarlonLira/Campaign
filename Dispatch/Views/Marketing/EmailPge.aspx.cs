using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dispatch.Controller;
using Dispatch.Helpers;

namespace Dispatch.Views.Marketing {
    public partial class EmailPge : Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (String.IsNullOrEmpty(txt_data_inicial.Text)) {
                txt_data_inicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txt_data_final.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        public void LoadTable() {
            Hlp Hlp = new Hlp();
            DbHelper dbHelper = new DbHelper();
            TableRow[] Row;
            MessageCtrl messageCtrl = new MessageCtrl();
            String DataInicial = Hlp.DateFormat(txt_data_inicial.Text);
            String DataFinal = Hlp.DateFormat(txt_data_final.Text);
            

            try {

                String Part = dd_unidades.SelectedValue;
                String[] Empresa_id = Part.Split('-');
                String Script2 = messageCtrl.Pesquisar("ALUNO", Convert.ToInt32(Empresa_id[0]), DataInicial, DataFinal);

                DataTable Table = dbHelper.DisplayData(Script2);

                Row = Hlp.TableLoad(Table);
                tbl_control.Rows.AddRange(Row);
                Session.Add("Table", Table);

            } catch (Exception Err) {

            }
        }

        public void LoadTable2() {
            Hlp Hlp = new Hlp();
            DbHelper dbHelper = new DbHelper();
            DataTable Table = new DataTable();
            TableRow Row = new TableRow();
            TableCell WebCell;
            TableRow WebRow;
            String Script = "SELECT TOP 5 convert(varchar(11), [nome]), [email], [tel_celular], Convert(varchar(10), Convert(date, [data_limite_acesso]))as data FROM FITNESS.TBL_ALUNO order by id desc";

            Table = dbHelper.DisplayData(Script);
            WebRow = new TableRow();
            foreach (DataRow Rows in Table.Rows) {

                foreach (object Cells in Rows.ItemArray) {
                    WebCell = new TableCell();
                    WebCell.Text = Cells.ToString();

                    WebRow.Cells.Add(WebCell);
                }

                tbl_control.Rows.Add(WebRow);

                WebRow = new TableRow();
            }

        }

        protected void btn_carregar_Click(object sender, EventArgs e) {
            LoadTable();
        }

        protected void btn_enviar_Click(object sender, EventArgs e) {
            Response.Redirect("~/Views/Marketing/MessagePge.aspx", false);
        }

    }
}