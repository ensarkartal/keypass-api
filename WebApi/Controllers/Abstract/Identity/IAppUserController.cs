using Business.Handlers.Identity.Auth.Query;
using Entity.DataTransfers.App.KeyGroup;
using Entity.DataTransfers.Identity.AppUser;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Abstract.Identity;

public interface IAppUserController
{
    Task<IActionResult> Login(LoginQuery request);
    Task<IActionResult> Add(AddAppUserDto request);
    Task<IActionResult> Update(string? id, UpdateAppUserDto request);
    Task<IActionResult> Get(string? id);
    Task<IActionResult> Get();
    Task<IActionResult> Delete(string? id);
}