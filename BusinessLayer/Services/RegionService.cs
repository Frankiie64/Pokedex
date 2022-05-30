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
    public class RegionService
    {
         
        private readonly RepositoryRegiones _repo;

        public RegionService(ApplicationDbContext db)
        {
            _repo = new(db);
        }

        public async Task<List<RegionesDto>> getAll()
        {
            var list = await _repo.GetRegiones();

            return list.Select(x => new RegionesDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion

            }).ToList();
        }

        public async Task<RegionesDto> getById(int id)
        {
            var x = await _repo.GetRegionById(id);

            RegionesDto item = new RegionesDto()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion

            };

            return item;

        }

        public async Task<bool> add(RegionesDto mv)
        {
            bool value = await getExistTipoPokemon(mv.Nombre);
         
            Regiones item = new()

            {
                Id = mv.Id,
                Nombre = mv.Nombre,
                Descripcion = mv.Descripcion
            };
            return await _repo.CreateRegion(item);

        }
        public async Task<bool> edit(RegionesDto mv)
        {
         
            Regiones tp = new()
            {
                Id = mv.Id,
                Nombre = mv.Nombre,
                Descripcion = mv.Descripcion
            };

            return await _repo.UpdateRegion(tp);
        }

        public async Task<bool> delete(int id)
        {
            Regiones tp = await _repo.GetRegionById(id);

            return await _repo.DeleteRegion(tp);
        }


        private async Task<bool> getExistTipoPokemon(string titulo)
        {
            return await _repo.ExisteRegion(titulo);
        }
    }
}
