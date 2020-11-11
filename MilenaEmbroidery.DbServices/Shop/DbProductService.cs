using Dapper;
using Microsoft.Extensions.Configuration;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            //throw new Exception("test exception - service");

            IEnumerable<ProductDTO> products = Enumerable.Empty<ProductDTO>();

            SqlConnection conn = new SqlConnection(_connectionString);

            products = await conn.QueryAsync<ProductDTO>(@"SELECT * FROM [Shop].[Products]");

            return products;
        }

        public Task<bool> CheckIfExists(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
