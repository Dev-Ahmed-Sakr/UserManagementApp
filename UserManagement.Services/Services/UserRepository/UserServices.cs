
using DataEntry.Services.Services.Authentication;
using Microsoft.EntityFrameworkCore;
using UserManagement.Services.Models;

namespace DataEntry.Services.Services.UserRepository;

public class UserServices : IUserServices
{
    private readonly UserContext _context;
    private readonly IIdentityUserService _identityUserService;

    public UserServices(UserContext context, IIdentityUserService identityUserService)
    {
        _context = context;
        _identityUserService = identityUserService;
    }
    public async Task<ResponseDTO<bool>> Create(AddUserModel model)
    {
        try
        {
            var toBeAddedUser = new User
            {
                Id = 0,
                UserTypeId = model.UserTypeId,
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                CreatedBy = _identityUserService.GetUserID(),
                CreationDate = DateTime.UtcNow,
            };

            var addedUser = await _context.Users.AddAsync(toBeAddedUser);
            await _context.SaveChangesAsync();
            // TODO Check if addedUser is null
            return new ResponseDTO<bool>
            {
                Data = true,
                IsSuccess = true,
                Message = "User Added Successfully"
            };
        }
        catch (Exception)
        {
            return new ResponseDTO<bool>
            {
                Data = false,
                IsSuccess = false,
                Message = "Faild to add User !"
            };

        }

    }

    public async Task<ResponseDTO<UpdateUserModel>> GetById(long id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return new ResponseDTO<UpdateUserModel>
            {
                Data = null,
                IsSuccess = false,
                Message = "User Not Found"
            };
        }
        UpdateUserModel res = new UpdateUserModel
        {
            Id = user.Id,
            Address = user.Address,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserTypeId = user.UserTypeId

        };
        return new ResponseDTO<UpdateUserModel>
        {
            Data = res,
            IsSuccess = true,
            Message = ""
        };
    }

    public async Task<ResponseDTO<IEnumerable<UserDTO>>> GetAll()
    {
        var users = await _context.Users.Where(xx=>!xx.IsDeleted).ToListAsync();

        // Coz Who will select if there is no users
        //if (users==null || users.Count() == 0)
        //{
        //    return new ResponseDTO<User>
        //    {
        //        Data = null,
        //        IsSuccess = false,
        //        Message = "User Not Found"
        //    };
        //}
        List<UserDTO> result = new List<UserDTO>();
        foreach (var user in users)
        {

            result.Add(new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                UserTypeId = user.UserTypeId,
                //UpdatedBy = _identityUserService.GetUserID();
                //UpdateDate = toBUpdatedUser.UpdateDate; 
            });
        }
        return new ResponseDTO<IEnumerable<UserDTO>>
        {
            Data = result,
            IsSuccess = true,
            Message = ""
        };
    }

    public async Task<ResponseDTO<bool>> Update(UpdateUserModel model)
    {
        try
        {
            var toBUpdatedUser = await _context.Users.FirstOrDefaultAsync(user => user.Id == model.Id);
            if (toBUpdatedUser == null)
            {
                return new ResponseDTO<bool>
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "Can't find a User with this information"
                };
            }
            toBUpdatedUser.FirstName = model.FirstName;
            toBUpdatedUser.LastName = model.LastName;
            toBUpdatedUser.Address = model.Address;
            toBUpdatedUser.PhoneNumber = model.PhoneNumber;
            toBUpdatedUser.Email = model.Email;
            toBUpdatedUser.UserTypeId = model.UserTypeId;
            toBUpdatedUser.UpdatedBy = _identityUserService.GetUserID();
            toBUpdatedUser.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return new ResponseDTO<bool>
            {
                Data = true,
                IsSuccess = true,
                Message = "User Data Updated Successfully"
            };
        }
        catch (Exception)
        {
            return new ResponseDTO<bool>
            {
                Data = false,
                IsSuccess = false,
                Message = "Faild to Update User !"
            };
        }

    }

    public async Task<ResponseDTO<bool>> Delete(long userId)
    {
        var toBeDeeletedUser = await _context.Users.FirstOrDefaultAsync(user => user.Id == userId);
        if (toBeDeeletedUser == null)
        {
            return new ResponseDTO<bool> { Message = "User Not Found", Data = false, IsSuccess = false };
        }

        toBeDeeletedUser.IsDeleted = true;
        toBeDeeletedUser.DeletedBy = _identityUserService.GetUserID();
        toBeDeeletedUser.DeleteDate = DateTime.Now;

        await _context.SaveChangesAsync();
        return new ResponseDTO<bool>
        {
            Data = false,
            IsSuccess = false,
            Message = "User Deleted Successfully"
        };
    }
}

