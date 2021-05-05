using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

//CRUD https://www.iodocs.com/insert-update-delete-display-data-in-mysql-using-net/
namespace hotelaria.DAL
{
    class LoginDaoComandos
    {
        MySqlCommand cmd = new MySqlCommand();
        Conexao con = new Conexao();
        MySqlDataReader dr; //armazena dados do banco
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataTable dt = new DataTable();  //using System.Data;

        User dadosUsers = new User();

        public User validarLogin(String usuario, String senha)
        {
            String query = "SELECT id,nome,status FROM users WHERE nome=@user AND senha = @password AND status=@status";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@user", usuario);
            cmd.Parameters.AddWithValue("@password", senha);
            cmd.Parameters.AddWithValue("@status", "Ativo");

            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)  // achou
                {
                    while (dr.Read())
                    {
                        dadosUsers.Id     = dr.GetInt32(0);
                        dadosUsers.Nome   = dr.GetString(1);
                        dadosUsers.Status = dr.GetString(2);
                    }
                    //Console.WriteLine("LoginDaoComandos: validarLogin: dr.HasRows = {0}", dr.HasRows);
                    return dadosUsers; //true
                }
                con.desconectar();
                dr.Close();
            }
            catch (Exception err)
            {
                //throw;
                Console.WriteLine("LoginDaoComandos: validarLogin: Erro =" + err.Message);
            }
            return dadosUsers; // false;
        }

        public System.Data.DataTable listarUsuarios()
        {
            //http://www.macoratti.net/18/09/c_crudcbo1.htm
            cmd.CommandText = "SELECT id,nome, status FROM users";
            da.SelectCommand = cmd;
            try
            {
                cmd.Connection = con.conectar();
                dt.Clear();
                da.Fill(dt);
               
                con.desconectar();
            }
            catch (Exception err)
            {
                Console.WriteLine("LoginDaoComandos: listarUsuarios: Erro =" + err.Message);
            }
            return dt;
        }

        public bool InserirUser(User dados)
        {
            String query = "INSERT INTO users (nome,senha,status) VALUES (@nome,@senha,@status)";
            cmd.CommandText = query;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nome", dados.Nome);
            cmd.Parameters.AddWithValue("@senha", dados.Senha);
            cmd.Parameters.AddWithValue("@status", dados.Status);

            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery(); // executa ao cmd SQL
                con.desconectar();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool AtualizarDadosUser(User dados)
        {
            //String query = "UPDATE users SET nome=@nomedAtualizar, senha=@senhadAtualizar, status=@status WHERE id=@idAtualizar";
            String query = "UPDATE users SET nome=@nomedAtualizar, status=@status WHERE id=@idAtualizar";
            cmd.Parameters.Clear();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nomedAtualizar", dados.Nome);
            //cmd.Parameters.AddWithValue("@senhadAtualizar", dados.Senha);
            cmd.Parameters.AddWithValue("@idAtualizar", dados.Id);
            cmd.Parameters.AddWithValue("@status", dados.Status);

            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery(); // executa ao cmd SQL
                con.desconectar();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool InativarUser(User dados)
        {
            String query = "UPDATE users SET status=0 WHERE id=@codigo";
            cmd.Parameters.Clear();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@codigo", dados.Id);

            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery(); // executa ao cmd SQL
                con.desconectar();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


    }
}
