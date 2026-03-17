using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_gestion_de_Semilleros
{
    public partial class Form1 : Form
    {

        Consultas c = new Consultas();
        public Form1()
        {
            InitializeComponent();
            AplicarEstiloModerno();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void AplicarEstiloModerno()
        {
            // 1. Configuracion del Formulario y Sombra
            // Usamos el BorderlessForm que ya tienes declarado
            guna2BorderlessForm1.BorderRadius = 30;
            this.BackColor = Color.White;

            // 2. Fondo Degradado Principal
            guna2GradientPanel1.FillColor = Color.FromArgb(0, 139, 139); // DarkCyan
            guna2GradientPanel1.FillColor2 = Color.FromArgb(178, 223, 219); // Teal muy claro
            guna2GradientPanel1.Size = new Size(975, 578);

            // 3. El GroupBox (Contenedor del Login)
            guna2GroupBox1.BorderRadius = 25;
            guna2GroupBox1.Size = new Size(465, 510);
            guna2GroupBox1.Location = new Point(450, 30);
            guna2GroupBox1.ShadowDecoration.Enabled = true;
            guna2GroupBox1.ShadowDecoration.Depth = 15;
            guna2GroupBox1.ShadowDecoration.Color = Color.FromArgb(100, 0, 0, 0);
            guna2GroupBox1.CustomBorderThickness = new Padding(0); // Elimina la franja superior gruesa
            guna2GroupBox1.FillColor = Color.White;
            guna2GroupBox1.Text = ""; // Quitamos el texto del GroupBox para usar los Labels

            // 4. Titulos (Labels principales)
            guna2HtmlLabel1.Text = "Iniciar Sesión";
            guna2HtmlLabel1.Location = new Point(85, 45);

            guna2HtmlLabel4.Text = "Accede a tu cuenta institucional";
            guna2HtmlLabel4.Location = new Point(65, 100);
            guna2HtmlLabel4.ForeColor = Color.DimGray;

            // 5. Seccion Correo
            guna2HtmlLabel2.Text = "Correo Institucional";
            guna2HtmlLabel2.Location = new Point(50, 150);
            guna2HtmlLabel2.Font = new Font("Roboto Mono", 10, FontStyle.Bold);

            ConfigurarInput(txtcorreo, "ejemplo@institucion.edu.co");
            txtcorreo.Location = new Point(50, 185);

            // 6. Seccion Contraseña
            guna2HtmlLabel3.Text = "Contraseña";
            guna2HtmlLabel3.Location = new Point(50, 260);
            guna2HtmlLabel3.Font = new Font("Roboto Mono", 10, FontStyle.Bold);

            ConfigurarInput(txtContraseña, "********");
            txtContraseña.Location = new Point(50, 295);
            txtContraseña.UseSystemPasswordChar = true;

            // 7. Boton de Ingreso
            guna2Button1.Size = new Size(365, 50);
            guna2Button1.Location = new Point(50, 400);
            guna2Button1.BorderRadius = 15;
            guna2Button1.FillColor = Color.FromArgb(46, 125, 50); // Verde Bosque
            guna2Button1.HoverState.FillColor = Color.FromArgb(67, 160, 71);
            guna2Button1.Font = new Font("Roboto Mono", 12, FontStyle.Bold);

            // 8. Imagen Lateral
            guna2PictureBox1.BorderRadius = 20;

           
             
             
            guna2DragControl1.TargetControl = guna2GradientPanel1;
        }

        // Metodo de soporte para estandarizar los TextBox
        private void ConfigurarInput(Guna.UI2.WinForms.Guna2TextBox txt, string placeholder)
        {
            txt.Size = new Size(365, 45);
            txt.BorderRadius = 12;
            txt.BorderThickness = 1;
            txt.BorderColor = Color.FromArgb(200, 200, 200);
            txt.FocusedState.BorderColor = Color.FromArgb(0, 150, 136);
            txt.PlaceholderText = placeholder;
            txt.Font = new Font("Segoe UI", 10);
            txt.FillColor = Color.FromArgb(250, 250, 250);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrWhiteSpace(txtcorreo.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, ingrese su ID y contraseña y que sean correctos.");
                return;
            }

           
            if (!int.TryParse(txtcorreo.Text, out id))
            {
                MessageBox.Show("El ID debe ser un número válido.");
                return;
            }

            bool resultado = c.Iniciar_Sesion(id, txtContraseña.Text);

            if (resultado)
            {
                MessageBox.Show("Inicio de sesión exitoso");
                this.Hide(); // Aquí puedes abrir otro formulario
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true;
        }
          
    }
}
