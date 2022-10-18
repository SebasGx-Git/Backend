using AutoMapper;
using PeruStar.API.Security.Authorization.Handlers.Interfaces;
using PeruStar.API.Security.Domain.Models;
using PeruStar.API.Security.Domain.Repositories;
using PeruStar.API.Security.Domain.Services;
using PeruStar.API.Security.Domain.Services.Communication;
using PeruStar.API.Security.Exceptions;
using PeruStar.API.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace PeruStar.API.Security.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }

    public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request)
    {
        var user = await _userRepository.FindByEmailAsync(request.Email!);
        //Valite
        if (user.Equals(null) || !BCryptNet.Verify(request.Password, user.PasswordHash))
        {
            throw new AppExceptions("Invalid credentials");
        }
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtHandler.GenerateToken(user);
        return response;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> FindByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user.Equals(null))
        {
            throw new AppExceptions("User not found");
        }
        return user;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        if(_userRepository.ExistsByEmail(request.Email!))
        {
            throw new AppExceptions($"Manager with email {request.Email} already exists");
        }
        var user = _mapper.Map<User>(request);
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            throw new AppExceptions($"An Error occurred while saving the user: {ex.Message}");
        }
    }

    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user=await _userRepository.FindByIdAsync(id);
        var userWithSameEmail = await _userRepository.FindByEmailAsync(request.Email!);
        if (userWithSameEmail != null && userWithSameEmail.Id != id)
        {
            throw new AppExceptions($"User with email {request.Email} already exists");
        }
        if(!string.IsNullOrEmpty(request.Password)&&request.Password!="")
        {
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
        }
        else
        {
            user.PasswordHash = user.PasswordHash;
        }
        _mapper.Map(request, user);
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            throw new AppExceptions($"An Error occured while updating user: {ex.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user.Equals(null))
        {
            throw new KeyNotFoundException("Manager not found");
        }

        try
        {
            _userRepository.Delete(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppExceptions($"An Error occured while deleting manager: {e.Message}");
        }
    }
}