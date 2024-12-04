using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CRUDAdoEstatus
{
    internal class ADOEstatus : ICRUDEstatus
    {
        string stringConexion = ConfigurationManager.ConnectionStrings["TichDB"].ConnectionString;

        public void Actualizar(Estatus _estatus)
        {
            string query = "updateEstatus";
            int idEstatus = _estatus.id;

            try
            {

                using (SqlConnection conexion = new SqlConnection(stringConexion))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@clave", _estatus.clave);
                    comando.Parameters.AddWithValue("@nombre", _estatus.nombre);
                    comando.Parameters.AddWithValue("@id", _estatus.id);


                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }

            }
            catch(SqlException ex)
            {
                Console.WriteLine($"Error al actualizar datos: {ex.Message} "); 
            }

        }

        public int Agregar(Estatus _estatus)
        {
            string query = $"createEstatus";
            int idEstatus = 0;

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConexion))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@clave", _estatus.clave);
                    comando.Parameters.AddWithValue("@nombre", _estatus.nombre);

                    SqlParameter returnValue = new SqlParameter(); 
                    returnValue.Direction = ParameterDirection.ReturnValue; 
                    comando.Parameters.Add(returnValue);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                    idEstatus = (int)returnValue.Value;
                    conexion.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al agregar datos : {ex.Message}");
            }

            
            return idEstatus;
        }

        public List<Estatus> Consultar()
        {
            List<Estatus> dataEstatus = new List<Estatus>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConexion))
                {
                    string query = "select * from EstatusAlumnos;";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.Text;
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        dataEstatus.Add(
                            new Estatus()
                            {
                                id = int.Parse(lector["id"].ToString()),
                                clave = lector["clave"].ToString(),
                                nombre = lector["nombre"].ToString()
                            }
                            );
                    }
                    conexion.Close();
                }
            }
            catch { Console.WriteLine("Error al realizar consulta global"); }

            
            return dataEstatus;
        }

        public Estatus Consultar(int id)
        {
            Estatus dataEstatus = new Estatus();

            try
            {
                using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["TichDB"].ToString()))
                {
                    string query = $"select * from EstatusAlumnos where id = {id}";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.Text;
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                        while (lector.Read())
                        {
                            dataEstatus.id = int.Parse(lector["id"].ToString());
                            dataEstatus.clave = lector["clave"].ToString();
                            dataEstatus.nombre = lector["nombre"].ToString();
                        }
                    
                    conexion.Close();
                }
            }
            catch
            {
                Console.WriteLine("Error al consultar los datos");
            }
            return dataEstatus;
        }

        public void Eliminar(int id)
        {
            string query = $" DELETE EstatusAlumnos WHERE id = {id} ";

            try
            {
                using (SqlConnection conexion = new SqlConnection(stringConexion))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.Text;
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al eliminar el estatus: {ex.Message}");
            }
        }
            
        public void ConsultarTodo()
        {
            try
            {
                foreach (var data in Consultar())
                {
                    Console.WriteLine($"idEstatus: {data.id}  |  Clave: {data.clave}  |  Nombre: {data.nombre}");
                }
            }
            catch { Console.WriteLine("Error al consultar los datos metodo CT"); }
        }
        public void ConsultarById()
        {
            Console.WriteLine("\nIngrese una id para buscar: \n");
            Estatus estaData = Consultar(int.Parse(Console.ReadLine()));
            if(estaData.nombre != null)
            {
                Console.WriteLine($"\n\n\nIdEstatus: {estaData.id}  ->  Clave: {estaData.clave} ->  Nombre: {estaData.nombre}\n");
            }
            else
            {
                Console.WriteLine("Dato no encontrado");
            }
            
        }
        public void AgregarEstatus()
        {
            Estatus dataEsta = new Estatus();
            dataEsta.id = 0;

            Console.WriteLine("\nIngrese un nuevo nombre para el estatus: \n");
            dataEsta.nombre = Console.ReadLine();
            Console.WriteLine("\nIngrese una nueva clave para el estatus: \n");
            dataEsta.clave = Console.ReadLine();
            Console.WriteLine($"\nLa nueva id de su estatus es: {Agregar(dataEsta)}\n");
            
        }
        public void ActualizarEstatus()
        {
            Estatus estaData = new Estatus();

            Console.WriteLine("\n\nIngrese el id de su estatus a actualizar: \n");
            estaData.id = int.Parse(Console.ReadLine().Trim());
            if (Consultar(estaData.id).nombre != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre de su estatus\n");
                estaData.nombre = Console.ReadLine();
                Console.WriteLine( "Ingresa la nueva clave de su estatus:\n" );
                estaData.clave = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Estatus no encontrado");
            }

            Actualizar(estaData);

        }
        public void EliminarEstatus()
        {
            int IdEstatus = 0;

            Console.WriteLine("\nIngrese el id a eliminar: \n");
            IdEstatus = int.Parse(Console.ReadLine());

            if (Consultar(IdEstatus).nombre != null)
            {
                Eliminar(IdEstatus);
            }
            else
            {
                Console.WriteLine("Dato no econtrado");
            }
        }
        public void Presentacion()
        {
            bool continuar = true;

            while (continuar)
            {

                int opcion = 0;

                Console.Clear();
                Console.WriteLine("Eliga una opcion: \n\n\n" +
                    "1.- Consultar Todo\n" +
                    "2.- Consultar por id\n" +
                    "3.- Agregar\n" +
                    "4.- Actualizar\n" +
                    "5.- Eliminar\n" +
                    "6.- Salir\n\n\n");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ConsultarTodo();
                        break;
                    case 2:
                        ConsultarById();
                        break;
                    case 3:
                        AgregarEstatus();
                        break;
                    case 4:
                        ActualizarEstatus();
                        break;
                    case 5:
                        EliminarEstatus();
                        break;
                    case 6:
                        continuar = false;
                        break;
                    default: Console.WriteLine("Ingrese una opcion valida"); break;
                }

                Console.WriteLine("\nOprima una tecla para continuar........");
                Console.ReadKey();

            }

        }
    }
}
