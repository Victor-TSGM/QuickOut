using Microsoft.EntityFrameworkCore;
using QuickOut.Application.Common;
using QuickOut.Domain.Products;
using QuickOut.Domain.Products.ValueObjects;
using QuickOut.Library;

namespace QuickOut.Application.Products.Queries;

public class ReadProductsParams
{
    public Guid? EstabilishmentId { get; set; }
    public string? Category { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public List<string>? Filters { get; set; } = new();
}

public class ReadProductsResult
{
    public List<ReadProductsResultItem> Data { get; set; }
    public int Total { get; set; }
}

public class ReadProductsResultItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    // public Promotion Promotion { get; set; }
}

public class ReadProductsQueryHandler : IQueryHandler<ReadProductsParams, ReadProductsResult>
{
    private readonly IQueryDatabase database;

    public ReadProductsQueryHandler(IQueryDatabase database)
    {
        this.database = database;
    }
    
    public async Task<ReadProductsResult> Handle(ReadProductsParams parameters)
    {
        IQueryable<Product> query = database.Query<Product>().AsNoTracking();

        if (parameters.Filters.Any())
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{parameters.Filters[0]}%"));
        }

        List<ReadProductsResultItem> data = await query
            .Select(x => new ReadProductsResultItem()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            })
            .OrderBy(x => x.Name)
            .Skip((parameters.Skip - 1) * parameters.Take)
            .Take(parameters.Take)
            .ToListAsync();

        return new ReadProductsResult()
        {
            Data = data,
            Total = data.Count
        };
    }
}