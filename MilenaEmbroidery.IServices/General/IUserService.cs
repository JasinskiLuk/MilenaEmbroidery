using MilenaEmbroidery.DTOs.General;
using TestingProject.Interfaces;

namespace MilenaEmbroidery.IServices.General
{
    public interface IUserService : ICreateUpdateService<UserDTO>, IReadCollectionService<UserDTO>
    {
    }
}
