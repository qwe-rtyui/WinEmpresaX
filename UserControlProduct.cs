using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsKyotoDesk.Data.DataAccess;
using WinFormsKyotoDesk.Data.Models;
using WinFormsKyotoDesk.Data.Repositories;
using WinFormsKyotoDesk.UI;
using WinFormsKyotoDesk.UI.Styles;

namespace WinFormsKyotoDesk
{
    public partial class UserControlProduct : UserControl
    {
        private readonly ProductRepository _produtoRepository;
        private string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Qwertyui;Database=KyotoDesk";
        private int selectId;

        public UserControlProduct()
        {
            InitializeComponent();
            _produtoRepository = new ProductRepository(DatabaseConnection.GetConnectionString());

            UIStyler.ApplyStyleTextBox(textBoxNome, textBoxPreco, textBoxEstoque, textBoxDescricao);
            UIStyler.ApplyStyleButton(buttonCancel, buttonPgAdd, buttonEdit, buttonSaveClient, buttonUpdateClient, buttonRemove);
            UIStyler.ConfigDataGridView(dataGridViewAddProduct);

            GetProducts();
        }

        // Carrega lista de produtos
        private void GetProducts()
        {
            try
            {
                var products = _produtoRepository.GetProducts();
                // Vincula os dados ao DataGridView
                dataGridViewAddProduct.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}");
            }
        }

        // Regarrega a lista
        private void RefreshData()
        {
            selectId = new();
            ObjectControl.ToggleVisibilityGroupBox(groupBox1, groupBox2);
            GetProducts();
        }

        // Botão para cadastrar um produto
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ObjectControl.TextBoxStringEmpty(textBoxNome, textBoxDescricao, textBoxPreco, textBoxEstoque);

            buttonSaveClient.Visible = true;
            buttonUpdateClient.Visible = false;
            ObjectControl.ButtomDisabled(buttonPgAdd, buttonEdit, buttonRemove);
            ObjectControl.ToggleVisibilityGroupBox(groupBox2, groupBox1);
        }

        // Botão para Cancelar e voltar para a lista de produtos
        private void button5_Click(object sender, EventArgs e)
        {
            ObjectControl.ButtomDisabled(buttonPgAdd);
            ObjectControl.ButtomDisabled(buttonEdit);
            
            ObjectControl.ToggleVisibilityGroupBox(groupBox1, groupBox2);
        }

        // Botão para salvar o Produto
        private void buttonSaveProduct_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                Name = textBoxNome.Text,
                Descricao = textBoxDescricao.Text,
                Price = decimal.Parse(textBoxPreco.Text),
                Stock = int.Parse(textBoxEstoque.Text)
            };

            // Valida os dados antes de inserir
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Descricao) || product.Price < 1 || product.Stock == null)
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }

            // Inserir dados no banco
            _produtoRepository.InsertProduct(product);
            RefreshData();
        }

        // Evento de Click em uma linha da lista
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula clicada não está no cabeçalho
            if (e.RowIndex >= 0 && dataGridViewAddProduct.Rows.Count > 0)
            {
                // Pega a linha selecionada
                DataGridViewRow row = dataGridViewAddProduct.Rows[e.RowIndex];
                if (row.Cells["Id"].Value != DBNull.Value && int.TryParse(row.Cells["Id"].Value.ToString(), out int id))
                {
                    // Preenche os TextBox com os dados da linha selecionada
                    selectId = int.Parse(row.Cells["Id"].Value.ToString());  // Usando o campo 'id' do produto
                    textBoxNome.Text = row.Cells["Name"].Value.ToString();    // Usando o campo 'nome' do produto
                    textBoxDescricao.Text = row.Cells["descricao"].Value.ToString(); // Usando o campo 'descricao'
                    textBoxPreco.Text = row.Cells["price"].Value.ToString();  // Usando o campo 'preco'
                    textBoxEstoque.Text = row.Cells["Stock"].Value.ToString();  // Usando o campo 'estoque'
                }
            }
        }

        // Botão para editar dados do produto
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            // Pega os dados dos TextBox
            var product = new Product
            {
                Id = selectId,
                Name = textBoxNome.Text,
                Descricao = textBoxDescricao.Text,
                Price = decimal.Parse(textBoxPreco.Text),
                Stock = int.Parse(textBoxEstoque.Text)
            };
            // Valida os dados antes de editar
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Descricao) || product.Price < 1 || product.Stock == null)
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }

            // Chama o método para editar os dados
            _produtoRepository.UpdateProduct(product);
            RefreshData();
        }
           
        // Botão remover Produto
        private void buttonRemove_Click_Click(object sender, EventArgs e)
        {
            if (selectId > 0)
            {
                int productId = selectId;
                var result = MessageBox.Show($"Você tem certeza que deseja remover o Produto {textBoxNome.Text}?", "Confirmar Remoção", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _produtoRepository.RemoveProduct(productId);
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para remover.");
            }
        }

        // Botão Editar Produto
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ObjectControl.ButtomDisabled(buttonEdit, buttonPgAdd, buttonRemove);
            buttonSaveClient.Visible = false;
            buttonUpdateClient.Visible = true;

            if (selectId == 0)
            {
                DataGridViewRow row = dataGridViewAddProduct.Rows[0];
                if (row.Cells["Id"].Value != DBNull.Value && int.TryParse(row.Cells["Id"].Value.ToString(), out int id))
                {
                    // Preenche os TextBox com os dados da linha selecionada
                    selectId = int.Parse(row.Cells["Id"].Value.ToString());  // Usando o campo 'id' do produto
                    textBoxNome.Text = row.Cells["Name"].Value.ToString();    // Usando o campo 'nome' do produto
                    textBoxDescricao.Text = row.Cells["descricao"].Value.ToString(); // Usando o campo 'descricao'
                    textBoxPreco.Text = row.Cells["price"].Value.ToString();  // Usando o campo 'preco'
                    textBoxEstoque.Text = row.Cells["Stock"].Value.ToString();  // Usando o campo 'estoque'

                    // Alterna a visibilidade dos GroupBox
                    ObjectControl.ToggleVisibilityGroupBox(groupBox2, groupBox1);
                }
            }
            ObjectControl.ToggleVisibilityGroupBox(groupBox2, groupBox1);
        }

        // Validar Preco numérico
        private void textBoxPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjectControl.TextBoxValidNumberKeyPress(sender, e);
        }
        // Validar Estoque numérico
        private void textBoxEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjectControl.TextBoxValidNumberKeyPress(sender, e);
        }
    }
}

