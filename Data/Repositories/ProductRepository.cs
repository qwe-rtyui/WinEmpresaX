using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsKyotoDesk.Data.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsKyotoDesk.Data.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM sp_list_product()";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            foreach (DataRow row in dataTable.Rows)
                            {
                                products.Add(new Product
                                {
                                    Id = Convert.ToInt32(row["id"]),
                                    Name = row["nome"].ToString(),
                                    Descricao = row["descricao"].ToString(),
                                    Price = decimal.Parse(row["preco"].ToString()),
                                    Stock = int.Parse(row["estoque"].ToString())
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar produtos", ex);
            }

            return products;
        }

        public void InsertProduct(Product product)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    // Comando SQL para chamar a procedure sp_insert_product
                    string query = "CALL sp_insert_product(@nome, @descricao, @preco, @estoque)";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Adiciona os parâmetros para evitar SQL Injection
                        command.Parameters.AddWithValue("@nome", product.Name);
                        command.Parameters.AddWithValue("@descricao", product.Descricao);
                        command.Parameters.AddWithValue("@preco", product.Price);
                        command.Parameters.AddWithValue("@estoque", product.Stock);

                        // Executa a procedure
                        int rowsAffected = command.ExecuteNonQuery();


                        MessageBox.Show("Produto inserido com sucesso.");

                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir produto: {ex.Message}");
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    // Comando SQL para chamar a procedure sp_update_product
                    string query = "CALL sp_update_product(@id, @nome, @descricao, @preco, @estoque)";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Adiciona os parâmetros para evitar SQL Injection
                        command.Parameters.AddWithValue("@id", product.Id);
                        command.Parameters.AddWithValue("@nome", product.Name);
                        command.Parameters.AddWithValue("@descricao", product.Descricao);
                        command.Parameters.AddWithValue("@preco", product.Price);
                        command.Parameters.AddWithValue("@estoque", product.Stock);

                        // Executa o comando e lê o resultado
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Se a atualização foi bem-sucedida, o resultado estará disponível
                                MessageBox.Show("Produto atualizado com sucesso.");
                            }
                            else
                            {

                                if (reader.RecordsAffected == -1)
                                {
                                    MessageBox.Show("Produto atualizado com sucesso.");
                                }
                                else
                                {
                                    MessageBox.Show("Produto atualizado com sucesso.");
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        public void RemoveProduct(int produtoId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    // Comando SQL para chamar a procedure sp_remove_product
                    string query = "CALL sp_remove_product(@id)";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Adiciona o parâmetro de ID
                        command.Parameters.AddWithValue("@id", produtoId);

                        // Executa a procedure
                        command.ExecuteNonQuery();

                        // Atualiza o DataGridView após a remoção                        
                        MessageBox.Show("Produto removido com sucesso.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover produto: {ex.Message}");
            }
        }
    }
}
