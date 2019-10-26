using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.DAL;

namespace Quiz.BL
{
    public class Logica
    {
      
        //Metodo para insertar Personas
        public static string AgregarPersona(string nombre, string apellido, int telefono)
        {
            using (DBContextCF context = new DBContextCF())
                try
                {

                    var persona = new Datos_Persona();
                    //persona.ID = id;
                    persona.Nombre = nombre;
                    persona.Apellido = apellido;
                    persona.Telefono = telefono;
                    context.Personas.Add(persona);
                    context.SaveChanges();
                    return "";

                }
                catch (Exception exp)
                {

                    return ("Error Insertar Persona: " + exp.Message);

                }

        }

        //Metodo para insertar Direcciones
        public static string AgregarDireccion(int iddireccion, int idpersona, string pais, string provincia,
                                              string canton, string distrito, string detalle)
        {
            using (DBContextCF context = new DBContextCF())
                try
                {

                    var direccion = new Direccion();
                    direccion.ID = iddireccion;
                    direccion.IDPersona = idpersona;
                    direccion.Pais = pais;
                    direccion.Provincia = provincia;
                    direccion.Canton = canton;
                    direccion.Distrito = distrito;
                    direccion.Detalle = detalle;
                    context.Direcciones.Add(direccion);
                    context.SaveChanges();
                    return "";

                }
                catch (Exception exp)
                {

                    return ("Error Insertar Direccion: " + exp.Message);

                }

        }

        //Metodo para Actualizar Personas
        public static string ActualizaPersona(int id, string nombre, string apellido, int telefono)
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
                    return "";
                }
                catch (Exception exp)
                {

                    return ("Error Actualizar Persona: " + exp.Message);
                }
        }

        //Metodo para Actualizar Direciones
        public static string ActualizaDirecciones(int id, int idpersona, string pais, string provincia, string canton, string distrito, string detalle)
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
                    return "";
                }
                catch (Exception exp)
                {

                    return ("Error Actualizar Direccion: " + exp.Message);
                }
        }

        //Metodo para eliminar Personas
        public static string EliminarPersona(int idremove)
        {
            using (DBContextCF context = new DBContextCF())
                try
                {
                    var persona = context.Personas.Where(x => x.ID == idremove).SingleOrDefault();
                    context.Personas.Remove(persona);
                    context.SaveChanges();
                    return "";
                }
                catch (Exception exp)
                {

                    return ("Error Eliminar Persona: " + exp.Message);
                }
        }

        //Metodo para eliminar Direcciones
        public static string EliminarDireccion(int idremovedir, int idremoveper)
        {
            using (DBContextCF context = new DBContextCF())
                try
                {
                    var direc = context.Direcciones.Where(x => x.ID == idremovedir && x.IDPersona == idremoveper).SingleOrDefault();
                    context.Direcciones.Remove(direc);
                    context.SaveChanges();
                    return "";
                }
                catch (Exception exp)
                {

                    return ("Error Eliminar Direccion: " + exp.Message);
                }
        }

        public static List<Datos_Persona> ObtenerPersonas()
        {
            DBContextCF contextCF = null;
            //using (DBContextCF contextCF = new DBContextCF()) ;
            List<Datos_Persona> lstresultados = new List<Datos_Persona>();

            try
            {
                contextCF = new DBContextCF();
                var consulta = (from per in contextCF.Personas
                                select new { per.ID, per.Nombre, per.Apellido, per.Telefono }).ToList();

                if (consulta != null)
                {
                    foreach (var item in consulta)
                    {
                        Datos_Persona u = new Datos_Persona();
                        u.ID = item.ID;
                        u.Nombre = item.Nombre;
                        u.Apellido = item.Apellido;
                        u.Telefono = item.Telefono;

                        lstresultados.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contextCF != null) contextCF.Dispose();
            }

            return lstresultados;

        }

        public static List<Direccion> ObtenerDirecciones(int id_persona)
        {
            DBContextCF contextCF = null;
            //using (DBContextCF contextCF = new DBContextCF()) ;
            List<Direccion> lstresultados = new List<Direccion>();

            try
            {
                contextCF = new DBContextCF();
                var consulta = (from per in contextCF.Direcciones
                                where (per.IDPersona == id_persona)
                                select new { per.ID, per.IDPersona, per.Pais, per.Provincia, per.Canton, per.Distrito, per.Detalle }).ToList();

                if (consulta != null)
                {
                    foreach (var item in consulta)
                    {
                        Direccion u = new Direccion();
                        u.ID = item.ID;
                        u.IDPersona = item.IDPersona;
                        u.Pais = item.Pais;
                        u.Provincia = item.Provincia;
                        u.Canton = item.Canton;
                        u.Distrito = item.Distrito;
                        u.Detalle = item.Detalle;



                        lstresultados.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (contextCF != null) contextCF.Dispose();
            }

            return lstresultados;

        }

    }

    

}
