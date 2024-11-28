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
using WinFormsKyotoDesk.Data.DataAccess;
using WinFormsKyotoDesk.Data.Models;
using WinFormsKyotoDesk.Data.Repositories;
using WinFormsKyotoDesk.UI;
using WinFormsKyotoDesk.UI.Styles;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsKyotoDesk
{
    public partial class UserControlClient : UserControl
    {        
        private readonly ClientRepository _clientRepository;
        private int selectId;

        public UserControlClient()
        {
            InitializeComponent();
            _clientRepository = new ClientRepository(DatabaseConnection.GetConnectionString());

            UIStyler.ApplyStyleTextBox(textBoxNome, textBoxEmail, textBoxEndereco, textBoxTelefone);
            UIStyler.ApplyStyleButton(buttonCancel, buttonPgAdd, buttonEdit, buttonSaveClient, buttonUpdateClient, buttonRemove);
            UIStyler.ConfigDataGridView(dataGridViewAddListClient);

            GetClients();
        }

        // Carrega Lista de Clientes
        private void GetClients()
        {
            try
            {
                var clients = _clientRepository.GetClients();
                // Vincula os dados ao DataGridView
                dataGridViewAddListClient.DataSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}");
            }
        }

        // Recarrega a lista de clientes
        private void RefreshData()
        {
            selectId = new();
            ObjectControl.ToggleVisibilityGroupBox(groupBox1, groupBox2);
            GetClients();
        }

        // Botão para UI cadastrar um cliente
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ObjectControl.TextBoxStringEmpty(textBoxNome, textBoxEndereco, textBoxTelefone, textBoxEmail);

            buttonSaveClient.Visible = true;
            buttonUpdateClient.Visible = false;
            ObjectControl.ButtomDisabled(buttonPgAdd, buttonEdit, buttonRemove);
            ObjectControl.ToggleVisibilityGroupBox(groupBox2, groupBox1);
        }

        // Botão para Cancelar e voltar para a lista de clientes
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ObjectControl.ButtomDisabled(buttonPgAdd);
            ObjectControl.ButtomDisabled(buttonEdit);
            ObjectControl.ButtomDisabled(buttonRemove);
            ObjectControl.ToggleVisibilityGroupBox(groupBox1, groupBox2);
        }

        // Botão para salvar o cliente no Db
        private void buttonSaveClient_Click(object sender, EventArgs e)
        {
            var client = new Client
            {
                Nome = textBoxNome.Text,
                Endereco = textBoxEndereco.Text,
                Telefone = textBoxTelefone.Text,
                Email = textBoxEmail.Text
            };

            // Valida os dados antes de inserir
            if (string.IsNullOrEmpty(client.Nome) || string.IsNullOrEmpty(client.Endereco) || string.IsNullOrEmpty(client.Telefone) || string.IsNullOrEmpty(client.Email))
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }

            // Inserir Cliente no Db
            _clientRepository.InsertClient(client);
            RefreshData();
            //InsertClient(nome, endereco, telefone, email);
        }

        // Evento de Click em uma linha da lista
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula clicada não está no cabeçalho
            if (e.RowIndex >= 0)
            {
                // Pega a linha selecionada
                DataGridViewRow row = dataGridViewAddListClient.Rows[e.RowIndex];
                if (row.Cells["Id"].Value != DBNull.Value && int.TryParse(row.Cells["Id"].Value.ToString(), out int id))
                {
                    // Preenche os TextBox com os dados da linha selecionada
                    selectId = int.Parse(row.Cells["Id"].Value.ToString());
                    textBoxNome.Text = row.Cells["Nome"].Value.ToString();
                    textBoxEndereco.Text = row.Cells["Endereco"].Value.ToString();
                    textBoxTelefone.Text = row.Cells["Telefone"].Value.ToString();
                    textBoxEmail.Text = row.Cells["Email"].Value.ToString();
                }
            }
        }

        // Botão para editar dados do cliente
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            var client = new Client
            {
                Id = selectId,
                Nome = textBoxNome.Text,
                Endereco = textBoxEndereco.Text,
                Telefone = textBoxTelefone.Text,
                Email = textBoxEmail.Text
            };

            // Valida os dados antes de editar
            if (string.IsNullOrEmpty(client.Nome) || string.IsNullOrEmpty(client.Endereco) || string.IsNullOrEmpty(client.Telefone) || string.IsNullOrEmpty(client.Email))
            {
                MessageBox.Show("Todos os campos são obrigatórios.");
                return;
            }

            // Edita cliente da Db
            _clientRepository.UpdateClient(client);
            RefreshData();
        }


        // Botão remover Cliente
        private void buttonRemove_Click_Click(object sender, EventArgs e)
        {
            // Verifique se um cliente foi selecionado no DataGridView
            if (selectId > 0)
            {
                // Obtém o ID do cliente selecionado
                int clienteId = selectId;

                // Confirmação para remover
                var result = MessageBox.Show($"Você tem certeza que deseja remover o cliente {textBoxNome.Text}?", "Confirmar Remoção", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Remover cliente do Db
                    _clientRepository.DeleteClient(selectId);
                    RefreshData();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente para remover.");
            }
        }

        // Botão para editar cliente
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ObjectControl.ButtomDisabled(buttonEdit, buttonPgAdd, buttonRemove);
            buttonSaveClient.Visible = false;
            buttonUpdateClient.Visible = true;

            if (selectId == 0)
            {
                DataGridViewRow row = dataGridViewAddListClient.Rows[0];

                if (row.Cells["Id"].Value != DBNull.Value && int.TryParse(row.Cells["Id"].Value.ToString(), out int id))
                {
                    // Preenche os TextBox com os dados da linha selecionada
                    selectId = int.Parse(row.Cells["Id"].Value.ToString());
                    textBoxNome.Text = row.Cells["Nome"].Value.ToString();
                    textBoxEndereco.Text = row.Cells["Endereco"].Value.ToString();
                    textBoxTelefone.Text = row.Cells["Telefone"].Value.ToString();
                    textBoxEmail.Text = row.Cells["Email"].Value.ToString();
                }
            }
            ObjectControl.ToggleVisibilityGroupBox(groupBox2, groupBox1);
        }

        // Validar Telefone numérico
        private void textBoxTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjectControl.TextBoxValidNumberKeyPress(sender, e);
        }

        // Validar Telefone e personalizar
        private void textBoxTelefone_TextChanged(object sender, EventArgs e)
        {
            ObjectControl.TextBoxValidTelefoneTextChanged(sender, e, textBoxTelefone);            
        }
    }
}
