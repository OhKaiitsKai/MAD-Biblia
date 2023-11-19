using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace biblia
{
    public partial class IniciarSesion : Form
    {
        private EnlaceDB enlaceDB;
        public IniciarSesion()
        {
            InitializeComponent();
            enlaceDB = new EnlaceDB();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Registro registro = new Registro();
            registro.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            if (email == "" || password == "" )
            {
                MessageBox.Show("Llena todos los campos", "Registro Fallido", MessageBoxButtons.OK);
            }
            else
            {
                bool inicioSesionExitoso = enlaceDB.IniciarSesion(email, password);

                if (inicioSesionExitoso)
                {
                    MessageBox.Show("Inicio de sesión exitoso", "Éxito", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Hide();
            Consultas consultas = new Consultas();
            consultas.Show();
        }
    }
}
