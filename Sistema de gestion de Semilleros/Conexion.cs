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
     class Conexion
    {
        public SqlConnection con;

        public SqlConnection Conectar()

        {

            try
            { 
            con = new SqlConnection("Data Source=CNGAPRCIPFSD070;Initial Catalog=Sistemas de gestion de Semilleros Tecnologicos;Integrated Security=True");
                con.Open();
            }
                
            catch (Exception )
            {
                MessageBox.Show("Credenciales / usuario / Contraseña Incorrectos");
            }

            return con;

        }

        public void Desconectar()
        {
            con.Close();
        }
    }
}
