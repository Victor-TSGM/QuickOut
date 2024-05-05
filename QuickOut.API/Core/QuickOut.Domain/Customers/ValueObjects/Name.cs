using QuickOut.Domain.Common.Shared;
using QuickOut.Library;
using System.Text.RegularExpressions;

namespace QuickOut.Domain.Customers.ValueObjects
{
    public class Name : ValueObject
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }

        protected Name() { }

        public static Result<Name> New(string firstName, string lastName)
        {
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return Result<Name>.Fail("Nove não pode ser vazio");
            }

            Regex regex = new Regex(@"^[a-zA-Z]{3,}$");

            if(!regex.IsMatch(firstName))
            {
                return Result<Name>.Fail("Primeiro nome inválido");
            }

            if (!regex.IsMatch(lastName))
            {
                return Result<Name>.Fail("Sobrenome nome inválido");
            }

            Name name = new Name
            {
                FirstName = firstName,
                LastName = lastName
            };

            return Result<Name>.Success(name);
        }
    }
}