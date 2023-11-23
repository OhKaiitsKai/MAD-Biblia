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
    public partial class Busqueda : Form
    {
        private EnlaceDB enlaceDB;
        public Busqueda()
        {
            InitializeComponent();
            enlaceDB = new EnlaceDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string palabraClave = textBox1.Text; // Obtener la palabra clave del textBox

            DataTable resultados = enlaceDB.BuscarVersiculosPorPalabra(palabraClave);

            dataGridView1.DataSource = resultados;

            int usuarioID = ObjetoDB.UsuarioID;
            bool guardadoExitoso = enlaceDB.GuardarBusqueda(usuarioID, palabraClave);
            if (guardadoExitoso)
            {
                MessageBox.Show("Se ha guardado en el historial.", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else{
                MessageBox.Show("No se ha guardado.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Historial historial = new Historial();
            historial.Show();
        }
    }
}
