using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace hotelaria.DAL
{
    public class Conexao
    {
        MySqlConnection con = new MySqlConnection();

        public Conexao()  // construtor
        {
            con.ConnectionString = @"server=localhost;uid=root;password=;database=unip33";
        }
        public MySqlConnection conectar()
        {
            //verifica se a conexão com o banco está fechada
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
