using MilenaEmbroidery.DTOs.Shop;
using TestingProject.Interfaces;

namespace MilenaEmbroidery.IServices.Shop
{
    public interface IOrderService : ICreateUpdateService<OrderDTO>, IDeleteService, IReadService<OrderDTO>, IReadCollectionService<OrderDTO>
    {
    }
}
