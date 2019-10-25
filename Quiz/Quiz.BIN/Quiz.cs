using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quiz.BL;

namespace Quiz.BIN
{
    public partial class Quiz : Form
    {
      

        public Quiz()
        {
            InitializeComponent();
        }
        
        private void btnInsertarP_Click(object sender, EventArgs e)
        {

            try
            {
                Logica persona = new Logica();
                persona.codigo = int.Parse(this.txtID.Text);
                persona.nombres = this.txtNombre.Text;
                persona.apellidos = this.txtApellido.Text;
                persona.telefono = this.txtTelefono.Text;
                Logica.AgregarPersona(persona);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Quiz_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtPais_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
