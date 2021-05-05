
namespace hotelaria.View
{
    partial class CadastrarFornecedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtGridFornecedor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridFornecedor)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridFornecedor
            // 
            this.dtGridFornecedor.AllowUserToAddRows = false;
            this.dtGridFornecedor.AllowUserToDeleteRows = false;
            this.dtGridFornecedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridFornecedor.Location = new System.Drawing.Point(141, 178);
            this.dtGridFornecedor.Name = "dtGridFornecedor";
            this.dtGridFornecedor.ReadOnly = true;
            this.dtGridFornecedor.RowTemplate.Height = 25;
            this.dtGridFornecedor.Size = new System.Drawing.Size(482, 150);
            this.dtGridFornecedor.TabIndex = 0;
            // 
            // CadastrarFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtGridFornecedor);
            this.Name = "CadastrarFornecedor";
            this.Text = "CadastrarFornecedor";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridFornecedor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridFornecedor;
    }
}