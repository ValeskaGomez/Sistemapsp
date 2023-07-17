using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sistemapsp
{
    public class ahorarios
    {
        public DataTable leerhorario()
        {
            {
                SqlDataAdapter adaptador = new SqlDataAdapter();
                DataTable dthorarios = new DataTable();
                using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-PHJVBF4\\SQLEXPRESS;Initial Catalog=Estadisticapsp;Integrated Security=True"))

                    try
                    {
                        string query = "select * from horarios;";
                        SqlCommand cd = new SqlCommand(query, conexion);
                        cd.CommandType = CommandType.Text;

                        conexion.Open();
                        adaptador = new SqlDataAdapter();
                        adaptador.SelectCommand = cd;
                        dthorarios = new DataTable();
                        adaptador.Fill(dthorarios);

                        conexion.Close();
                        return dthorarios;


                    }
                    catch (Exception)
                    {
                        dthorarios = new DataTable();
                        return null;

                    }


            }


        }

    }
}
