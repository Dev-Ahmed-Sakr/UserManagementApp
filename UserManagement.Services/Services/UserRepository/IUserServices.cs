
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Services.Models;

namespace DataEntry.Services.Services.UserRepository;

public interface IUserServices
{
    Task<ResponseDTO<bool>> Create(AddUserModel model);
    Task<ResponseDTO<UpdateUserModel>> GetById(long id);
    Task<ResponseDTO<IEnumerable<UserDTO>>> GetAll();
    Task<ResponseDTO<bool>> Update(UpdateUserModel model);
    Task<ResponseDTO<bool>> Delete(long userId);
}
