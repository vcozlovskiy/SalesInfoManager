using SalesInfoManager.Persistence.Models;
using System;

namespace SalesInfoManager.BL.Abstractions
{
    public class SalesDataSourceDTO
    {
        public DateTime DataTimeOrder { get; set; }
        public DateTime DateTimeFile { get; set; }
        public string ManagerLastName { get; set; }
        public string ClientName { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}