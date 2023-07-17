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

namespace Sistemapsp
{
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-ULGE4070\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal principal = new Principal();
            principal.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal principal = new Principal();
            principal.Show();
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            string consulta = "select C.no_c[Nº],C.tipo_curso[Tipo],C.nombre[Nombre],C.categoria[Categoria], H.dia[Dìa],M.lugar[Lugar],M.cantidad_e[Cantidad de Encuentros],C.estado_curso[Estado],M.duracion[Cantidad de Horas],h.hora_inicio[Hora Inicio],h.hora_fin[Hora Final],M.fecha_inicio[Fecha Inicio],M.fecha_final[Fecha Final],M.hombres[Cantidad de Hombres],M.mujeres[Cantidad de Mujeres],M.hombres+M.mujeres[Total] from cursos C INNER JOIN horarios H ON C.cod_h = H.cod_h INNER JOIN matricula M ON C.no_c = M.no_c";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
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
    }
}
