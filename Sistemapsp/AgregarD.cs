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
using System.Data.SqlClient;

namespace Sistemapsp
{
    public partial class AgregarD : Form
    {
        public AgregarD()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-PHJVBF4\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True");

       

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Principal principal = new Principal();
            principal.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Principal principal = new Principal();
            principal.Show();
        }

        private void Estado_Load(object sender, EventArgs e)
        {

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Horarios horarios = new Horarios();
            horarios.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cursos  curso = new Cursos();
            curso.Show();
        }
    }
}