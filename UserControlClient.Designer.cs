namespace WinFormsKyotoDesk
{
    partial class UserControlClient
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
            dataGridViewAddListClient = new System.Windows.Forms.DataGridView();
            buttonPgAdd = new System.Windows.Forms.Button();
            buttonRemove = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            textBoxNome = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            textBoxEndereco = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBoxTelefone = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            textBoxEmail = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            buttonSaveClient = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            buttonUpdateClient = new System.Windows.Forms.Button();
            buttonEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAddListClient).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente";
            // 
            // dataGridViewAddListClient
            // 
            dataGridViewAddListClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAddListClient.Location = new System.Drawing.Point(6, 22);
            dataGridViewAddListClient.Name = "dataGridViewAddListClient";
            dataGridViewAddListClient.RowTemplate.Height = 25;
            dataGridViewAddListClient.Size = new System.Drawing.Size(1088, 423);
            dataGridViewAddListClient.TabIndex = 1;
            dataGridViewAddListClient.CellClick += dataGridView1_CellClick;
            // 
            // buttonPgAdd
            // 
            buttonPgAdd.Location = new System.Drawing.Point(24, 30);
            buttonPgAdd.Name = "buttonPgAdd";
            buttonPgAdd.Size = new System.Drawing.Size(103, 37);
            buttonPgAdd.TabIndex = 2;
            buttonPgAdd.Text = "Adicionar";
            buttonPgAdd.UseVisualStyleBackColor = true;
            buttonPgAdd.Click += buttonAdd_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new System.Drawing.Point(242, 30);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new System.Drawing.Size(103, 37);
            buttonRemove.TabIndex = 4;
            buttonRemove.Text = "Remover";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewAddListClient);
            groupBox1.Location = new System.Drawing.Point(20, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1100, 451);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lista de Clientes";
            // 
            // textBoxNome
            // 
            textBoxNome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxNome.Location = new System.Drawing.Point(6, 55);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new System.Drawing.Size(445, 36);
            textBoxNome.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(6, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(78, 30);
            label2.TabIndex = 1;
            label2.Text = "Nome:";
            // 
            // textBoxEndereco
            // 
            textBoxEndereco.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxEndereco.Location = new System.Drawing.Point(6, 127);
            textBoxEndereco.Name = "textBoxEndereco";
            textBoxEndereco.Size = new System.Drawing.Size(445, 36);
            textBoxEndereco.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(6, 94);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(109, 30);
            label3.TabIndex = 3;
            label3.Text = "Endereço:";
            // 
            // textBoxTelefone
            // 
            textBoxTelefone.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxTelefone.Location = new System.Drawing.Point(4, 199);
            textBoxTelefone.Name = "textBoxTelefone";
            textBoxTelefone.Size = new System.Drawing.Size(447, 36);
            textBoxTelefone.TabIndex = 4;
            textBoxTelefone.TextChanged += textBoxTelefone_TextChanged;
            textBoxTelefone.KeyPress += textBoxTelefone_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(6, 166);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(101, 30);
            label4.TabIndex = 5;
            label4.Text = "Telefone:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxEmail.Location = new System.Drawing.Point(4, 271);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new System.Drawing.Size(447, 36);
            textBoxEmail.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(4, 238);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(69, 30);
            label5.TabIndex = 7;
            label5.Text = "Email:";
            // 
            // buttonSaveClient
            // 
            buttonSaveClient.Location = new System.Drawing.Point(936, 391);
            buttonSaveClient.Name = "buttonSaveClient";
            buttonSaveClient.Size = new System.Drawing.Size(141, 37);
            buttonSaveClient.TabIndex = 6;
            buttonSaveClient.Text = "Adicionar Cliente";
            buttonSaveClient.UseVisualStyleBackColor = true;
            buttonSaveClient.Click += buttonSaveClient_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(827, 391);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(103, 37);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Cancelar";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonUpdateClient);
            groupBox2.Controls.Add(buttonCancel);
            groupBox2.Controls.Add(buttonSaveClient);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBoxEmail);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBoxTelefone);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textBoxEndereco);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxNome);
            groupBox2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            groupBox2.Location = new System.Drawing.Point(20, 84);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(1083, 434);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Adicionar Cliente";
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
            // buttonEdit
            // 
            buttonEdit.Location = new System.Drawing.Point(133, 30);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new System.Drawing.Size(103, 37);
            buttonEdit.TabIndex = 7;
            buttonEdit.Text = "Editar";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // UserControlClient
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(buttonEdit);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonRemove);
            Controls.Add(buttonPgAdd);
            Controls.Add(label1);
            Name = "UserControlClient";
            Size = new System.Drawing.Size(1142, 548);
            ((System.ComponentModel.ISupportInitialize)dataGridViewAddListClient).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewAddListClient;
        private System.Windows.Forms.Button buttonPgAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTelefone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSaveClient;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonUpdateClient;
        private System.Windows.Forms.Button buttonEdit;
    }
}
