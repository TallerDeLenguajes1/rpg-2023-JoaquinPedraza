using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoTaller.Caballo;

namespace ProyectoTaller
{
    public class FabricaDeCaballos
    {
        public Caballo CrearCaballo()
        {
            var rnd = new Random();
            Caballo caballo = new Caballo();
            caballo.Nombre = "Chirs Titus";

            caballo.Estrellas = rnd.Next(3, 6);

            switch (caballo.Estrellas)
            {
                case 3:
                    caballo.Velocidad = rnd.Next(63, 68);
                    caballo.EnergEsprint = rnd.Next(73, 78);
                    caballo.Aceleracion = rnd.Next(10, 31) / 100.000 + 1;
                    caballo.Agilidad = rnd.Next(50, 65);
                    caballo.Salto = rnd.Next(50, 65);
                    break;
                case 4:
                    caballo.Velocidad = rnd.Next(68, 73);
                    caballo.EnergEsprint = rnd.Next(78, 83);
                    caballo.Aceleracion = rnd.Next(20, 41)/100.000 + 1;
                    caballo.Agilidad = rnd.Next(65, 85);
                    caballo.Salto = rnd.Next(65, 85);
                    break;
                case 5:
                    caballo.Velocidad = rnd.Next(73, 79);
                    caballo.EnergEsprint = rnd.Next(73, 89);
                    caballo.Aceleracion = rnd.Next(30, 51)/100.000 + 1;
                    caballo.Agilidad = rnd.Next(85, 105);
                    caballo.Salto = rnd.Next(85, 105);
                    break;
                default:
                    break;
            }
            caballo.Edad = rnd.Next(2, 6);

            caballo.Pista = (TipoPista)Enum.GetValues(typeof(TipoPista)).GetValue(index: rnd.Next(0, 6));

            caballo.Pelaje = (TipoPelaje)Enum.GetValues(typeof(TipoPelaje)).GetValue(index: rnd.Next(0, 26));

            caballo.Raza = (eRaza)Enum.GetValues(typeof(eRaza)).GetValue(index: rnd.Next(0, 89));

            caballo.Distancia = 800 + rnd.Next(1, 7)*400;

            caballo.FechaDeNacimiento = new FechaDeNacimiento().Obtener(caballo.Edad);

            return caballo;
        }

        public List<Caballo> CrearCaballos()
        {
            var rnd = new Random();

            int cantCaballos = (int)Math.Pow(2, rnd.Next(2,5));  //puede ser semifinal, cuartos de final , y octavo de final

            List<Caballo> listaCaballos = new List<Caballo>();
            for (int i = 0; i < cantCaballos; i++)
            {
                listaCaballos.Add(CrearCaballo());
            }

            return listaCaballos;
        }

        //public void MatarCaballo(

    }
}