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
    public partial class Matricular : Form
    {
        
     
        public Matricular()
        {
              

            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-ULGE4070\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True");
        public void llenar_tabla()
        {
            string consulta = "SELECT fecha_inicio[Fecha_Inicio], fecha_final[Fecha_Final], cantidad_e[Cantidad de Encuentros], duracion[Cantidad de Horas], lugar[Lugar], hombres[Hombres], mujeres[Mujeres],hombres + mujeres[Total],no_c[Nº curso] from matricula";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dtgmatricula.DataSource = dt;
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
            Principal principal = new Principal();
            principal.Show();
        }

        private void cbbtipo_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void Matricular_Load(object sender, EventArgs e)
        {

            string consulta = "SELECT no_c [Nº curso],cod_cp[Código], fecha_inicio[Fecha_Inicio],fecha_final[Fecha_Final],cantidad_e[Cantidad de Encuentros],duracion[Cantidad de Horas], lugar[Lugar],hombres[Hombres],mujeres[Mujeres],hombres + mujeres[Total] from matricula";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dtgmatricula.DataSource = dt;
        }

        private void cbxdia_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbnombre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txthoraini_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
     
            String Query = "Insert into matricula (fecha_inicio,fecha_final,cantidad_e,duracion, lugar,hombres,mujeres,no_c) VALUES (@fecha_inicio,@fecha_final,@cantidad_e, @duracion,@lugar,@hombres,@mujeres,@no_c)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(Query, conexion);
            comando.Parameters.AddWithValue("@fecha_inicio",dtpfechainicio.Text);
            comando.Parameters.AddWithValue("@fecha_final",dtpfechafinal.Text);
            comando.Parameters.AddWithValue("@cantidad_e", txtencuentros.Text);
            comando.Parameters.AddWithValue("@duracion", txtcantidadhora.Text);
            comando.Parameters.AddWithValue("@lugar", txtlugar.Text);
            comando.Parameters.AddWithValue("@hombres", txthombres.Text);
            comando.Parameters.AddWithValue("@mujeres", txtcantmujeres.Text);
            comando.Parameters.AddWithValue("@no_c", txtcurso.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Datos Guardados");
            conexion.Close();
            llenar_tabla();
        }

        private void btnbuscarc_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string curso = txtcurso.Text;
            buscarcurso c = new buscarcurso();
            c.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conexion.Open();
            if (MessageBox.Show("¿Desea eliminar el registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                string consultaeliminar = "delete from matricula where cod_cp= " + txtcodigom.Text + "";
                SqlCommand c = new SqlCommand(consultaeliminar, conexion);
                c.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado");
                llenar_tabla();
                conexion.Close();
            }
            else
            {
                conexion.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conexion.Open();
            String consultamodificar = "update matricula set fecha_inicio ='" + dtpfechainicio.Text + "',fecha_final='" + dtpfechafinal.Text + "',cantidad_e = '" + txtencuentros.Text + "', duracion = '" + txtcantidadhora.Text + "' , lugar = '" + txtlugar + "', hombres = '"+txthombres+"' , mujeres ='"+txtcantmujeres.Text+"' where cod_cp = '" + txtcodigom.Text+"' " ;
            SqlCommand co = new SqlCommand(consultamodificar, conexion);
            int can;
            can = co.ExecuteNonQuery();
            if (can > 0)
            {
                MessageBox.Show("Registro modificado");
            }
            conexion.Close();
            llenar_tabla();
        }

        private void dtgmatricula_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcurso.Text = dtgmatricula.CurrentRow.Cells[0].Value.ToString();
            txtcodigom.Text = dtgmatricula.CurrentRow.Cells[1].Value.ToString();
            dtpfechainicio.Text = dtgmatricula.CurrentRow.Cells[2].Value.ToString();
            dtpfechafinal.Text = dtgmatricula.CurrentRow.Cells[3].Value.ToString();
            txtencuentros.Text = dtgmatricula.CurrentRow.Cells[4].Value.ToString();
            txtcantidadhora.Text = dtgmatricula.CurrentRow.Cells[5].Value.ToString();
            txtlugar.Text = dtgmatricula.CurrentRow.Cells[6].Value.ToString();
            txthombres.Text = dtgmatricula.CurrentRow.Cells[7].Value.ToString();
             txtcantmujeres.Text = dtgmatricula.CurrentRow.Cells[8].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Limpiar limpiar = new Limpiar();
            limpiar.borrarcampos(this);
        }
    }
}
