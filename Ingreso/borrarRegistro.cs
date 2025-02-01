using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ingreso
{
    public partial class borrarRegistro : Form
    {

        public borrarRegistro()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Login.str))
            {
                con.Open();
                string cod = txtCodigo.Text;

                string cadena = "SELECT nombre,categoria,precio FROM JUEGOS WHERE codigo=" + cod;
                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    SqlDataReader registro = cmd.ExecuteReader();

                    if (registro.Read())
                    {
                        lblNombre.Text = registro["nombre"].ToString();
                        lblCategoria.Text = registro["categoria"].ToString();
                        lblPrecio.Text = registro["precio"].ToString();
                        btnBorrar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No existe un juego con el código ingresado");
                    }

                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Login.str))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("ELIMINA_JUEGO", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@wcodigo", int.Parse(txtCodigo.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Juego eliminado con exito");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar juego: " + ex.Message);
                }
            }
        }
    }
}
