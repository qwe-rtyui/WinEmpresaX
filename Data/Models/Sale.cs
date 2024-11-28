using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsKyotoDesk.Data.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Client Client { get; set; }
        public List<ItemSale> Itens { get; set; } = new List<ItemSale>();
        public decimal Total => Itens.Sum(item => item.PriceTotal);
    }

    public class ItemSale
    {
        public Product Product { get; set; }
        public int Quantidade { get; set; }
        public decimal PriceTotal => Product.Price * Quantidade;
    }

}
