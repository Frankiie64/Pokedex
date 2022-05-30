using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IR
{
    public interface IRepositoryTipoPokemon
    {
        public Task<List<TiposPokemones>> GetTiposPokemones();
        public Task<TiposPokemones> GetTiposPokemonById(int id);
        public Task<bool> ExisteTiposPokemones(string name);
        public Task<bool> UpdateTipoPokemon(TiposPokemones mv);
        public Task<bool> DeleteTipoPokemon(TiposPokemones mv);
        public Task<bool> CreateTiposPokemones(TiposPokemones mv);
        public Task<bool> Save();
    }
}

