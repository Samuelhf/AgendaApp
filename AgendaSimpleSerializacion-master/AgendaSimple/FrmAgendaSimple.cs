using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace AgendaSimple
{
    public partial class FrmAgendaSimple : Form
    {

        private readonly ServicioPersona _servicio;
        public int index;
        public FrmAgendaSimple()
        {
            InitializeComponent();
            _servicio = new ServicioPersona();
            index = -1;
        }

        #region "Eventos"

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (index < 0)
            {
                AddPersona();
            }
            else
            {
                EditPersona();
            }
            
        }

        private void FrmAgendaSimple_Load(object sender, EventArgs e)
        {
            LoadPersona();
        }

        private void DgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                BtnDeseleccionar.Visible = true;

                Persona personaEditar = new Persona();

                personaEditar = _servicio.GetItem(index);

                TxtNombre.Text = personaEditar.Nombre;
                TxtApellido.Text = personaEditar.Apellido;
                TxtDireccion.Text = personaEditar.Direccion;
                TxtTelefono.Text = personaEditar.Telefono;
                TxtTelfonoT.Text = personaEditar.TelefonoT;

            }
        }

        private void BtnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deselect();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            EliminarPersona();
        }

        private void cerrarSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           MessageBox.Show("hice click en cerrar session");
            Login log = new Login();
            log.Show();
            this.Close();

        }


        #endregion

        #region "Metodos privados"

        private void LoadPersona()
        {
           BindingSource dataSource = new BindingSource();

           dataSource.DataSource = _servicio.GetList();

           DgvPersonas.DataSource = dataSource;

           DgvPersonas.ClearSelection();

        }

        private void AddPersona()
        {
            Persona persona = new Persona();
            persona.Nombre = TxtNombre.Text;
            persona.Apellido = TxtApellido.Text;
            persona.Direccion = TxtDireccion.Text;
            persona.Telefono = TxtTelefono.Text;
            persona.TelefonoT = TxtTelfonoT.Text;

            _servicio.Add(persona);

            MessageBox.Show("Se ha guardado con exito","Notificacion");
            ClearData();
            LoadPersona();
        }

        private void EditPersona()
        {
            Persona persona = new Persona();
            persona.Nombre = TxtNombre.Text;
            persona.Apellido = TxtApellido.Text;
            persona.Direccion = TxtDireccion.Text;
            persona.Telefono = TxtTelefono.Text;
            persona.TelefonoT = TxtTelfonoT.Text;

            _servicio.Edit(index,persona);

            MessageBox.Show("Se ha guardado con exito", "Notificacion");
            ClearData();
            Deselect();
            LoadPersona();
        }

        private void Deselect()
        {
            DgvPersonas.ClearSelection();
            index = -1;
            BtnDeseleccionar.Visible = false;
        }

        private void ClearData()
        {
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtDireccion.Clear();
            TxtTelefono.Clear();
            TxtTelfonoT.Clear();
        }

        private void EliminarPersona()
        {

            if (index < 0)
            {
                MessageBox.Show("Debe seleccionar una persona", "Notificacion");
            }
            else
            {

                DialogResult respuesta = MessageBox.Show("Esta seguro que desea eliminar este contacto", "Advertencia",
                    MessageBoxButtons.OKCancel);

                if (respuesta == DialogResult.OK)
                {
                    _servicio.Delete(index);
                    LoadPersona();
                    Deselect();
                }

            }
          
        }







        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
