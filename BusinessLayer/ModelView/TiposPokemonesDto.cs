using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ModelView
{
    public class TiposPokemonesDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe colocar el titulo de esta habilidad")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Debe colocar una descripcion acerca de este tipo.")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Debe colocar una imagen a esta habilidad")]
        public string ImagenUrl { get; set; }
    }
}
