using HospitalManagementSystem.Core.CQRS.Relative.Commands.Models;
using HospitalManagementSystem.Core.CQRS.Relative.Queries.Models;
using HospitalManagementSystem.DataService.DTOs.Relative;
using HospitalManagementSystem.Entites.Entites;
using HospitalManagementSystem.Entites.Roles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HospitalManagementSystem.Presentation.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = nameof(RolesEnum.Admin))]
public class RelativeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly UserManager<ApplicationUser> _userManager;
    public RelativeController(IMediator mediator, UserManager<ApplicationUser> userManager)
    {
        _mediator = mediator;
        _userManager = userManager;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RelativeReadDTO>> GetRelative(string id)
    {
        var result = await _mediator.Send(new GetRelativeQuery(id));
        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IQueryable<RelativeReadDTO>>> GetAllRelatives()
    {
        var result = await _mediator.Send(new GetAllRelativesQuery());
        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }


    [HttpPost]
    public async Task<ActionResult<RelativeCreateDTO>> CreateRelative(RelativeCreateDTO relativeCreate)
    {
        string password = GeneratePassword(relativeCreate);
        var relative = new Relative
        {
            FirstName = relativeCreate.FirstName,
            LastName = relativeCreate.LastName,
            SSN = relativeCreate.SSN,
            UserName = relativeCreate.FirstName + relativeCreate.LastName,
            PasswordHash = password,
            PatientId = relativeCreate.PatientId
        };
        var result = await _userManager.CreateAsync(relative, password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok(new RelativeCreatedDTO(relative.SSN, password));
    }

    private string GeneratePassword(RelativeCreateDTO relativeCreateDTO)
    {
        var password = new StringBuilder();
        password.Append(relativeCreateDTO.FirstName[0..2].ToUpper());
        password.Append(relativeCreateDTO.LastName[0..2].ToLower());
        password.Append('@');
        password.Append(relativeCreateDTO.SSN.Substring(0, 6));
        return password.ToString();
    }
    // for testing
    [HttpGet]
    public ActionResult<string> GetPassword()
    {
        var relative = new RelativeCreateDTO
        {
            FirstName = "abdullrhman",
            LastName = "Elhelw",
            SSN = "14725836912345"
        };
        return Ok(GeneratePassword(relative));
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteRelative(string id)
    {
        var result = await _mediator.Send(new DeleteRelativeCommand(id));
        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateRelative(RelativeUpdateDTO relative)
    {
        var result = await _mediator.Send(new UpdateRelativeCommand(relative));
        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    [HttpPatch]

    public ActionResult UpdateRelative(string id, JsonPatchDocument patchDocument)
    {
        var result = _mediator.Send(new UpdateRelativePatchCommand(id, patchDocument));
        return result.Result.IsSuccess ? Ok() : NotFound(result.Result.Error);
    }

    [HttpGet]
    public ActionResult<IQueryable<RelativeReadDTO>> FindRelativeByName(string name)
    {
        var result = _mediator.Send(new FindRelativesByNameQuery(name));
        return result.Result.IsSuccess ? Ok(result.Result.Data) : NotFound(result.Result.Error);
    }

}
