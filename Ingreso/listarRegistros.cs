using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ingreso
{
    public partial class listarRegistros : Form
    {
        public listarRegistros()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            textBox1.Text = "Código - Nombre - Categoría - Precio";

            Login f = new Login();
            f.con.Open();

            string cadena = "select Código,Nombre,Categoría,Precio from games";
            SqlCommand cmd = new SqlCommand(cadena, f.con);

            SqlDataReader registros = cmd.ExecuteReader();

            while(registros.Read())
            {
                textBox1.AppendText(Environment.NewLine);

                textBox1.AppendText(registros["Código"].ToString());
                textBox1.AppendText(" - ");

                textBox1.AppendText(registros["Nombre"].ToString());
                textBox1.AppendText(" - ");
                
                textBox1.AppendText(registros["Categoría"].ToString());
                textBox1.AppendText(" - ");

                textBox1.AppendText(registros["Precio"].ToString());
            }

            f.con.Close();
            */
            using (SqlConnection con = new SqlConnection(Login.str))
            {
                try
                {
                    con.Open();
                    string cadena = "select codigo,nombre,categoria,precio from JUEGOS";
                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            listView1.Items.Clear();
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["codigo"].ToString());
                                item.SubItems.Add(reader["nombre"].ToString());
                                item.SubItems.Add(reader["categoria"].ToString());
                                item.SubItems.Add(reader["precio"].ToString());
                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al visualizar los juegos: " + ex.Message);
                }
            }
        }
    }
}
