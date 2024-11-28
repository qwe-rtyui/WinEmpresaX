using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsKyotoDesk.Data.Models;

namespace WinFormsKyotoDesk.Data.Repositories
{
    public class ReportRepository
    {
        private readonly string _connectionString;

        public ReportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetSale(int vendaId)
        {
            string jsonResult;
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT sp_get_sale(@vendaId)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("vendaId", vendaId);

                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return jsonResult = result.ToString();
                            //MessageBox.Show(jsonResult);
                        }
                        else
                        {
                            MessageBox.Show("Venda não encontrada.");
                            return "{\"Venda não encontrada.\"}";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar relatório de vendas: {ex.Message}");
                return ex.Message.ToString();

            }

        }

        public List<ReportSale> GetReportSales()
        {
            var sales = new List<ReportSale>();
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM sp_list_sales()";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Vincula os dados ao DataGridView
                            foreach (DataRow row in dataTable.Rows)
                            {
                                sales.Add(new ReportSale
                                {
                                    Id = Convert.ToInt32(row["venda_Id"]),
                                    Client = row["cliente"].ToString(),
                                    Data_ = DateTime.Parse(row["data_venda"].ToString()),
                                    Total = decimal.Parse(row["total_venda"].ToString())
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar relatório de vendas: {ex.Message}");
            }

            return sales;
        }

        public List<ClientPurchases> GetReportClient()
        {
            var clientPurchases = new List<ClientPurchases>();
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    // Query para chamar a procedure
                    string query = "SELECT * FROM sp_list_client_purchases()";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Vincula os dados ao DataGridView
                            foreach (DataRow row in dataTable.Rows)
                            {
                                clientPurchases.Add(new ClientPurchases
                                {
                                    Id = Convert.ToInt32(row["cliente_id"]),
                                    Name = row["cliente"].ToString(),
                                    Endereco = row["endereco"].ToString(),
                                    Telefone = row["telefone"].ToString(),
                                    Email = row["email"].ToString(),
                                    Total = int.Parse(row["total_vendas"].ToString()),
                                    ValorTotal = decimal.Parse(row["valor_total_compras"].ToString()),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar relatório de clientes: {ex.Message}");
            }
            return clientPurchases;
        }

        public List<ReportStock> GetReportStock()
        {
            var reportStock = new List<ReportStock>();
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * from sp_list_product() order by nome";

                    using (var command = new NpgsqlCommand(query, connection))
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            reportStock.Add(new ReportStock
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
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}");
            }

            return reportStock;
        }




    }
}
