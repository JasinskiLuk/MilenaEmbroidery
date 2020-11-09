using Microsoft.Extensions.Configuration;
using MilenaEmbroidery.DTOs.General;
using MilenaEmbroidery.IServices.General;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilenaEmbroidery.DbServices.General
{
    public class DbUserService : DbBaseService, IUserService
    {
        public DbUserService(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> Create(UserDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(UserDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> Get()
        {
            throw new NotImplementedException();
        }
    }
}
