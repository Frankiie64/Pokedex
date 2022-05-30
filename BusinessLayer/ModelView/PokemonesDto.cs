using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ModelView
{
    public class PokemonesDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string ImagenUrl { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public int IdRegion { get; set; }
        public RegionCreateForPokemon Region { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]

        public int IdHabilidadPrincipal { get; set; }

        public TipoCreateForPokemon TipoHabilidadPrincipal { get; set; }

        public int IdHabilidadSecundaria { get; set; }
        public TipoCreateForPokemon TipoHabilidadSecundaria { get; set; }

    }
}
