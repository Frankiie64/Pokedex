using BusinessLayer.Repository.IR;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class RepositoryRegiones : IRepositoryRegiones
    {
        private readonly ApplicationDbContext _db;

        public RepositoryRegiones(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateRegion(Regiones mv)
        {
            await _db.Regiones.AddAsync(mv);
            return await Save();
        }
        public async Task<bool> DeleteRegion(Regiones mv)
        {
            _db.Set<Regiones>().Remove(mv);
            return await Save();
        }
        public async Task<bool> UpdateRegion(Regiones mv)
        {
            _db.Entry(mv).State = EntityState.Modified;
            return await Save();
        }

        public async Task<bool> ExisteRegion(string name)
        {
            return await _db.Regiones.AnyAsync(x => x.Nombre.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<Regiones> GetRegionById(int id)
        {
            return await _db.Set<Regiones>().FindAsync(id);
        }

        public async Task<List<Regiones>> GetRegiones()
        {
            return await _db.Set<Regiones>().ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }        
       
    }
}
