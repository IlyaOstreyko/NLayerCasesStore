using NLayerCasesStore.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.BLL.Interfaces
{
    public interface ICaseService
    {
        //void MakeOrder(CaseDTO caseDto);
        CaseDTO GetCase(int id);
        IEnumerable<CaseDTO> GetCases();
        IEnumerable<CaseDTO> GetCasesInBasketFromEmail(string email);
        IEnumerable<CaseDTO> GetCasesInBasketInStock(string email);
        void CreateCase(CaseDTO caseDto);
        void DeleteCase(int id);
        void UpdateCase(CaseDTO caseDto);
    }
}
