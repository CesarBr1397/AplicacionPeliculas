using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Pelicula
    {
        public int idPelicula { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public DateTime fechaLanzamiento { get; set; }

        public string nombreImagen { get; set; }
    }
}
