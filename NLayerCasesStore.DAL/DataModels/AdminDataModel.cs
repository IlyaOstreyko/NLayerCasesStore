using System.ComponentModel.DataAnnotations;

namespace NLayerCasesStore.DAL.DataModels
{
    public class AdminDataModel
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminMail { get; set; }
    }
}
