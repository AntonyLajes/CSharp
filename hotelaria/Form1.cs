using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using hotelaria.Control;
using hotelaria.DAL;

namespace hotelaria
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e) {

            if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Favor informar o Usuário!", "ATENÇÃO");
                txtUsuario.Focus();
                return;
            } ///else if
            if (String.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Favor informar a Senha!", "ATENÇÃO");
                txtSenha.Focus();
                return;
            }

            pictureBox1.Visible = true; //gif

            Controle control = new Controle();
            //Variável/Objeto Global do tipo User
            Program.dadosLogin = control.validarUsuario(txtUsuario.Text, txtSenha.Text);

            if (!String.IsNullOrEmpty(Program.dadosLogin.Nome))
            {
                this.Tag = true;
                pictureBox1.Visible = false;
                MessageBox.Show("Login efetuado com sucesso!\n\nSeja bem-vindo(a) "+ Program.dadosLogin.Nome);
                Close();
            }
            else
            {
                MessageBox.Show("Usuário e senha Inválida!");
                pictureBox1.Visible = false;
            }

        }

       


        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabelCadastrarSe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                txtSenha.Focus();
            }
        }
        private void txtSenha_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Enter){
                btnLogin.Focus();
            }
        }
        private void txtUsuario_Enter(object sender, EventArgs e){
            txtUsuario.BackColor = Color.LightSkyBlue;
        }
        private void txtUsuario_Leave(object sender, EventArgs e){
            txtUsuario.BackColor = Color.White;
        }
        private void txtSenha_Enter(object sender, EventArgs e){
            txtSenha.BackColor = Color.LightSkyBlue;
        }
        private void txtSenha_Leave(object sender, EventArgs e){
            txtSenha.BackColor = Color.White;
        }

       
    }
}
