using Microsoft.Extensions.Configuration;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilenaEmbroidery.DbServices.Shop
{
    public class DbProductService : DbBaseService, IProductService
    {
        public DbProductService(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> Create(ProductDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ProductDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckIfExists(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
