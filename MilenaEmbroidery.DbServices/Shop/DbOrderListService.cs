using Microsoft.Extensions.Configuration;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilenaEmbroidery.DbServices.Shop
{
    public class DbOrderListService : DbBaseService, IOrderListService
    {
        public DbOrderListService(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> Create(OrderListDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(OrderListDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderListDTO> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderListDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIfExists(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
