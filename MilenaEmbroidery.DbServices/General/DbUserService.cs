using Dapper;
using Microsoft.Extensions.Configuration;
using MilenaEmbroidery.DTOs.General;
using MilenaEmbroidery.IServices.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MilenaEmbroidery.DbServices.General
{
    public class DbUserService : DbBaseService, IUserService
    {
        private static Dictionary<string, string> _procedures = new Dictionary<string, string>
        {
            { "createUserQuery", "[General].[up_CreateUser]" },
            { "updateUserQuery", "[General].[up_UpdateUser]" },
            { "getUserQuery", "[General].[up_GetUser]" },
            { "getUsersQuery", "[General].[up_GetUsers]" },
            { "loginQuery", "[General].[up_LoginUser]" }
        };

        public DbUserService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> Create(UserDTO DTO)
        {
            int id = -1;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                var model = new { DTO.FirstName, DTO.LastName, DTO.Email, DTO.Country, DTO.City, DTO.Street, DTO.PlotNo, DTO.ApartmentNo, DTO.IsAdmin };

                id = await conn.ExecuteScalarAsync<int>(_procedures["createUserQuery"], model, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return id;
        }

        public async Task<int> Update(UserDTO DTO)
        {
            int id = -1;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                var model = new { DTO.Id, DTO.FirstName, DTO.LastName, DTO.Email, DTO.Country, DTO.City, DTO.Street, DTO.PlotNo, DTO.ApartmentNo, DTO.IsAdmin };

                id = await conn.ExecuteScalarAsync<int>(_procedures["updateUserQuery"], model, commandType: CommandType.StoredProcedure);
            }
            catch
            {

                throw;
            }

            return id;
        }

        public async Task<UserDTO> Get(int Id)
        {
            UserDTO user = null;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                user = await conn.QueryFirstOrDefaultAsync<UserDTO>(_procedures["getUserQuery"], new { Id }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return user ?? new NullUserDTO();
        }

        public async Task<IEnumerable<UserDTO>> Get()
        {
            IEnumerable<UserDTO> users = Enumerable.Empty<UserDTO>();

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                users = await conn.QueryAsync<UserDTO>(_procedures["getUsersQuery"], commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return users;
        }

        public Task<bool> CheckIfExists(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Login(string FirstName, string LastName)
        {
            int loggedUserId = -1;

            SqlConnection conn = new SqlConnection(_connectionString);

            try
            {
                loggedUserId = await conn.ExecuteScalarAsync<int>(_procedures["loginQuery"], new { FirstName, LastName }, commandType: CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }

            return loggedUserId;
        }
    }
}
