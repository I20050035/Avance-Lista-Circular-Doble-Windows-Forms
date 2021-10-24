using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace LDobleCircular
{
    public partial class Form1 : Form
    {
        Lista Lista;
        public Form1()
        {
            InitializeComponent();
            Lista = new Lista();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                int d = int.Parse(txtDato.Text);
                string nombre = txtNombre.Text;
                Nodo n = new Nodo(d, nombre);
                Lista.agregarNodo(n);
                txtDato.Clear();
                txtNombre.Clear();
                txtDato.Focus();
                Lista.Mostrar(DCLista);
                Lista.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtDato.Text);
                Lista.eliminarNodo(d);
                txtDato.Clear();
                Lista.Mostrar(DCLista);
                Lista.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }  

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtDato.Text);
                Nodo b = new Nodo();
                if (Lista.Buscar(d, ref b))
                {
                    txtNombre.Text = b.nombre;
                }
                else
                {
                    txtNombre.Clear();
                    MessageBox.Show("NO Existe ");
                }
                txtDato.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Lista.Cargar();
            Lista.Mostrar(DCLista);
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtDato.Text);
                Lista.Modificar(d, txtNombre.Text);
                txtDato.Clear();
                txtNombre.Clear();
                txtDato.Focus();
                Lista.Mostrar(DCLista);
                Lista.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        } 
    }
}
