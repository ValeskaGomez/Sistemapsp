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
    public partial class Horarios : Form
    {
        public object Conexion { get; private set; }

        public Horarios()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-ULGE4070\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True");

        public void llenar_tabla()
        {
            string consulta = "SELECT cod_h[Código], dia[Día], hora_inicio[Hora_Inicio], hora_fin[Hora_Final] from horarios";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal Principal = new Principal();
            Principal.Show();
        }

        private void Horarios_Load(object sender, EventArgs e)
        {
            string consulta = "select cod_h[Código], dia[Dia],hora_inicio[Hora Inicio], hora_fin[Hora Final] from horarios";

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String Query = "Insert into horarios (dia,hora_inicio,hora_fin) VALUES (@dia,@hora_inicio,@hora_fin)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(Query, conexion);
            comando.Parameters.AddWithValue("@dia", cbbdia.Text);
            comando.Parameters.AddWithValue("@hora_inicio", cbbhorainicio.Text);
            comando.Parameters.AddWithValue("@hora_fin", cbbhorafin.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Datos Guardados");
            conexion.Close();
            llenar_tabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Open();
            String consultaeliminar = " delete from horarios where cod_h= " + txtcodigo.Text + "";
            SqlCommand c = new SqlCommand(consultaeliminar, conexion);
            c.ExecuteNonQuery();
            MessageBox.Show("Registro eliminado");
            conexion.Close();
            llenar_tabla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conexion.Open();
            String consultamodificar = "update horarios set dia='" + cbbdia.Text + "',hora_inicio='" + cbbhorainicio.Text + "',hora_fin = '" + cbbhorafin.Text + "' where cod_h = " + txtcodigo.Text + " ";
            SqlCommand co = new SqlCommand(consultamodificar, conexion);
            int cant;
            cant = co.ExecuteNonQuery();
            if (cant > 0)
            {
                MessageBox.Show("Registro modificado");
            }
            conexion.Close();
            llenar_tabla();

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

        private void button6_Click(object sender, EventArgs e)
        {
            Limpiar limpiar = new Limpiar();
            limpiar.borrarcampos(this);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cbbdia.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbbhorainicio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbbhorafin.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
