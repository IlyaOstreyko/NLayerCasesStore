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
    }
}
