namespace MilenaEmbroidery.DTOs.Shop
{
    public class OrderStatusDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class NullOrderStatusDTO : OrderStatusDTO
    {
        public NullOrderStatusDTO()
        {
            Name = "Empty";
            Code = "N/A";
        }
    }
}
