using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListasUsuarios_Matriz
{
    public partial class Principal : Form
    {
        public NodoUsuario usuario;
        public Principal()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JSON Files|*.json";
            openFileDialog1.Title = "Select a Cursor File json";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                button3.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            Pila pilaUsu = usuario.pila;
            if (pilaUsu == null)
            {
                usuario.pila = new Pila();
                Matriz mat = new Matriz(x,y);
                mat = mat.crearMatriz(x, y);
                usuario.pila.push(mat);
            }else
            {
                Matriz mat = new Matriz(x,y);
                mat = mat.crearMatriz(x, y);
                usuario.pila.push(mat);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
            int y = Convert.ToInt32(textBox4.Text);
            Cola colaUsu = usuario.cola;
            if (colaUsu == null)
            {
                usuario.cola = new Cola();
                Matriz mat = new Matriz(x,y);
                mat = mat.crearMatriz(x,y);
                usuario.cola.encolar(mat);
            }else
            {
                Matriz mat = new Matriz(x, y);
                mat = mat.crearMatriz(x, y);
                usuario.cola.encolar(mat);
            }
        }

        private void eliminarUsuario_Click(object sender, EventArgs e)
        {
            Registro.usuarios.eliminarUsuario(usuario);
            Login log = new Login();
            log.Show();
            this.Hide();
        }
                
        private void button3_Click(object sender, EventArgs e)
        {
            archivoJson atjson = new archivoJson();
            archivoJson output = JsonConvert.DeserializeObject<archivoJson>(richTextBox1.Text.ToString());
            try
            {
                foreach (archMatriz x in output.archivo.pila.matrices.matriz)
                {
                    Console.WriteLine("Matriz para la pila:");
                    Console.WriteLine("Tamano x =" + x.size_x);
                    Console.WriteLine("Tamano y =" + x.size_y);
                    Matriz matrizNueva = new Matriz(Convert.ToInt32(x.size_x), Convert.ToInt32(x.size_y));
                    matrizNueva.crearMatriz(Convert.ToInt32(x.size_x), Convert.ToInt32(x.size_y));
                    foreach (Valor val in x.valores.valor)
                    {
                        //ASIGNAR VALORES EN LA MATRIZ-----------------------------------------------
                        matrizNueva.asignarDato(Convert.ToInt32(val.pos_x), Convert.ToInt32(val.pos_y), Convert.ToInt32(val.dato));
                        Console.WriteLine("Dato a guardar en matriz de la pila:");
                        Console.WriteLine("Coordenada x " + val.pos_x);
                        Console.WriteLine("Coordenada y " + val.pos_y);
                        Console.WriteLine("Dato " + val.dato);
                    }
                    Pila pilaUsu = usuario.pila;
                    if (pilaUsu == null)
                    {
                        usuario.pila = new Pila();
                        usuario.pila.push(matrizNueva);
                    }
                    else
                    {
                        usuario.pila.push(matrizNueva);
                    }
                }
                MessageBox.Show("Pila cargada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay matrices para la pila");
            }
            
            try
            {
                foreach (Matriz1 y in output.archivo.cola.matrices.matriz)
                {
                    Matriz matrizNueva = new Matriz(Convert.ToInt32(y.size_x), Convert.ToInt32(y.size_y));
                    matrizNueva.crearMatriz(Convert.ToInt32(y.size_x), Convert.ToInt32(y.size_y));
                    Console.WriteLine("Matriz cola");
                    Console.WriteLine("Tamano en x =" + y.size_x);
                    Console.WriteLine("Tamano en y =" + y.size_y);

                    foreach (Valor1 val2 in y.valores.valor)
                    {
                        //ASIGNAR VALORES EN LA MATRIZ DE LA COLA
                        matrizNueva.asignarDato(Convert.ToInt32(val2.pos_x), Convert.ToInt32(val2.pos_y), Convert.ToInt32(val2.dato));
                        Console.WriteLine("Dato a guardar en cola:");
                        Console.WriteLine("Coordenada x " + val2.pos_x);
                        Console.WriteLine("Coordenada x " + val2.pos_y);
                        Console.WriteLine("Dato " + val2.dato);
                    }
                    Cola colaUsu = usuario.cola;
                    if (colaUsu == null)
                    {
                        usuario.cola = new Cola();
                        usuario.cola.encolar(matrizNueva);
                    }
                    else
                    {
                        usuario.cola.encolar(matrizNueva);
                    }
                }
                MessageBox.Show("Cola cargada");
            }
            catch(Exception ex)
            {
                MessageBox.Show("No hay matrices para la cola");
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            usuario.multiplicarMatrices(usuario);
        }

        private void graficarPila_Click(object sender, EventArgs e)
        {
            usuario.pila.graficarPila();
            Imagenes image = new Imagenes("Grafica de Pila", "C:/EDD/Pila.jpg");
            image.Show();
        }

        private void graficarCola_Click(object sender, EventArgs e)
        {
            usuario.cola.graficarCola();
            Imagenes image = new Imagenes("Grafica de Cola", "C:/EDD/Cola.jpg");
            image.Show();
        }

        private void btnGraphUsuarios_Click(object sender, EventArgs e)
        {
            Registro.usuarios.dibujarGrafo();
            Imagenes image = new Imagenes("Grafica de Usuarios", "C:/EDD/Usuarios.jpg");
            image.Show();
        }
    }

    [Serializable]
    public class archivoJson
    {
        public Archivo archivo { get; set; }
    }

    public class Archivo
    {
        public archPila pila { get; set; }
        public archCola cola { get; set; }
    }

    public class archPila
    {
        public Matrices matrices { get; set; }
    }

    public class Matrices
    {
        public archMatriz[] matriz { get; set; }
    }

    public class archMatriz
    {
        public string size_x { get; set; }
        public string size_y { get; set; }
        public Valores valores { get; set; }
    }

    public class Valores
    {
        public Valor[] valor { get; set; }
    }

    public class Valor
    {
        public string pos_x { get; set; }
        public string pos_y { get; set; }
        public string dato { get; set; }
    }

    public class archCola
    {
        public Matrices1 matrices { get; set; }
    }

    public class Matrices1
    {
        public Matriz1[] matriz { get; set; }
    }

    public class Matriz1
    {
        public string size_x { get; set; }
        public string size_y { get; set; }
        public Valores1 valores { get; set; }
    }

    public class Valores1
    {
        public Valor1[] valor { get; set; }
    }

    public class Valor1
    {
        public string pos_x { get; set; }
        public string pos_y { get; set; }
        public string dato { get; set; }
    }

}
