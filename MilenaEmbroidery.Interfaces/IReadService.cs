using System.Threading.Tasks;

namespace TestingProject.Interfaces
{
    public interface IReadService<T>
    {
        Task<T> Get(int Id);
        Task<bool> CheckIfExists(int Id);
    }
}
