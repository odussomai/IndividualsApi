using IndividualsApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualsApi.Data
{
    public interface IIndividualsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Individuals
        Task<Individual[]> GetAllIndividualsAsync();
        Task<Individual> GetIndividualAsync(int id);
    }
}
