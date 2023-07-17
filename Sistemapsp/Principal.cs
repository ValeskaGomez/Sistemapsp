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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-PHJVBF4\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True");


        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            this.Hide();
            Historial Historial = new Historial();
            Historial.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgregarD frmagregardatos = new AgregarD();
            frmagregardatos.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Matricular frmagregardatos = new Matricular();
            frmagregardatos.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void horarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Horarios horarios = new Horarios();
            horarios.Show();
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cursos frmagregardatos = new Cursos();
            frmagregardatos.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Principal = new Login();
            Principal.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro(a) que desea salir de la aplicación?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
