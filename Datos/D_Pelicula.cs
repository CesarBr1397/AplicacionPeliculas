using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Pelicula
    {
        private string CadenaConexion = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

        public List<E_Pelicula> ObtenerTodos()
        {
            //Creamos la lista para almaecnar las peliculas
            List<E_Pelicula> lista = new List<E_Pelicula>();
            //Creamos el objeto conexion
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                //Abrimos la conexión
                conexion.Open();
                //Crear el objeto para ejecutar el stores procedure
                //Le pasamos el nombre del stored procedure a ejecutar
                SqlCommand comando = new SqlCommand("obtener_todos_pelicula", conexion);
                //Le indicamos al objeto comando que va a ejecutar un stores procedure
                comando.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    //Creamos un objeto de la clase pelicula
                    E_Pelicula pelicula = new E_Pelicula();

                    pelicula.idPelicula = Convert.ToInt32(reader["idPelicula"]);
                    pelicula.nombre = reader["nombre"].ToString();
                    pelicula.genero = reader["genero"].ToString();
                    pelicula.fechaLanzamiento = Convert.ToDateTime(reader["fechaLanzamiento"]);
                    pelicula.nombreImagen = reader["nombreImagen"].ToString();

                    lista.Add(pelicula);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }
        public void Agregar(E_Pelicula pelicula)
        {
            //Creamos el objeto conexion
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                //Abrimos la conexión
                conexion.Open();
                //Crear el objeto para ejecutar el stores procedure
                //Le pasamos el nombre del stored procedure a ejecutar
                SqlCommand comando = new SqlCommand("agregar_pelicula", conexion);
                //Le indicamos al objeto comando que va a ejecutar un stores procedure
                comando.CommandType = CommandType.StoredProcedure;

                //Le pasamos los parametros al stored procedure
                comando.Parameters.AddWithValue("@nombre", pelicula.nombre);
                comando.Parameters.AddWithValue("@genero", pelicula.genero);
                comando.Parameters.AddWithValue("@fechaLanzamiento", pelicula.fechaLanzamiento);
                comando.Parameters.AddWithValue("@nombreImagen", pelicula.nombreImagen);

                //Ejecutamos el stored procedure
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void Editar(E_Pelicula peliculas)
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("seleccionarPeliculaId", conexion);

                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    //Creamos un objeto de la clase pelicula
                    E_Pelicula pelicula = new E_Pelicula();

                    pelicula.idPelicula = Convert.ToInt32(reader["idPelicula"]);
                    pelicula.nombre = reader["nombre"].ToString();
                    pelicula.genero = reader["genero"].ToString();
                    pelicula.fechaLanzamiento = Convert.ToDateTime(reader["fechaLanzamiento"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public E_Pelicula EditarPorId(int idPelicula)
        {
            E_Pelicula peliculas = new E_Pelicula();
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("seleccionarPeliculaId", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPelicula", idPelicula);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    peliculas.idPelicula = Convert.ToInt32(reader["idPelicula"]);
                    peliculas.nombre = reader["nombre"].ToString();
                    peliculas.genero = reader["genero"].ToString();
                    peliculas.fechaLanzamiento = Convert.ToDateTime(reader["fechaLanzamiento"]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return peliculas;
        }
        public void actualizar(E_Pelicula pelicula)
        {
            //Creamos el objeto conexion
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                //Abrimos la conexión
                conexion.Open();
                //Crear el objeto para ejecutar el stores procedure
                //Le pasamos el nombre del stored procedure a ejecutar
                SqlCommand comando = new SqlCommand("actualizar_pelicula", conexion);
                //Le indicamos al objeto comando que va a ejecutar un stores procedure
                comando.CommandType = CommandType.StoredProcedure;

                //Le pasamos los parametros al stored procedure
                comando.Parameters.AddWithValue("@nombre", pelicula.nombre);
                comando.Parameters.AddWithValue("@genero", pelicula.genero);
                comando.Parameters.AddWithValue("@fechaLanzamiento", pelicula.fechaLanzamiento);
                comando.Parameters.AddWithValue("@idPelicula", pelicula.idPelicula);

                //Ejecutamos el stored procedure
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
        public void eliminar(E_Pelicula pelicula)
        {
            //Creamos el objeto conexion
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                //Abrimos la conexión
                conexion.Open();
                //Crear el objeto para ejecutar el stores procedure
                //Le pasamos el nombre del stored procedure a ejecutar
                SqlCommand comando = new SqlCommand("eliminarPelicula", conexion);
                //Le indicamos al objeto comando que va a ejecutar un stores procedure
                comando.CommandType = CommandType.StoredProcedure;

                //Le pasamos los parametros al stored procedure
                comando.Parameters.AddWithValue("@idPelicula", pelicula.idPelicula);

                //Ejecutamos el stored procedure
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<E_Pelicula> Buscar(string texto)
        {
            //Creamos la lista para almaecnar las peliculas
            List<E_Pelicula> lista = new List<E_Pelicula>();
            //Creamos el objeto conexion
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            try
            {
                //Abrimos la conexión
                conexion.Open();
                //Crear el objeto para ejecutar el stores procedure
                //Le pasamos el nombre del stored procedure a ejecutar
                SqlCommand comando = new SqlCommand("buscar_peliculas", conexion);
                //Le indicamos al objeto comando que va a ejecutar un stores procedure
                comando.CommandType = CommandType.StoredProcedure;

                //Pasamos el valor del parametro
                comando.Parameters.AddWithValue("@texto", texto);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    //Creamos un objeto de la clase pelicula
                    E_Pelicula pelicula = new E_Pelicula();

                    pelicula.idPelicula = Convert.ToInt32(reader["idPelicula"]);
                    pelicula.nombre = reader["nombre"].ToString();
                    pelicula.genero = reader["genero"].ToString();
                    pelicula.fechaLanzamiento = Convert.ToDateTime(reader["fechaLanzamiento"]);
                    pelicula.nombreImagen = reader["nombreImagen"].ToString();

                    lista.Add(pelicula);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return lista;
        }

        public E_Pelicula EditarPorNombre(string nombre)
        {
            E_Pelicula peliculas = null;
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("obtener_peliculas_por_nombre", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", nombre);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    peliculas.idPelicula = Convert.ToInt32(reader["idPelicula"]);
                    peliculas.nombre = reader["nombre"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return peliculas;
        }
    }
}
