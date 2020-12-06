using Dapper;
using Microsoft.Extensions.Configuration;
using MilenaEmbroidery.DTOs.Shop;
using MilenaEmbroidery.IServices.Shop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MilenaEmbroidery.DbServices.Shop
{
    public class DbOrderListService : DbBaseService, IOrderListService
    {
        private static Dictionary<string, string> _procedures = new Dictionary<string, string>
        {
            { "createOrderListQuery", "[Shop].[up_CreateOrderList]" },
            { "updateOrderListQuery", "[Shop].[up_UpdateOrderList]" },
            { "deleteOrderListQuery", "[Shop].[up_DeleteOrderList]" },
            { "getOrderListQuery", "[Shop].[up_GetOrderList]" },
            { "getOrderListsQuery", "[Shop].[up_GetOrderLists]" },
            { "checkIfOrderListExistQuery", "[Shop].[up_CheckIfOrderListExist]" }
        };

        public DbOrderListService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> Create(OrderListDTO DTO)
        {
            int id = -1;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                var model = new { DTO.OrderId, DTO.ProductId, DTO.Quantity };

                id = await conn.ExecuteScalarAsync<int>(_procedures["createOrderListQuery"], model, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return id;
        }

        public async Task<int> Update(OrderListDTO DTO)
        {
            int id = -1;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                var model = new { DTO.Id, DTO.OrderId, DTO.ProductId, DTO.Quantity };

                id = await conn.ExecuteScalarAsync<int>(_procedures["updateOrderListQuery"], model, commandType: CommandType.StoredProcedure);
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
                await conn.ExecuteAsync(_procedures["deleteOrderListQuery"], new { Id }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
        }

        public async Task<OrderListDTO> Get(int UserId)
        {
            OrderListDTO OrderList = null;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                OrderList = await conn.QueryFirstOrDefaultAsync<OrderListDTO>(_procedures["getOrderListQuery"], new { UserId }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return OrderList ?? new NullOrderListDTO();
        }

        public async Task<IEnumerable<OrderListDTO>> Get()
        {
            IEnumerable<OrderListDTO> OrderLists = Enumerable.Empty<OrderListDTO>();

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                OrderLists = await conn.QueryAsync<OrderListDTO>(_procedures["getOrderListsQuery"], commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return OrderLists;
        }

        public async Task<bool> CheckIfExists(int Id)
        {
            bool check = false;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                check = await conn.ExecuteScalarAsync<bool>(_procedures["checkIfOrderListExistQuery"], new { Id }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return check;
        }
    }
}
