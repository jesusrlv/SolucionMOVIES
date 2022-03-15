using SolucionMOVIES.Models;
using System.Data.SqlClient;
using System.Data;

namespace SolucionMOVIES.Peliculas
{
    public class Actores
    {
        public List<actores> Listar()
        {
            var oLista = new List<actores>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarActores", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new actores()
                        {
                            idActores = Convert.ToInt32(dr["idActores"]),
                            nombre = dr["nombre"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public List<ListadoCompleto> ListarParticipaciones()
        {
            var oLista = new List<ListadoCompleto>();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListaCOMPLETA", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ListadoCompleto()
                        {
                            PELICULA = dr["PELICULA"].ToString(),
                            ACTOR = dr["ACTOR"].ToString(),
                            GENERO = dr["GENERO"].ToString()
                            //nombre = dr["nombre"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public actores Obtener(int IdActores)
        {
            var oActor = new actores();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerID", conexion);
                cmd.Parameters.AddWithValue("idActor", IdActores);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oActor.idActores = Convert.ToInt32(dr["idActores"]);
                        oActor.nombre = dr["nombre"].ToString();
                    }
                }
            }
            return oActor;
        }

        //public bool guardar(Actores oactores)
        public bool guardar(genero ogenero) //guarda género
        {
            bool rpta;

            //insert
            try
            {
                //captura de respuesta
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuadarGenero", conexion); //solicita donde guardar en los procedures SQL
                    cmd.Parameters.AddWithValue("genero", ogenero.nombre);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool guardarActor(actores oactores)//guardar actores
        {
            bool rpta;

            //insert
            try
            {
                //captura de respuesta
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion); //solicita donde guardar en los procedures SQL
                    cmd.Parameters.AddWithValue("nombre", oactores.nombre);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool guardarPelicula(peliculas opeliculas)//guardar actores
        {
            bool rpta;

            //insert
            try
            {
                //captura de respuesta
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarPelicula", conexion); //solicita donde guardar en los procedures SQL
                    cmd.Parameters.AddWithValue("pelicula", opeliculas.pelicula);
                    cmd.Parameters.AddWithValue("pelicula", opeliculas.genero);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool guardarParticipaciones(participaciones oparticipaciones)//guardar actores
        {
            bool rpta;

            //insert
            try
            {
                //captura de respuesta
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarParticipaciones", conexion); //solicita donde guardar en los procedures SQL
                    cmd.Parameters.AddWithValue("id_peli", oparticipaciones.peli);
                    cmd.Parameters.AddWithValue("id_actor", oparticipaciones.actor);
                    cmd.Parameters.AddWithValue("id_genero", oparticipaciones.genero);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool EditarParticipaciones(participaciones oparticipaciones)//editar participaciones
        {
            bool rpta;

            //insert
            try
            {
                //captura de respuesta
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarParticipaciones", conexion); //solicita donde guardar en los procedures SQL
                    cmd.Parameters.AddWithValue("id_participaciones", oparticipaciones.idParticipaciones);
                    cmd.Parameters.AddWithValue("id_peli", oparticipaciones.peli);
                    cmd.Parameters.AddWithValue("id_peli", oparticipaciones.actor);
                    cmd.Parameters.AddWithValue("id_peli", oparticipaciones.genero);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool EliminarParticipaciones(int idParticipaciones)//eliminar participaciones
        {
            bool rpta;

            //insert
            try
            {
                //captura de respuesta
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarParticipaciones", conexion); //solicita donde guardar en los procedures SQL
                    cmd.Parameters.AddWithValue("id_participaciones", idParticipaciones);
                   
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


        //aquí iba el código anteriormente



    }

}
