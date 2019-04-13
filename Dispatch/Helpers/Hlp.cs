using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Dispatch.Helpers {
    public class Hlp {

        public TableRow[] TableLoad(String Script) {
            Table WebTable;
            TableCell WebCell;
            TableRow WebRow;
            TableRow[] WebRow2;
            DataTable Table;
            DbHelper dbHelper;
            
            try {

                WebTable = new Table();
                dbHelper = new DbHelper();
                Table = new DataTable();
                WebRow = new TableRow();

                Table = dbHelper.DisplayData(Script);

                WebRow2 = new TableRow[Table.Rows.Count];
                int count = 0;
                foreach (DataRow Rows in Table.Rows) {

                    foreach (object Cells in Rows.ItemArray) {
                        WebCell = new TableCell();
                        WebCell.Text = Cells.ToString();

                        WebRow.Cells.Add(WebCell);
                    }

                    WebTable.Rows.Add(WebRow);
                    WebRow2[count] = WebRow;
                    WebRow = new TableRow();
                    count++;
                }


            } catch (Exception Err) {
                WebTable = null;
                WebRow2 = null;
            }

            return WebRow2;
        }
    }
}