﻿using WebApi.Entity.DataTransfers.Identity.AppUser;
using WebApi.Entity.Tables.Identity;

namespace WebApi.Domain.Abstract.IDentity;

public interface IAppUserDal
{
    Task<AppUser?> GetUser(string? userName);
    Task<string> AddUSer(AddAppUserDto?  user);
    Task UpdateUSer(string? id, UpdateAppUserDto?  user);
    Task DeleteUSer(string? appUserId);
    Task<GetAppUserDto> GetAppUser(string? appUserId);
    Task<List<GetAppUserDto>> GetAppUsers();
}