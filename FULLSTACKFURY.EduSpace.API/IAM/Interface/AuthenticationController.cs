using System.Net.Mime;
using FULLSTACKFURY.EduSpace.API.IAM.Domain.Model.Commands;
using FULLSTACKFURY.EduSpace.API.IAM.Domain.Services;
using FULLSTACKFURY.EduSpace.API.IAM.Interface.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FULLSTACKFURY.EduSpace.API.IAM.Interface.Transform;

public class AuthenticationController
{
    //TODO: Add token 
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AccountController(IAccountCommandService accountCommandService, IAccountQueryService accountQueryService)
        : ControllerBase
    {
        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
        {
            var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
            await accountCommandService.Handle(signUpCommand);
            return Ok(new { message = "User created succesfully" });
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
        {
            var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
            var authenticatedUser = await accountCommandService.Handle(signInCommand);
            var authenticatedResource = AccountResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser);
            return Ok(authenticatedUser);
        }
    }
}