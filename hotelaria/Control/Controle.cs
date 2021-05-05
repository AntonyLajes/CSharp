using System;
using System.Collections.Generic;
using System.Text;
using hotelaria.DAL;
using System.Windows.Forms;
using System.Data;

namespace hotelaria.Control
{
     public class Controle
    {
        LoginDaoComandos loginDao = new LoginDaoComandos();

        public User validarUsuario(String usuario, String senha)
        {
            //LoginDaoComandos loginDao = new LoginDaoComandos();

            User dadosUsers = new User();            
            dadosUsers =  loginDao.validarLogin(usuario,senha);
            return dadosUsers;
        }

        public DataTable listarUsuarios()
        {
            //LoginDaoComandos loginDao = new LoginDaoComandos();

            DataTable dt = new DataTable();
            dt = loginDao.listarUsuarios();
            return dt;
        }

        public bool SalvarNovoUser(User dados)
        {
            return loginDao.InserirUser(dados);
        }

        public bool SalvarEdicaoUser(User dados)
        {
            return loginDao.AtualizarDadosUser(dados);
        }

        public bool InativarUser(User dados)
        {
            return loginDao.InativarUser(dados);
        }

    }
}
