using AutoMapper;
using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.BLL.Infrastructure;
using NLayerCasesStore.BLL.Interfaces;
using NLayerCasesStore.DAL.DataModels;
using NLayerCasesStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Services
{
    public class UserService : IUserService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public UserDTO GetUser(int id)
        {
            var userItem = _unitOfWork.Users.Get(id);

            if (userItem == null)
            {
                throw new ValidationException("", "пользователь не найден");
            }

            return _mapper.Map<UserDTO>(userItem);
        }
        
        public UserDTO GetUserOnEmailAndPassword(string email, string password)
        {
            var userItem = _unitOfWork.Users.GetOnEmailAndPassword(email, password);

            if (userItem == null)
            {
                throw new ValidationException("", "пользователь не найден");
            }

            return _mapper.Map<UserDTO>(userItem);
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _unitOfWork.Users.GetAll();
            var userDto = _mapper.Map<IEnumerable<UserDTO>>(users);
            return userDto;
        }
        public bool CheckLogin(string login)
        {
            return _unitOfWork.Users.CheckLogin(login);
        }
        public bool CheckEmail(string email)
        {
            return _unitOfWork.Users.CheckEmail(email);
        }

        public void CreateUser(UserDTO userDto)
        {
            var userDM = _mapper.Map<UserDataModel>(userDto);
            _unitOfWork.Users.Create(userDM);
            _unitOfWork.Save();
        }
    }
}
