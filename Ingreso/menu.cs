using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingreso
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            insertarRegistro ins = new insertarRegistro();
            ins.ShowDialog();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            borrarRegistro del = new borrarRegistro();
            del.ShowDialog();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listarRegistros lis = new listarRegistros();
            lis.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            modificarRegistros mod = new modificarRegistros();
            mod.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            consultarRegistros con = new consultarRegistros();
            con.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            form1.txtUsuario.Clear();
            form1.txtClave.Clear();
            this.Close();
        }
    }
}
