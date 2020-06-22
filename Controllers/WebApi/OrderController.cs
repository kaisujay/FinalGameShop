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
    public class OrderController : ApiController
    {
        //GET : Api/Order
        [HttpGet]
        public IEnumerable<OrderDto> GetOrder()
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var AllOrders = finalDBContext.Order
                            .Include(x=>x.Game).Include(x=>x.Player)
                            .Select(Mapper.Map<Order, OrderDto>)
                            .ToList();
                return AllOrders;
            }
        }

        //GET : Api/Order/{id}
        [HttpGet]
        public OrderDto GetOrder(int id)
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var OneOrder = finalDBContext.Order                            
                            .Include(x => x.Game).Include(x => x.Player)
                            .Select(Mapper.Map<Order, OrderDto>)
                            .Where(x=>x.Id==id)
                            .SingleOrDefault();

                return OneOrder;
            }
        }

        //POST : Api/Order
        [HttpPost]
        public OrderDto CreateOrder([FromBody]OrderDto orderDto)
        {
            using (FinalGameShopDBContext finalDBContext = new FinalGameShopDBContext())
            {
                var createOrder = Mapper.Map<OrderDto, Order>(orderDto);
                finalDBContext.Order.Add(createOrder);
                finalDBContext.SaveChanges();

                return orderDto;
            }
        }
    }
}
