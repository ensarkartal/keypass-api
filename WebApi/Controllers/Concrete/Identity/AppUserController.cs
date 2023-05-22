using Business.Handlers.App.KeyGroup.Command.AddKeyGroup;
using Business.Handlers.App.KeyGroup.Command.DeleteKeyGroup;
using Business.Handlers.App.KeyGroup.Command.UpdateKeyGroup;
using Business.Handlers.App.KeyGroup.Query.GetKeyGroup;
using Business.Handlers.App.KeyGroup.Query.GetKeyGroups;
using Business.Handlers.Identity.Auth.Query;
using Business.Handlers.Identity.User.Command.AddAppUser;
using Business.Handlers.Identity.User.Command.DeleteUser;
using Business.Handlers.Identity.User.Command.UpdateUser;
using Business.Handlers.Identity.User.Queries.GetUser;
using Business.Handlers.Identity.User.Queries.GetUsers;
using Entity.DataTransfers.App.KeyGroup;
using Entity.DataTransfers.Identity.AppUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstract.Identity;

namespace WebApi.Controllers.Concrete.Identity;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class AppUserController : ControllerBase, IAppUserController
{
    private readonly IMediator _mediator;

    public AppUserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginQuery request)
    {
        var result = await _mediator.Send(new LoginQuery() { Email = request.Email, Password = request.Password });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddAppUserDto request)
    {
        var result = await _mediator.Send(new AddAppCommand() { CreateUserRequest = request });
        return StatusCode(201, result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string? id, UpdateAppUserDto request)
    {
        await _mediator.Send(new UpdateAppUserCommand() { UserId = id, UpdateUserRequest = request });
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string? id)
    {
        var result = await _mediator.Send(new GetUserQuery() { UserId = id });
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetUsersQuery());
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string? id)
    {
        await _mediator.Send(new DeleteAppUserCommand() { UserId = id });
        return Ok();
    }
}