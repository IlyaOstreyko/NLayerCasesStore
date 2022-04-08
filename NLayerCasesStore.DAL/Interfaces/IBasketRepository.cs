using NLayerCasesStore.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Interfaces
{
    public interface IBasketRepository
    {
        void Create(int idUser);
        void AddCaseInBasket(int idUser, CaseDataModel caseDM);
        void ClearBasket();
        void DeleteCasesInBasket(List<CaseDataModel> casesDM);
        List<CaseDataModel> GetCaseInBasket(int idUser);

    }
}
