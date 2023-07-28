using System;
using System.IO;

namespace TrabajandoJson
{
    public class HelperDeJson
    {

        public string AbrirArchivoTexto(string nombreArchivo)
        {
            if (!File.Exists(nombreArchivo))
            {
                var fileStream = File.Create(nombreArchivo);
                fileStream.Close();
            }
            string documento;

              using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }


            return documento;
        }

        public void GuardarArchivoTexto(string nombreArchivo, string datos)
        {
             using(var archivo = new FileStream(nombreArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", datos);
                    strWriter.Close();
                }
            }
        }
    }
}
