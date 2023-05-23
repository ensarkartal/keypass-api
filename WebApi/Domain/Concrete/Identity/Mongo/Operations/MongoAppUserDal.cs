using MongoDB.Driver;
using WebApi.Core.Security.Hashing;
using WebApi.Core.Tenant.Abstract;
using WebApi.Domain.Abstract.IDentity;
using WebApi.Domain.Concrete.Identity.Mongo.Infrastructure;
using WebApi.Entity.DataTransfers.Identity.AppUser;
using WebApi.Entity.Tables.Identity;

namespace WebApi.Domain.Concrete.Identity.Mongo.Operations;

public class MongoAppUserDal : BaseMongoDb,IAppUserDal
{
    private IMongoCollection<AppUser> _appUsercollection;
    public MongoAppUserDal(ITenantService tenantService, IConfiguration configuration) : base(tenantService, configuration)
    {
        _appUsercollection = _db.GetCollection<AppUser>("AppUsers");
    }

    public async Task<AppUser?> GetUser(string? userName)
    {
        var filter = Builders<AppUser>.Filter
            .Eq(r => r.Email, userName);
        var result = await _appUsercollection.Find(filter).FirstOrDefaultAsync();
        if (result == null)
            return null;
        return result;
    }

    public async Task<string> AddUSer(AddAppUserDto? user)
    {
        AppUser appUser = new();
        appUser.Id = Guid.NewGuid().ToString("N");
        HashingHelper.CreatePasswordHash(user.Password, out var passwordHash, out var passwordSalt);
        appUser.PasswordHash = passwordHash;
        appUser.PasswordSalt = passwordSalt;
        appUser.Email = user.Email;
        appUser.FullName = user.FullName;
        appUser.PhoneNumber = user.PhoneNumber;
        await _appUsercollection.InsertOneAsync(appUser);
        return appUser.Id;
    }

    public async Task UpdateUSer(string? id, UpdateAppUserDto? user)
    {
        var birim = Builders<AppUser>.Filter
            .Eq(restaurant => restaurant.Id, id);
        var update = Builders<AppUser>.Update
            .Set(restaurant => restaurant.Email, user.Email)
            .Set(restaurant => restaurant.FullName, user.FullName)
            .Set(restaurant => restaurant.PhoneNumber, user.MobilePhones);
        await _appUsercollection.UpdateOneAsync(birim, update);
    }

    public async Task DeleteUSer(string? appUserId)
    {
        var filter = Builders<AppUser>.Filter
            .Eq(r => r.Id, appUserId);
        await _appUsercollection.DeleteOneAsync(filter);
    }

    public async Task<GetAppUserDto> GetAppUser(string? appUserId)
    {
        var filter = Builders<AppUser>.Filter
            .Eq(r => r.Id, appUserId);
        var result = await _appUsercollection.Find(filter).FirstOrDefaultAsync();
        if (result == null)
            return null;
        return new GetAppUserDto()
        {
            Id = result.Id,
            Email = result.Email,
            IsActive = result.IsActive
        };
    }

    public async Task<List<GetAppUserDto>> GetAppUsers()
    {
        var result = await IAsyncCursorSourceExtensions.ToListAsync(_appUsercollection.AsQueryable());
        return result.Select(p => new GetAppUserDto()
        {
            Id = p.Id,
            Email = p.Email,
            IsActive = p.IsActive
        }).ToList();
    }
}