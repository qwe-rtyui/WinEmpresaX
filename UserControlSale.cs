using Newtonsoft.Json;
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
using WinFormsKyotoDesk.Data.DataAccess;
using WinFormsKyotoDesk.Data.Repositories;
using WinFormsKyotoDesk.UI;
using WinFormsKyotoDesk.UI.Styles;

namespace WinFormsKyotoDesk
{
    public partial class UserControlSale : UserControl
    {
        private readonly ClientRepository _clientRepository;
        private readonly ProductRepository _productRepository;
        private readonly SaleRepository _saleRepository;

        private string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Qwertyui;Database=KyotoDesk";
        private int selectId;

        public UserControlSale()
        {
            InitializeComponent();
            _clientRepository = new ClientRepository(DatabaseConnection.GetConnectionString());
            _productRepository = new ProductRepository(DatabaseConnection.GetConnectionString());
            _saleRepository = new SaleRepository(DatabaseConnection.GetConnectionString());

            UIStyler.ApplyStyleButton(button1, button2);
            UIStyler.ApplyStyleTextBox(textBoxQuantidade);
            UIStyler.ConfigDataGridView(dataGridViewProducts);
            UIStyler.ConfigDataGridView(dataGridViewItenssales);

            GetClients();
            GETProducts();
            ConfigDataGridViewItensSale();
        }

        // Botão para adicionar o produto selecionar na lista para serem finalizados
        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            AddProductinListSale();
            textBoxQuantidade.Clear();
        }

        // Botão para finalizar a venda
        private void buttonFinalizarVenda_Click(object sender, EventArgs e)
        {
            if (dataGridViewItenssales.Rows.Count > 0)
            {
                FinalizeSale();
                GETProducts();
                dataGridViewItenssales.Rows.Clear();
            }
            else
            {
                MessageBox.Show($"Erro ao finalizar compra sem produtos na lista: 'produtos à serem vendidos'");
            }
        }

        // Carrega lista de clientes
        private void GetClients()
        {
            try
            {
                var clients = _clientRepository.GetClients();

                comboBoxClientes.DataSource = clients;
                comboBoxClientes.DisplayMember = "nome";
                comboBoxClientes.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}");
            }
        }

        // Carrega lista de produtos
        private void GETProducts()
        {
            try
            {
                var products = _productRepository.GetProducts();
                // Vincula os dados ao DataGridView
                dataGridViewProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}");
            }
        }

        // Add produtos na lista a para realizar a venda
        private void AddProductinListSale()
        {
            try
            {
                if (dataGridViewProducts.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewProducts.SelectedRows[0];
                    int produtoId = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                    string produtoNome = selectedRow.Cells["Name"].Value.ToString();
                    decimal preco = decimal.Parse(selectedRow.Cells["Price"].Value.ToString());
                    int stock = int.Parse(selectedRow.Cells["Stock"].Value.ToString());

                    int quantidade = int.Parse(textBoxQuantidade.Text);
                    if (quantidade <= 0)
                    {
                        MessageBox.Show("Quantidade deve ser maior que zero.");
                        return;
                    }

                    if (stock <= 0)
                    {
                        MessageBox.Show("Não tem estoque do produto selecionado");
                        return;
                    }

                    // Adiciona ao DataGridView de itens da venda
                    dataGridViewItenssales.Rows.Add(produtoId, produtoNome, preco, quantidade, preco * quantidade);
                }
                else
                {
                    MessageBox.Show("Selecione um produto para adicionar.");
                }
            }
            catch (Exception ex)
            {
                if (textBoxQuantidade.Text == string.Empty)
                {
                    MessageBox.Show($"Erro ao adicionar item à venda: 'Precisa digitar uma quantidade de itens que deseja adcionar");
                }
                else
                {
                    MessageBox.Show($"Erro ao adicionar item à venda: {ex.Message}");
                }

            }
        }
        private void FinalizeSale()
        {
            try
            {
                int clienteId = (int)comboBoxClientes.SelectedValue;

                // Monta os itens em formato JSON
                var itens = new List<object>();
                foreach (DataGridViewRow row in dataGridViewItenssales.Rows)
                {
                    if (row.Cells["produtoId"].Value != null)
                    {
                        itens.Add(new
                        {
                            produto_id = (int)row.Cells["produtoId"].Value,
                            quantidade = (int)row.Cells["quantidade"].Value
                        });
                    }
                }

                var jsonItens = JsonConvert.SerializeObject(itens);

                _saleRepository.FinalizeSale(clienteId, jsonItens);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar venda: {ex.Message}");
            }
        }        

        // Editando a Grid da lista dos produtos a serem vendidos 
        private void ConfigDataGridViewItensSale()
        {
            dataGridViewItenssales.Columns.Clear();

            dataGridViewItenssales.Columns.Add("produtoId", "ID do Produto");
            dataGridViewItenssales.Columns.Add("nomeProduto", "Nome do Produto");
            dataGridViewItenssales.Columns.Add("preco", "Preço");
            dataGridViewItenssales.Columns.Add("quantidade", "Quantidade");
            dataGridViewItenssales.Columns.Add("total", "Total");

            // Opcional: define formatos
            dataGridViewItenssales.Columns["preco"].DefaultCellStyle.Format = "C2";  // Formato monetário
            dataGridViewItenssales.Columns["total"].DefaultCellStyle.Format = "C2";  // Formato monetário
        }


        //Validar textbox numérico
        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjectControl.TextBoxValidNumberKeyPress(sender, e);
        }
    }
}
