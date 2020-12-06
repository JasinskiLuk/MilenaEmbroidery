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
    public class DbOrderService : DbBaseService, IOrderService
    {
        private static Dictionary<string, string> _procedures = new Dictionary<string, string>
        {
            { "createOrderQuery", "[Shop].[up_CreateOrder]" },
            { "updateOrderQuery", "[Shop].[up_UpdateOrder]" },
            { "deleteOrderQuery", "[Shop].[up_DeleteOrder]" },
            { "getOrderQuery", "[Shop].[up_GetOrder]" },
            { "getOrdersQuery", "[Shop].[up_GetOrders]" },
            { "checkIfOrderExistQuery", "[Shop].[up_CheckIfOrderExist]" }
        };

        public DbOrderService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> Create(OrderDTO DTO)
        {
            int id = -1;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                var model = new { DTO.UserId, DTO.OrderStatusId };

                id = await conn.ExecuteScalarAsync<int>(_procedures["createOrderQuery"], model, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return id;
        }

        public async Task<int> Update(OrderDTO DTO)
        {
            int id = -1;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                var model = new { DTO.Id, DTO.UserId, DTO.OrderStatusId };

                id = await conn.ExecuteScalarAsync<int>(_procedures["updateOrderQuery"], model, commandType: CommandType.StoredProcedure);
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
                await conn.ExecuteAsync(_procedures["deleteOrderQuery"], new { Id }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task<OrderDTO> Get(int UserId)
        {
            OrderDTO order = null;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                order = await conn.QueryFirstOrDefaultAsync<OrderDTO>(_procedures["getOrderQuery"], new { UserId }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return order ?? new NullOrderDTO();
        }

        public async Task<IEnumerable<OrderDTO>> Get()
        {
            IEnumerable<OrderDTO> orders = Enumerable.Empty<OrderDTO>();

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                orders = await conn.QueryAsync<OrderDTO>(_procedures["getOrdersQuery"], commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return orders;
        }

        public async Task<bool> CheckIfExists(int Id)
        {
            bool check = false;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                check = await conn.ExecuteScalarAsync<bool>(_procedures["checkIfOrderExistQuery"], new { Id }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return check;
        }
    }
}
