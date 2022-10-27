using HotelDelLuna.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDelLuna.DataAccess
{
    public class HotelDelLunaContext : DbContext
    {
        public HotelDelLunaContext() : base(GetOptions()) { }

        private static DbContextOptions GetOptions()
        {
            //var serverName = "LAPTOP-6EDAQBLP";
            //var databaseName = "HotelDelLuna";
            string connectionString =
                $@"Data Source=LAPTOP-6EDAQBLP;
                Initial Catalog=HotelDelLuna;
                User ID=1557;
                Password=indocyber";
            var modelBuilder = new DbContextOptionsBuilder();
            modelBuilder = modelBuilder.UseSqlServer(connectionString);
            var options = modelBuilder.Options;
            return options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasIndex(gst => gst.IdNumber).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(a => a.Username).IsUnique();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Guest> Guests { set; get; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BookHistory> BookHistories { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }

    }
}
