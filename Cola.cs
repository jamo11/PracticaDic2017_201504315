using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListasUsuarios_Matriz
{
    public class Cola
    {
        nodoCola primero;
        nodoCola nodoAux;

        public Cola()
        {
            primero = null;
        }
        public void encolar(Matriz matriz)
        {
            nodoCola nuevo = new nodoCola(matriz);
            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                nodoAux = primero;
                while (nodoAux.siguiente != null)
                {
                    nodoAux = nodoAux.siguiente;
                }
                nodoAux.siguiente = nuevo;

            }
        }
        public Matriz desenconlar()
        {
            nodoAux = primero;
            if (primero != null)
            {
                primero = primero.siguiente;
                return nodoAux.matriz;
            }
            else
            {
                MessageBox.Show("La cola esta vacia");
                return null;
            }
        }
        public void graficarCola()
        {
            nodoCola aux = primero;
            Graficar graficar = new Graficar();
            aux = primero;
            string temp = "";
            string str = "digraph {rankdir=LR;node[shape = box]; ";
            int cont = 0;
            if (aux == null)
            {
                MessageBox.Show("Cola está vacía");
            }
            while (aux != null)
            {
                if (aux.siguiente != null)
                {
                    temp = temp + Convert.ToString(cont) + "[shape=box,label = " + Convert.ToString(aux.matriz.getValor()) + "]";
                    cont++;
                    Console.WriteLine(temp);
                    str = str + temp;
                    Console.WriteLine(" str lleva:" + str);
                }
                else
                {
                    temp = temp + Convert.ToString(cont) + "[shape=box,label = " + Convert.ToString(aux.matriz.getValor()) + "]";
                    Console.WriteLine(temp);
                    str = str + temp;

                }
                temp = "";
                aux = aux.siguiente;
            }
            aux = primero;
            cont = 0;
            while (aux != null)
            {
                if (aux.siguiente != null)
                {
                    str += Convert.ToString(cont) + "->";
                    cont++;
                }
                else
                {
                    str += Convert.ToString(cont);
                }
                aux = aux.siguiente;
            }

            graficar.Construir(str, "Cola");
            graficar.GraficarEstructura("Cola.txt", "C:/EDD");
        }
    }

    public class nodoCola
    {
        public Matriz matriz;
        public nodoCola siguiente;
        public nodoCola(Matriz valor)
        {
            matriz = valor;
            siguiente = null;
        }
    }
}
