using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IR
{
    public interface IRepositoryRegiones
    {
        
            public Task<List<Regiones>> GetRegiones();
            public Task<Regiones> GetRegionById(int id);
            public Task<bool> ExisteRegion(string name);
            public Task<bool> UpdateRegion(Regiones mv);
            public Task<bool> DeleteRegion(Regiones mv);
            public Task<bool> CreateRegion(Regiones mv);
            public Task<bool> Save();
        
    }
}
