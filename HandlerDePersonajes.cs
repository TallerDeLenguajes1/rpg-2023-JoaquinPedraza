﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TrabajandoJson;

namespace ProyectoTaller
{
    public class HandlerDePersonajes
    {
        public List<Caballo> LeerCaballos(string nombreArchivo)
        {
            var miHelperdeArchivos = new HelperDeJson();

            //Abro el Archivo
            string jsonDocument = miHelperdeArchivos.AbrirArchivoTexto(nombreArchivo);

            if (jsonDocument == "")
            {
                return new List<Caballo>();
            }
            List<Caballo> listadoCaballosRecuperados= JsonSerializer.Deserialize<List<Caballo>>(jsonDocument);


            return listadoCaballosRecuperados;
        }

        public void GuardarCaballos(string NombreArchivo, List<Caballo> caballos)
        {
            var miHelperdeArchivos = new HelperDeJson();

            var options = new JsonSerializerOptions { WriteIndented = true };
            string informeJson = JsonSerializer.Serialize(caballos, options);
            miHelperdeArchivos.GuardarArchivoTexto(NombreArchivo, informeJson);
        }
    }
}
