using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    class Conexao
    {

        SqlConnection con = new SqlConnection();

        public Conexao()
        {
            con.ConnectionString = "Data Source=localhost;Initial Catalog=RegistraVac; Integrated Security=true";

        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public SqlConnection Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }

            return con;
        }

    }
}
