using Microsoft.EntityFrameworkCore;
using QuickOut.Application.Common;
using QuickOut.Domain.Customers;
using QuickOut.Library;

namespace QuickOut.Application.Customers.Queries
{
    public class GetCustomerByIdParams
    {
        public Guid Id { get; }
    }

    public class GetCustomerByIdResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class GetCustomerByIdQueryHanndler : IQueryHandler<GetCustomerByIdParams, GetCustomerByIdResult>
    {
        private readonly IQueryDatabase database;

        public GetCustomerByIdQueryHanndler(IQueryDatabase database)
        {
            this.database = database;
        }

        public async Task<GetCustomerByIdResult> Handle(GetCustomerByIdParams parameters)
        {
            IQueryable<Customer> query = database.Query<Customer>().AsNoTracking();

            GetCustomerByIdResult? result = await query
                .Select(x => new GetCustomerByIdResult
                {
                    Id = x.Id,
                    Name = x.Name.FirstName + " " + x.Name.LastName,
                    Cpf = x.CPF.Document,
                    Email = x.Email.Address,
                    Phone = x.Phone.Number,
                })
                .FirstOrDefaultAsync(x => x.Id == parameters.Id);
            
            return result;
        }
    }
}