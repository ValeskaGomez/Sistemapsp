using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistemapsp
{
    public class Limpiar
    {
        public void borrarcampos(Control controls) 
        {
            foreach (var txt  in controls.Controls) 
            { 
               if (txt is TextBox)
               {
                   ((TextBox)txt).Clear();  
               }
               else if (txt is ComboBox) 
               {
                    ((ComboBox)txt).SelectedItem = 0;
               }
            }
        }
    }
}
