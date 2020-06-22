using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalGameShop.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Int64 Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
    }
}