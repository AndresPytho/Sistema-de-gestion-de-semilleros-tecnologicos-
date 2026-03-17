using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sistema_de_gestion_de_Semilleros
{

    class Consultas
    {

        Conexion cn = new Conexion(); // Instancia de la clase Conexion para establecer la conexión a la base de datos
        DataSet ds = new DataSet(); // Instancia de la clase Dataset para almacenar los datos obtenidos de la base de datos
        Boolean Estado_conexion = false; // Variable booleana para verificar el estado de la conexión a la base de datos

        public Boolean Iniciar_Sesion(int idUsuario, String contraseñaUsuario)

        {
            SqlCommand Consulta;
            Consulta = new SqlCommand("Select idUsuario, nombreUsuario, rolUsuario, contraseñaUsuario, correoUsuario From Usuario Where idUsuario=@idUsuario and contraseñaUsuario=@contraseñaUsuario", cn.Conectar());
            Consulta.CommandType = CommandType.Text;
            Consulta.Parameters.AddWithValue("@idUsuario", idUsuario);
            Consulta.Parameters.AddWithValue("@contraseñaUsuario", contraseñaUsuario);
            Consulta.ExecuteNonQuery();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(Consulta);
                da.Fill(ds, "Usuario");
                DataRow dr;
                dr = ds.Tables["Usuario"].Rows[0];
                if (Convert.ToString(idUsuario) == dr["idUsuario"].ToString() & contraseñaUsuario == dr["contraseñaUsuario"].ToString() & "Administrador" == dr["rolUsuario"].ToString())
                {
                    MessageBox.Show("Bienvenido al sistema de Gestion de Semilleros!");
                    Interfaz_Administrador ifa = new Interfaz_Administrador();
                    ifa.Show();
                    Estado_conexion = true;

                }

                else if (Convert.ToString(idUsuario) == dr["idUsuario"].ToString() & contraseñaUsuario == dr["contraseñaUsuario"].ToString() & "Lider" == dr["rolUsuario"].ToString())
                {
                    MessageBox.Show("Bienvenido al sistema de Gestion de Semilleros!");
                    IntrfazLider ifl = new IntrfazLider();
                    ifl.Show();
                    Estado_conexion = true;

                }




            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                cn.Desconectar();
            }

            return Estado_conexion;

        }
    }
}