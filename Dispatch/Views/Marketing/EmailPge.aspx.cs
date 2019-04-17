using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
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
            String[] Part = Hlp.EmpresaFind(tbl_empresa);
            String [] Empresa_id = Part[0].Split('-');
            //String Script = "SELECT TOP 10 convert(varchar(20), [nome]), [email], [tel_celular], Convert(varchar(10), Convert(date, [data_limite_acesso]))as data FROM FITNESS.TBL_ALUNO order by id desc";

            String Script2 = messageCtrl.Pesquisar("ALUNO", Convert.ToInt32(Empresa_id[0]), "2019-04-01", "2019-04-16");

            DataTable Table = dbHelper.DisplayData(Script2);
           
            Row = Hlp.TableLoad(Table);
            tbl_control.Rows.AddRange(Row);
            Session.Add("Table", Table);

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