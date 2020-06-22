using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalGameShop.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Email { get; set; }
        public Int64 Phone { get; set; }
        public float DiscountPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}