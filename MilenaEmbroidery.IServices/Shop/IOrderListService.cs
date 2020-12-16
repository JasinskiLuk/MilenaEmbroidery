using MilenaEmbroidery.DTOs.Shop;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingProject.Interfaces;

namespace MilenaEmbroidery.IServices.Shop
{
    public interface IOrderListService : ICreateUpdateService<OrderListDTO>, IDeleteService, IReadService<OrderListDTO>, IReadCollectionService<OrderListDTO>
    {
        Task<IEnumerable<OrderListDTO>> GetByOrderId(int OrderId);
    }
}
