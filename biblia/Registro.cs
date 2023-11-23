using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biblia
{
    public partial class Registro : Form
    {
        private EnlaceDB enlaceDB;
        public Registro()
        {
            InitializeComponent();
            enlaceDB = new EnlaceDB();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string email_val = email.Text;
            string password_val = contrasena.Text;
            string nombrec_val = nombre_completo.Text;
            DateTime fechaNacimiento = fecha_nacimiento.Value;
            bool femeninoChecked = F.Checked;
            bool masculinoChecked = M.Checked;
            string rol_val = "UsuarioNormal";

            // Expresión regular para validar el formato del correo electrónico y contraseña
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";

            if (email_val == "" || password_val == "" || nombrec_val == "")
            {
                MessageBox.Show("Llena todos los campos", "Registro Fallido", MessageBoxButtons.OK);
            }
            else if (!Regex.IsMatch(email_val, emailPattern))
            {
                MessageBox.Show("El formato del correo electrónico no es válido", "Registro Fallido", MessageBoxButtons.OK);
            }
            else if (!Regex.IsMatch(password_val, passwordPattern))
            {
                MessageBox.Show("La contraseña no cumple con los criterios mínimos de seguridad", "Registro Fallido", MessageBoxButtons.OK);
            }
            else if (DateTime.Today.AddYears(-13) < fechaNacimiento) // Verificar si la persona tiene al menos 13 años
            {
                MessageBox.Show("Debes tener al menos 13 años para registrarte", "Registro Fallido", MessageBoxButtons.OK);
            }
            else if (!(femeninoChecked || masculinoChecked))
            {
                MessageBox.Show("Debes seleccionar tu género", "Registro Fallido", MessageBoxButtons.OK);
            }
            else if (femeninoChecked && masculinoChecked)
            {
                MessageBox.Show("Selecciona solo un género", "Registro Fallido", MessageBoxButtons.OK);
            }
            else {
                //MessageBox.Show("Te has registrado exitosamente", "Registro", MessageBoxButtons.OK);
                if (femeninoChecked)
                {
                    string Femenino = "F";
                    // bool registrado = enlaceDB.RegistrarUsuario(nombrec_val, Femenino, email_val,
                    //   password_val, fechaNacimiento);
                    bool registrado = enlaceDB.RegistrarUsuario(nombrec_val, Femenino, email_val,
                       password_val, fechaNacimiento, rol_val, DateTime.Now, true);
                    if (registrado)
                    {
                        _ = enlaceDB.ObtenerUsuarioID(email_val, password_val);
                        MessageBox.Show("Usuario registrado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                        Consultas consultas = new Consultas();
                        consultas.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar usuario.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string Masculino = "M";
                   // bool registrado = enlaceDB.RegistrarUsuario(nombrec_val, Masculino, email_val,
                     //   password_val, fechaNacimiento);
                    bool registrado = enlaceDB.RegistrarUsuario(nombrec_val, Masculino, email_val,
                        password_val, fechaNacimiento, rol_val, DateTime.Now, true);

                    if (registrado)
                    {
                        _ = enlaceDB.ObtenerUsuarioID(email_val, password_val);
                        ObjetoDB.UsuarioID = enlaceDB.UsuarioID;
                        MessageBox.Show("Usuario registrado correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);  
                        Hide();
                        Consultas consultas = new Consultas();
                        consultas.Show();
                    }
                    else 
                    {
                        MessageBox.Show("Error al registrar usuario.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
            //Registro registro = new Registro();
            //registro.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void M_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Registro_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
