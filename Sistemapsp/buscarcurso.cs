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
    public partial class buscarcurso : Form
    {
        public buscarcurso()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-ULGE4070\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True");

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcurso2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void buscarcurso_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT no_c[Nº],tipo_curso[Tipo],nombre[Nombre], estado_curso[Estado], categoria[Categoria], cod_h[Día] from cursos";

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Matricular m = new Matricular();
            m.txtcurso.Text = txtcurso2.Text;
            m.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal principal = new Principal();
            principal.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            AgregarD agregarD = new AgregarD();
            agregarD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Close();
            Cursos c = new Cursos();
            c.Show();
        }
    }
}
