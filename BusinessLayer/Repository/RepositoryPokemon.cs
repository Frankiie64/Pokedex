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
    public class RepositoryPokemon : IRepositoryPokemon
    {
        private readonly ApplicationDbContext _db;
        public RepositoryPokemon(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreatePokemones(Pokemones mv)
        {
            await _db.Pokemones.AddAsync(mv);
            return await Save();
        }

        public async Task<bool> DeletePokemones(Pokemones mv)
        {
            _db.Set<Pokemones>().Remove(mv);
            return await Save();
        }
        public async Task<bool> UpdatePokemo(Pokemones mv)
        {
            _db.Entry(mv).State = EntityState.Modified;
            return await Save();
        }

        public async Task<bool> ExistePokemon(string name)
        {
            return await _db.Pokemones.AnyAsync(x => x.Nombre.Trim().ToLower() == name.Trim().ToLower());
        }

        public async Task<List<Pokemones>> GetPokemones()
        {
            return await _db.Pokemones.OrderBy(x=>x.Nombre)
                .Include(x => x.Region)
                .Include(x => x.TipoHabilidadPrincipal)
                .Include(x => x.TipoHabilidadSecundaria)
                .ToListAsync();


        }

        public async Task<Pokemones> GetPokemonById(int id)
        {
            return await _db.Set<Pokemones>().FindAsync(id);
        }

        public async Task<IEnumerable<Pokemones>> GetPokemonByName(string name)
        {
            IQueryable<Pokemones> query = _db.Pokemones;
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Nombre.Contains(name));
            }

            return await query.Include(x => x.Region).Include(x => x.TipoHabilidadPrincipal).Include(x => x.TipoHabilidadSecundaria).ToListAsync();
        }
        public async Task<IEnumerable<Pokemones>> GetPokemonByRegion(int id)
        {
            IQueryable<Pokemones> query = _db.Pokemones;
            if (id != 0)
            {
                query = query.Where(p => p.IdRegion == id);
            }

            return await query.Include(x => x.Region).Include(x => x.TipoHabilidadPrincipal).Include(x => x.TipoHabilidadSecundaria).ToListAsync();
        }
        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }

    }
}
