using AutoMapper;
using FinalGameShop.Dtos;
using FinalGameShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalGameShop.Controllers.WebApi
{
    public class GameController : ApiController
    {
        //Get : Api/Game
        [HttpGet]
        //[Route("api/Game")]
        public IEnumerable<GameDto> GetGame()
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var AllGames = finalDBContext.Game
                            .Select(Mapper.Map<Game, GameDto>)
                            .ToList();
                return AllGames;
            }
        }

        //Get : Api/Game/{id}
        [HttpGet]
        //[Route("Api/Game")]
        public GameDto GetGame(int id)
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var AllGames = finalDBContext.Game
                            .Select(Mapper.Map<Game, GameDto>)
                            .Where(x=>x.Id==id)
                            .SingleOrDefault();
                return AllGames;
            }
        }

        //POST : Api/Game
        [HttpPost]
        //[Route("Api/Game")]
        public GameDto CreateGame([FromBody]GameDto gameDto)
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var game = Mapper.Map<GameDto, Game>(gameDto);
                finalDBContext.Game.Add(game);
                finalDBContext.SaveChanges();

                return gameDto;
            }
        }
    }
}
