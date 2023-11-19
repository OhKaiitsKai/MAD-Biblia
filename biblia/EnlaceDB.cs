using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public bool RegistrarUsuario(string nombreCompleto, string genero, string email, string contraseña, DateTime fechaNacimiento)
        {
            bool registrado = false;

            try
            {
                conectar();
                string qry = "INSERT INTO dbo.Usuario (nombre_completo, genero, " +
                    "email, contraseña, fecha_nacimiento) " +
                                      "VALUES (@nombreCompleto, @genero, @email," +
                                      "@contraseña, @fechaNacimiento)";

                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                _comandosql.Parameters.AddWithValue("@genero", genero);
                _comandosql.Parameters.AddWithValue("@email", email);
                _comandosql.Parameters.AddWithValue("@contraseña", contraseña);
                _comandosql.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);

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

    }
}
