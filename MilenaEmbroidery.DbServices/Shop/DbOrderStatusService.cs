using Microsoft.Extensions.Configuration;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilenaEmbroidery.DbServices.Shop
{
    public class DbOrderStatusService : DbBaseService, IOrderStatusService
    {
        public DbOrderStatusService(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<IEnumerable<OrderStatusDTO>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
