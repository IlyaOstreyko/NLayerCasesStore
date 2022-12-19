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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

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
            var userDto = _mapper.Map<UserDTO>(userItem);

            return userDto;
        }
        public int GetIdOnEmail(string email)
        {
            var userId = _unitOfWork.Users.GetIdOnEmail(email);

            return userId;
        }

        public UserDTO GetUserOnEmail(string email)
        {
            var userId = _unitOfWork.Users.GetIdOnEmail(email);
            var userDto = GetUser(userId);
            return userDto;
        }

        public UserDTO GetUserOnEmailAndPassword(string email, string password)
        {
            var userItem = _unitOfWork.Users.GetOnEmailAndPassword(email, password);

            if (userItem == null)
            {
                var user = new UserDTO() { UserMail = null, UserPassword = null };
                return user;
            }
            var userDto = _mapper.Map<UserDTO>(userItem);

            return userDto;
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
