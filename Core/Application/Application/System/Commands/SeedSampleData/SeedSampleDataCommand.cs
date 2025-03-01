using MediatR;
using Northwind.Application.Common.Interfaces;

namespace Northwind.Application.System.Commands.SeedSampleData;

public class SeedSampleDataCommand : IRequest<Unit>
{
}

public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand, Unit>
{
    private readonly INorthwindDbContext _context;

    public SeedSampleDataCommandHandler(INorthwindDbContext context)
    {
        this._context = context;
    }
    public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
    {
        var seeder = new SampleDataSeeder(_context);
        await seeder.SeedAllAsync(cancellationToken);

        return Unit.Value;
    }
}