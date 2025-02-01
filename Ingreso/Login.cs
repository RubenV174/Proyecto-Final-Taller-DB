using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Ingreso
{
    public partial class Login : Form
    {

        public static string str = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Admin" && txtClave.Text == "0000")
            {
                menu menu = new menu();
                menu.show

            }
            else
            {
                MessageBox.Show("Usuario o clave incorrecta", "Error");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                txtClave.UseSystemPasswordChar = true;
            }
            else
            {
                txtClave.UseSystemPasswordChar = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            DialogResult res = MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
