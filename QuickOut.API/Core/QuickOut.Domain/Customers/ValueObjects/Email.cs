using System.Text.RegularExpressions;
using QuickOut.Domain.Common.Shared;
using QuickOut.Library;

namespace QuickOut.Domain.Customers.ValueObjects;

public class Email : ValueObject
{
    public string Address { get; private set; }
    
    protected Email() {}

    public static Result<Email> New(string address)
    {
        if (string.IsNullOrEmpty(address))
        {
            return Result<Email>.Fail("Email inválido");
        }

        Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

        if (!regex.IsMatch(address))
        {
            return Result<Email>.Fail("Email inválido");
        }

        Email email = new Email()
        {
            Address = address
        };

        return Result<Email>.Success(email);
    }
}