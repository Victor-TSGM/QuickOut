using Microsoft.EntityFrameworkCore;
using QuickOut.Application.Common;
using QuickOut.Domain.Estabilishments;
using QuickOut.Library;

namespace QuickOut.Application.Estabilishments.Queries;

public class ReadEstabilishmentsParams
{
    public int Skip { get; set; }
    public int Take { get; set; }
    public List<string>? Filters { get; set; } = new();
}

public class ReadEstabilishmentsResult
{
    public List<ReadEstabilishmentsResultItem> Data { get; set; }
    public int total { get; set; }
}

public class ReadEstabilishmentsResultItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Address { get; set; }
    //public string Rating { get; set; }
    //public string Distance { get; set; }
}

public class ReadEstabilishmentsQueryHandler : IQueryHandler<ReadEstabilishmentsParams, ReadEstabilishmentsResult>
{
    private readonly IQueryDatabase database;

    public ReadEstabilishmentsQueryHandler(IQueryDatabase database)
    {
        this.database = database;
    }
    
    public async Task<ReadEstabilishmentsResult> Handle(ReadEstabilishmentsParams parameters)
    {
        IQueryable<Estabilishment> query = database.Query<Estabilishment>().AsNoTracking();

        if (parameters.Filters.Any())
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{parameters.Filters[0]}%"));
        }

        List<ReadEstabilishmentsResultItem> data = await query
            .Select(x => new ReadEstabilishmentsResultItem
            {
                Id = x.Id,
                Name = x.Name
            })
            .OrderBy(x => x.Name)
            .Skip((parameters.Skip - 1) * parameters.Take)
            .Take((parameters.Take))
            .ToListAsync();

        return new ReadEstabilishmentsResult()
        {
            Data = data,
            total = data.Count
        };
    }
}