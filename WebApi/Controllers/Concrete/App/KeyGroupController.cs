using Business.Handlers.App.KeyGroup.Command.AddKeyGroup;
using Business.Handlers.App.KeyGroup.Command.DeleteKeyGroup;
using Business.Handlers.App.KeyGroup.Command.UpdateKeyGroup;
using Business.Handlers.App.KeyGroup.Query.GetKeyGroup;
using Business.Handlers.App.KeyGroup.Query.GetKeyGroups;
using Entity.DataTransfers.App.KeyGroup;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Abstract.App;

namespace WebApi.Controllers.Concrete.App;

[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class KeyGroupController : ControllerBase, IKeyGroupController
{
    private readonly IMediator _mediator;

    public KeyGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddKeyGroupDto request)
    {
        var result = await _mediator.Send(new AddKeyGroupCommand() { AddKeyGroupDto = request });
        return StatusCode(201, result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string? id, UpdateKeyGroupDto request)
    {
        await _mediator.Send(new UpdateKeyGroupCommand() { KeyGroupId = id, UpdateKeyGroupDto = request });
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string? id)
    {
        var result = await _mediator.Send(new GetKeyGroupQuery() { KeyGroupId = id });
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new GetKeyGroupsQuery());
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string? id)
    {
        await _mediator.Send(new DeleteKeyGroupCommand() { KeyGroupId = id });
        return Ok();
    }
}