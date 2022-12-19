using NLayerCasesStore.BLL.DTO;
using NLayerCasesStore.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        UserDTO GetUserOnEmail(string email);
        int GetIdOnEmail(string email);
        UserDTO GetUserOnEmailAndPassword(string email, string password);
        bool CheckEmail(string email);
        bool CheckLogin(string login);
        void CreateUser(UserDTO userDto);
        IEnumerable<UserDTO> GetUsers();
    }
}
