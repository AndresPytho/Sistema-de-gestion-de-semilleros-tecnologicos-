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
    public partial class Interfaz_Administrador : Form
    {
        // Reemplaza las declaraciones de object por los tipos correctos
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;

        // Asegúrate de inicializar los controles antes de usarlos, por ejemplo en el constructor:
        public Interfaz_Administrador()
        {
            InitializeComponent();
            // Inicialización de los controles si no se hace en el diseñador
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl();
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            guna2DragControl1.TargetControl = guna2GradientPanel1;
            AplicarEstiloDashboard();
        }
        private void AplicarEstiloDashboard()
        {
            // --- 1. FORMULARIO Y FONDO ---
            guna2BorderlessForm1.BorderRadius = 15;
            panelAdministracion.FillColor = Color.FromArgb(248, 250, 252);

            lblPanelAdministacion.BackColor = Color.Transparent;
            lblPanelAdministacion.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblPanelAdministacion.ForeColor = Color.FromArgb(15, 23, 42);

            // --- 2. BARRA LATERAL ---
            guna2Panel1.FillColor = Color.FromArgb(15, 23, 42);

            Guna.UI2.WinForms.Guna2Button[] menuButtons = { txtUsuario, txtSemillero, txtEventos, txtReportes };
            foreach (var btn in menuButtons)
            {
                btn.FillColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(148, 163, 184);
                btn.Font = new Font("Segoe UI", 11);
                btn.HoverState.FillColor = Color.FromArgb(30, 41, 59);
                btn.HoverState.ForeColor = Color.White;
                btn.TextAlign = HorizontalAlignment.Left;
                btn.TextOffset = new Point(20, 0);
                btn.BorderRadius = 8;
                btn.Cursor = Cursors.Hand;
                btn.Height = 44;
            }

            txtUsuario.FillColor = Color.FromArgb(30, 41, 59);
            txtUsuario.ForeColor = Color.White;

            // --- 3. TARJETAS ---
            ConfigurarTarjeta(guna2Panel3, lblSemillero, lblS0, Color.FromArgb(34, 197, 94));
            ConfigurarTarjeta(guna2Panel4, lblUsuario, lbl0U, Color.FromArgb(59, 130, 246));
            ConfigurarTarjeta(guna2Panel5, lblEventos, lblE0, Color.FromArgb(249, 115, 22));
            ConfigurarTarjeta(guna2Panel6, label5, lblP0, Color.FromArgb(239, 68, 68));

            // --- 4. DATA GRID VIEW — Diseño completo ---
            dataGrideTablaSemillero.Theme = (Guna.UI2.WinForms.Enums.DataGridViewPresetThemes)0;
            dataGrideTablaSemillero.BackgroundColor = Color.White;
            dataGrideTablaSemillero.BorderStyle = BorderStyle.None;
            dataGrideTablaSemillero.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGrideTablaSemillero.GridColor = Color.FromArgb(226, 232, 240);
            dataGrideTablaSemillero.RowHeadersVisible = false;
            dataGrideTablaSemillero.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrideTablaSemillero.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cabecera con fondo gris claro — se distingue bien del contenido
            dataGrideTablaSemillero.EnableHeadersVisualStyles = false;
            dataGrideTablaSemillero.ColumnHeadersHeight = 42;
            dataGrideTablaSemillero.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGrideTablaSemillero.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249); // Gris suave
            dataGrideTablaSemillero.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dataGrideTablaSemillero.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);
            dataGrideTablaSemillero.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            dataGrideTablaSemillero.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGrideTablaSemillero.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 0, 0);

            // Filas normales
            dataGrideTablaSemillero.RowTemplate.Height = 46;
            dataGrideTablaSemillero.DefaultCellStyle.BackColor = Color.White;
            dataGrideTablaSemillero.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGrideTablaSemillero.DefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dataGrideTablaSemillero.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255); // Azul muy suave al seleccionar
            dataGrideTablaSemillero.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dataGrideTablaSemillero.DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);

            // Filas alternas con gris muy sutil
            dataGrideTablaSemillero.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dataGrideTablaSemillero.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(51, 65, 85);
            dataGrideTablaSemillero.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGrideTablaSemillero.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // --- 5. GROUPBOX ACCIONES RÁPIDAS ---
            gropboxAccionesRapidas.FillColor = Color.White;
            gropboxAccionesRapidas.BorderRadius = 12;
            gropboxAccionesRapidas.CustomBorderThickness = new Padding(0);
            gropboxAccionesRapidas.ShadowDecoration.Enabled = true;
            gropboxAccionesRapidas.ShadowDecoration.BorderRadius = 12;
            gropboxAccionesRapidas.ShadowDecoration.Depth = 5;
            gropboxAccionesRapidas.ShadowDecoration.Color = Color.FromArgb(200, 210, 220);
            gropboxAccionesRapidas.ShadowDecoration.Shadow = new Padding(0, 2, 6, 6);
            gropboxAccionesRapidas.Font = new Font("Segoe UI Semibold", 12);
            gropboxAccionesRapidas.ForeColor = Color.FromArgb(15, 23, 42);

            txtCrearUsuarios.FillColor = Color.FromArgb(15, 23, 42);
            txtCrearSemillero.FillColor = Color.FromArgb(34, 197, 94);
            txtRegistrarEvento.FillColor = Color.FromArgb(59, 130, 246);
            txtVerReportes.FillColor = Color.FromArgb(249, 115, 22);

            Guna.UI2.WinForms.Guna2Button[] actionButtons = { txtCrearUsuarios, txtCrearSemillero, txtRegistrarEvento, txtVerReportes }; // Botones de acciones rápidas
            foreach (var btn in actionButtons)
            {
                btn.ForeColor = Color.White;
                btn.BorderRadius = 10;
                btn.Font = new Font("Segoe UI Semibold", 11);
                btn.Height = 48;
                btn.Cursor = Cursors.Hand;
                btn.TextAlign = HorizontalAlignment.Center;
                btn.HoverState.ForeColor = Color.White;
                btn.HoverState.FillColor = ControlPaint.Dark(btn.FillColor, 0.08f);
            }

            // --- 6. BUSCADOR ---
            txtFiltrar.BorderRadius = 20;
            txtFiltrar.FillColor = Color.White;
            txtFiltrar.BorderColor = Color.FromArgb(226, 232, 240);
            txtFiltrar.BorderThickness = 1;
            txtFiltrar.FocusedState.BorderColor = Color.FromArgb(59, 130, 246);
            txtFiltrar.FocusedState.FillColor = Color.White;
            txtFiltrar.Font = new Font("Segoe UI", 10);
            txtFiltrar.ForeColor = Color.FromArgb(15, 23, 42);
            txtFiltrar.PlaceholderText = "Buscar semillero...";
            txtFiltrar.PlaceholderForeColor = Color.FromArgb(148, 163, 184);

            guna2DragControl2.TargetControl = panelAdministracion;
        }

        private void ConfigurarTarjeta(Guna.UI2.WinForms.Guna2Panel panel, Label titulo, Label valor, Color colorBorde)
        {
            panel.FillColor = Color.White;
            panel.BorderRadius = 12;

            panel.ShadowDecoration.Enabled = true;
            panel.ShadowDecoration.BorderRadius = 12;
            panel.ShadowDecoration.Depth = 5;
            panel.ShadowDecoration.Color = Color.FromArgb(200, 210, 225);
            panel.ShadowDecoration.Shadow = new Padding(0, 2, 6, 6);

            panel.CustomBorderThickness = new Padding(5, 0, 0, 0);
            panel.CustomBorderColor = colorBorde;

            // Título — pequeño y gris
            titulo.BackColor = Color.Transparent;
            titulo.Font = new Font("Segoe UI", 10);
            titulo.ForeColor = Color.FromArgb(100, 116, 139);

            // ✅ CORREGIDO: Número más pequeño, proporcional a la tarjeta
            valor.BackColor = Color.Transparent;
            valor.Font = new Font("Segoe UI", 18, FontStyle.Bold); // Bajado de 26 a 18
            valor.ForeColor = Color.FromArgb(15, 23, 42);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
