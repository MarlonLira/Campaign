using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dispatch.Views.Marketing {
    public partial class EmailPge : Page {
        protected void Page_Load(object sender, EventArgs e) {

            carregar();
        }

        public void carregar() {
            DataTable Table = new DataTable();
            TableRow Row = new TableRow();
            TableCell Cell;
            TableCell[] Cell2 = new TableCell[5];
            string[] array = new string[] { "Testando", "Testando2", "Testando3", "Testando4" };
            Table.Columns.Add("Nome");
            Table.Columns.Add("Email");
            Table.Columns.Add("Telefone");
            Table.Columns.Add("Data");

            Table.Rows.Add("Marlon", "Marlonlira2@gmail.com", "55888555", "03/05/1995");
            
            Int32 count = 1;
           
            foreach (string arrays in array){
                Cell = new TableCell();
                Cell.Text = arrays;
                count++;
                Row.Cells.Add(Cell);
            }

            Table.Rows.Add(Row);
            tbl_control2.Rows.Add(Row);
            
        }


    }
}