using SalesInfoManager.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using SalesInfoManager.Persistence.Models;
using NLog;
using System.Linq;
using System.Text;

namespace SalesInfoManager.Persistence.Context
{
    public class SalesInfoManagerDbContext : DbContext
    {
        private readonly DbConnection _connection;

        public DbSet<Client> Clients { get; set; }

        public SalesInfoManagerDbContext(DbConnection connection, bool ownConnection) : base(connection, ownConnection)
        {
            _connection = connection;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Client>()
                .Property(x => x.FullName).IsRequired().HasMaxLength(40);
            modelBuilder
                .Entity<Client>().HasMany(x => x.Orders);

            modelBuilder.Entity<Item>().HasKey(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Item>()
                .Property((x) => x.Name);

            modelBuilder.Entity<Manager>()
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Manager>()
                .Property(x => x.FullName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Manager>()
                .HasMany(x => x.Orders);

            modelBuilder.Entity<Order>().HasKey(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);            
            modelBuilder.Entity<Order>()
                .HasOptional(x => x.Item);
            modelBuilder.Entity<Order>()
                .Property(x => x.dateTimeOrder);
            modelBuilder.Entity<Order>()
                .Property(x => x.Price);

            base.OnModelCreating(modelBuilder);

        }
    }
}
