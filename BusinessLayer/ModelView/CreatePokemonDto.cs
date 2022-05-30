using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ModelView
{
    public class CreatePokemonDto
    {
        public PokemonesDto Pokemon { get; set; }
        public List<RegionCreateForPokemon> Regiones { get; set; }
        public List<TipoCreateForPokemon> Tipos { get; set; }
    }
}
