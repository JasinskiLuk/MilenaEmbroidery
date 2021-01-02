using MilenaEmbroidery.DTOs.General;
using System.Threading.Tasks;
using TestingProject.Interfaces;

namespace MilenaEmbroidery.IServices.General
{
    public interface IUserService : ICreateUpdateService<UserDTO>, IReadService<UserDTO>, IReadCollectionService<UserDTO>
    {
        // TODO:  Add autenthications to app
        Task<UserDTO> Login(string FirstName, string LastName);
    }
}
