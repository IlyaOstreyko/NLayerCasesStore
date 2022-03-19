using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerCasesStore.DAL.DataModels
{
    public class OrderDataModel
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
    }
}
