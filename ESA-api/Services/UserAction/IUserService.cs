using ESA_api.Mapping.DTO.UserProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.UserAction
{
    public interface IUserService
    {
        Task<UserDTO> GetUserDataAsync(int userId);
        Task<List<UserDTO>> GetUsersAsync();
        Task<int> UpdateUserAsync(int id, UserDTO userDTO);
    }
}
