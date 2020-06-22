using FinalGameShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalGameShop
{
    public class FinalGameShopDBContext : DbContext
    {
        public DbSet<Game> Game{ get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}