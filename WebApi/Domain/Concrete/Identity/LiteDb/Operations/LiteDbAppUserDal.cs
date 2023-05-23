using Core.Security.Hashing;
using Core.Tenant.Abstract;
using Domain.Abstract.IDentity;
using Domain.Concrete.Identity.LiteDb.Infrastructure;
using Entity.DataTransfers.Identity.AppUser;
using Entity.Tables.Identity;
using LiteDB.Async;
using Microsoft.Extensions.Configuration;
using SharpCompress.Common;

namespace Domain.Concrete.Identity.LiteDb.Operations;

public class LiteDbAppUserDal : BaseLiteDb, IAppUserDal
{
    public LiteDbAppUserDal(ITenantService tenantService, IConfiguration configuration) : base(tenantService, configuration)
    {
    }

    public async Task<AppUser?> GetUser(string? userName)
    {
        var tablename = nameof(AppUser);
        var _collection = Db.GetCollection<AppUser>(tablename);
        var result = await _collection.FindOneAsync(p => p.Email == userName);
        return result;
    }

    public async Task<string> AddUSer(AddAppUserDto? user)
    {
        var tablename = nameof(AppUser);
        var _collection = Db.GetCollection<AppUser>(tablename);
        AppUser appUser = new();
        appUser.Id = Guid.NewGuid().ToString("N");
        HashingHelper.CreatePasswordHash(user.Password, out var passwordHash, out var passwordSalt);
        appUser.PasswordHash = passwordHash;
        appUser.PasswordSalt = passwordSalt;
        appUser.Email = user.Email;
        appUser.FullName = user.FullName;
        appUser.PhoneNumber = user.PhoneNumber;
        await _collection.InsertAsync(appUser);
        return appUser.Id;
    }

    public async Task UpdateUSer(string? id, UpdateAppUserDto user)
    {
        var tablename = nameof(AppUser);
        var _collection = Db.GetCollection<AppUser>(tablename);
        var result = await _collection.FindByIdAsync(id);
        result.Email = user.Email;
        result.FullName = user.FullName;
        result.PhoneNumber = user.MobilePhones;
    }

    public async Task DeleteUSer(string? appUserId)
    {
        var tablename = nameof(AppUser);
        var _collection = Db.GetCollection<AppUser>(tablename);
        await _collection.DeleteAsync(appUserId);
    }

    public async Task<GetAppUserDto> GetAppUser(string? appUserId)
    {
        var tablename = nameof(AppUser);
        var _collection = Db.GetCollection<AppUser>(tablename);
        var result = await _collection.FindByIdAsync(appUserId);
        return new GetAppUserDto()
        {
            Id = result.Id,
            Email = result.Email,
            IsActive = result.IsActive,
        };
    }

    public async Task<List<GetAppUserDto>> GetAppUsers()
    {
        var tablename = nameof(AppUser);
        var _collection = Db.GetCollection<AppUser>(tablename);
        var result = await _collection.Query().Select(p => new GetAppUserDto()
        {
            Id = p.Id,
            Email = p.Email,
            IsActive = p.IsActive,
        }).ToListAsync();
        return result;
    }


}