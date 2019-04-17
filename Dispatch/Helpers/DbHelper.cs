using System;
using System.Data;
using Dispatch.Context;

namespace Dispatch.Helpers {
    public class DbHelper {

        #region Variaveis
        DataTable Table;
        ConnectDb Con;
        #endregion

        public DataTable DisplayData(String Script) {
            Con = new ConnectDb();
            Con.OpenCon();
            Table = new DataTable();
            Con.OpenAdpter(Script);
            Con.Adapt.Fill(Table);
            Con.CloseCon();

            return Table;
        }


        
        public DataTable DataWarden(String Script) {
            Con = new ConnectDb();
            Con.OpenConWarden();
            Table = new DataTable();
            Con.OpenAdpter(Script);
            Con.Adapt.Fill(Table);
            Con.CloseCon();

            return Table;
        }
        
    }
}