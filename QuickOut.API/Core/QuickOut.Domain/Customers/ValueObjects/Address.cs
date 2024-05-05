using QuickOut.Domain.Common.Shared;
using QuickOut.Library;

namespace QuickOut.Domain.Customers.ValueObjects;

public class Address : ValueObject
{
    public string Country { get; private set; }
    public string State { get; private set; }
    
    public string City { get; private set; }
    public string Street { get; private set; }
    public int AddressNumber { get; private set; }
    
    public string ZipCode { get; private set; }
    
    protected Address() {}

    public static Result<Address> New(
        string country, string state, string city, string street, int addressNumber, string zipCode)
    {
        if (string.IsNullOrEmpty(country))
            return Result<Address>.Fail("Pais não pode ser vazio");
        
        if (string.IsNullOrEmpty(state))
            return Result<Address>.Fail("Estado não pode ser vazio");
        
        if (string.IsNullOrEmpty(city))
            return Result<Address>.Fail("Cidade não pode ser vazio");
        
        if (string.IsNullOrEmpty(street))
            return Result<Address>.Fail("Rua não pode ser vazio");

        if (addressNumber <= 0)
            return Result<Address>.Fail("Numero vazio");
        
        if (string.IsNullOrEmpty(zipCode))
            return Result<Address>.Fail("CEP não pode ser vazio");

        Address address = new Address()
        {
            Country = country,
            State = state,
            City = city,
            Street = street,
            AddressNumber = addressNumber,
            ZipCode = zipCode
        };

        return Result<Address>.Success(address);
    }
}