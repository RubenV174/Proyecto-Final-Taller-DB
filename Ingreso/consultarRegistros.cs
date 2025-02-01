using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingreso
{
    public partial class consultarRegistros : Form
    {
        public consultarRegistros()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(Login.str))
            {
                con.Open();
                string cod = textBox1.Text;

                string cadena = "SELECT nombre,categoria,precio FROM JUEGOS WHERE codigo=" + cod;
                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    SqlDataReader registro = cmd.ExecuteReader();

                    if (registro.Read())
                    {
                        lblNombre.Text = registro["nombre"].ToString();
                        lblCategoria.Text = registro["categoria"].ToString();
                        lblPrecio.Text = registro["precio"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No existe un juego con el código ingresado");
                    }

                }
            }

        }
    }
}