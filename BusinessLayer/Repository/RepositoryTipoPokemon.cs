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
    public class RepositoryTipoPokemon : IRepositoryTipoPokemon
    {
        private readonly ApplicationDbContext _db;

        public RepositoryTipoPokemon(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateTiposPokemones(TiposPokemones mv)
        {
            await _db.TiposPokemones.AddAsync(mv);
            return await Save();
        }

        public async Task<bool> DeleteTipoPokemon(TiposPokemones mv)
        {
            _db.Set<TiposPokemones>().Remove(mv);
            return await Save();
        }
        public async Task<bool> UpdateTipoPokemon(TiposPokemones mv)
        {
            _db.Entry(mv).State = EntityState.Modified;
            return await Save();
        }

        public async Task<bool> ExisteTiposPokemones(string name)
        {
            return await _db.TiposPokemones.AnyAsync(x => x.Titulo.Trim().ToLower() == name.Trim().ToLower() );
        }

        public async Task<TiposPokemones> GetTiposPokemonById(int id)
        {
            return await _db.Set<TiposPokemones>().FindAsync(id);
        }

        public async Task<List<TiposPokemones>> GetTiposPokemones()
        {
            return await _db.Set<TiposPokemones>().ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }

       
    }
}
