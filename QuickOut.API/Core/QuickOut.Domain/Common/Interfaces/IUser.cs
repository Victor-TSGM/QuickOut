namespace QuickOut.Domain.Common.Interfaces
{
    public interface IUser
    {
        public Guid Id { get;  }
        public UserRole UserRole { get;  }
        public string Name { get;  }
        public string Email { get;  }
        public string Password { get;  }
    }

    public enum UserRole
    {
        Administrator,
        Customer
    }
}
