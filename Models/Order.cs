using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalGameShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public float DiscountPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}