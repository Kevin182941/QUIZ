using Quiz.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {

            var error = Logica.EliminarPersona(2);
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Adding new students");
            }
            else
                {
                Console.WriteLine("Error new students");
            }
        }
    }
}
