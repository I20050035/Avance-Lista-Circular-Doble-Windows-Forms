using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LDobleCircular
{
    class Lista
    {
        private Nodo head;

        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }


        public Lista()
        {
            head = null;
        }


        public void agregarNodo(Nodo nuevo)
        {
            if (head == null)
            {
                nuevo.siguiente = nuevo;
                nuevo.anterior = nuevo;
                head = nuevo;
                return;
            }
            Nodo h = head;
            if (nuevo.dato < head.dato)
            {
                Nodo ultimo = head.anterior;
                nuevo.siguiente = head;
                nuevo.anterior = ultimo;
                head.anterior = nuevo;
                ultimo.siguiente = nuevo;
                head = nuevo;
                while (h.siguiente != head)
                {
                    h = h.siguiente;
                }
                h.siguiente = nuevo;
                h.anterior = head;
                head = nuevo;
                return;
            }
            while (nuevo != head)
            {
                if (nuevo.dato < h.siguiente.dato)
                {
                    break;
                }
                h = h.siguiente;
                h.anterior = head;
                if (nuevo.dato > h.dato)
                {
                    Nodo ultimo = head.anterior;
                    nuevo.siguiente = head;
                    nuevo.anterior = ultimo;
                    head.anterior = nuevo;
                    ultimo.siguiente = nuevo;
                    return;
                }
            }
            nuevo.siguiente = h.siguiente;
            h.anterior = h.siguiente;
            h.siguiente = nuevo;

        }
        public bool Buscar(int d, ref Nodo b)
        {
            if (head == null)
            {
                return false;
            }
            if (head.dato == d)
            {
                b = head;
                return true;
            }
            Nodo h = head;
            while (h.siguiente != head)
            {
                if (h.siguiente.dato == d)
                {
                    b = h.siguiente;
                    return true;
                }
                h.anterior = h;
                h = h.siguiente;
            }
            return false;
        }
        public void Modificar(int d, string n)
        {
            if (head == null)
            {
                return;
            }
            if (head.dato == d)
            {
                head.nombre = n;
                return;
            }
            Nodo h = head;
            while (h.siguiente != head)
            {
                if (h.siguiente.dato == d)
                {
                    h.siguiente.nombre = n;
                    return;
                }
                h.anterior = h;
                h = h.siguiente;
            }
            return;
        }


        public void eliminarNodo(int d)
        {
            if (head == null)
            {
                return;
            }
            Nodo h = head;
            if (head.dato == d)
            {
                if (head.siguiente == head)
                {
                    head = null;
                    return;
                }
                while (h.siguiente != head)
                {
                    h.anterior = h;
                    h = h.siguiente;
                }
                h.anterior = head;
                h.siguiente = head.siguiente;
                head.anterior = head;
                head = head.siguiente;
                return;
            }

            while (h.siguiente != head)
            {
                if (h.siguiente.dato == d)
                {
                    break;
                }
                h.anterior = h;
                h = h.siguiente;
            }
            if (h.siguiente != head)
            {
                h.anterior = h.siguiente;
                h.siguiente = h.siguiente.siguiente;
            }
        }
        public void Mostrar(ListBox lista)
        {
            Nodo h = head;
            lista.Items.Clear();
            if (head == null)
            {
                return;
            }
            do
            {
                lista.Items.Add(h.ToString());
                h = h.siguiente;
            } while (h != head);
            return;
        }
        public void Guardar()
        {
            Nodo h = head;
            if (head == null)
            {
                return;
            }
            string path = @"C:\LDobleCircular.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                do
                {
                    sw.WriteLine(h.dato + " " + h.nombre);
                    h = h.siguiente;
                } while (h != head);
            }
            return;
        }
        public void Cargar(string nombreArchivo)
        {
            nombreArchivo = "LDobleCircular";
            string[] lineas = File.ReadAllLines(@"C:\" + nombreArchivo + ".txt");
            foreach (string linea in lineas)
            {
                if (linea.Length == 0)
                {
                    continue;
                }
                string[] datos = linea.Split('-');
                int dato = int.Parse(datos[0]);
                string nombre = datos[1];
                Nodo nuevo = new Nodo(dato, nombre);
                agregarNodo(nuevo);
            }
        }
    }
}


