using System;
using System.Collections.Generic;
using System.Text;

namespace hotelaria.DAL
{
    public class User
    {
        int id;
        string nome;
        string senha;
        string status;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Status { get => status; set => status = value; }
    }
}
