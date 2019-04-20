using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Dispatch.Context {
    public class ConnectDb : DbContext{


	public ConnectDb()
        : base("DataContext")
        {

        }
        public DbSet<AlunoMdl> Alunos { get; set; }


        // Conexão sql 
        public string CreateCon = ConfigurationManager.ConnectionStrings["gestor2"].ConnectionString;
        public string CreateWardenCon = ConfigurationManager.ConnectionStrings["Campaign"].ConnectionString;

        public SqlConnection Con;
        public SqlCommand Cmd;
        public SqlDataAdapter Adapt;

        //Conexão banco

        public void OpenCon() {
            Con = new SqlConnection(CreateCon);
            Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandTimeout = 600;
            Con.Open();
        }
        /*
        public void OpenConlocal() {
            Con = new SqlConnection(CreateCon2);
            Con.Open();
        }*/

        public void OpenConWarden() {
            Con = new SqlConnection(CreateWardenCon);
            Cmd = new SqlCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandTimeout = 600;
            Con.Open();
        }
        
        public void OpenAdpter(string tabela) {
            Adapt = new SqlDataAdapter(tabela, Con);
            Adapt.SelectCommand.CommandTimeout = 600;
        }

        public void CloseCon() {
            Con.Close();
        }
    }
}