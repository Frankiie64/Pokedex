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

        private readonly RepositoryPokemon _repoPokemon;

        public TiposPokemonService(ApplicationDbContext db)
        {
            _repo = new(db);
            _repoPokemon = new(db);
        }

        public async Task<List<TiposPokemonesDto>> getAll()
        {
            var list = await _repo.GetTiposPokemones();

            await AddNoneInDataBase(list);

            return list.Select(x => new TiposPokemonesDto
            {
                Id = x.Id,
                Titulo = x.Titulo,                                   
                Description = x.Description,
                ImagenUrl = x.ImagenUrl
                
            }).ToList();
        }

        private async Task AddNoneInDataBase(List<TiposPokemones> list )
        {
            if(list.Count == 0)
            {
                TiposPokemonesDto item = new TiposPokemonesDto()
                {                    
                    Titulo = "No",
                    Description = "No posee habilidad secundaria",
                    ImagenUrl = "no"
                };

                await add(item);
            }
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

            var list = await _repoPokemon.GetPokemones();

            foreach (var item in list)
            {
                if (item.IdHabilidadSecundaria == id)
                {
                    item.IdHabilidadSecundaria = 1;
                }
                await _repoPokemon.UpdatePokemo(item);
            }
            return await _repo.DeleteTipoPokemon(tp);
        }


        public async Task<bool> getExistTipoPokemon(string titulo)
        {
            return await _repo.ExisteTiposPokemones(titulo);
        }
    }
}
