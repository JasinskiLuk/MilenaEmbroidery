using MilenaEmbroidery.DTOs.Shop;
using TestingProject.Interfaces;

namespace MilenaEmbroidery.IServices.Shop
{
    public interface IOrderListService : ICreateUpdateService<OrderListDTO>, IDeleteService, IReadService<OrderListDTO>, IReadCollectionService<OrderListDTO>
    {
    }
}
