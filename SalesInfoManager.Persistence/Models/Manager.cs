using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.Persistence.Models
{
    public class Manager
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Manager()
        {
            Orders = new List<Order>();
        }

        public Manager(string FullName)
        {
            this.FullName = FullName;
            Orders = new List<Order>();
        }
    }
}
