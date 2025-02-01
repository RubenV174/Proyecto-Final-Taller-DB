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
    public partial class insertarRegistro : Form
    {
        public insertarRegistro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(Login.str))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERTA_JUEGO", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@wcodigo", int.Parse(txtCodigo.Text));
                        cmd.Parameters.AddWithValue("@wnombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@wcategoria", txtCategoria.Text);
                        cmd.Parameters.AddWithValue("@wprecio", double.Parse(txtPrecio.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Juego insertado correctamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar juego: " + ex.Message);
                }
            }




            MessageBox.Show("Juego registrado correctamente");

            txtCodigo.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
        }
    }
}