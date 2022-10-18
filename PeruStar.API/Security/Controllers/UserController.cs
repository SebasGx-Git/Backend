
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeruStar.API.Security.Authorization.Attributes;
using PeruStar.API.Security.Domain.Models;
using PeruStar.API.Security.Domain.Services;
using PeruStar.API.Security.Domain.Services.Communication;
using PeruStar.API.Security.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace PeruStar.API.Security.Controllers;
[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Create, Read, Update and Delete a User")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [AllowAnonymous]
    [HttpPost("sign-in")]
    [SwaggerResponse(200, "The operation was success", typeof(UserResource))]
    [SwaggerResponse(400, "The client sent a bad request")]
    [SwaggerOperation(
        Summary = "Get a user using their credentials",
        Description = "Get a user using their credentials",
        OperationId = "SignIn",
        Tags = new[] { "User" })]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.AuthenticateAsync(request);
        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpPost("sign-up")]
    [SwaggerOperation(
        Summary = "Create a new user",
        Description = "Create a new user",
        OperationId = "SignUp",
        Tags = new[] { "User" })]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "User registered successfully" });
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all users",
        Description = "Get all users",
        OperationId = "GetAll",
        Tags = new[] { "User" })]
    public async Task<IActionResult> GetAll()
    {
        var response = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(response);
        return Ok(resources);
    }
    
    [AllowAnonymous]
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get a user by id",
        Description = "Get a user by id",
        OperationId = "GetById",
        Tags = new[] { "User" })]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _userService.FindByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(response);
        return Ok(resource);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a user",
        Description = "Update a user",
        OperationId = "Update",
        Tags = new[] { "User" })]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a user",
        Description = "Delete a user",
        OperationId = "Delete",
        Tags = new[] { "User" })]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }
}