using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FinalGameShop.Dtos;
using FinalGameShop.Models;

namespace FinalGameShop.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();

            CreateMap<Player, RegisterPlayerDto>();
            CreateMap<RegisterPlayerDto, Player>();

            CreateMap<Player, LogInPlayerDto>();
            CreateMap<LogInPlayerDto, Player>();

            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.GameId, opt => opt.MapFrom(src => src.Game.Id))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.Player.Id))
                .ForMember(dest => dest.GameName, opt => opt.MapFrom(src => src.Game.GameName))
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Player.PlayerName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Player.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Player.Phone));
            CreateMap<OrderDto, Order>();
        }
    }
}