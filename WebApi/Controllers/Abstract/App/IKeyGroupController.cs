
using Entity.DataTransfers.App.KeyGroup;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Abstract.App;

public interface IKeyGroupController
{
    Task<IActionResult> Add(AddKeyGroupDto request);
    Task<IActionResult> Update(string? id, UpdateKeyGroupDto request);
    Task<IActionResult> Get(string? id);
    Task<IActionResult> Get();
    Task<IActionResult> Delete(string? id);
}