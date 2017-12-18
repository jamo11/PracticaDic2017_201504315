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
    public partial class Imagenes : Form
    {
        string nombreA = "";
        string documento = "";
        public Imagenes(string nombre, string doc)
        {
            InitializeComponent();
            nombreA = nombre;
            documento = doc;
        }

        private void Imagenes_Load(object sender, EventArgs e)
        {
            groupBox1.Text = nombreA;
            pictureBox1.Image = Image.FromFile(documento);
        }
    }
}
