using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProyectoPapeleria
{
    public partial class Papeleria : Form
    {
        // Se declara la instancia de la clase de conexión a la base de datos MySQL.
        private Conexion miConexion = new Conexion();

        public Papeleria()
        {
            InitializeComponent();
            // Llama a la función que recupera y muestra todos los productos al iniciar el formulario.
            CargarTodosLosProductosEnListBox();
        }

        // --------------------------------------------------------------- FUNCIONES AUXILIARES-----------------------------------------------------------------------
        // Limpia los campos de texto de ID, Nombre y Cantidad en el formularioy pone el foco en el campo de ID de Producto.
       
        private void LimpiarCampos()
        {
            txtIdProd.Clear();
            txtNomProd.Clear();
            txtCantidad.Text = "0";
            txtIdProd.Focus();
        }

        // Realiza una consulta SELECT a la base de datos para obtener TODOS los productos y los lista en el control lstbProd.
        private void CargarTodosLosProductosEnListBox()
        {
            lstbProd.Items.Clear();
            string query = "SELECT idProducto, nombreProducto, cantidad FROM Productos ORDER BY idProducto ASC";

            if (miConexion.AbrirConexion())
            {
                MySqlCommand comando = new MySqlCommand(query, miConexion.ObtenerConexion());
                MySqlDataReader? reader = null;

                try
                {
                    reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        // Agrega cada producto al ListBox en formato [ID] - Nombre (Cantidad)
                        lstbProd.Items.Add($"[{reader!.GetInt32(0)}] - {reader.GetString(1)!} ({reader.GetInt32(2)})");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al cargar productos: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (reader != null) reader.Close();
                    miConexion.CerrarConexion();
                }
            }
        }

        // Limpia el ListBox y muestra ÚNICAMENTE el producto proporcionado,se usa para mostrar resultados de búsqueda específicos.
        private void MostrarProductoEnListBox(int id, string nombre, int cantidad)
        {
            lstbProd.Items.Clear();
            lstbProd.Items.Add($"[{id}] - {nombre} ({cantidad})");
        }

        // ---------------------------------------------------- FUNCIONES PRINCIPALES DE BD --------------------------------------------------------------------------
        // Busca un producto específico por su ID en la base de datos. Si lo encuentra, carga sus datos en los TextBox y lo muestra filtrado en el ListBox.
        private void BuscarProducto(int id)
        {
            string query = "SELECT nombreProducto, cantidad FROM Productos WHERE idProducto = @id";
            LimpiarCampos();

            if (miConexion.AbrirConexion())
            {
                MySqlCommand comando = new MySqlCommand(query, miConexion.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);

                MySqlDataReader? reader = null;
                try
                {
                    reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        // Asigna los datos del producto encontrado a los TextBox.
                        string nombre = reader!.GetString(0)!;
                        int cantidad = reader.GetInt32(1);

                        txtIdProd.Text = id.ToString();
                        txtNomProd.Text = nombre;
                        txtCantidad.Text = cantidad.ToString();

                        // Filtra el ListBox para mostrar solo el resultado.
                        MostrarProductoEnListBox(id, nombre, cantidad);
                    }
                    else
                    {
                        // Si no se encuentra, deja el ID en el campo y limpia los demás.
                        txtIdProd.Text = id.ToString();
                        CargarTodosLosProductosEnListBox();
                        MessageBox.Show("Producto no encontrado. Puede registrar uno nuevo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al buscar: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (reader != null) reader.Close();
                    miConexion.CerrarConexion();
                }
            }
        }

        /// Realiza una operación Un Update o Insert:
        /// 1. Verifica si el producto ya existe por su ID.
        /// 2. Si existe, lo ACTUALIZA.
        /// 3. Si no existe, lo INSERTA como nuevo registro.
        private void RegistrarOActualizarProducto(int id, string nombre, int cantidad)
        {
            // Lógica para verificar existencia (consulta SELECT COUNT)
            string verificarQuery = "SELECT COUNT(*) FROM Productos WHERE idProducto = @id";
            bool existe = false;

            if (miConexion.AbrirConexion())
            {
                MySqlCommand cmdVerificar = new MySqlCommand(verificarQuery, miConexion.ObtenerConexion());
                cmdVerificar.Parameters.AddWithValue("@id", id);
                try
                {
                    object? result = cmdVerificar.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        existe = Convert.ToInt32(result) > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar producto: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    miConexion.CerrarConexion();
                    return;
                }
                miConexion.CerrarConexion();
            }
            else { return; }

            // Define la consulta a ejecutar (UPDATE o INSERT)
            string upsertQuery;
            if (existe)
            {
                upsertQuery = "UPDATE Productos SET nombreProducto = @nombre, cantidad = @cantidad WHERE idProducto = @id";
            }
            else
            {
                upsertQuery = "INSERT INTO Productos (idProducto, nombreProducto, cantidad) VALUES (@id, @nombre, @cantidad)";
            }

            // Ejecuta la consulta
            if (miConexion.AbrirConexion())
            {
                MySqlCommand comando = new MySqlCommand(upsertQuery, miConexion.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@cantidad", cantidad);

                try
                {
                    comando.ExecuteNonQuery();
                    MessageBox.Show(existe ? "Producto actualizado con éxito." : "Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarTodosLosProductosEnListBox();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al registrar/actualizar: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    miConexion.CerrarConexion();
                }
            }
        }

        //Elimina el producto cuyo ID se proporciona de la base de datos, previa confirmación del usuario.
        private void EliminarProducto(int id)
        {
            string query = "DELETE FROM Productos WHERE idProducto = @id";

            // Pide confirmación antes de borrar
            if (MessageBox.Show("¿Está seguro que desea eliminar el producto con ID: " + id + "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (miConexion.AbrirConexion())
                {
                    MySqlCommand comando = new MySqlCommand(query, miConexion.ObtenerConexion());
                    comando.Parameters.AddWithValue("@id", id);

                    try
                    {
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            CargarTodosLosProductosEnListBox();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto con ese ID.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        miConexion.CerrarConexion();
                    }
                }
            }
        }

        // Actualiza el campo 'cantidad' de un producto específico en la base de datos. Se usa por los botones +Cantidad y -Cantidad.
        private void ActualizarCantidad(int id, int nuevaCantidad)
        {
            string query = "UPDATE Productos SET cantidad = @cantidad WHERE idProducto = @id";

            if (miConexion.AbrirConexion())
            {
                MySqlCommand comando = new MySqlCommand(query, miConexion.ObtenerConexion());
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@cantidad", nuevaCantidad);

                try
                {
                    if (comando.ExecuteNonQuery() > 0)
                    {
                        // Actualiza el TextBox y el ListBox para reflejar el cambio.
                        txtCantidad.Text = nuevaCantidad.ToString();
                        CargarTodosLosProductosEnListBox();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el producto para actualizar la cantidad. Intente buscarlo primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al actualizar la cantidad: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    miConexion.CerrarConexion();
                }
            }
        }

        // ---------------------------------------------- MANEJADORES DE EVENTOS DE BOTONES Y CONTROLES ------------------------------------------------------
        // botón "Registrar Producto". Valida los campos y llama a la función RegistrarOActualizarProducto() para guardar o modificar.
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdProd.Text, out int id) &&
                int.TryParse(txtCantidad.Text, out int cantidad) &&
                !string.IsNullOrWhiteSpace(txtNomProd.Text))
            {
                string nombre = txtNomProd.Text.Trim();
                RegistrarOActualizarProducto(id, nombre, cantidad);
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos (ID, Nombre y Cantidad) con valores válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // botón "Buscar (Id)".Valida el ID del TextBox y llama a la función BuscarProducto().
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdProd.Text, out int id))
            {
                BuscarProducto(id);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de producto válido para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // botón "Mostrar Todos". Limpia los campos y recarga la lista completa de productos desde la DB.
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarTodosLosProductosEnListBox();
        }

        /// Evento asociado al botón "+Cantidad".Incrementa la cantidad actual del producto mostrado en 1 y actualiza la base de datos.
        private void btnMas_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdProd.Text, out int id) && int.TryParse(txtCantidad.Text, out int cantidad))
            {
                int nuevaCantidad = cantidad + 1;
                ActualizarCantidad(id, nuevaCantidad);
            }
            else
            {
                MessageBox.Show("Debe cargar un producto (usando Buscar) o seleccionarlo de la lista antes de modificar la cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // botón "-Cantidad". Decrementa la cantidad actual del producto mostrado en 1 (si es mayor a cero) y actualiza la base de datos.
        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdProd.Text, out int id) && int.TryParse(txtCantidad.Text, out int cantidad))
            {
                if (cantidad > 0)
                {
                    int nuevaCantidad = cantidad - 1;
                    ActualizarCantidad(id, nuevaCantidad);
                }
                else
                {
                    MessageBox.Show("La cantidad no puede ser negativa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe cargar un producto (usando Buscar) o seleccionarlo de la lista antes de modificar la cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
        // Evento asociado al botón "Borrar Producto". Lee el ID del TextBox y llama a la función EliminarProducto() para borrar el registro.
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdProd.Text, out int id))
            {
                EliminarProducto(id);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese el ID del producto que desea eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento asociado al botón "Cerrar".Simplemente cierra el formulario actual.
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// Al SELECCIONAR un elemento en el ListBox. Lee el ID del elemento seleccionado y llama a BuscarProducto para cargar sus detalles en los TextBox.
        private void lstbProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Carga los datos del producto seleccionado en los TextBox
            if (lstbProd.SelectedItem is string selectedItem)
            {
                // Extrae el ID del formato [ID] - Nombre...
                int start = selectedItem.IndexOf('[') + 1;
                int end = selectedItem.IndexOf(']');

                if (start > 0 && end > start)
                {
                    string idStr = selectedItem.Substring(start, end - start);
                    if (int.TryParse(idStr, out int id))
                    {
                        BuscarProducto(id);
                    }
                }
            }
        }

    }
}