using FinalGameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalGameShop.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Publisher { get; set; }
        public int PlayTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string GameType { get; set; }
        public float Price { get; set; }
    }
}