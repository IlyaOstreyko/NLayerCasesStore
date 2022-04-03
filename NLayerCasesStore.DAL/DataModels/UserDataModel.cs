using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerCasesStore.DAL.DataModels
{
    public class UserDataModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }   
        public string UserRole { get; set; }  
        public int? BasketId { get; set; }
    }
}
