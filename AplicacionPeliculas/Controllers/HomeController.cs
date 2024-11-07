using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionPeliculas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            return View("Inicio");
        }

        public ActionResult irMostrar()
        {
            List<E_Pelicula> peliculas = new List<E_Pelicula>();

            try
            {
                //Crear el obejto de la capa de negocio
                N_Pelicula negocio = new N_Pelicula();

                peliculas = negocio.ObtenerTodos();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("Mostrar", peliculas);
        }

        public ActionResult irAgregar()
        {
            return View("Agregar");
        }

        public ActionResult IrMostrarEditar()
        {
            List<E_Pelicula> peliculas = new List<E_Pelicula>();

            try
            {
                //Crear el obejto de la capa de negocio
                N_Pelicula negocio = new N_Pelicula();

                peliculas = negocio.ObtenerTodos();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("MostrarTodosEditar", peliculas);
        }
        public ActionResult IrMostrarBorrar()
        {
            List<E_Pelicula> peliculas = new List<E_Pelicula>();

            try
            {
                //Crear el obejto de la capa de negocio
                N_Pelicula negocio = new N_Pelicula();

                peliculas = negocio.ObtenerTodos();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("MostrarTodosBorrar", peliculas);
        }

        public ActionResult Agregar(E_Pelicula objPelicula, HttpPostedFileBase ArchivoImagen)
        {
            try
            {
                //Guardar imagen en el servidor
                //Crea la ruta donde se guardará el archivo
                string rutaArchivo = Path.Combine(Server.MapPath("~/Imgs"), ArchivoImagen.FileName);

                //Guardar el archivo en el servidor
                ArchivoImagen.SaveAs(rutaArchivo);

                //Asignar el nombre de ña imagen a el objeto de E_Pelicula
                objPelicula.nombreImagen = ArchivoImagen.FileName;

                //Mandamos a llamar el metodo agregar de la capa de negocio
                N_Pelicula negocio = new N_Pelicula();

                negocio.Agregar(objPelicula);
                TempData["mensaje"] = $"La pelicula {objPelicula.nombre}, se registró correctamente.";
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult editarPorId(int idPelicula)
        {
            E_Pelicula pelicula = new E_Pelicula();
            try
            {
                N_Pelicula negocio = new N_Pelicula();
                pelicula = negocio.editarPorId(idPelicula);

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message; 
            }
            return View("IdEditar", pelicula);
        }

        public ActionResult eliminarPorId(int idPelicula)
        {
            E_Pelicula pelicula = new E_Pelicula();
            try
            {
                N_Pelicula negocio = new N_Pelicula();
                pelicula = negocio.editarPorId(idPelicula);

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("IdEliminar", pelicula);
        }

        public ActionResult actualizar(E_Pelicula pelicula)
        {
            try
            {
                N_Pelicula negocio = new N_Pelicula();
                negocio.actualizar(pelicula);
                TempData["mensaje"] = $"La pelicula {pelicula.nombre}, se editó correctamente.";

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        public ActionResult eliminar(E_Pelicula pelicula)
        {
            try
            {
                N_Pelicula negocio = new N_Pelicula();
                negocio.eliminar(pelicula);
                TempData["mensaje"] = $"La pelicula {pelicula.nombre}, se eliminó correctamente.";

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("Inicio");
        }

        public ActionResult IrAtrasEditar()
        {
            return RedirectToAction("IrMostrarEditar");
        }

        public ActionResult IrAtrasEliminar()
        {
            return RedirectToAction("IrMostrarBorrar");
        }

        public ActionResult Buscar(string textoBusqueda)
        {
            //Creamos una lista vacia
            List<E_Pelicula> peliculas = new List<E_Pelicula>();
            try
            {
                //Creamos un objeto de la capa de negocio
                N_Pelicula negocio = new N_Pelicula();

                //Obtengo la lista de peliculas realizando la busqueda
                peliculas = negocio.Buscar(textoBusqueda);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("Busqueda", peliculas);
        }
    }
}