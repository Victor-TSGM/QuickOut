using Microsoft.EntityFrameworkCore;
using QuickOut.Infrastructure.Common;
using QuickOut.Library;

namespace QuickOut.Infrastructure;
public class UnitOfWork : IDisposable
{
    private readonly QuickOutContext _dbContext;
    private bool _disposed;

    public UnitOfWork(QuickOutContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Result Commit()
    {
        try
        {
            _dbContext.SaveChanges();
            return Result.Success();
        }
        catch (Exception ex)
        {
            Rollback();
            return Result.Fail(ex.Message);
        }
    }

    public void Rollback()
    {
        foreach (var entry in _dbContext.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Modified:
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
            }
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}