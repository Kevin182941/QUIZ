using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DAL
{
    public class DBContextCF : DbContext
    {
        //Se realiza la conexion al entidad (Base de datos )
        public DBContextCF()
            //El nombre CFQuiz es el nombre que uno configura en el App.config
            : base("name=CFQuiz")
        {

        }
        //Referencia a las tablas que se van a crear 
        public  DbSet<Datos_Persona> Personas { get; set; }

        public  DbSet<Direccion> Direcciones { get; set; }

    }
}
