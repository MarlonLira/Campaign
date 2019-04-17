using Dispatch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dispatch.Views.Marketing {
    public partial class WaitingPge : Page {
        protected void Page_Load(object sender, EventArgs e) {
            Preencher();
        }

        public void Preencher() {
            Hlp Hlp = new Hlp();
            DbHelper dbHelper = new DbHelper();
            TableRow[] Row;
            String Script = "SELECT TOP 10 convert(varchar(30), [nome]),[status], [email], [tel_celular], Convert(varchar(10), Convert(date, [data_limite_acesso]))as data FROM FITNESS.TBL_ALUNO order by id desc";

            Row = Hlp.TableLoad(Script);
            tbl_waiting.Rows.AddRange(Row);

        }
    }
}

