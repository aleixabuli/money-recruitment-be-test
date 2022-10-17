using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.VacationalRental.Common.Mapper
{
    public interface IMapperPersistence<TDomain, TPersistence>
        where TDomain : class
        where TPersistence : class
    {
        TDomain MapToDomainModel(TPersistence persistence);
        TPersistence CreatePersistenceModel(TDomain domain);
        void MapToPersistenceModel(TDomain domain, TPersistence persistence);
    }
}
