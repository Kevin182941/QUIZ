using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Quiz.BL;
using Quiz.DAL;

namespace Quiz.UI
{
    public partial class Quiz : Form
    {
        public Quiz()
        {
            InitializeComponent();
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            CargaPersona();
        }

        #region Persona
        //El metodo ejecuta el Obtener persona y los carga en un DataGridView 
        public void CargaPersona()
        {
            List<Datos_Persona> lstresultado = Logica.ObtenerPersonas();
            dgvPersonas.AutoGenerateColumns = false;
            
            dgvPersonas.DataSource = lstresultado;
            dgvPersonas.Refresh();
        }
        //Limpia los textbox de Persona
        public void LimpiarPersona()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
        }
        //El botón se encarga de insertar a la persona digitada
        private void btnInsertarP_Click_1(object sender, EventArgs e)
        {
            try
            {

                var error = Logica.AgregarPersona(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtTelefono.Text));
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error, $"Error al insertar la persona {txtNombre.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Exito al insertar la persona {txtNombre.Text}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarPersona();
                    CargaPersona();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"Error al insertar la persona {txtNombre.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //El botón se encarga de actualizar la persona digitada
        private void btnActualizarP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show($"No se puede actualizar la persona porque el dato ID esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    var error = Logica.ActualizaPersona(Convert.ToInt32(txtID.Text), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtTelefono.Text));
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, $"Error al actualizar la persona {txtNombre.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Exito al actualizar la persona {txtNombre.Text}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarPersona();
                        CargaPersona();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"Error al actualizar la persona {txtNombre.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //El botón se encarga de eliminar  la persona digitada
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show($"No se puede eliminar la persona porque el dato ID esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    var error = Logica.EliminarPersona(Convert.ToInt32(txtID.Text));
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, $"Error al eliminar la persona {txtNombre.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Exito al eliminar la persona {txtNombre.Text}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarPersona();
                        CargaPersona();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"Error al eliminar la persona {txtNombre.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //El envento seleccionado,sirve para traer los datos del Grid y ponerlos en los textbox
        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvPersonas.Rows[e.RowIndex].Cells[0].ToString()))
            {
                this.txtID.Text = dgvPersonas.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else
            {
                txtID.Text = "";
            }

            if (!string.IsNullOrEmpty(dgvPersonas.Rows[e.RowIndex].Cells[1].ToString()))
            {
                this.txtNombre.Text = dgvPersonas.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else
            {
                txtNombre.Text = "";
            }

            if (!string.IsNullOrEmpty(dgvPersonas.Rows[e.RowIndex].Cells[2].Value.ToString()))
            {
                this.txtApellido.Text = dgvPersonas.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            else
            {
                txtApellido.Text = "";
            }
            if (!string.IsNullOrEmpty(dgvPersonas.Rows[e.RowIndex].Cells[3].Value.ToString()))
            {
                this.txtTelefono.Text = dgvPersonas.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {
                txtTelefono.Text = "";
            }
            CargaDirecciones(Convert.ToInt32(txtID.Text));
        }
        //El botón se encarga de limpiar los campos textbox con la clase
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarPersona();

        }
        //El evento seleccionado sirve para que el campo telefono solo se digite numeros y no letras
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Direccion
        //El metodo ejecuta el Obtener direccion y los carga en un DataGridView 
        public void CargaDirecciones(int p_id)
        {
            List<Direccion> lstresultado = Logica.ObtenerDirecciones(id_persona: p_id);
            dvgDirecciones.AutoGenerateColumns = false;

            dvgDirecciones.DataSource = lstresultado;
            dvgDirecciones.Refresh();
        }
        //Limpia los textbox de direcciones 
        public void LimpiarDirecciones()
        {
            txtIDirecion.Text = "";
            txtIPersona.Text = "";
            txtPais.Text = "";
            txtProvincia.Text = "";
            txtCanton.Text = "";
            txtDistrito.Text = "";
            txtDetalle.Text = "";
        }
        //El botón se encarga de insertar la dirección digitada
        private void btnInsertarD_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDirecion.Text))
                {
                    MessageBox.Show($"No se puede insertar la Direccion porque el dato ID esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    var error = Logica.AgregarDireccion(Convert.ToInt32(txtIDirecion.Text), Convert.ToInt32(txtIPersona.Text), txtPais.Text,
                                                                    txtProvincia.Text, txtCanton.Text, txtDistrito.Text, txtDetalle.Text);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, $"Error al insertar la Dirección {txtIDirecion.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Exito al insertar la Dirección {txtIDirecion.Text}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaDirecciones(Convert.ToInt32(txtID.Text));
                        LimpiarDirecciones();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"Error al insertar la Dirección {txtIDirecion.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //El botón se encarga de actualizar la dirección digitada
        private void btnActualizarD_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDirecion.Text))
                {
                    MessageBox.Show($"No se puede actualizar la Direccion porque el dato ID esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    var error = Logica.ActualizaDirecciones(Convert.ToInt32(txtIDirecion.Text), Convert.ToInt32(txtIPersona.Text), txtPais.Text,
                                                                        txtProvincia.Text, txtCanton.Text, txtDistrito.Text, txtDetalle.Text);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, $"Error al actualizar la Dirección {txtIDirecion.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Exito al insertar la Dirección {txtIDirecion.Text}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaDirecciones(Convert.ToInt32(txtID.Text));
                        LimpiarDirecciones();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"Error al actualizar la Dirección {txtIDirecion.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //El botón se encarga de eliminar  la dirección digitada
        private void btnEliminarD_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIDirecion.Text))
                {
                    MessageBox.Show($"No se puede eliminar la Direccion porque el dato ID esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    var error = Logica.EliminarDireccion(Convert.ToInt32(txtIDirecion.Text), Convert.ToInt32(txtIPersona.Text));
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, $"Error al eliminar la Dirección {txtIDirecion.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Exito al eliminar la Dirección {txtIDirecion.Text}", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargaDirecciones(Convert.ToInt32(txtID.Text));
                        LimpiarDirecciones();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), $"Error al eliminar la Dirección {txtIDirecion.Text}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //El envento seleccionado,sirve para traer los datos del Grid y ponerlos en los textbox
        private void dvgDirecciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrEmpty(dvgDirecciones.Rows[e.RowIndex].Cells[0].ToString()))
            {
                this.txtIDirecion.Text = dvgDirecciones.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else
            {
                txtIDirecion.Text = "";
            }
            if (!string.IsNullOrEmpty(dvgDirecciones.Rows[e.RowIndex].Cells[1].ToString()))
            {
            this.txtIPersona.Text = dvgDirecciones.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else
            {
                txtIPersona.Text = "";
            }
            if (!string.IsNullOrEmpty(dvgDirecciones.Rows[e.RowIndex].Cells[2].ToString()))
            {        
            this.txtPais.Text = dvgDirecciones.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            else
            {
                txtPais.Text = "";
            }
            if (!string.IsNullOrEmpty(dvgDirecciones.Rows[e.RowIndex].Cells[3].ToString()))
            {
            this.txtProvincia.Text = dvgDirecciones.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else
            {
                txtProvincia.Text = "";
            }
            if (!string.IsNullOrEmpty(dvgDirecciones.Rows[e.RowIndex].Cells[4].ToString()))
            {
            this.txtCanton.Text = dvgDirecciones.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            else
            {
                txtCanton.Text = "";
            }
            if (!string.IsNullOrEmpty(dvgDirecciones.Rows[e.RowIndex].Cells[5].ToString()))
            {
            this.txtDistrito.Text = dvgDirecciones.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            else
            {
                txtDistrito.Text = "";
            }
            if (!string.IsNullOrEmpty(dvgDirecciones.Rows[e.RowIndex].Cells[6].ToString()))
            {
            this.txtDetalle.Text = dvgDirecciones.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            else
            {
                txtDetalle.Text = "";
            }

        }
        //El botón se encarga de limpiar los campos textbox con la clase
        private void btnLimpiarD_Click(object sender, EventArgs e)
        {
            LimpiarDirecciones();
        }
        #endregion

    }
}
