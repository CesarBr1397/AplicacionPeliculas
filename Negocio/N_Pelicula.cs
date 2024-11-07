using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class N_Pelicula
    {
        public void Agregar(E_Pelicula objPelicula)
        {
            //Crear un objeto de la capa de datos
            D_Pelicula datos = new D_Pelicula();

            //Validaciones
            ValidarCaracteres(objPelicula);
            ValidarFecha(objPelicula);

            //Validar nombre repetido
            //E_Pelicula peliculaRepetida = datos.EditarPorNombre(objPelicula.nombre);
            //if (peliculaRepetida != null)
            //{
            //    throw new Exception($"La pelicula {objPelicula.nombre} ya existe en la cartelera con el id: {objPelicula.idPelicula}.");
            //}

            //Mando a llamar el metodo Agregar de la capa de datos
            datos.Agregar(objPelicula);
        }

        private void ValidarCaracteres(E_Pelicula objPelicula)
        {
            if (objPelicula.nombre.Count() < 5)
                throw new Exception("El nombre tiene que ser de al menos 5 caracteres");
            if (objPelicula.genero.Count() < 5)
                throw new Exception("El genero tiene que ser de al menos 5 caracteres");
        }

        private void ValidarFecha(E_Pelicula objPelicula)
        {
            if (objPelicula.fechaLanzamiento < DateTime.Now)
                throw new Exception("La fecha de lanzamiento invalida");
        }

        public List<E_Pelicula> ObtenerTodos()
        {
            //Crear un objeto de la capa de datos
            D_Pelicula datos = new D_Pelicula();

            //Mandar a llamar el metodo para obtener la lista de peliculas
            return datos.ObtenerTodos();
        }

        public E_Pelicula editarPorId(int id)
        {
            D_Pelicula datos = new D_Pelicula();

            return datos.EditarPorId(id);
        }

        public void actualizar(E_Pelicula pelicula)
        {
            D_Pelicula datos = new D_Pelicula();

            datos.actualizar(pelicula);
        }

        public void eliminar(E_Pelicula pelicula)
        {
            D_Pelicula datos = new D_Pelicula();

            datos.eliminar(pelicula);
        }

        public List<E_Pelicula> Buscar(string texto)
        {
            D_Pelicula datos = new D_Pelicula();

            return datos.Buscar(texto);
        }
    }
}
