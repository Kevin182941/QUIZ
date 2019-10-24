using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DAL
{
    public class Direccion
    {
        //con los primeros campos se esta realizando una llave compuesta que seria ID y IDPersona
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int IDPersona { get; set; }

        public string Pais { get; set; }

        public string Provincia { get; set; }

        public string Canton { get; set; }

        public string Distrito { get; set; }

        public string Detalle { get; set; }

        //Se esta identificando cual va ser la llave Foranea y cual va ser la tabla que va tener referencia.
        //La posicion de las dos entidades va ser 1 a muchos, en la tabla direccion le estamos declarando que solo,
        //puede tener una persona
        [ForeignKey("IDPersona")]
        public virtual Datos_Persona Persona { get; set; }


    }
}
