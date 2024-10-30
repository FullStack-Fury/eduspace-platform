using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.Profiles.Domain.Services;
using FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.REST.Resources;
using FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace FULLSTACKFURY.EduSpace.API.Profiles.Interfaces.REST;

public class AdministratorProfilesController(IAdminProfileCommandService profileCommandService)
: ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAdministratorProfile([FromBody] CreateAdminProfileResource resource)
    {
        var createAdminProfileCommand = CreateAdminProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var adminProfile = await profileCommandService.Handle(createAdminProfileCommand);
        
        if (adminProfile is null) return BadRequest();

        var adminProfileResource = AdminProfileResourceFromEntityAssembler.ToResourceFromEntity(adminProfile);
        
        return Ok(adminProfileResource); 
    }
}