using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListasUsuarios_Matriz
{
    public class Pila
    {
        nodoPila primero;
        public Pila()
        {
            primero = null;
        }
        public void push(Matriz matriz)
        {
            nodoPila nuevoNodo = new nodoPila(matriz);
            if (primero == null)
            {
                primero = nuevoNodo;
            }
            else
            {
                nuevoNodo.siguiente = primero;
                primero = nuevoNodo;

            }
        }
        public Matriz pop()
        {
            nodoPila temp;
            if (primero != null)
            {
                temp = primero;
                primero = primero.siguiente;
                return temp.matriz;
            }else
            {
                MessageBox.Show("La pila está vacía");
                return null;
            }
        }
        public void graficarPila()
        {
            nodoPila aux = primero;
            Graficar graficar = new Graficar();
            aux = primero;
            string temp = "";
            string str = "digraph { rankdir=TB;node[shape = box]; ";
            int cont = 0;
            if (aux == null)
            {
                MessageBox.Show("Pila está vacía");
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

            graficar.Construir(str, "Pila");
            graficar.GraficarEstructura("Pila.txt", "C:/EDD");
        }
    }

    public class nodoPila
    {
        public Matriz matriz;
        public nodoPila siguiente;
        public nodoPila(Matriz dato)
        {
            matriz = dato;
            siguiente = null;

        }


    }
}
