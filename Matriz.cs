using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListasUsuarios_Matriz
{
    public class Matriz
    {
        public nodoMatriz raiz;
        int x, y;
        public Matriz(int fil, int col)
        {
            raiz = new nodoMatriz(0, 0, 0);
            x = fil;
            y = col;
        }

        public Matriz crearMatriz(int tamX, int tamY)
        {
            int contadorX = 1, contadorY = 0;
            x = tamX;
            y = tamY;
            nodoMatriz nodoAux = raiz;
            nodoMatriz tempAuxX = raiz;
            nodoMatriz auxiliar = raiz;
            while (contadorY < tamY)
            {
                while (contadorX < tamX)
                {
                    nodoMatriz nuevoNodo = new nodoMatriz(0, contadorX, contadorY);
                    tempAuxX.right = nuevoNodo;
                    nuevoNodo.left = tempAuxX;
                    tempAuxX = nuevoNodo;
                    if (contadorY > 0)
                    {
                        auxiliar = auxiliar.right;
                        nuevoNodo.up = auxiliar;
                        auxiliar.down = nuevoNodo;
                    }
                    //MessageBox.Show("Insertando X: " + Convert.ToString(contadorX) + ", Y: " + Convert.ToString(contadorY));
                    contadorX++;
                }

                if ((contadorY + 1) != tamY)
                {
                    contadorX = 0;
                    contadorY++;
                    auxiliar = nodoAux;
                    nodoMatriz nuevoY = new nodoMatriz(0, contadorX, contadorY);
                    nodoAux.down = nuevoY;
                    nuevoY.up = nodoAux;
                    nodoAux = nuevoY;
                    tempAuxX = nodoAux;
                    //MessageBox.Show("Insertando X: " + Convert.ToString(contadorX) + ", Y: " + Convert.ToString(contadorY));
                    contadorX = 1;
                }
                else
                {
                    contadorY++;
                }
            }
            return this;
        }

        public int getValor()
        {
            nodoMatriz auxX = raiz;
            nodoMatriz auxY = raiz;
            int valor = 0;
            for (int j = 0; j < y; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    valor = valor + auxX.numero;
                    auxX = auxX.right;
                }
                auxY = auxY.down;
                auxX = auxY;
            }
            return valor;
        }

        public void asignarDato(int x, int y, int dato)
        {
            Matriz mat = this;
            nodoMatriz aux = raiz;
            if ((x == 0) && (y == 0))
            {
                raiz.numero = dato;
            }
            else
            {
                if (y == 0)
                {
                    while (aux.getX() < x)
                    {
                        aux = aux.right;
                    }

                }
                else if (x == 0)
                {
                    while (aux.getY() < y)
                    {
                        aux = aux.down;
                    }
                }
                else
                {
                    while (aux.getY() < y)
                    {
                        while (aux.getX() < x)
                        {
                            aux = aux.right;
                        }
                        aux = aux.down;
                    }
                }
                aux.numero = dato;
            }
        }


        public void graficarMatriz()
        {
            string str = "";









            Graficar graficar = new Graficar();
            graficar.Construir(str, "Matriz");
            graficar.GraficarEstructura("Matriz.txt", "C:/EDD");
            Imagenes image = new Imagenes("Grafica de Pila", "C:/EDD/Pila.jpg");
            image.Show();
        }
        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }
    }

    public class nodoMatriz
    {
        public int numero, x, y;
        public nodoMatriz up, down, left, right;

        public nodoMatriz(int dato, int posX, int posY)
        {
            numero = dato;
            x = posX;
            y = posY;
        }

        public int getDato()
        {
            return numero;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

    }
}
