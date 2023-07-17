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
    public partial class Cursos : Form
    {
        ahorarios Ahorarios;
        public Cursos()
        {
            InitializeComponent();
            Ahorarios = new ahorarios();
        }
        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-ULGE4070\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True");


        public void llenar_tabla()
        {
            string consulta = "Select no_c[Nº], tipo_curso[Tipo],nombre[Nombre],estado_curso[Estado],categoria[Categoria] from cursos";
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

        private void Cursos_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT no_c[Nº],tipo_curso[Tipo],nombre[Nombre], estado_curso[Estado], categoria[Categoria], cod_h[Día] from cursos";

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            String Query = "Insert into cursos (tipo_curso,nombre,categoria,estado_curso, cod_h) VALUES (@tipo_curso,@nombre,@categoria,@estado_curso, @cod_h)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(Query, conexion);
            comando.Parameters.AddWithValue("@tipo_curso", cbbtipo.Text);
            comando.Parameters.AddWithValue("@nombre", txtnombre.Text);
            comando.Parameters.AddWithValue("@categoria", cbbcategoria.Text);
            comando.Parameters.AddWithValue("@estado_curso", txtestado.Text);
            comando.Parameters.AddWithValue("@cod_h", txtcod1.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Datos Guardados");
            conexion.Close();
            llenar_tabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            conexion.Open(); 
            if (MessageBox.Show("¿Desea eliminar el registro?" , "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)==DialogResult.Yes)
            {
                string consultaeliminar = "delete from cursos where no_c= " + txtno.Text + "";
                SqlCommand c = new SqlCommand(consultaeliminar, conexion);
                c.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado");
                llenar_tabla();
                conexion.Close() ;
            }
            else
            {
                conexion.Close();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            conexion.Open();
            String consultamodificar = "update cursos set nombre='" + txtnombre.Text + "',estado_curso='" + txtestado.Text + "',categoria = '" + cbbcategoria.Text + "', tipo_curso = '" + cbbtipo.Text + "'  where no_c = " + txtno.Text + " ";
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

        private void button6_Click(object sender, EventArgs e)
        {
           Limpiar limpiar = new Limpiar();
            limpiar.borrarcampos(this);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbbcategoria.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtestado.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbbtipo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtcod1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void txtno_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string horario = txtcod1.Text;
            buscarhorario hora = new buscarhorario();
            hora.ShowDialog();

        }
    }
}
