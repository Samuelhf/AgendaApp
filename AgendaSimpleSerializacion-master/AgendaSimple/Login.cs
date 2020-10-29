using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaSimple
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

 
        private void Txtcontraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            
            if (Txtusuario.Text == "Samuel" && Txtcontraseña.Text == "hola")
            {
                this.DialogResult = DialogResult.OK;
                FrmAgendaSimple agen = new FrmAgendaSimple();
                agen.Show();
                this.Close();

            }
            if(Txtusuario.Text == "Juan" && Txtcontraseña.Text == "hola")
            {
                this.DialogResult = DialogResult.OK;
                FrmAgendaSimple agen = new FrmAgendaSimple();
                agen.Show();
                this.Close();
            }
            else
            {
                LabelError.Visible = true;
                this.DialogResult = DialogResult.None;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro re = new Registro();
            re.Show();

        }
    
    }
}
