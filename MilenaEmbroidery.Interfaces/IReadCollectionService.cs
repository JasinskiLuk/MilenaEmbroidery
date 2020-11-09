using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestingProject.Interfaces
{
    public interface IReadCollectionService<T>
    {
        Task<IEnumerable<T>> Get();
    }
}
