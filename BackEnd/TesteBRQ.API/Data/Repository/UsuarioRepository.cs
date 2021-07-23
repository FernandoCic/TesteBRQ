using Microsoft.Extensions.Configuration;
using Raven.Database.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteBRQ.API.Data.Repository.Interface;
using TesteBRQ.API.Entities;
using TesteBRQ.API.Enums;

namespace TesteBRQ.API.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private const string _connectionString = "Server=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TesteBRQ;Data Source=DESKTOP-E83LJFS\\SQLEXPRESS;";
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string comandoSQL = "Delete from Usuarios where Id = @id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Usuario GetUsuarioPorId(int id)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Usuarios WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(dataReader["Id"]);
                    usuario.Nome = dataReader["Nome"].ToString();
                    usuario.CPF = dataReader["CPF"].ToString();
                    usuario.Email = dataReader["Email"].ToString();
                    usuario.Sexo = (ESexo)Enum.Parse(typeof(ESexo), dataReader["Sexo"].ToString());
                    usuario.DataNascimento = Convert.ToDateTime(dataReader["DataNascimento"]);
                    usuario.Telefone = dataReader["Telefone"].ToString();
                }
            }
            return usuario;
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            List<Usuario> lstUsuarios = new List<Usuario>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, Nome, CPF, Email, Sexo, DataNascimento, Telefone from Usuarios", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                Usuario usuario = null;
                while (dataReader.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(dataReader["Id"]);
                    usuario.Nome = dataReader["Nome"].ToString();
                    usuario.CPF = dataReader["CPF"].ToString();
                    usuario.Email = dataReader["Email"].ToString();
                    usuario.Sexo = (ESexo)Enum.Parse(typeof(ESexo), dataReader["Sexo"].ToString());
                    usuario.DataNascimento = Convert.ToDateTime(dataReader["DataNascimento"]);
                    usuario.Telefone = dataReader["Telefone"].ToString();
                    lstUsuarios.Add(usuario);
                }
                con.Close();
            }
            return lstUsuarios;
        }

        public void AddUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string comandoSQL = "Insert into Usuarios (Nome, CPF, Email, Sexo, DataNascimento, Telefone) Values(@Nome, @CPF, @Email, @Sexo, @DataNascimento, @Telefone)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", usuario.Id);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@CPF", usuario.CPF);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
                cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string comandoSQL = "Update Usuarios set Nome = @Nome, CPF = @CPF, Email = @Email, Sexo = @Sexo, DataNascimento = @DataNascimento, Telefone = @Telefone WHERE Id= " + usuario.Id;
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", usuario.Id);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@CPF", usuario.CPF);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
                cmd.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
    }
}
