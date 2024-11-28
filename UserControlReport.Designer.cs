namespace WinFormsKyotoDesk
{
    partial class UserControlReport
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
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            groupBoxSale = new System.Windows.Forms.GroupBox();
            dataGridViewListaVendas = new System.Windows.Forms.DataGridView();
            groupBoxStock = new System.Windows.Forms.GroupBox();
            dataGridViewStock = new System.Windows.Forms.DataGridView();
            groupBoxClient = new System.Windows.Forms.GroupBox();
            dataGridViewClient = new System.Windows.Forms.DataGridView();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            groupBoxSale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewListaVendas).BeginInit();
            groupBoxStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStock).BeginInit();
            groupBoxClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClient).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Relatório";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(40, 39);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(144, 37);
            button1.TabIndex = 4;
            button1.Text = "Vendas";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonReportSale_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(340, 39);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(144, 37);
            button2.TabIndex = 5;
            button2.Text = "Clientes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonReportClient_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(190, 39);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(144, 37);
            button3.TabIndex = 6;
            button3.Text = "Estoque";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonReportStock_Click;
            // 
            // groupBoxSale
            // 
            groupBoxSale.Controls.Add(dataGridViewListaVendas);
            groupBoxSale.Location = new System.Drawing.Point(40, 121);
            groupBoxSale.Name = "groupBoxSale";
            groupBoxSale.Size = new System.Drawing.Size(1073, 401);
            groupBoxSale.TabIndex = 7;
            groupBoxSale.TabStop = false;
            groupBoxSale.Text = "Lista de Vendas";
            groupBoxSale.Visible = false;
            // 
            // dataGridViewListaVendas
            // 
            dataGridViewListaVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewListaVendas.Location = new System.Drawing.Point(6, 22);
            dataGridViewListaVendas.Name = "dataGridViewListaVendas";
            dataGridViewListaVendas.RowTemplate.Height = 25;
            dataGridViewListaVendas.Size = new System.Drawing.Size(1061, 373);
            dataGridViewListaVendas.TabIndex = 2;
            dataGridViewListaVendas.CellClick += dataGridViewListaVendas_CellClick;
            // 
            // groupBoxStock
            // 
            groupBoxStock.Controls.Add(dataGridViewStock);
            groupBoxStock.Location = new System.Drawing.Point(40, 121);
            groupBoxStock.Name = "groupBoxStock";
            groupBoxStock.Size = new System.Drawing.Size(1073, 401);
            groupBoxStock.TabIndex = 8;
            groupBoxStock.TabStop = false;
            groupBoxStock.Text = "Estoque";
            groupBoxStock.Visible = false;
            // 
            // dataGridViewStock
            // 
            dataGridViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStock.Location = new System.Drawing.Point(6, 22);
            dataGridViewStock.Name = "dataGridViewStock";
            dataGridViewStock.RowTemplate.Height = 25;
            dataGridViewStock.Size = new System.Drawing.Size(1061, 373);
            dataGridViewStock.TabIndex = 4;
            // 
            // groupBoxClient
            // 
            groupBoxClient.Controls.Add(dataGridViewClient);
            groupBoxClient.Location = new System.Drawing.Point(40, 121);
            groupBoxClient.Name = "groupBoxClient";
            groupBoxClient.Size = new System.Drawing.Size(1073, 401);
            groupBoxClient.TabIndex = 9;
            groupBoxClient.TabStop = false;
            groupBoxClient.Text = "Cliente";
            groupBoxClient.Visible = false;
            // 
            // dataGridViewClient
            // 
            dataGridViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClient.Location = new System.Drawing.Point(9, 22);
            dataGridViewClient.Name = "dataGridViewClient";
            dataGridViewClient.RowTemplate.Height = 25;
            dataGridViewClient.Size = new System.Drawing.Size(1058, 373);
            dataGridViewClient.TabIndex = 3;
            // 
            // UserControlReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBoxClient);
            Controls.Add(groupBoxStock);
            Controls.Add(groupBoxSale);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "UserControlReport";
            Size = new System.Drawing.Size(1137, 646);
            groupBoxSale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewListaVendas).EndInit();
            groupBoxStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStock).EndInit();
            groupBoxClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewClient).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBoxSale;
        private System.Windows.Forms.DataGridView dataGridViewListaVendas;
        private System.Windows.Forms.GroupBox groupBoxStock;
        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.DataGridView dataGridViewClient;
        private System.Windows.Forms.DataGridView dataGridViewStock;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
