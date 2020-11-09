namespace MilenaEmbroidery.DTOs.Shop
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
    }

    public class NullOrderDTO : OrderDTO
    {
        public NullOrderDTO()
        {
            UserId = -1;
            OrderStatusId = -1;
        }
    }
}
