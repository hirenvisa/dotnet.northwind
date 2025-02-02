using Persistence;

namespace Application.UnitTest.Common;

public class CommandTestBase : IDisposable
{
    public readonly NorthwindDbContext _context;

    public CommandTestBase() => this._context = NorthwindDbContextFactory.Create();

    public void Dispose()
    {
        NorthwindDbContextFactory.Distroy(_context);
    }
}