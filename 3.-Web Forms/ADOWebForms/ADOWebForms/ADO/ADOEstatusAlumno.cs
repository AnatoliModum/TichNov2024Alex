using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ADOWebForms.Entidades;

namespace ADOWebForms.ADO
{
    public class ADOEstatusAlumno : ICRUD
    {
        string stringConnection = ConfigurationManager.ConnectionStrings["TichDB"].ConnectionString;

        public void Actualizar(EstatusAlumno estatus)
        {
            string query = "updateEstatus";
            int idEstatus = estatus.id;

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    SqlCommand comando = new SqlCommand(query,conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@clave", estatus.clave);
                    comando.Parameters.AddWithValue("@nombre", estatus.nombre);
                    comando.Parameters.AddWithValue("@id", estatus.id);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al actualizar los datos "+e.Message);
            }

        }

        public int Agregar(EstatusAlumno estatus)
        {
            string query = "createEstatus";
            int idEstatus = 0;

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    SqlCommand comando = new SqlCommand(query,conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@nombre",estatus.nombre);
                    comando.Parameters.AddWithValue("@clave",estatus.clave);

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    comando.Parameters.Add(returnValue);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    idEstatus = (int)returnValue.Value;
                    conexion.Close();
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine("Error al agregar datos: "+e);
            }

            return idEstatus;
        }

        public List<EstatusAlumno> Consultar()
        {
            List<EstatusAlumno> listaEA = new List<EstatusAlumno>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    string query = "Select * from EstatusAlumnos";
                    SqlCommand comando = new SqlCommand(query,conexion);
                    comando.CommandType = CommandType.Text;

                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        listaEA.Add(
                            new EstatusAlumno()
                            {
                                id = int.Parse(lector["id"].ToString()),
                                clave = lector["clave"].ToString(),
                                nombre = lector["nombre"].ToString()
                            }
                            );
                    }

                }
            }catch(SqlException e)
            {
                throw new Exception ("Error al consultar: "+e);
            }

            return listaEA;
        }

        public EstatusAlumno Consultar(int id)
        {
            EstatusAlumno entidadEstatus = new EstatusAlumno();
            string query = $"Select * from EstatusAlumnos where id = {id}";

            try
            {

                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {

                    SqlCommand comando = new SqlCommand(query,conexion);
                    comando.CommandType = CommandType.Text;
                    
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        entidadEstatus.id = int.Parse(lector["id"].ToString());
                        entidadEstatus.nombre = lector["nombre"].ToString();
                        entidadEstatus.clave = lector["clave"].ToString();
                    }
                    conexion.Close();

                }

            }catch(SqlException e)
            {
                Console.WriteLine("Error al consular el Estatus: "+e);
            }
            return entidadEstatus;
        }

        public void Eliminar(int id)
        {
            string query = $"delete EstatusAlumnos where id = {id} ";

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    SqlCommand comando = new SqlCommand(query,conexion);
                    comando.CommandType = CommandType.Text;

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al eliminar el estatus: "+e);
            }
        }
    }
}