using System.Text.RegularExpressions;
using QuickOut.Library;

namespace QuickOut.Domain.Customers.ValueObjects;

public class PhoneNumber
{
    public string Number { get; private set; }
    
    protected PhoneNumber() {}

    public static Result<PhoneNumber> New(string number)
    {
        if (string.IsNullOrEmpty(number))
        {
            return Result<PhoneNumber>.Fail("Número de telefone inválido");
        }

        Regex regex = new Regex(@"^[+]?[(]?[0-9]{3}[)]?[-\s.]?[0-9]{3}[-\s.]?[0-9]{4,6}$");

        if (!regex.IsMatch(number))
        {
            return Result<PhoneNumber>.Fail("Número de telefone inválido");
        }

        PhoneNumber phone = new PhoneNumber
        {
            Number = number
        };

        return Result<PhoneNumber>.Success(phone);
    }
}