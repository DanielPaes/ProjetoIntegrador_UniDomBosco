using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    class Controle
    {

        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public String mensagem;

        public void Cadastrar(string nome, string cpf, string telefone, string nascimento, string cep, string endereco, string complemento, string numero, string vacina, string lote, string registro)
        {
            cmd.CommandText = "INSERT INTO pessoas VALUES (@nome, @cpf, @telefone, @nascimento, @cep, @endereco, @complemento, @numero, @vacina, @lote, @registro)";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@telefone", telefone);
            cmd.Parameters.AddWithValue("@nascimento", nascimento);
            cmd.Parameters.AddWithValue("@cep", cep);
            cmd.Parameters.AddWithValue("@endereco", endereco);
            cmd.Parameters.AddWithValue("@complemento", complemento);
            cmd.Parameters.AddWithValue("@numero", numero);
            cmd.Parameters.AddWithValue("@vacina", vacina);
            cmd.Parameters.AddWithValue("@lote", lote);
            cmd.Parameters.AddWithValue("@registro", registro);

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
                this.mensagem = "Registrado com sucesso!";
            }
            catch
            {
                this.mensagem = "Ocorreu um erro.";
            }
        }

        public void Deletar(String cpf)
        {
            cmd.CommandText = "DELETE FROM pessoas WHERE cpf = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
                this.mensagem = "Registro deletado!";
            }
            catch
            {
                this.mensagem = "Ocorreu um erro.";
            }
        }

        public DataTable Consultar()
        {
            cmd.CommandText = "SELECT * from pessoas";


            try
            {
                cmd.Connection = conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                conexao.Desconectar();
                return dt;
            }
            catch
            {
                this.mensagem = "Ocorreu um erro.";
                DataTable dt = new DataTable();
                return dt;
            }
        }

        public DataTable ConsultarCpf(string cpf, string nome)
        {
            cmd.CommandText = "SELECT * from pessoas where cpf = @cpf or nome=@nome";

            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@nome", nome);

            try
            {
                cmd.Connection = conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                conexao.Desconectar();
                return dt;
            }
            catch
            {
                this.mensagem = "Ocorreu um erro.";
                DataTable dt = new DataTable();
                return dt;
            }
        }

    }
}
