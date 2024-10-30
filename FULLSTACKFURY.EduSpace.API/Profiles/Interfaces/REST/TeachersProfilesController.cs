using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.REST.Resources;
using FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.REST;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TeachersProfilesController(ITeacherProfileCommandService teacherProfileCommandService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTeacherProfile([FromBody] CreateTeacherProfileResource resource)
    {
        var createProfileCommand = CreateTeacherProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var teacherProfile = await teacherProfileCommandService.Handle(createProfileCommand);
        if (teacherProfile is null) return BadRequest();
        var teacherProfileResource = TeacherProfileResourceFromEntityAssembler.ToResourceFromEntity(teacherProfile);
        return Ok(teacherProfileResource);
    }
}