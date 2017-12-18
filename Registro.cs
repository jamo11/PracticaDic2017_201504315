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
    public partial class Registro : Form
    {
        public static Usuarios usuarios = new Usuarios();
        Login log = new Login();
        public Registro()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(usuarios.nuevoUsuario(textBox1.Text, textBox2.Text, textBox3.Text))
            {
                log.Show();
                this.Hide();
            }
        }
    }
}
