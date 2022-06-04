using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.ModelView;
using BusinessLayer.Repository;
using DataLayer.Data;
using DataLayer.Model;

namespace BusinessLayer.Services
{
    public class TiposPokemonService
    {
        private readonly RepositoryTipoPokemon _repo;

        public TiposPokemonService(ApplicationDbContext db)
        {
            _repo = new(db);
        }

        public async Task<List<TiposPokemonesDto>> getAll()
        {
            var list = await _repo.GetTiposPokemones();

            return list.Select(x => new TiposPokemonesDto
            {
                Id = x.Id,
                Titulo = x.Titulo,                                   
                Description = x.Description,
                ImagenUrl = x.ImagenUrl
                
            }).ToList();
        }

        public async Task<TiposPokemonesDto> getById(int id)
        {
            var x = await _repo.GetTiposPokemonById(id);

          TiposPokemonesDto item = new TiposPokemonesDto()
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Description = x.Description,
                ImagenUrl = x.ImagenUrl

            };

            return item;

        }

        public async Task<bool> add(TiposPokemonesDto mv)
        {
          
            TiposPokemones tp = new()
            {
                Titulo = mv.Titulo,
                Description = mv.Description,
                ImagenUrl = mv.ImagenUrl
            };

            return await _repo.CreateTiposPokemones(tp);

        }
        public async Task<bool> edit(TiposPokemonesDto mv)
        {
           
            TiposPokemones tp = new()
            {
                Id = mv.Id,
                Titulo = mv.Titulo,
                Description = mv.Description,
                ImagenUrl = mv.ImagenUrl
            };

            return await _repo.UpdateTipoPokemon(tp);
        }

        public async Task<bool> delete(int id)
        {
            TiposPokemones tp = await _repo.GetTiposPokemonById(id);            

            return await _repo.DeleteTipoPokemon(tp);
        }


        public async Task<bool> getExistTipoPokemon(string titulo)
        {
            return await _repo.ExisteTiposPokemones(titulo);
        }
    }
}
