using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Pokemones
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string ImagenUrl { get; set; }

        //Region
        public int IdRegion { get; set; }
        //Navegation Property
        public Regiones Region { get; set; }


        //Habilidades

        public int IdHabilidadPrincipal { get; set; }

        public TiposPokemones TipoHabilidadPrincipal { get; set; }

        public int IdHabilidadSecundaria { get; set; }
        //Navegation Property
        public TiposPokemones TipoHabilidadSecundaria { get; set; }

    }
}
