using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfoManager.Persistence.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Item()
        {

        }
        public Item(string name)
        {
            Name = name;
        }
    }
}
