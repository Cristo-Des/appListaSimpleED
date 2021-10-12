using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appListaSimpleED
{
    public partial class Form1 : Form
    {
        Listas miLista;
        Graphics graficos;
        public Form1()
        {
            InitializeComponent();
            miLista = new Listas();
            this.WindowState = FormWindowState.Maximized;
            graficos = this.CreateGraphics();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                string nombre = txtNombre.Text;
                string telefono = txtTelefono.Text;
                Nodo n = new Nodo(numero, nombre, telefono);
                miLista.Agregar(n);
                txtNumero.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstDatos);
                // MessageBox.Show(miLista + " ");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message); ;
            }
            for (int i = 0; i < lstDatos.Items.Count; i++)
            {
                DibujarRectangulo(i);
            }
            
           
        }
        public void DibujarRectangulo(int x)
        {
           
            Pen pluma = new Pen(Color.Black, 2);
            Rectangle rectangulo = new Rectangle(10 + (x * 120), 400, 100, 50);
            graficos.DrawRectangle(pluma, rectangulo);
            graficos.DrawLine(pluma, 80 + (x * 120), 400, 80 + (x * 120), 450);
            graficos.DrawLine(pluma, 95 + (x * 120), 425, 130 + (x * 120), 425);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                miLista.Eliminar(numero);
                txtNumero.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstDatos);
                // MessageBox.Show(miLista + " ");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error "+ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int numero = int.Parse(txtNumero.Text);
            Nodo b = new Nodo();
            if (miLista.Buscar(numero,ref b))
            {
                txtNombre.Text = b.Nombre;
                txtTelefono.Text = b.Telefono;
               // MessageBox.Show("Existe");
            } 
            else
            {
                txtNombre.Clear();
                txtTelefono.Clear();
                MessageBox.Show("No Existe");
            }
           
            txtNumero.Focus();
            //MessageBox.Show(miLista + " ");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtNumero.Text);
                miLista.Modificar(numero,txtNombre.Text, txtTelefono.Text);
                txtNumero.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lstDatos);
                // MessageBox.Show(miLista + " ");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nom = "DatosListaSimple";
            miLista.Guardar(nom);
            txtNumero.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            string nom = "DatosListaSimple";
            miLista.Cargar(nom);
            miLista.Mostrar(lstDatos);
        }
    }
}
