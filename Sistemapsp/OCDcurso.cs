using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Sistemapsp
{
    public class OCDcurso
    {
        public DataTable leercurso() {
            {
                SqlDataAdapter adaptador = new SqlDataAdapter();    
                DataTable dtcursos = new DataTable();
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-PHJVBF4\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True"))

                    try
                    {
                        string query = "select * from cursos;";
                        SqlCommand cd = new SqlCommand(query, conexion);
                        cd.CommandType = CommandType.Text;

                        conexion.Open();
                        adaptador = new SqlDataAdapter();
                        adaptador.SelectCommand = cd;
                        dtcursos = new DataTable();
                        adaptador.Fill(dtcursos);

                        conexion.Close();
                        return dtcursos;


                    }
                    catch (Exception ) 
                    {
                        dtcursos = new DataTable();
                        return null;
                    
                    }


            }
        }
    }
}
