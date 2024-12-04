using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DEstado
    {
        string stringConnection = ConfigurationManager.ConnectionStrings["TichDB"].ConnectionString;
        public List<Estado> Consultar()
        {
            List<Estado> listEstado = new List<Estado>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    string query = "consultarEstados";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    conexion.Open();
                    comando.Parameters.AddWithValue("@idEstado", -1);
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        listEstado.Add(
                            new Estado()
                            {
                                id = int.Parse(lector["id"].ToString()),
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

            return listEstado;
        }

        public Estado Consultar(int id)
        {
            Estado listEstado = new Estado();

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    string query = $"consultarEstados";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    conexion.Open();
                    comando.Parameters.AddWithValue("@idEstado", id);
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        listEstado.id = int.Parse(lector["id"].ToString());
                        listEstado.nombre = lector["nombre"].ToString();
                    }

                }
            }
            catch (SqlException e)
            {
                throw new Exception("Error al consultar: " + e);
            }

            return listEstado;
        }
    }
}
