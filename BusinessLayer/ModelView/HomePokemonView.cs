using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ModelView
{
    public class HomePokemonView
    {
        public List<RegionCreateForPokemon> Regiones { get; set; }
        public List<PokemonesDto> Pokemon { get; set; }
        public PokemonesDto Region { get; set; }

    }
}
