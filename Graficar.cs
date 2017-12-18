using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListasUsuarios_Matriz
{
    public class Graficar
    {
        public void Construir(string cadena, string nombre)
        {
            StreamWriter archivo = new StreamWriter("C:/EDD/" + nombre + ".txt");
            archivo.Write(cadena);
            archivo.Write("}");
            archivo.Close();
        }

        public void GraficarEstructura(string fileName, string path)
        {
            try
            {
                var command = string.Format("C:/Graphviz2.38/bin/dot.exe -Tjpg {0} -o {1}",
                    Path.Combine(path, fileName), Path.Combine(path,
                    fileName.Replace(".txt", ".jpg")));
                var command2 = string.Format("C:/Graphviz2.38/bin/dot.exe -Tjpg {0} -o {1}", 
                    Path.Combine(path, fileName), Path.Combine(path, 
                    fileName.Replace(".txt", ".jpg")), true);
                var procStartInfo = new ProcessStartInfo("cmd", "/C " + command2);
                var proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
