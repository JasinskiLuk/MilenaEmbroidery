using Microsoft.Extensions.Configuration;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilenaEmbroidery.DbServices.Shop
{
    public class DbOrderService : DbBaseService, IOrderService
    {
        public DbOrderService(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> Create(OrderDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(OrderDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIfExists(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
