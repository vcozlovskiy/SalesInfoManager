using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.Persistence.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public DateTime dateTimeOrder { get; set; }

        public decimal Price { get; set; }

        public Order()
        {

        }
        public Order(Item item)
        {
            dateTimeOrder = DateTime.Now;
            Item = item;
        }
    }
}
