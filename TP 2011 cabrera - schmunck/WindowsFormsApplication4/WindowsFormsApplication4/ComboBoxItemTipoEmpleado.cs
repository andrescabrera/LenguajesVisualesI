using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlAsistencia
{
    public class ComboBoxItemTipo
    {
        public Type Tipo { get; set; }

        public override string ToString()
        {
            return Tipo.Name;
        }
        
    }
}
