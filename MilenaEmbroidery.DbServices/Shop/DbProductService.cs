using Dapper;
using Microsoft.Extensions.Configuration;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MilenaEmbroidery.DbServices.Shop
{
    public class DbProductService : DbBaseService, IProductService
    {
        private static Dictionary<string, string> _procedures = new Dictionary<string, string>
        {
            { "createProductQuery", "[Shop].[up_CreateProduct]" },
            { "updateProductQuery", "[Shop].[up_UpdateProduct]" },
            { "deleteProductQuery", "[Shop].[up_DeleteProduct]" },
            { "getProductQuery", "[Shop].[up_GetProduct]" },
            { "getProductsQuery", "[Shop].[up_GetProducts]" },
            { "checkIfProductExistQuery", "[Shop].[up_CheckIfProductExist]" }
        };

        public DbProductService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> Create(ProductDTO DTO)
        {
            int id = -1;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                var model = new { DTO.Name, DTO.IsLimited, DTO.CountLimited, DTO.IsShown, DTO.DateAdded, DTO.Price, DTO.PictureLink };

                id = await conn.ExecuteScalarAsync<int>(_procedures["createProductQuery"], model, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return id;
        }

        public async Task<int> Update(ProductDTO DTO)
        {
            int id = -1;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                var model = new { DTO.Id, DTO.Name, DTO.IsLimited, DTO.CountLimited, DTO.IsShown, DTO.DateAdded, DTO.Price, DTO.PictureLink };

                id = await conn.ExecuteScalarAsync<int>(_procedures["updateProductQuery"], model, commandType: CommandType.StoredProcedure);
            }
            catch
            {

                throw;
            }

            return id;
        }

        public async Task Delete(int Id)
        {
            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                await conn.ExecuteAsync(_procedures["deleteProductQuery"], new { Id }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductDTO> Get(int Id)
        {
            ProductDTO product = null;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                product = await conn.QueryFirstOrDefaultAsync<ProductDTO>(_procedures["getProductQuery"], new { Id }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return product ?? new NullProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            IEnumerable<ProductDTO> products = Enumerable.Empty<ProductDTO>();

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                products = await conn.QueryAsync<ProductDTO>(_procedures["getProductsQuery"], commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return products;
        }

        public async Task<bool> CheckIfExists(int Id)
        {
            bool check = false;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                check = await conn.ExecuteScalarAsync<bool>(_procedures["checkIfProductExistQuery"], new { Id }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return check;
        }
    }
}
