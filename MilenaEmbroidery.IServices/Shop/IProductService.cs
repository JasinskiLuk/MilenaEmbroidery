using MilenaEmbroidery.DTOs.Shop;
using TestingProject.Interfaces;

namespace MilenaEmbroidery.IServices.Shop
{
    public interface IProductService : ICreateUpdateService<ProductDTO>, IDeleteService, IReadService<ProductDTO>, IReadCollectionService<ProductDTO>
    {
    }
}
