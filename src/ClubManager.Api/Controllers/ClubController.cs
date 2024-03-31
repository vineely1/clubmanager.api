using ClubManager.Application.Clubs.Command.CreateClub;
using ClubManager.Application.Clubs.Command.DeleteClub;
using ClubManager.Application.Clubs.Command.UpdateClub;
using ClubManager.Application.Clubs.Dtos;
using ClubManager.Application.Clubs.Queries.GetAllClubsQuery;
using ClubManager.Application.Clubs.Queries.GetClubByIdQuery;
using ClubManager.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClubManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ClubController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    [Route("~/api/[controller]s")]
    public async Task<ActionResult<IEnumerable<Club>>> GetAll([FromQuery] GetAllClubsQuery query)
    {
        var clubs = await mediator.Send(query);
        return Ok(clubs);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ClubDto>> Get([FromRoute] int id)
    {
        var club = await mediator.Send(new GetClubByIdQuery(id));
        if (club == null)
            return NotFound();

        return Ok(club);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClub(CreateClubCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateClub([FromRoute] int id, [FromBody] UpdateClubCommand command)
    {
        command.Id = id;
        var routeId = await mediator.Send(command);
        return CreatedAtAction(nameof (Get), new { id = routeId }, null); 
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteClub([FromRoute] int id)
    {
        await mediator.Send(new DeleteClubCommand(id));
        return Ok();
    }
}
