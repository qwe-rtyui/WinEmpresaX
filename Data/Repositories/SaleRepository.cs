using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsKyotoDesk.Data.Repositories
{
    public class SaleRepository
    {
        private readonly string _connectionString;

        public SaleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void FinalizeSale(int clienteId, string jsonItens)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new NpgsqlCommand("SELECT sp_register_sale(@clienteId, @itens)", connection))
                    {
                        command.Parameters.AddWithValue("@clienteId", clienteId); // Deve ser um INT
                        command.Parameters.AddWithValue("@itens", NpgsqlTypes.NpgsqlDbType.Json, jsonItens); // JSON formatado

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Venda registrada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar venda: {ex.Message}");
            }
        }
    }
}
