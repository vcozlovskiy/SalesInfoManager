using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.Persistence.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Client()
        {
        }
        public Client(string fullName)
        {
            FullName = fullName;

            Orders = new List<Order>();
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
