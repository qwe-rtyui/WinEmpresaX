namespace WinFormsKyotoDesk
{
    partial class UserControlSale
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
            comboBoxClientes = new System.Windows.Forms.ComboBox();
            dataGridViewProducts = new System.Windows.Forms.DataGridView();
            button1 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            dataGridViewItenssales = new System.Windows.Forms.DataGridView();
            button2 = new System.Windows.Forms.Button();
            textBoxQuantidade = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItenssales).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Vendas";
            // 
            // comboBoxClientes
            // 
            comboBoxClientes.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBoxClientes.FormattingEnabled = true;
            comboBoxClientes.Location = new System.Drawing.Point(223, 69);
            comboBoxClientes.Name = "comboBoxClientes";
            comboBoxClientes.Size = new System.Drawing.Size(367, 38);
            comboBoxClientes.TabIndex = 1;
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new System.Drawing.Point(6, 22);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowTemplate.Height = 25;
            dataGridViewProducts.Size = new System.Drawing.Size(553, 373);
            dataGridViewProducts.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(862, 532);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(301, 37);
            button1.TabIndex = 3;
            button1.Text = "Concluir Venda";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonFinalizarVenda_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(26, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 15);
            label2.TabIndex = 4;
            label2.Text = "Realizar Venda";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(26, 72);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(191, 30);
            label3.TabIndex = 5;
            label3.Text = "Selecionar Cliente:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewProducts);
            groupBox1.Location = new System.Drawing.Point(25, 111);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(565, 401);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Estoque de produtos";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridViewItenssales);
            groupBox2.Location = new System.Drawing.Point(596, 111);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(567, 401);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Produtos à serem vendidos";
            // 
            // dataGridViewItenssales
            // 
            dataGridViewItenssales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItenssales.Location = new System.Drawing.Point(6, 22);
            dataGridViewItenssales.Name = "dataGridViewItenssales";
            dataGridViewItenssales.RowTemplate.Height = 25;
            dataGridViewItenssales.Size = new System.Drawing.Size(555, 373);
            dataGridViewItenssales.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(376, 527);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(214, 37);
            button2.TabIndex = 8;
            button2.Text = "Adicionar Produdo Selecionado";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonAdicionar_Click;
            // 
            // textBoxQuantidade
            // 
            textBoxQuantidade.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxQuantidade.Location = new System.Drawing.Point(252, 528);
            textBoxQuantidade.Name = "textBoxQuantidade";
            textBoxQuantidade.Size = new System.Drawing.Size(118, 36);
            textBoxQuantidade.TabIndex = 9;
            textBoxQuantidade.KeyPress += textBoxQuantidade_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(31, 532);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(215, 25);
            label4.TabIndex = 10;
            label4.Text = "Quantidade do Produto:";
            // 
            // UserControlSale
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(textBoxQuantidade);
            Controls.Add(button2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(comboBoxClientes);
            Controls.Add(label1);
            Name = "UserControlSale";
            Size = new System.Drawing.Size(1179, 577);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewItenssales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxClientes;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewItenssales;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.Label label4;
    }
}
