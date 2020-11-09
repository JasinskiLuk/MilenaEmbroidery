namespace MilenaEmbroidery.DTOs.General
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PlotNo { get; set; }
        public string ApartmentNo { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class NullUserDTO : UserDTO
    {
        public NullUserDTO()
        {
            FirstName = "Empty";
            LastName = "Empty";
            Email = "Empty";
            Country = "Empty";
            City = "Empty";
            Street = "Empty";
            PlotNo = "Empty";
            ApartmentNo = "Empty";
            IsAdmin = false;
        }
    }
}
