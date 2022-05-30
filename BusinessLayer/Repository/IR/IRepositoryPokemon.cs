using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.IR
{
    public interface IRepositoryPokemon
    {
        public Task<List<Pokemones>> GetPokemones();
        public Task<Pokemones> GetPokemonById(int id);
        public Task<bool> ExistePokemon(string name);
        public Task<bool> UpdatePokemo(Pokemones mv);
        public Task<bool> DeletePokemones(Pokemones mv);
        public Task<bool> CreatePokemones(Pokemones mv);
        public Task<bool> Save();

    }
}
