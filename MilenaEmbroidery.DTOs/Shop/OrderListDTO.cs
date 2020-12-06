namespace MilenaEmbroidery.DTOs.Shop
{
    public class OrderListDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class NullOrderListDTO : OrderListDTO
    {
        public NullOrderListDTO()
        {
            Id = -1;
            OrderId = -1;
            ProductId = -1;
            Quantity = -1;
        }
    }
}
