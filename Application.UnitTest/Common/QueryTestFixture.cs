using Application.Common.Mapper;
using AutoMapper;
using Persistence;

namespace Application.UnitTest.Common;

public class QueryTestFixture: IDisposable
{
    public NorthwindDbContext Context { get; set; }
    public IMapper Mapper { get; set; }

    public QueryTestFixture()
    {
        Context = NorthwindDbContextFactory.Create();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        Mapper = configurationProvider.CreateMapper();
    }
    
    public void Dispose()
    {
        NorthwindDbContextFactory.Distroy(Context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture>
    {
    }
}