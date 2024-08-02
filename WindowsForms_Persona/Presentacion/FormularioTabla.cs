using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms_Persona.Models;

namespace WindowsForms_Persona.Presentacion
{
    public partial class FormularioTabla : Form
    {
        public int? id;
        Persona oPersona = null;
        public FormularioTabla(int? id=null)
        {
            InitializeComponent();
            this.id = id;
            if(id != null)
            {
                CargaDatos();
            }
        }

        private void CargaDatos()
        {
            using (EntitiesWFPersona db = new EntitiesWFPersona())
            {
                oPersona = db.Persona.Find(id);
                txtNombre.Text = oPersona.nombre;
                txtCorreo.Text = oPersona.correo;
                txtFecha.Text = oPersona.fecha;
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using(EntitiesWFPersona db = new EntitiesWFPersona())
            {
                if (id==null)
                oPersona = new Persona();
                oPersona.nombre = txtNombre.Text;
                oPersona.correo = txtFecha.Text;
                oPersona.fecha = txtFecha.Text;
                if (id == null)
                    db.Persona.Add(oPersona);
                else
                {
                    db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
