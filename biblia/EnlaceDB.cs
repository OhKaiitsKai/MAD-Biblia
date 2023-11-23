using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace biblia
{
    public class EnlaceDB
    {
        static private SqlConnection _conexion;
        static private SqlCommand _comandosql = new SqlCommand();

        private static void conectar()
        {
            string cnn = ConfigurationManager.ConnectionStrings["piamad_db"].ToString();
            _conexion = new SqlConnection(cnn);
            _conexion.Open();
        }

        private static void desconectar()
        {
            _conexion.Close();
        }

        public bool RegistrarUsuario(string nombreCompleto, string genero, string email, string contraseña, 
            DateTime fechaNacimiento, string rol, DateTime fechaRegistro, bool activo)
        {
            bool registrado = false;

            try
            {
                conectar();
                string qry = "INSERT INTO dbo.Usuario (nombre_completo, genero, email, contraseña, fecha_nacimiento, rol, fechahora_registro, activo) " +
                     "VALUES (@nombreCompleto, @genero, @email, @contraseña, @fechaNacimiento, @rol, @fechaRegistro, @activo)";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                _comandosql.Parameters.AddWithValue("@genero", genero);
                _comandosql.Parameters.AddWithValue("@email", email);
                _comandosql.Parameters.AddWithValue("@contraseña", contraseña);
                _comandosql.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                _comandosql.Parameters.AddWithValue("@rol", rol);
                _comandosql.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);
                _comandosql.Parameters.AddWithValue("@activo", activo);


                int filasAfectadas = _comandosql.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    registrado = true;
                }
            }
            catch (SqlException ex)
            {
                // Manejo de la excepción, puedes mostrar un mensaje o realizar alguna acción específica.
                Console.WriteLine("Error al registrar usuario: " + ex.Message);
                MessageBox.Show("Error en la conexión:"+ ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                desconectar();
            }

            return registrado;
        }

        public bool IniciarSesion(string email, string contraseña)
        {
            bool inicioSesionExitoso = false;

            try
            {
                conectar();
                string qry = "SELECT COUNT(*) FROM dbo.Usuario WHERE email = @email AND contraseña = @contraseña";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@email", email);
                _comandosql.Parameters.AddWithValue("@contraseña", contraseña);

                int resultado = Convert.ToInt32(_comandosql.ExecuteScalar());
                if (resultado > 0)
                {
                    inicioSesionExitoso = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al iniciar sesión: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return inicioSesionExitoso;
        }
        public List<string> ObtenerNombresLibros()
        {
            List<string> nombresLibros = new List<string>();

            try
            {
                conectar();
                string qry = "SELECT Nombre FROM dbo.Libros";
                _comandosql = new SqlCommand(qry, _conexion);

                SqlDataReader reader = _comandosql.ExecuteReader();
                while (reader.Read())
                {
                    nombresLibros.Add(reader["Nombre"].ToString());
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener nombres de libros: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return nombresLibros;
        }

        public List<string> ObtenerNumerosCapitulo(string nombreLibro)
        {
            List<string> numerosCapitulo = new List<string>();

            try
            {
                conectar();
                string qry = "SELECT NumeroCap FROM dbo.Versiculos " +
                             "INNER JOIN Libros ON Versiculos.Id_Libro = Libros.Id_Libro " +
                             "WHERE Libros.Nombre = @nombreLibro";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@nombreLibro", nombreLibro);

                SqlDataReader reader = _comandosql.ExecuteReader();
                while (reader.Read())
                {
                    numerosCapitulo.Add(reader["NumeroCap"].ToString());
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener números de capítulo: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return numerosCapitulo;
        }

        public List<string> ObtenerNumerosVersiculo(string nombreLibro, int numeroCapitulo)
        {
            List<string> numerosVersiculo = new List<string>();

            try
            {
                conectar();
                string qry = "SELECT NumeroVers FROM dbo.Versiculos " +
                             "INNER JOIN Libros ON Versiculos.Id_Libro = Libros.Id_Libro " +
                             "WHERE Libros.Nombre = @nombreLibro AND Versiculos.NumeroCap = @numeroCapitulo";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@nombreLibro", nombreLibro);
                _comandosql.Parameters.AddWithValue("@numeroCapitulo", numeroCapitulo);

                SqlDataReader reader = _comandosql.ExecuteReader();
                while (reader.Read())
                {
                    numerosVersiculo.Add(reader["NumeroVers"].ToString());
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener números de versículo: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return numerosVersiculo;
        }

        public DataTable ObtenerTextoVersiculo(string nombreLibro, int numeroCapitulo, int numeroVersiculo)
        {
            DataTable dataTable = new DataTable();

            try
            {
                conectar();
                string qry = "SELECT Versiculos.Texto, Versiculos.Id_Version, Versiculos.NumeroCap, Versiculos.NumeroVers," +
                    " Libros.Nombre AS NombreLibro, Versiculos.Id_Libro " +
                     "FROM dbo.Versiculos " +
                     "INNER JOIN Libros ON Versiculos.Id_Libro = Libros.Id_Libro " +
                     "WHERE Libros.Nombre = @nombreLibro AND " +
                     "Versiculos.NumeroCap = @numeroCapitulo AND " +
                     "Versiculos.NumeroVers = @numeroVersiculo";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@nombreLibro", nombreLibro);
                _comandosql.Parameters.AddWithValue("@numeroCapitulo", numeroCapitulo);
                _comandosql.Parameters.AddWithValue("@numeroVersiculo", numeroVersiculo);

                SqlDataAdapter adapter = new SqlDataAdapter(_comandosql);
                adapter.Fill(dataTable);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener datos: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return dataTable;
        }

        public int UsuarioID { get; private set; }
        public int ObtenerUsuarioID(string email, string contraseña)
        {
            int usuarioID = -1; // Valor predeterminado para indicar un inicio de sesión no exitoso

            try
            {
                conectar();
                string qry = "SELECT IDUsuario FROM dbo.Usuario" +
                    " WHERE email = @email AND contraseña = @contraseña";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@email", email);
                _comandosql.Parameters.AddWithValue("@contraseña", contraseña);

                object result = _comandosql.ExecuteScalar();
                if (result != null)
                {
                    usuarioID = Convert.ToInt32(result); // Se obtiene el ID del usuario
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener ID de usuario: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return usuarioID;
        }

        public bool GuardarFavorito(int usuarioID, int libroFK, int numeroCap, int numeroVers, int versionFK)
        {
            bool guardadoExitoso = false;

            try
            {
                conectar();
                string qry = "INSERT INTO dbo.Favoritos (UsuarioFK, LibroFK, NumeroCap, NumeroVers, VersionFK) " +
                             "VALUES (@usuarioID, @libroFK, @numeroCap, @numeroVers, @versionFK)";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@usuarioID", usuarioID);
                _comandosql.Parameters.AddWithValue("@libroFK", libroFK);
                _comandosql.Parameters.AddWithValue("@numeroCap", numeroCap);
                _comandosql.Parameters.AddWithValue("@numeroVers", numeroVers);
                _comandosql.Parameters.AddWithValue("@versionFK", versionFK);

                int filasAfectadas = _comandosql.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    guardadoExitoso = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al guardar en favoritos: " + ex.Message);
            }
            finally
            {
                desconectar();
            }

            return guardadoExitoso;
        }

        public DataTable ObtenerDatosFavoritos()
        {
            DataTable favoritosData = new DataTable();

            try
            {
                conectar();

                string qry = "SELECT * FROM dbo.Favoritos"; // Ajusta la consulta según tus necesidades

                _comandosql = new SqlCommand(qry, _conexion);
                SqlDataAdapter adapter = new SqlDataAdapter(_comandosql);

                adapter.Fill(favoritosData);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener datos de Favoritos: " + ex.Message);
                // Manejo de errores aquí
            }
            finally
            {
                desconectar();
            }

            return favoritosData;
        }

        public DataTable BuscarVersiculosPorPalabra(string palabraClave)
        {
            DataTable resultados = new DataTable();

            try
            {
                conectar();

                string qry = "SELECT Libros.Nombre AS NombreLibro, Versiculos.NumeroCap, " +
                             "Versiculos.NumeroVers, Versiculos.Texto " +
                             "FROM dbo.Versiculos " +
                             "INNER JOIN Libros ON Versiculos.Id_Libro = Libros.Id_Libro " +
                             "WHERE Versiculos.Texto LIKE @palabraClave";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@palabraClave", "%" + palabraClave + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(_comandosql);
                adapter.Fill(resultados);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al buscar versículos: " + ex.Message);
                // Manejo de errores aquí
            }
            finally
            {
                desconectar();
            }

            return resultados;
        }

        public bool GuardarBusqueda(int usuarioID, string palabraClave)
        {
            try
            {
                conectar();

                string qry = "INSERT INTO dbo.Busqueda (fecha_hora, texto_busqueda, UsuarioFK) " +
                             "VALUES (@fechaHora, @textoBusqueda, @usuarioID)";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@fechaHora", DateTime.Now);
                _comandosql.Parameters.AddWithValue("@textoBusqueda", palabraClave);
                _comandosql.Parameters.AddWithValue("@usuarioID", usuarioID);

                int filasAfectadas = _comandosql.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true; // Se guardó la búsqueda correctamente
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al guardar búsqueda: " + ex.Message);
                // Manejo de errores aquí
            }
            finally
            {
                desconectar();
            }

            return false; // Error al guardar la búsqueda
        }

        public DataTable ObtenerHistorialBusqueda(int usuarioID)
        {
            DataTable historialBusqueda = new DataTable();

            try
            {
                conectar();

                string qry = "SELECT IDBusqueda, fecha_hora, texto_busqueda " +
                             "FROM dbo.Busqueda " +
                             "WHERE UsuarioFK = @usuarioID";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@usuarioID", usuarioID);

                SqlDataAdapter adapter = new SqlDataAdapter(_comandosql);
                adapter.Fill(historialBusqueda);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al obtener historial de búsqueda: " + ex.Message);
                // Manejo de errores aquí
            }
            finally
            {
                desconectar();
            }

            return historialBusqueda;
        }



    }
}
