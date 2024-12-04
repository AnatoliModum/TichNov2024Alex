using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.Configuration;

namespace Datos
{
    public class DEstatusAlumno
    {
        string stringConnection = ConfigurationManager.ConnectionStrings["TichDB"].ConnectionString;
        public List<EstatusAlumno> Consultar()
        {
            List<EstatusAlumno> listEstaAlu = new List<EstatusAlumno>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    string query = "consultarEstatusAlumnos";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    conexion.Open();
                    comando.Parameters.AddWithValue("@idEstatus", -1);
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        listEstaAlu.Add(
                            new EstatusAlumno()
                            {
                                id = int.Parse(lector["id"].ToString()),
                                clave = lector["clave"].ToString(),
                                nombre = lector["nombre"].ToString()
                            }
                            );
                    }

                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al consultar: " + e);
            }

            return listEstaAlu;


        }
        public EstatusAlumno Consultar(int id)
        {
            EstatusAlumno listEstaAlu = new EstatusAlumno();

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    string query = $"consultarEstatusAlumnos";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    conexion.Open();
                    comando.Parameters.AddWithValue("@idEstatus", id);
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        listEstaAlu.id = int.Parse(lector["id"].ToString());
                        listEstaAlu.clave = lector["clave"].ToString();
                        listEstaAlu.nombre = lector["nombre"].ToString();
                    }

                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al consultar: " + e);
            }

            return listEstaAlu;


        }
    }
}
