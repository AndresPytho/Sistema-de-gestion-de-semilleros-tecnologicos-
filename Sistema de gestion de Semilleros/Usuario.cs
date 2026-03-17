using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_gestion_de_Semilleros
{
     class Usuario
    {
        Conexion cn = new Conexion();


        public bool Iniciar_Sesion(int idUsuario, string contraseña)
        {
            bool existe = false;

            try
            {
                cn.Conectar();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Usuario WHERE idUsuario=@idUsuario AND contraseñaUsuario=@contraseñaUsuario",
                    cn.con
                );

                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@contraseñaUsuario", contraseña);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    existe = true;
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

            return existe;
        }
    }
}
