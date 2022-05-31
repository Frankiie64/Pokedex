using BusinessLayer.ModelView;
using BusinessLayer.Repository;
using DataLayer.Data;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PokemonService
    {
        private readonly RepositoryPokemon _repo;
        private readonly RepositoryRegiones _repoRegiones;
        private readonly RepositoryTipoPokemon _repoTipoPokemon;


        public PokemonService(ApplicationDbContext db)
        {
            _repo = new(db);
            _repoRegiones = new(db);
            _repoTipoPokemon = new(db);

        }

        public async Task<List<TipoCreateForPokemon>> getAllTiposPokemones()
        {
            var list = await _repoTipoPokemon.GetTiposPokemones();
            return list.Select(x => new TipoCreateForPokemon
            {
                Id = x.Id,
                Titulo = x.Titulo,
            }).ToList();
        }

        public async Task<RegionCreateForPokemon> GetRegionById(int id)
        {
            var mv = await _repoRegiones.GetRegionById(id);

            RegionCreateForPokemon item = new RegionCreateForPokemon()
            {
                Id = mv.Id,
                Nombre = mv.Nombre
            };
            return item;
        }
        public async Task<TipoCreateForPokemon> getAllTiposPokemonById(int id)
        {
            var mv = await _repoTipoPokemon.GetTiposPokemonById(id);

            TipoCreateForPokemon item = new TipoCreateForPokemon()
            {
                Id = mv.Id,
                Titulo = mv.Titulo
            };
            return item;
        }

        public async Task<List<RegionCreateForPokemon>> getAllRegiones()
        {
            var list = await _repoRegiones.GetRegiones();
            return list.Select(x => new RegionCreateForPokemon
            {
                Id = x.Id,
                Nombre = x.Nombre

            }).ToList();
        }


        public async Task<List<PokemonesDto>> getAll()
        {
            var list = await _repo.GetPokemones();

            return list.Select(x => new PokemonesDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                ImagenUrl = x.ImagenUrl,
                IdHabilidadPrincipal = x.IdHabilidadPrincipal,
                IdHabilidadSecundaria = x.IdHabilidadSecundaria,
                IdRegion = x.IdRegion,
                Region = new RegionCreateForPokemon()
                {
                    Id = x.Region.Id,
                    Nombre = x.Region.Nombre
                },
                TipoHabilidadPrincipal = new TipoCreateForPokemon()
                {
                    Id = x.TipoHabilidadPrincipal.Id,
                    Titulo = x.TipoHabilidadPrincipal.Titulo,
                    ImagenUrl = x.TipoHabilidadPrincipal.ImagenUrl
                },
                TipoHabilidadSecundaria = new TipoCreateForPokemon()
                {
                    Id = x.TipoHabilidadSecundaria.Id,
                    Titulo = x.TipoHabilidadSecundaria.Titulo,
                    ImagenUrl = x.TipoHabilidadSecundaria.ImagenUrl

                }

            }).ToList();
        }
        public async Task<PokemonesDto> getById(int id)
        {
            var x = await _repo.GetPokemonById(id);

            PokemonesDto item = new PokemonesDto()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                ImagenUrl = x.ImagenUrl,
                IdHabilidadPrincipal = x.IdHabilidadPrincipal,
                IdHabilidadSecundaria = x.IdHabilidadSecundaria,
                IdRegion = x.IdRegion,
            };
            return item;
        }

        public async Task<bool> add(PokemonesDto x)
        {
            bool value = await getExistPokemon(x.Nombre);

            if (value)
            {
                return false;
            }

            Pokemones mv = new()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                ImagenUrl = x.ImagenUrl,
                IdHabilidadPrincipal = x.IdHabilidadPrincipal,
                IdHabilidadSecundaria = x.IdHabilidadSecundaria,
                IdRegion = x.IdRegion
            };

            return await _repo.CreatePokemones(mv);

        }
        public async Task<bool> edit(PokemonesDto x)
        {

            Pokemones mv = new()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                ImagenUrl = x.ImagenUrl,
                IdHabilidadPrincipal = x.IdHabilidadPrincipal,
                IdHabilidadSecundaria = x.IdHabilidadSecundaria,
                IdRegion = x.IdRegion,
            };

            return await _repo.UpdatePokemo(mv);
        }

        public async Task<bool> delete(int id)
        {
            Pokemones tp = await _repo.GetPokemonById(id);

            return await _repo.DeletePokemones(tp);
        }
        public async Task<bool> getExistPokemon(string titulo)
        {
            return await _repo.ExistePokemon(titulo);
        }
        public async Task<List<PokemonesDto>> GetPokemonesBySearch(string name)
        {
            var list = await _repo.GetPokemonByName(name);

            return list.Select(x=> new PokemonesDto()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                ImagenUrl = x.ImagenUrl,
                IdHabilidadPrincipal = x.IdHabilidadPrincipal,
                IdHabilidadSecundaria = x.IdHabilidadSecundaria,
                IdRegion = x.IdRegion,
                Region = new RegionCreateForPokemon()
                {
                    Id = x.Region.Id,
                    Nombre = x.Region.Nombre
                },
                TipoHabilidadPrincipal = new TipoCreateForPokemon()
                {
                    Id = x.TipoHabilidadPrincipal.Id,
                    Titulo = x.TipoHabilidadPrincipal.Titulo,
                    ImagenUrl = x.TipoHabilidadPrincipal.ImagenUrl
                },
                TipoHabilidadSecundaria = new TipoCreateForPokemon()
                {
                    Id = x.TipoHabilidadSecundaria.Id,
                    Titulo = x.TipoHabilidadSecundaria.Titulo,
                    ImagenUrl = x.TipoHabilidadSecundaria.ImagenUrl

                }

            }).ToList();

        }
        public async Task<List<PokemonesDto>> GetPokemonesBySearch(int id)
        {
            var list = await _repo.GetPokemonByRegion(id);

            return list.Select(x => new PokemonesDto()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                ImagenUrl = x.ImagenUrl,
                IdHabilidadPrincipal = x.IdHabilidadPrincipal,
                IdHabilidadSecundaria = x.IdHabilidadSecundaria,
                IdRegion = x.IdRegion,
                Region = new RegionCreateForPokemon()
                {
                    Id = x.Region.Id,
                    Nombre = x.Region.Nombre
                },
                TipoHabilidadPrincipal = new TipoCreateForPokemon()
                {
                    Id = x.TipoHabilidadPrincipal.Id,
                    Titulo = x.TipoHabilidadPrincipal.Titulo,
                    ImagenUrl = x.TipoHabilidadPrincipal.ImagenUrl
                },
                TipoHabilidadSecundaria = new TipoCreateForPokemon()
                {
                    Id = x.TipoHabilidadSecundaria.Id,
                    Titulo = x.TipoHabilidadSecundaria.Titulo,
                    ImagenUrl = x.TipoHabilidadSecundaria.ImagenUrl

                }

            }).ToList();

        }
        public async Task<List<PokemonesDto>> GetPokemonByFilter(int id,string name)
        {
            var list = await _repo.GetPokemonByFilter(id,name);

            return list.Select(x => new PokemonesDto()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                ImagenUrl = x.ImagenUrl,
                IdHabilidadPrincipal = x.IdHabilidadPrincipal,
                IdHabilidadSecundaria = x.IdHabilidadSecundaria,
                IdRegion = x.IdRegion,
                Region = new RegionCreateForPokemon()
                {
                    Id = x.Region.Id,
                    Nombre = x.Region.Nombre
                },
                TipoHabilidadPrincipal = new TipoCreateForPokemon()
                {
                    Id = x.TipoHabilidadPrincipal.Id,
                    Titulo = x.TipoHabilidadPrincipal.Titulo,
                    ImagenUrl = x.TipoHabilidadPrincipal.ImagenUrl
                },
                TipoHabilidadSecundaria = new TipoCreateForPokemon()
                {
                    Id = x.TipoHabilidadSecundaria.Id,
                    Titulo = x.TipoHabilidadSecundaria.Titulo,
                    ImagenUrl = x.TipoHabilidadSecundaria.ImagenUrl

                }

            }).ToList();

        }
    }
}
