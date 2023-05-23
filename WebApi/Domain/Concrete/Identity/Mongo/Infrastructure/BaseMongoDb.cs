using MongoDB.Driver;
using WebApi.Core.Tenant.Abstract;

namespace WebApi.Domain.Concrete.Identity.Mongo.Infrastructure;

public class BaseMongoDb
{
    private readonly ITenantService _tenantService;
    private IConfiguration _configuration;
    private readonly IMongoClient _mongoClient;
    public IMongoDatabase _db;

    public BaseMongoDb(ITenantService tenantService, IConfiguration configuration)
    {
        _tenantService = tenantService;
        _configuration = configuration;
        _mongoClient = new MongoClient("mongodb://localhost:7002");
        _db = _mongoClient.GetDatabase("keypass_Master");
    }
}