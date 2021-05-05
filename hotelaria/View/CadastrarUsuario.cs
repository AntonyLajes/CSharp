using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using hotelaria.Control;
//impressão
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace hotelaria.View
{
    public partial class frmUsuario : Form
    {
        Controle control = new Controle();  //instânciar o controle
        DAL.User dadosUser = new DAL.User();

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void CadastrarUsuario_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            try
            {
                dtGridUser.DataSource = control.listarUsuarios();
                FormatarDtGridUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar dados do usuário " + ex.Message);
            }
        }

        private void dtGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // DataGrid 
        private void FormatarDtGridUser()
        {
            //dtGridUser.Columns[0].HeaderText = "Nome";  //Cabeçaho
            //dtGridUser.Columns[0].Width = 50; // Definir Largura

            

            /*for (int i=0; i< dtGridUser.Rows.Count; i++)
            {
                string status = Convert.ToString(dtGridUser.Rows[i].Cells[2].Value.ToString());
                if ( status == "1")
                    dtGridUser.Rows[i].Cells[0].Style.BackColor = Color.LightSalmon;
                else
                    dtGridUser.Rows[i].Cells[0].Style.BackColor = Color.Aquamarine;
            }*/
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCamposUsers();
            HabilitarEdicaoUser();
        }

        private void HabilitarEdicaoUser()
        {
            txtNome.Enabled = true;
            txtSenha.Enabled = true;
            txtConfirmarSenha.Enabled = true;
            cbStatus.Enabled = true;
        }

        private void DesabilitarEdicaoUser()
        {
            txtNome.Enabled = false;
            txtSenha.Enabled = false;
            txtConfirmarSenha.Enabled = false;
            cbStatus.Enabled = false;
        }

        private void LimparCamposUsers()
        {
            txtNome.Text = "";
            txtSenha.Text = "";
            txtConfirmarSenha.Text = "";
            // usado no botão Novo e Salvar para controlar se é Insert ou Update
            dadosUser.Id = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           if  (ValidarCamposUser()){
                if (dadosUser.Id == 0) // se igual a zero é um Novo registro
                {
                    if (SalvarNovoUser())
                    {
                        btnCancelar.PerformClick(); //simula um click no botão cancelar
                        MessageBox.Show("Usuário Inserido com Sucesso!", "ATENÇÃO");
                    }
                    else
                        MessageBox.Show("Erro ao Inserir Usuário!", "ATENÇÃO");
                }
                else //atualização
                {
                    if (SalvarEdicaoUser())
                    {
                        btnCancelar.PerformClick(); //simula um click no botão cancelar
                        MessageBox.Show("Alteração salvo com  Sucesso!", "ATENÇÃO");
                    }
                    else
                        MessageBox.Show("Erro ao atualizar dados do Usuário!", "ATENÇÃO");
                }
            }
        }

        private bool ValidarCamposUser()
        {
            if (String.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Favor informar o Nome do Usuário!", "ATENÇÃO");
                txtNome.Focus();
                return false;
            }else if (String.IsNullOrEmpty(cbStatus.Text))
            {
                MessageBox.Show("Favor escolhe o Status!", "ATENÇÃO");
                cbStatus.Focus();
                return false;

            }
            
            if (dadosUser.Id == 0) // novo usuário
            {
                if (String.IsNullOrEmpty(txtSenha.Text))
                {
                    MessageBox.Show("Favor informar a senha!", "ATENÇÃO");
                    txtSenha.Focus();
                    return false;
                }
                else if (!(txtSenha.Text == txtConfirmarSenha.Text))
                {
                    MessageBox.Show("Senha não são iguais!", "ATENÇÃO");
                    txtSenha.Focus();
                    return false;
                }
            }
             
            return true;
        }

        // Para os alunos estudarem #Dicas - http://www.macoratti.net/17/05/aspncore_identi1.htm
        private bool SalvarNovoUser()
        {
            dadosUser.Nome   = txtNome.Text;
            dadosUser.Senha  = txtSenha.Text;
            dadosUser.Status = cbStatus.Text;
            return control.SalvarNovoUser(dadosUser);
        }
        private bool SalvarEdicaoUser()
        {
            dadosUser.Nome = txtNome.Text;
            dadosUser.Senha = txtSenha.Text;
            dadosUser.Status = cbStatus.Text;
            return control.SalvarEdicaoUser(dadosUser);
        }

        private void dtGridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            carregarDadosForm();
            dadosUser.Id = 0;
        }

        private void dtGridUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            carregarDadosForm();
            HabilitarEdicaoUser();
            txtSenha.Enabled = false;
            txtConfirmarSenha.Enabled = false;
            // Carrega o ID para validar se é edição
            dadosUser.Id = (int)dtGridUser.CurrentRow.Cells[0].Value;
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            if (!(dadosUser.Id == 0))
            {
                DialogResult result = MessageBox.Show("Inativar Usuário?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (control.InativarUser(dadosUser))
                    {
                        btnCancelar.PerformClick();
                        MessageBox.Show("Usuário Inativado com  Sucesso!", "ATENÇÃO");
                    }
                    else
                        MessageBox.Show("Erro ao Inativar o Usuário!", "ATENÇÃO");
                }
            }
        }



        private void carregarDadosForm()
        {
            //Pega o dados da segunda coluna
            txtNome.Text  = dtGridUser.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCamposUsers();
            DesabilitarEdicaoUser();
            Listar();
        }

        private void dtGridUser_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        //https://www.dynamicpdf.com/examples/create-pdf-.net-core?filter=create&gclid=Cj0KCQjw4cOEBhDMARIsAA3XDRjHwHDW78TX88PeeeEsOIeKCyD_Lt3RYMyztX-nDOTi0xrCyR1dKbIaAu2-EALw_wcB
        // https://www.youtube.com/watch?v=92-GXNHLVa4
        // https://www.youtube.com/watch?v=fDbNfewFttI - pegar dados do banco 
        // 
        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            //string diretorioApp = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            //MessageBox.Show(diretorioApp.ToString());
            string dados = "";
            //string nomeArquivo = @"C:\cSharp\turmas-" + DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf";
            string nomeArquivo = @"C:\cSharp\turmas.pdf";
            FileStream arqPDF = new FileStream(nomeArquivo, System.IO.FileMode.Create); // OpenOrCreate

            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4); //, 15f, 15f, 75f, 75f
            // Erro de execções: https://stackoverflow.com/questions/15833285/pdfwriter-getinstance-throws-system-nullreferenceexception
            // provavelmente o PdfWrite já está tratando a exeção, tem q desativar me Depurar+exceções + remover caixa seleção "Execções de tempo de execução"
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, arqPDF);

            doc.Open();

            //criando o objeto
            Paragraph paragrafo1 = new Paragraph(dados,new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL,18, (int) System.Drawing.FontStyle.Bold));
            paragrafo1.Alignment = Element.ALIGN_CENTER;
            paragrafo1.Add("NOME DA EMPRESA\n");
            paragrafo1.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Italic);
            paragrafo1.Add("RELATÓRIO DE USUÁRIOS\n");
            string texto = "Aula de C#-OOP\n";
            paragrafo1.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Italic);
            paragrafo1.Add(texto+"\n");

            //criando o objeto
            Paragraph paragrafo2 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Italic));
            paragrafo1.Alignment = Element.ALIGN_LEFT;
            texto = "Paragráfo 2P\n";
            paragrafo1.Add(texto + "\n");

            doc.Add(paragrafo1);
            doc.Close();

            //abrir o arquivo pdf
            //System.Diagnostics.Process.Start("C:\\Program Files\\Internet Explorer\\iexplore.exe", "www.northwindtraders.com");
            System.Diagnostics.Process.Start("C:\\Program Files\\Internet Explorer\\iexplore.exe","C:\\cSharp\\turmas.pdf");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
