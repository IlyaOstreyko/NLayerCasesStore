﻿using NLayerCasesStore.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCasesStore.DAL.Interfaces
{
    public interface IBasketRepository
    {
        void AddCaseInBasket(int idUser, CaseDataModel caseDM);
        void RemoveCaseFromBasket(int idUser, int caseId);
        void ClearBasket(int idUser);
        void DeleteCasesInBasket(List<CaseDataModel> casesDM);
        List<CaseDataModel> GetCaseInBasket(int idUser);

    }
}
