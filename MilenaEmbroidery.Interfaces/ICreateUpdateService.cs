using System.Threading.Tasks;

namespace TestingProject.Interfaces
{
    public interface ICreateUpdateService<T>
    {
        Task<int> Create(T model);
        Task<int> Update(T model);
    }
}
