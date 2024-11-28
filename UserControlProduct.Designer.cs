namespace WinFormsKyotoDesk
{
    partial class UserControlProduct
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            buttonUpdateClient = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            buttonSaveClient = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            textBoxEstoque = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            textBoxPreco = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBoxDescricao = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            textBoxNome = new System.Windows.Forms.TextBox();
            buttonRemove = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            dataGridViewAddProduct = new System.Windows.Forms.DataGridView();
            buttonPgAdd = new System.Windows.Forms.Button();
            buttonEdit = new System.Windows.Forms.Button();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAddProduct).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Produto";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonUpdateClient);
            groupBox2.Controls.Add(buttonCancel);
            groupBox2.Controls.Add(buttonSaveClient);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBoxEstoque);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBoxPreco);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBoxDescricao);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxNome);
            groupBox2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            groupBox2.Location = new System.Drawing.Point(20, 84);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(1083, 434);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Adicionar Produto";
            groupBox2.Visible = false;
            // 
            // buttonUpdateClient
            // 
            buttonUpdateClient.Location = new System.Drawing.Point(936, 391);
            buttonUpdateClient.Name = "buttonUpdateClient";
            buttonUpdateClient.Size = new System.Drawing.Size(141, 37);
            buttonUpdateClient.TabIndex = 8;
            buttonUpdateClient.Text = "Salvar Edição";
            buttonUpdateClient.UseVisualStyleBackColor = true;
            buttonUpdateClient.Click += buttonEditar_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(827, 391);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(103, 37);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Cancelar";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += button5_Click;
            // 
            // buttonSaveClient
            // 
            buttonSaveClient.Location = new System.Drawing.Point(936, 391);
            buttonSaveClient.Name = "buttonSaveClient";
            buttonSaveClient.Size = new System.Drawing.Size(141, 37);
            buttonSaveClient.TabIndex = 6;
            buttonSaveClient.Text = "Adicionar Produto";
            buttonSaveClient.UseVisualStyleBackColor = true;
            buttonSaveClient.Click += buttonSaveProduct_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(6, 238);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(95, 30);
            label5.TabIndex = 7;
            label5.Text = "Estoque:";
            // 
            // textBoxEstoque
            // 
            textBoxEstoque.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxEstoque.Location = new System.Drawing.Point(6, 271);
            textBoxEstoque.Name = "textBoxEstoque";
            textBoxEstoque.Size = new System.Drawing.Size(445, 36);
            textBoxEstoque.TabIndex = 6;
            textBoxEstoque.KeyPress += textBoxEstoque_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(6, 166);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(73, 30);
            label4.TabIndex = 5;
            label4.Text = "Preço:";
            // 
            // textBoxPreco
            // 
            textBoxPreco.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxPreco.Location = new System.Drawing.Point(6, 199);
            textBoxPreco.Name = "textBoxPreco";
            textBoxPreco.Size = new System.Drawing.Size(445, 36);
            textBoxPreco.TabIndex = 4;
            textBoxPreco.KeyPress += textBoxPreco_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(6, 94);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 30);
            label3.TabIndex = 3;
            label3.Text = "Descrição";
            // 
            // textBoxDescricao
            // 
            textBoxDescricao.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxDescricao.Location = new System.Drawing.Point(6, 127);
            textBoxDescricao.Name = "textBoxDescricao";
            textBoxDescricao.Size = new System.Drawing.Size(445, 36);
            textBoxDescricao.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(6, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(195, 30);
            label2.TabIndex = 1;
            label2.Text = "Nome do produto:";
            // 
            // textBoxNome
            // 
            textBoxNome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxNome.Location = new System.Drawing.Point(6, 55);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new System.Drawing.Size(445, 36);
            textBoxNome.TabIndex = 0;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new System.Drawing.Point(238, 28);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new System.Drawing.Size(103, 37);
            buttonRemove.TabIndex = 4;
            buttonRemove.Text = "Remover";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewAddProduct);
            groupBox1.Location = new System.Drawing.Point(20, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1100, 451);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lista de Produtos";
            // 
            // dataGridViewAddProduct
            // 
            dataGridViewAddProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAddProduct.Location = new System.Drawing.Point(6, 22);
            dataGridViewAddProduct.Name = "dataGridViewAddProduct";
            dataGridViewAddProduct.RowTemplate.Height = 25;
            dataGridViewAddProduct.Size = new System.Drawing.Size(1088, 423);
            dataGridViewAddProduct.TabIndex = 1;
            dataGridViewAddProduct.CellClick += dataGridView1_CellClick;
            // 
            // buttonPgAdd
            // 
            buttonPgAdd.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            buttonPgAdd.ForeColor = System.Drawing.Color.White;
            buttonPgAdd.Location = new System.Drawing.Point(20, 28);
            buttonPgAdd.Name = "buttonPgAdd";
            buttonPgAdd.Size = new System.Drawing.Size(103, 37);
            buttonPgAdd.TabIndex = 7;
            buttonPgAdd.Text = "Adicionar";
            buttonPgAdd.UseVisualStyleBackColor = false;
            buttonPgAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new System.Drawing.Point(129, 28);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new System.Drawing.Size(103, 37);
            buttonEdit.TabIndex = 10;
            buttonEdit.Text = "Editar";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // UserControlProduct
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(buttonEdit);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonRemove);
            Controls.Add(buttonPgAdd);
            Controls.Add(label1);
            Name = "UserControlProduct";
            Size = new System.Drawing.Size(1142, 548);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAddProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonUpdateClient;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonSaveClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEstoque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPreco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewAddProduct;
        private System.Windows.Forms.Button buttonPgAdd;
        private System.Windows.Forms.Button buttonEdit;
    }
}
