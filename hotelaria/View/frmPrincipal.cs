using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hotelaria.View
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            using (frmLogin objForm = new frmLogin())
            {
                objForm.ShowDialog();
                //if ((bool)objForm.Tag)   
                if (objForm.Tag.Equals(""))   //se vazio não fez login
                {
                    Application.Exit();
                }   
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            frmUsuario frmUser = new frmUsuario();
            frmUser.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Program.dadosLogin.Nome);
        }
    }
}
