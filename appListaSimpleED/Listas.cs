using System;
using System.IO;
using System.Windows.Forms;

namespace appListaSimpleED
{
    class Listas
    {
       private Nodo head;

        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }
        public Listas()
        {
            head = null;
        }
        //Operaciones
        //Agregar
        //Eliminar
        //Buscar
        //Mostrar
        //Modificar
        public void Agregar(Nodo n)
        {
            //Lista Esta Vacia
            if (head==null)
            {
                head = n;
                return;
            }
            //No esta Vacia
            if (n.Numero < head.Numero)
            {
                //Al inicio
                n.Siguiente = head;
                head = n;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (n.Numero < h.Siguiente.Numero)
                {
                    break;
                }
                h = h.Siguiente;
            }
            n.Siguiente = h.Siguiente;
            h.Siguiente = n;
        }
        public void Eliminar(int d)
        {
            //Revisar que la lista este vacia
            if (head==null)
            {
                return;
            }
            //Si el nodo a eliminar es el primero (head)
            if (head.Numero == d)
            {
                head = head.Siguiente;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    break;
                }
                h = h.Siguiente;
            }
            if (h.Siguiente != null)
            {
                h.Siguiente = h.Siguiente.Siguiente;
            }
           
        }
        public bool Buscar(int d,ref Nodo b)
        {           
            //Revisar que la lista este vacia
            if (head == null)
            {
                return false;
            }
            //Si el nodo a buscar es el primero (head)
            if (head.Numero == d)
            {
                b = head;
                return true;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    b = h.Siguiente;
                    return true;
                }
                h = h.Siguiente;
            }
            return false;
        }
        public void Mostrar(ListBox lista)
        {
            Nodo h = head;
            lista.Items.Clear();
            while (h != null)
            {
                lista.Items.Add(h.ToString());
                h = h.Siguiente;
            }
        }
        public void Modificar(int d, string n, string t)
        {
            //Revisar que la lista este vacia
            if (head == null)
            {
                return;
            }
            //Si el nodo a modificar es el primero (head)
            if (head.Numero == d)
            {
                head.Nombre = n;
                head.Telefono = t;
                return;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    h.Siguiente.Nombre=n;
                    h.Siguiente.Telefono = t;
                    return;
                }
                h = h.Siguiente;
            }
            return;
        }
        public void Guardar(string nombreArchivo)
        {
            Nodo h = head;
            if (head == null)
            {
                return;
            }
           
            string path = @"D:\" + nombreArchivo + ".txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                do
                {
                   
                    sw.WriteLine(h.Numero + "-" + h.Nombre + "-" + h.Telefono);
                    h = h.Siguiente;
                } while (h != null);
            }
            return;
        }
        public void Cargar(string nombreArchivo)
        {
           
            string[] lineas = File.ReadAllLines(@"D:\" + nombreArchivo + ".txt");
            foreach (string linea in lineas)
            {
                if (linea.Length == 0)
                {
                    continue;
                }
                string[] datos = linea.Split('-');
                int numero = int.Parse(datos[0]);
                string nombre = datos[1];
                string telefono = datos[2];
                Nodo n = new Nodo(numero, nombre, telefono);
                Agregar(n);
            }
        }
        public override string ToString()
        {
            string listaEnTexto = "";
            Nodo h = head;
            while (h != null)
            {
                listaEnTexto += h.ToString() + " ";
                h = h.Siguiente;
            }
            return listaEnTexto;
        }

    }
}
