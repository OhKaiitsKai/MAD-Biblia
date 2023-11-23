using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace biblia
{
    public partial class Consultas : Form
    {
        private EnlaceDB enlaceDB;
        public Consultas()
        {
            InitializeComponent();
            enlaceDB = new EnlaceDB();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                string nombreLibro = comboBox1.SelectedItem.ToString();
                int numeroCapitulo = Convert.ToInt32(comboBox2.SelectedItem.ToString());
                int numeroVersiculo = Convert.ToInt32(comboBox3.SelectedItem.ToString());

                EnlaceDB enlaceDB = new EnlaceDB();
                DataTable dataTable = enlaceDB.ObtenerTextoVersiculo(nombreLibro, numeroCapitulo, numeroVersiculo);

                dataGridView1.DataSource = dataTable;
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            List<string> nombresLibros = enlaceDB.ObtenerNombresLibros();

            comboBox1.DataSource = nombresLibros;

            if (comboBox1.SelectedItem != null)
            {
                string nombreLibroSeleccionado = comboBox1.SelectedItem.ToString();
                List<string> numerosCapitulo = enlaceDB.ObtenerNumerosCapitulo(nombreLibroSeleccionado);

                comboBox2.DataSource = numerosCapitulo;
            }
            if (comboBox2.SelectedItem != null)
            {
                string nombreLibroSeleccionado = comboBox1.SelectedItem.ToString();
                int numeroCapituloSeleccionado = Convert.ToInt32(comboBox2.SelectedItem.ToString());

                List<string> numerosVersiculo = enlaceDB.ObtenerNumerosVersiculo(nombreLibroSeleccionado, numeroCapituloSeleccionado);

                comboBox3.DataSource = numerosVersiculo;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Consultas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Obtener los valores de las celdas en la fila seleccionada
                string texto = selectedRow.Cells["Texto"].Value.ToString();
                int numeroCap = Convert.ToInt32(selectedRow.Cells["NumeroCap"].Value);
                int numeroVers = Convert.ToInt32(selectedRow.Cells["NumeroVers"].Value);
                string nombreLibro = selectedRow.Cells["NombreLibro"].Value.ToString();
                int idLibro = Convert.ToInt32(selectedRow.Cells["Id_Libro"].Value);
                int idVersion = Convert.ToInt32(selectedRow.Cells["Id_Version"].Value);

                // Aquí debes obtener el UsuarioID del usuario actual, que se almacena previamente al iniciar sesión
                int usuarioID = ObjetoDB.UsuarioID;  

                // Ahora, realiza la inserción en la tabla de Favoritos utilizando tu método en EnlaceDB
                bool guardadoExitoso = enlaceDB.GuardarFavorito(usuarioID, idLibro, numeroCap, numeroVers, idVersion);

                if (guardadoExitoso)
                {
                    MessageBox.Show("Se ha guardado en favoritos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hubo un error al guardar en favoritos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void favoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Favoritos favoritos = new Favoritos();
            favoritos.Show();
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
