using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProyectoPapeleria
{
    public class Conexion
    {
        private readonly string cadenaConexion = "server=localhost;database=PapeleriaDB;uid=root;pwd=Pkpablo28@";

        private MySqlConnection conexion;

        // Constructor
        public Conexion()
        {
            conexion = new MySqlConnection(cadenaConexion);
        }

        // Método para obtener la conexión
        public MySqlConnection ObtenerConexion()
        {
            return conexion;
        }

        public bool AbrirConexion()
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                    return true;
                }
                return true; // Ya estaba abierta
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Método para cerrar la conexión de forma segura
        public bool CerrarConexion()
        {
            try
            {
                if (conexion.State != System.Data.ConnectionState.Closed)
                {
                    conexion.Close();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cerrar la conexión: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
