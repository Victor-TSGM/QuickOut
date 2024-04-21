using QuickOut.Domain.Common;
using QuickOut.Domain.Common.Interfaces;
using QuickOut.Library;

namespace QuickOut.Domain.Users
{
    public class User : IUser
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }
        public UserRole UserRole { get; private set; }
        public UserStatus UserStatus { get; private set; }
        public List<Section>? Sections { get; private set; }


        protected User()
        {

        }

        public static Result<User> New(
                string name,
                string cpf,
                string phone,
                string email,
                string password,
                DateTime birthDate,
                Address address
            )
        {
            User entity = new User()
            {
                Id = Guid.NewGuid(),
                Name = name,
                CPF = cpf,
                Phone = phone,
                Email = email,
                Password = password,
                BirthDate = birthDate,
                Address = address,
                UserRole = UserRole.Customer,
                UserStatus = UserStatus.Active,
            };

            return Result<User>.Success( entity );
        }
    }

    public enum UserType
    {
        Customer,
        Administrator
    }

    public enum UserStatus
    {
        Active,
        Inactive,
    }
}
