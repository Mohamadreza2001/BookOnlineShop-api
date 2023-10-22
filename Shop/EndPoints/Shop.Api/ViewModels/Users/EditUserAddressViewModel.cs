namespace Shop.Api.ViewModels.Users
{
    public class EditUserAddressViewModel
    {
        public long AddressId { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PostAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
    }
}
