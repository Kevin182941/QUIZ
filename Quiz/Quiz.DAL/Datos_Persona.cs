using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Quiz.DAL
{
    public class Datos_Persona
    {
        //Se esta realizando una llave Primaria que seria ID 
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Telefono { get; set; }

        //La posicion de las dos entidades va ser 1 a muchos, en la tabla Datos_Persona le estamos declarando que va,
        // tener muchas direcciones.
        public virtual ICollection<Direccion> Direcciones { get; set; }
    }
}
