using AutoMapper;
using FinalGameShop.Dtos;
using FinalGameShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace FinalGameShop.Controllers.WebApi
{
    public class PlayerController : ApiController
    {
        // GET : Api/Player
        [HttpGet]
        [Route("api/Player/AllPlayers")]
        public IEnumerable<PlayerDto> GetPlayer()
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var AllPlayerDto = finalDBContext.Player
                            .Select(Mapper.Map<Player, PlayerDto>)
                            .ToList();
                return AllPlayerDto;
            }
        }

        //GET : Api/Player/{id}
        [HttpGet]
        [Route("api/Player/AllPlayers/{id}")]
        public PlayerDto GetPlayer(int id)
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var OnePlayerDto = finalDBContext.Player
                    .Select(Mapper.Map<Player, PlayerDto>)
                    .Where(x => x.Id == id)
                    .SingleOrDefault();

                return OnePlayerDto;
            }
        }

        //GET : Api/Player/{username:regex(^[A-Za-z0-9, ]+$)}
        [HttpPost]
        [Route("api/Player/LogInPlayer")]
        public IHttpActionResult LogInPlayer([FromBody]LogInPlayerDto logInPlayerDto)
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var LogInPlayerDto = finalDBContext.Player
                    //.Select(Mapper.Map<Player, LogInPlayerDto>)
                    .Where(x => x.UserName.ToLower() == logInPlayerDto.UserName.ToLower() && x.Password == logInPlayerDto.Password)
                    .SingleOrDefault();

                return Json(LogInPlayerDto.Id);
            }
        }

        //POST : Api/Player
        [HttpPost]
        [Route("api/Player/CreatePlayer")]
        public RegisterPlayerDto CreatePlayer([FromBody]RegisterPlayerDto registerPlayerDto)
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var Player = Mapper.Map<RegisterPlayerDto, Player>(registerPlayerDto);
                finalDBContext.Player.Add(Player);
                finalDBContext.SaveChanges();

                return registerPlayerDto;
            }
        }
    }
}
