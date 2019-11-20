using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.UserProfileDTO;
using ESA_api.Repositories.UserRepository.NormalUser;

namespace ESA_api.Services.UserAction
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserDataAsync(int userId)
        {
            var userData = await _repository.GetUserDataAsync(userId);
            return _mapper.Map<UserDTO>(userData);
        }
    }
}
