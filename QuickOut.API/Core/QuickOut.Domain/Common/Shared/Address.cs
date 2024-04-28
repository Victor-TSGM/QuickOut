namespace QuickOut.Domain.Common
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int AddressNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
