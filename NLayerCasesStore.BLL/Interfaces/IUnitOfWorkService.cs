using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Interfaces
{
    public interface IUnitOfWorkService 
    {
        IBasketService Baskets { get; }
        //IOrderService Orders { get; }
        IUserService Users { get; }
        ICaseService Cases { get; }
    }
}
