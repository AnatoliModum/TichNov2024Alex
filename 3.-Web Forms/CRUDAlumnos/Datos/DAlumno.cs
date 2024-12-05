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
    public class DAlumno
    {
        string stringConnection = ConfigurationManager.ConnectionStrings["TichDB"].ConnectionString;

        public List<Alumno> Consultar()
        {
            List<Alumno> aluCon = new List<Alumno>();
            string query = "consultarEAlumnos";

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@idAlumno", -1);


                    conexion.Open();

                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        aluCon.Add(
                            new Alumno()
                            {
                                id = int.Parse(lector["id"].ToString()),
                                nombre = lector["nombre"].ToString(),
                                pApellido = lector["primerApellido"].ToString(),
                                sApellido = lector["segundoApellido"].ToString(),
                                correo = lector["correo"].ToString(),
                                telefono = lector["telefono"].ToString(),
                                fNacimiento = DateTime.Parse(lector["fechaNacimiento"].ToString()),
                                curp = lector["curp"].ToString(),
                                sueldo = (decimal)lector["sueldo"],
                                idEstadoOrigen = int.Parse(lector["idEstadoOrigen"].ToString()),
                                idEstatus = int.Parse(lector["idEstatus"].ToString())
                            }
                            );
                    }


                    conexion.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al agregar datos: " + e);
            }

            return aluCon;
        }
        public Alumno Consultar(int id)
        {
            Alumno aluCon = new Alumno();
            string query = "consultarEAlumnos";

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@idAlumno", id);


                    conexion.Open();

                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        aluCon.id = int.Parse(lector["id"].ToString());
                        aluCon.nombre = lector["nombre"].ToString();
                        aluCon.pApellido = lector["primerApellido"].ToString();
                        aluCon.sApellido = lector["segundoApellido"].ToString();
                        aluCon.correo = lector["correo"].ToString();
                        aluCon.telefono = lector["telefono"].ToString();
                        aluCon.fNacimiento = DateTime.Parse(lector["fechaNacimiento"].ToString());
                        aluCon.curp = lector["curp"].ToString();
                        aluCon.sueldo = (decimal)lector["sueldo"];
                        aluCon.idEstadoOrigen = int.Parse(lector["idEstadoOrigen"].ToString());
                        aluCon.idEstatus = int.Parse(lector["idEstatus"].ToString());
                    }


                    conexion.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al agregar datos: " + e);
            }

            return aluCon;
        }
        public void Agregar(Alumno alumno)
        {
            string query = "agregarAlumnos";
            int idAlumno = 0;

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Nombre", alumno.nombre);
                    comando.Parameters.AddWithValue("@pap", alumno.pApellido);
                    comando.Parameters.AddWithValue("@sap", alumno.sApellido);
                    comando.Parameters.AddWithValue("@cor", alumno.correo);
                    comando.Parameters.AddWithValue("@tel", alumno.telefono);
                    comando.Parameters.AddWithValue("@fn", alumno.fNacimiento);
                    comando.Parameters.AddWithValue("@curp", alumno.curp);
                    comando.Parameters.AddWithValue("@sueldo", alumno.sueldo);
                    comando.Parameters.AddWithValue("@idestado", alumno.idEstadoOrigen);
                    comando.Parameters.AddWithValue("@idest", alumno.idEstatus);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al actualizar los datos " + e.Message);
            }
        }
        public void Actualizar(Alumno alumno)
        {
            string query = "actualizarAlumnos";
            int idAlumno = 0;

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@id", alumno.id);
                    comando.Parameters.AddWithValue("@Nombre", alumno.nombre);
                    comando.Parameters.AddWithValue("@pap", alumno.pApellido);
                    comando.Parameters.AddWithValue("@sap", alumno.sApellido);
                    comando.Parameters.AddWithValue("@cor", alumno.correo);
                    comando.Parameters.AddWithValue("@tel", alumno.telefono);
                    comando.Parameters.AddWithValue("@fn", alumno.fNacimiento);
                    comando.Parameters.AddWithValue("@curp", alumno.curp);
                    comando.Parameters.AddWithValue("@sueldo", alumno.sueldo);
                    comando.Parameters.AddWithValue("@idestado", alumno.idEstadoOrigen);
                    comando.Parameters.AddWithValue("@idest", alumno.idEstatus);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al actualizar los datos " + e.Message);
            }
        }
        public void Eliminar(int id)
        {
            string query = "eliminarAlumnos";

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@idAlumno", id);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al actualizar los datos " + e.Message);
            }
        }
        public List<ItemTablaISR> ConsultarTablaISR()
        {
            List<ItemTablaISR> list = new List<ItemTablaISR>();
            string query = "select * from TablaISR";

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConnection))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.Text;
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();


                    while (lector.Read())
                    {
                        list.Add(
                            new ItemTablaISR()
                            {
                                limiteInferior = decimal.Parse(lector["LimInf"].ToString()),
                                limiteSuperior = decimal.Parse(lector["LimSup"].ToString()),
                                cuotaFija = decimal.Parse(lector["CuotaFija"].ToString()),
                                excedente = decimal.Parse(lector["ExedLimInf"].ToString()),
                                subsidio = decimal.Parse(lector["Subsidio"].ToString()),
                                ISR = 0
                            }
                            );
                    }


                    conexion.Close();
                }
            }
            catch (SqlException ex)
            {


            }

            return list;
        }

    }
}
