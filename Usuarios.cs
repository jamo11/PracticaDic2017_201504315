using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListasUsuarios_Matriz
{
    public class Usuarios
    {
        public NodoUsuario primero = null;
        public bool nuevoUsuario(string nombre, string user, string psw)
        {
            if (validarUsuario(user))//QUE NO HAYA NINGUN USUARIO IGUAL
            {
                NodoUsuario nuevoNodo = new NodoUsuario(nombre, user, psw);
                if (primero == null)
                {
                    primero = nuevoNodo;
                    primero.siguiente = primero;
                    primero.anterior = primero;
                    MessageBox.Show("Usuario creado exitosamente!");
                    return true;
                }
                else
                {
                    insertarUsuario(primero, nuevoNodo);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool validarUsuario(string user)
        {
            if (primero != null)
            {
                if (primero.getUser().Equals(user))
                {
                    MessageBox.Show("Usuario ya existe");
                    return false;
                }
                else
                {
                    bool bandera = true;
                    NodoUsuario aux = primero;
                    while (bandera)
                    {
                        if (aux.siguiente != primero)
                        {
                            if (aux.siguiente.getUser().Equals(user))
                            {
                                MessageBox.Show("Usuario ya existe");
                                return false;
                            }
                            else
                            {
                                aux = aux.siguiente;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        private void insertarUsuario(NodoUsuario primero, NodoUsuario nuevo)
        {
            NodoUsuario aux = primero;
            bool bandera = true;
            while (bandera)
            {
                if (aux.siguiente == primero)
                {
                    aux.siguiente = nuevo;
                    nuevo.anterior = aux;
                    nuevo.siguiente = primero;
                    primero.anterior = nuevo;
                    bandera = false;
                    MessageBox.Show("Usuario creado exitosamente");
                }
                else
                {
                    aux = aux.siguiente;
                }
            }
        }

        public NodoUsuario Login(string user, string psw)
        {
            if (primero != null)
            {
                if (primero.getUser().Equals(user))
                {
                    if (primero.getContrasena().Equals(psw))
                    {
                        return primero;
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    bool bandera = true;
                    NodoUsuario aux = primero;
                    while (bandera)
                    {
                        if (aux.siguiente != primero)
                        {
                            if (aux.siguiente.getUser().Equals(user))
                            {
                                if (aux.siguiente.getContrasena().Equals(psw))
                                {
                                    return aux.siguiente;
                                }
                                else
                                {
                                    return null;
                                }
                            }
                            else
                            {
                                aux = aux.siguiente;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            else
            {
                return null;
            }
            return null;
        }

        public void eliminarUsuario(NodoUsuario usuario)
        {
            NodoUsuario aux = primero;
            if (primero.getUser().Equals(usuario.getUser()))
            {
                if (primero.siguiente == primero)
                {
                    primero = null;
                }
                else
                {
                    NodoUsuario next = primero.siguiente;
                    NodoUsuario prev = primero.anterior;
                    prev.siguiente = next;
                    next.anterior = prev;
                    primero = prev;
                }
            }
            else
            {
                bool flag = true;
                while (flag)
                {
                    if (aux.siguiente != primero)
                    {
                        aux = aux.siguiente;
                    }
                    else
                    {
                        flag = false;
                    }

                    if (aux.getUser().Equals(usuario.getUser()))
                    {
                        NodoUsuario prev = aux.anterior;
                        NodoUsuario next = aux.siguiente;
                        prev.siguiente = next;
                        next.anterior = prev;
                        flag = false;
                    }
                }
            }
        }

        public void dibujarGrafo()
        {
            string cadena = getGraphUsuarios();
            Graficar graficar = new Graficar();
            graficar.Construir(cadena, "Usuarios");
            graficar.GraficarEstructura("Usuarios.txt", "C:/EDD");
        }

        public string getGraphUsuarios()
        {
            NodoUsuario nodo = primero;
            bool flag = true;
            string cadena = "";
            cadena += "digraph { rankdir=LR; ";
            NodoUsuario aux = null;
            if (primero != null)
            {
                while (flag)
                {
                    if (nodo.siguiente != primero)
                    {
                        if (aux == null)
                        {
                            cadena += nodo.getUser() + "[shape=box] ";
                            aux = nodo;
                        }
                        else
                        {
                            cadena += nodo.getUser() + "[shape=box] ";
                            cadena += aux.getUser() + "->" + nodo.getUser() + " [dir=both] ";
                            aux = nodo;
                        }
                        nodo = nodo.siguiente;
                    }
                    else
                    {
                        if (aux == null)
                        {
                            cadena += nodo.getUser() + "[shape=box] ";
                            aux = nodo;
                        }
                        else
                        {
                            cadena += nodo.getUser() + "[shape=box] ";
                            cadena += aux.getUser() + "->" + nodo.getUser() + " [dir=both] ";
                            cadena += primero.getUser() + "->" + nodo.getUser() + "[dir=both] ";
                        }
                        flag = false;
                    }
                }
                return cadena.ToString();
            }
            return "";
        }
    }

    public class NodoUsuario
    {

        string nombre, user, contrasena;
        public NodoUsuario anterior, siguiente;
        public Pila pila;
        public Cola cola;
        public NodoUsuario(string name, string usuario, string psw)
        {
            nombre = name;
            user = usuario;
            contrasena = psw;
            pila = null;
            cola = null;
        }


        public void multiplicarMatrices(NodoUsuario usuario)
        {
            try
            {
                Pila userPila = usuario.pila;
                Cola userCola = usuario.cola;
                Matriz matrizPila = pila.pop();
                Matriz matrizCola = cola.desenconlar();
                nodoMatriz nodoMatrizCola = matrizCola.raiz;
                nodoMatriz nodoMatrizPila = matrizPila.raiz;
                nodoMatriz auxCola = nodoMatrizCola;
                nodoMatriz auxPila = nodoMatrizPila;
                string cadena = "graph { node[shape= box]; {rank=same;";
                int resultado = 0;
                if (matrizCola.getX() == matrizPila.getY())
                {
                    while (auxCola != null)
                    {
                        while (nodoMatrizCola != null)
                        {
                            resultado += (nodoMatrizCola.numero * nodoMatrizPila.numero);
                            nodoMatrizCola = nodoMatrizCola.right;
                            nodoMatrizPila = nodoMatrizPila.down;
                        }
                        Console.Write("Coordenada: " + auxPila.getX().ToString() + "," + auxCola.getY().ToString() + "; Dato: " + resultado.ToString());
                        cadena += auxPila.getX().ToString() + auxCola.getY().ToString() + "[label = " + resultado.ToString() + "]";
                        resultado = 0;
                        auxPila = auxPila.right;
                        if (auxPila != null)
                        {
                            nodoMatrizPila = auxPila;
                            nodoMatrizCola = auxCola;
                        }
                        else
                        {
                            auxCola = auxCola.down;
                            nodoMatrizCola = auxCola;
                            auxPila = matrizPila.raiz;
                            nodoMatrizPila = auxPila;
                            //CAMBIA DE FILA EN LA MATRIZ DE LA COLA Y PILA REGRESA A RAIZ
                            if (auxCola != null)
                            {
                                cadena += "}{rank=same;";
                            }else
                            {
                                cadena += "}";
                            }
                        }
                    }
                    string aux ="";
                    for (int i = 0; i < matrizCola.getY(); i++)
                    {
                        for (int j = 0; j < matrizPila.getX(); j++)
                        {
                            if (i == 0)
                            {
                                if (j == matrizPila.getX() -1)
                                {
                                    aux += j.ToString() + i.ToString() + " ";
                                }
                                else
                                {
                                    aux += j.ToString() + i.ToString() + "--";
                                }
                            }else
                            {
                                if (j == matrizPila.getX() - 1)
                                {
                                    aux += j.ToString() + i.ToString() + "--" + j.ToString() + (i - 1).ToString() + " ";
                                }
                                else
                                {
                                    aux += j.ToString() + i.ToString() + "--" + j.ToString() + (i - 1).ToString() + " ";
                                    aux += j.ToString() + i.ToString() + "--";
                                }
                                
                            }
                        }
                    }
                    cadena += aux;
                    cadena += "}";
                    Graficar graficar = new Graficar();
                    graficar.Construir(cadena, "Matriz");
                    graficar.GraficarEstructura("Matriz.txt", "C:/EDD");
                    Imagenes image = new Imagenes("Grafica de Matriz", "C:/EDD/Matriz.jpg");
                    image.Show();
                }
                else
                {
                    MessageBox.Show("Es imposible multiplicar entre si tales matrices" +
                        ", así que el número de columnas de la matriz A (" + matrizCola.getX().ToString() +
                        ") no equivale al número de filas de la matriz B(" + matrizPila.getY().ToString() + ")");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al querer operar");
            }
        }

        public Pila getPila()
        {
            return pila;
        }

        public Cola getCola()
        {
            return cola;
        }

        public string getUser()
        {
            return user;
        }
        public string getContrasena()
        {
            return contrasena;
        }
        public string getNombre()
        {
            return nombre;
        }
    }

}
