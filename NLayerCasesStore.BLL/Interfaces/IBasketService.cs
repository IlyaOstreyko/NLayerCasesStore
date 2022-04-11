using NLayerCasesStore.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Interfaces
{
    public interface IBasketService
    {
        void AddCaseInBasket(string userEmail, CaseDTO caseDto);
        void RemoveCaseFromBasket(string userEmail, int caseId);
        void ClearBasket(string userEmail);
    }
}
