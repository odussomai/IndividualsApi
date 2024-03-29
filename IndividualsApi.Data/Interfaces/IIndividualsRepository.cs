﻿using IndividualsApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualsApi.Data.Enums;

namespace IndividualsApi.Data.Interfaces
{
    public interface IIndividualsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Individuals
        Task<IEnumerable<Individual>> GetAllIndividualsAsync(int pageIndex, int pageSize);
        Task<Individual> GetIndividualAsync(int id);
        Task<IEnumerable<T>> FindPaged<T>(int page, int pageSize) where T : class;
        Task<Individual[]> Search(string term);
        Task<City>  GetCityByIdAsync(int id);
        Task<int> GetRelationCountAsync(int id, RelationType type);
        Task<Relation> GetRelationByRelativeId(int id, int relativeId, int relType);
    }
}
