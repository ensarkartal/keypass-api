using Amazon.Runtime.Internal;
using Core.Entity.Concrete;
using Core.Tenant.Abstract;
using Domain.Abstract.App;
using Domain.Concrete.Identity.Mongo.Infrastructure;
using Entity.DataTransfers.App.KeyGroup;
using Entity.Tables.App;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Domain.Concrete.App.MongoDb.Operations;

public class MongoKeyGroupDal : BaseMongoDb, IKeyGroupDal
{
    public MongoKeyGroupDal(ITenantService tenantService, IConfiguration configuration) : base(tenantService, configuration)
    {
    }

    public async Task<string> AddKeyGroup(AddKeyGroupDto? keyGroup)
    {
        IMongoCollection<KeyGroup> collection = _db.GetCollection<KeyGroup>("KeyGroups");
        var group = new KeyGroup()
        {
            Id = Guid.NewGuid().ToString("N"),
            Name = keyGroup.Name,
        };
        await collection.InsertOneAsync(group);
        return group.Id;
    }

    public async Task UpdateKeyGroyp(string? keyGroupId, UpdateKeyGroupDto? keyGroup)
    {
        IMongoCollection<KeyGroup> collection = _db.GetCollection<KeyGroup>("KeyGroups");
        var birim = Builders<KeyGroup>.Filter
            .Eq(restaurant => restaurant.Id, keyGroupId);
        var update = Builders<KeyGroup>.Update
            .Set(restaurant => restaurant.Name, keyGroup.Name);
        await collection.UpdateOneAsync(birim, update);
    }

    public async Task DeleteKeyGroup(string? keyGroupId)
    {
        var filter = Builders<KeyGroup>.Filter
            .Eq(r => r.Id, keyGroupId);
        IMongoCollection<KeyGroup> collection = _db.GetCollection<KeyGroup>("KeyGroups");
        await collection.DeleteOneAsync(filter);
    }

    public async Task<GetKeyGroupDto?> GetKeyGroup(string? keyGroupId)
    {
        var filter = Builders<KeyGroup>.Filter
            .Eq(r => r.Id, keyGroupId);
        IMongoCollection<KeyGroup> collection = _db.GetCollection<KeyGroup>("KeyGroups");
        var result = await collection.Find(filter).FirstOrDefaultAsync();
        if (result == null)
            return null;
        return new GetKeyGroupDto()
        {
            Id = result.Id,
            Name = result.Name,
        };
    }

    public async Task<List<GetKeyGroupDto>> GetKeyGroups()
    {
        IMongoCollection<KeyGroup> collection = _db.GetCollection<KeyGroup>("KeyGroups");
        return collection.AsQueryable().Select(p => new GetKeyGroupDto()
        {
            Id = p.Id,
            Name = p.Name,
        }).ToList();
    }
}