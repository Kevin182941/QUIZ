using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.DAL;

namespace Quiz.BL
{
    public class Logica : DBContextCF
    {
        private Datos_Persona DatoPersona = new Datos_Persona(); 

        private Direccion DatoDireccion  = new Direccion();

        //Metodo para insertar Personas
        public void AgregarPersona(Datos_Persona persona)
        {
            using (DBContextCF context = new DBContextCF())
                try
                {

                    context.Personas.Add(persona);
                    context.SaveChanges();

                }
                catch (Exception exp)
                {

                    var p_error = ("Error Insertar Persona: " + exp.Message);
                    
                }
            
        }

        //Metodo para insertar Direcciones
        public static void AgregarDireccion(Direccion direccion)
        {
            using (DBContextCF context = new DBContextCF())
                try
                {
                    
                    context.Direcciones.Add(direccion);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {

                    Console.WriteLine("Error Insertar Direccion: " + exp.Message);
                }
            
        }

        //Metodo para Actualizar Personas
        public static void ActualizaPersona(int id,string nombre,string apellido,int telefono )
        {
            using (DBContextCF context = new DBContextCF())
                try
                {
                    var persona = context.Personas.Where(x => x.ID == id).SingleOrDefault();
                    persona.ID = id;
                    persona.Nombre = nombre;
                    persona.Apellido = apellido;
                    persona.Telefono = telefono;
                    context.SaveChanges();
                }
                catch (Exception exp)
                {

                    Console.WriteLine("Error Actualizar Persona: " + exp.Message);
                }
        }

        //Metodo para Actualizar Direciones
        public static void ActualizaDirecciones(int id,int idpersona, string pais, string provincia, string canton,string distrito,string detalle)
        {
            using (DBContextCF context = new DBContextCF())
                try
                {
                    var direcciones = context.Direcciones.Where(x => x.ID == id && x.IDPersona == idpersona).SingleOrDefault();
                    direcciones.ID = id;
                    direcciones.IDPersona = idpersona;
                    direcciones.Pais = pais;
                    direcciones.Provincia = provincia;
                    direcciones.Canton = canton;
                    direcciones.Distrito = distrito;
                    direcciones.Detalle = detalle;
                    context.SaveChanges();
                }
                catch (Exception exp)
                {

                    Console.WriteLine("Error Actualizar Direccion: " + exp.Message);
                }
        }
       
        //Metodo para eliminar Personas
        public static void EliminarPersona(int idremove)
        {
            using (DBContextCF context = new DBContextCF())
                try
                {
                    var persona = context.Personas.Where(x => x.ID == idremove).SingleOrDefault();
                    context.Personas.Remove(persona);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {

                    Console.WriteLine("Error Eliminar Persona: " + exp.Message);
                }
        }
        
        //Metodo para eliminar Direcciones
        public static void EliminarDireccion(int idremovedir,int idremoveper)
        {
            using (DBContextCF context = new DBContextCF())
                try
                {
                    var direc = context.Direcciones.Where(x => x.ID == idremovedir && x.IDPersona ==idremoveper).SingleOrDefault();
                    context.Direcciones.Remove(direc);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {

                    Console.WriteLine("Error Eliminar Direccion: " + exp.Message);
                }
        }
    }
}
