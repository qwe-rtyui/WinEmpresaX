using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WinFormsKyotoDesk.Data.Models;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsKyotoDesk.Data.Repositories
{
    public class ClientRepository
    {
        private readonly string _connectionString;

        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para listar os clientes
        public List<Client> GetClients()
        {
            var clients = new List<Client>();

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM sp_list_client()";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                clients.Add(new Client
                                {
                                    Id = Convert.ToInt32(row["cliente_id"]),
                                    Nome = row["nome_cliente"].ToString(),
                                    Endereco = row["endereco_cliente"].ToString(),
                                    Telefone = row["telefone_cliente"].ToString(),
                                    Email = row["email_cliente"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar clientes", ex);
            }

            return clients;
        }

        // Método para inserir um cliente
        public void InsertClient(Client client)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO clientes (nome, endereco, telefone, email) VALUES (@nome, @endereco, @telefone, @email)";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nome", client.Nome);
                        command.Parameters.AddWithValue("@endereco", client.Endereco);
                        command.Parameters.AddWithValue("@telefone", client.Telefone);
                        command.Parameters.AddWithValue("@email", client.Email);

                        int rowsAffected = command.ExecuteNonQuery();

                        // Verifica se a inserção foi bem-sucedida
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente cadastrado com sucesso.");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao cadastrar cliente.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar cliente", ex);
            }
        }

        // Método para atualizar um cliente
        public void UpdateClient(Client client)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "CALL sp_update_client(@id, @nome, @endereco, @telefone, @email)";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", client.Id);
                        command.Parameters.AddWithValue("@nome", client.Nome);
                        command.Parameters.AddWithValue("@endereco", client.Endereco);
                        command.Parameters.AddWithValue("@telefone", client.Telefone);
                        command.Parameters.AddWithValue("@email", client.Email);

                        // Executa o comando e lê o resultado
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Se a atualização foi bem-sucedida, o resultado estará disponível
                                MessageBox.Show("Cliente atualizado com sucesso.");
                            }
                            else
                            {

                                if (reader.RecordsAffected == -1)
                                {
                                    MessageBox.Show("Cliente atualizado com sucesso.");
                                }
                                else
                                {
                                    MessageBox.Show("Cliente atualizado com sucesso.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar cliente", ex);
            }
        }

        // Método para remover um cliente
        public void DeleteClient(int clientId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "CALL sp_remove_client(@id)";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", clientId);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cliente removido com sucesso.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover cliente", ex);
            }
        }
    }
}
