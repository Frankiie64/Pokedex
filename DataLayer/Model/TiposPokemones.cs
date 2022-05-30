using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Model
{
    public class TiposPokemones
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Description { get; set; }
        public string ImagenUrl{ get; set; }
        public ICollection<Pokemones> PokemonP { get; set; }
        public ICollection<Pokemones> PokemonS { get; set; }


    }
}
