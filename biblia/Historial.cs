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
    public partial class Historial : Form
    {
        private EnlaceDB enlaceDB;
        public Historial()
        {
            InitializeComponent();
            enlaceDB = new EnlaceDB(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
                    }

        private void Historial_Load(object sender, EventArgs e)
        {
            int usuarioID = ObjetoDB.UsuarioID;

            DataTable historialBusqueda = enlaceDB.ObtenerHistorialBusqueda(usuarioID);

            dataGridView1.DataSource = historialBusqueda;
        }

        private void Historial_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
