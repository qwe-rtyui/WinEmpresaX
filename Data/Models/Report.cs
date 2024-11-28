using System.Collections.Generic;
using System;

namespace WinFormsKyotoDesk.Data.Models
{
    public class Report
    {
    }

    public class ClientPurchases
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Total { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class ReportSale
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public DateTime Data_ { get; set; }
        public decimal Total { get; set; }
    }

    public class ReportStock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }


    }
}