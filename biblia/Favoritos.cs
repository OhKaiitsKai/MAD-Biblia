using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biblia
{
    public partial class Favoritos : Form
    {
        private EnlaceDB enlaceDB;
        public Favoritos()
        {
            InitializeComponent();
            enlaceDB = new EnlaceDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int filaSeleccionada = dataGridView1.SelectedRows[0].Index;
                int idFavorito = Convert.ToInt32(dataGridView1.Rows[filaSeleccionada].Cells["IDFavorito"].Value);

                // Eliminar la fila correspondiente en la base de datos usando el ID del favorito seleccionado
                bool eliminacionExitosa = enlaceDB.EliminarFavorito(idFavorito);

                if (eliminacionExitosa)
                {
                    // Actualizar el DataGridView después de la eliminación
                    int usuarioID = ObjetoDB.UsuarioID;
                    DataTable nuevosDatosFavoritos = enlaceDB.ObtenerDatosFavoritos(usuarioID);
                    dataGridView1.DataSource = nuevosDatosFavoritos;

                    // Mensaje de éxito o proceder con lógica adicional
                    MessageBox.Show("Se eliminó el favorito correctamente.", 
                        "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Mensaje de error si la eliminación falla
                    MessageBox.Show("Error al eliminar el favorito.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Mensaje si no hay fila seleccionada
                MessageBox.Show("Selecciona una fila para eliminar.", 
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Favoritos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Favoritos_Load(object sender, EventArgs e)
        {
            int usuarioID = ObjetoDB.UsuarioID;

            DataTable datosFavoritos = enlaceDB.ObtenerDatosFavoritos(usuarioID);

            dataGridView1.DataSource = datosFavoritos;

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
