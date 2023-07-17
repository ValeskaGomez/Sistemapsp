using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Sistemapsp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-ULGE4070\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True");

        private void Login_Load(object sender, EventArgs e)
        {
            

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "SELECT* FROM usuarios WHERE usuario = '" + txtusuario.Text + "' AND contrasena = '" + txtcontrasena.Text + "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.HasRows == true)
            {
                Principal p = new Principal();
                this.Hide();
                p.Show();
                txtcontrasena.Clear();
                txtusuario.Clear();
                txtusuario.Focus();
            }
            else
            {
                MessageBox.Show("usuario y contraseña incorrectos");
                txtusuario.Clear();
                txtcontrasena.Clear();
                txtusuario.Focus();
            }
            conexion.Close();
        }
    }
}
