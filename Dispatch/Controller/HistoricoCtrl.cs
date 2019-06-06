using System;
using System.Data.SqlClient;
using Dispatch.Context;

namespace Dispatch.Controller {
    public class HistoricoCtrl {


        protected const String COMMOM = "@matricula, @nome, @mensagem, @telefone, " +
                "@email, @empresa, @empresa_id, @status_msg, @data_ult_msg, @data_prox_msg, @observacao";

        public string Atualizar() {
            String Query = "EXEC [Zap].[stp_historico_alterar] " + COMMOM;

            return Query;
        }
        /*
        public string Cadastrar(WhatsAppSendPST App) {
            String Query = "EXEC [Zap].[stp_historico_cadastrar] " + COMMOM;
            AppEdit = App;
            Param(Query);

            return Query;
        }*/
        public string Cadastrar() { throw new NotImplementedException(); }
        public string Deletar() {
            throw new NotImplementedException();
        }
        public string Pesquisar() { throw new NotImplementedException(); }
        public string Pesquisar(String Matricula) {
            String Query = "SELECT * FROM [Zap].[viw_historico] WHERE matricula = " + "'" + Matricula + "'";

            return Query;
        }
        public string Pesquisar(Int32 Empresa_id, String DataInicial, String DataFinal) {
            String Query = "SELECT * FROM [Zap].[viw_historico] WHERE empresa_id = " + Empresa_id +
                " AND data_ult_msg BETWEEN " + "'" + DataInicial + "'" + " AND " + "'" + DataFinal + "'";

            return Query;
        }
        
        public void Param(String Query) {
            ConnectDb Dba = new ConnectDb();
            Dba.OpenConWarden();
            /*AppEdit.Destinatario = new AppEdit.Destinatario();
            //App = new WhatsAppSend();
            AppEdit.Destinatario.Empresa = new Empresa();
            /*
            AppEdit.Destinatario.Nome = "Felipe";
            AppEdit.Destinatario.Matricula = "000222";
            AppEdit.Destinatario.Telefone = "99775566";
            App.Texto = "testando novamente";
            AppEdit.Destinatario.Email = "Felipe@gmail.com";
            AppEdit.Destinatario.Empresa.Id = 1;*/

            DateTime Data = DateTime.Now;

            try {
                using (SqlCommand command = Dba.Con.CreateCommand()) {

                    command.CommandText = @Query;
                    /*
                    SqlParameter Nome = new SqlParameter("@nome", AppEdit.Destinatario.Nome);
                    SqlParameter Matricula = new SqlParameter("@matricula", AppEdit.Destinatario.Matricula);
                    SqlParameter Mensagem = new SqlParameter("@mensagem", AppEdit.Texto);
                    SqlParameter DataUltMsg = new SqlParameter("@data_ult_msg", Data);
                    SqlParameter DataProxMsg = new SqlParameter("@data_prox_msg", Data.AddMonths(1));
                    SqlParameter Observacao = new SqlParameter("@observacao", DBNull.Value);
                    SqlParameter Telefone = new SqlParameter("@telefone", DBNull.Value);
                    SqlParameter Email = new SqlParameter("@email", DBNull.Value);
                    SqlParameter StatusM = new SqlParameter("@status_msg", DBNull.Value);
                    SqlParameter Empresa = new SqlParameter("@empresa", DBNull.Value);
                    SqlParameter Empresa_id = new SqlParameter("@empresa_id", DBNull.Value);

                    if (!String.IsNullOrEmpty(AppEdit.Destinatario.Telefone)) {

                        Telefone = new SqlParameter("@telefone", AppEdit.Destinatario.Telefone);
                    }

                    if (!String.IsNullOrEmpty(AppEdit.Destinatario.Email)) {

                        Email = new SqlParameter("@email", AppEdit.Destinatario.Email);
                    }

                    if (!String.IsNullOrEmpty(AppEdit.Status)) {

                        StatusM = new SqlParameter("@status_msg", AppEdit.Status);
                    }

                    if (!String.IsNullOrEmpty(AppEdit.Destinatario.Empresa.Nome)) {

                        Empresa = new SqlParameter("@empresa", AppEdit.Destinatario.Empresa.Nome);

                    }
                    if (!String.IsNullOrEmpty(Convert.ToString(AppEdit.Destinatario.Empresa.Id))) {

                        Empresa_id = new SqlParameter("@empresa_id", AppEdit.Destinatario.Empresa.Id);
                    }

                    command.Parameters.Add(Nome);
                    command.Parameters.Add(Matricula);
                    command.Parameters.Add(Mensagem);
                    command.Parameters.Add(Telefone);
                    command.Parameters.Add(Email);
                    command.Parameters.Add(StatusM);
                    command.Parameters.Add(Empresa);
                    command.Parameters.Add(Empresa_id);
                    command.Parameters.Add(DataUltMsg);
                    command.Parameters.Add(DataProxMsg);
                    command.Parameters.Add(Observacao);
                    command.ExecuteNonQuery();*/
                }
            } catch (Exception Err) {
                Param(Atualizar());
            }


        }
    }
}