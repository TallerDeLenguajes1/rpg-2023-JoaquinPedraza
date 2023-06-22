using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller
{
    internal class Caballo
    {
        class Caracteristicas
        {
            int velocidad;  //entre 50-65(3), 65-85(4), 85-105(5)
            int energEsprint; //entre 50-65(3), 65-85(4), 85-105(5)
            int aceleracion;  //entre 50-65(3), 65-85(4), 85-105(5)
            int agilidad;   //entre 50-65(3), 65-85(4), 85-105(5)
            int salto;     //entre 50-65(3), 65-85(4), 85-105(5)
            int distancia; //entre 800 - 3200
            string? pista; //MUY BLANDA/BLANDA/MEDIA/FIRMA/DURA/MUY DURA
            int estrellas; //entre 3 y 5

        }

        class Datos
        {
            int edad;
            string? nombre;
            string? raza;
            string? pelaje;
            DateTime fechaDeNacimiento;

        }

    }
}