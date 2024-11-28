using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Newtonsoft.Json;
using WinFormsKyotoDesk.UI.Styles;
using WinFormsKyotoDesk.Data.Repositories;
using WinFormsKyotoDesk.Data.DataAccess;
using WinFormsKyotoDesk.UI;

namespace WinFormsKyotoDesk
{
    public partial class UserControlReport : UserControl
    {
        private readonly ReportRepository _reportRepository;

        public UserControlReport()
        {
            InitializeComponent();
            _reportRepository = new ReportRepository(DatabaseConnection.GetConnectionString());
            UIStyler.ConfigDataGridView(dataGridViewListaVendas, dataGridViewStock, dataGridViewClient);
            UIStyler.ApplyStyleButton(button1, button2, button3);
        }

        // Botão relatorio Vendas
        private void buttonReportSale_Click(object sender, EventArgs e)
        {
            ObjectControl.ToggleVisibilityGroupBox(groupBoxSale, groupBoxStock, groupBoxClient);
            dataGridViewListaVendas.DataSource = _reportRepository.GetReportSales();            
        }

        // Botão relatorio Estoque
        private void buttonReportStock_Click(object sender, EventArgs e)
        {
            ObjectControl.ToggleVisibilityGroupBox(groupBoxStock, groupBoxSale, groupBoxClient);
            dataGridViewStock.DataSource = _reportRepository.GetReportStock();
        }

        // Botão relatorio Cliente
        private void buttonReportClient_Click(object sender, EventArgs e)
        {
            ObjectControl.ToggleVisibilityGroupBox(groupBoxClient, groupBoxSale, groupBoxStock);
            dataGridViewClient.DataSource = _reportRepository.GetReportClient();
            dataGridViewClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewClient.ReadOnly = true; 
        }

        // Quando clicar em uma linha do relatorio de vendas, abrir um popup mostrando os detalhes da venda
        private void dataGridViewListaVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula clicada não está no cabeçalho
            if (e.RowIndex >= 0)
            {
                // Pega a linha selecionada
                DataGridViewRow row = dataGridViewListaVendas.Rows[e.RowIndex];
                if (row.Cells["Id"].Value != DBNull.Value && int.TryParse(row.Cells["Id"].Value.ToString(), out int id))
                {
                    // Preenche os TextBox com os dados da linha selecionada
                    int vendaId = int.Parse(row.Cells["Id"].Value.ToString());

                    FormJsonResult(_reportRepository.GetSale(vendaId));
                }
            }
        }

        private void FormJsonResult(string jsonResult)
        {
            var saleDetails = JsonConvert.DeserializeObject<dynamic>(jsonResult);
            string message = $"Detalhes da Venda:\n\n" +
                             $"ID da Venda: {saleDetails.venda_id}\n" +
                             $"Cliente: {saleDetails.cliente}\n" +
                             $"Data da Venda: {saleDetails.data_venda}\n" +
                             $"Total:  R$ {saleDetails.total_venda}\n\n" +
                             $"Produtos:\n";

            foreach (var produto in saleDetails.produtos)
            {
                message += $"- {produto.produto} (Qtd: {produto.quantidade}, Preço Unitário: {produto.preco_unitario}, Total: {produto.preco_total})\n";
            }

            MessageBox.Show(message, "Detalhes da Venda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
