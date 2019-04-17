using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dispatch.Helpers;

namespace Dispatch.Views.Marketing {
    public partial class WaitingPge : Page {
        protected void Page_Load(object sender, EventArgs e) {
            Preencher();
        }

        public void Preencher() {
            Hlp Hlp = new Hlp();
            DbHelper dbHelper = new DbHelper();
            TableRow[] Row;
            //String Script = "SELECT TOP 10 convert(varchar(30), [nome]),[status], [email], [tel_celular], Convert(varchar(10), Convert(date, [data_limite_acesso]))as data FROM FITNESS.TBL_ALUNO order by id desc";
            DataTable teste = new DataTable();
            //teste.Rows[]
            try {
                Row = Hlp.TableLoad((DataTable)Session["Table"]);
                tbl_waiting.Rows.AddRange(Row);
            } catch (Exception Err) {

            }

        }
    }
}

