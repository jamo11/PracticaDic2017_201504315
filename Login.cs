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
    public partial class Login : Form
    {
        Usuarios usuarios = Registro.usuarios;
        public Login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //usuarios.dibujarGrafo();
            NodoUsuario usuario = usuarios.Login(textBox1.Text, textBox2.Text);
            if (usuario != null)
            {
                MessageBox.Show("Login exitoso");
                Principal reg = new Principal();
                reg.usuario = usuario;
                reg.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Error al intentar loguearse");
            }
        }
    }
}
