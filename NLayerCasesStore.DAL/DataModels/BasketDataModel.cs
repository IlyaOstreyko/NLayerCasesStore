using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerCasesStore.DAL.DataModels
{
    public class BasketDataModel
    {
        public int BasketId { get; set; }
        public int? UserId { get; set; }
    }
}
