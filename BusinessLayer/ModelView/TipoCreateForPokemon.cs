using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ModelView
{
    public class TipoCreateForPokemon
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Description { get; set; }
        public string ImagenUrl { get; set; }
    }
}
