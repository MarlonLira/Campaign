using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dispatch.Helpers;

namespace Dispatch.Views.Marketing {
    public partial class EmailPge : Page {
        protected void Page_Load(object sender, EventArgs e) {

            
        }

        public void LoadTable() {
            Hlp Hlp = new Hlp();
            DbHelper dbHelper = new DbHelper();
            TableRow[] Row;
            String Script = "SELECT TOP 10 convert(varchar(20), [nome]), [email], [tel_celular], Convert(varchar(10), Convert(date, [data_limite_acesso]))as data FROM FITNESS.TBL_ALUNO order by id desc";

            Row = Hlp.TableLoad(Script);
            tbl_control.Rows.AddRange(Row);

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