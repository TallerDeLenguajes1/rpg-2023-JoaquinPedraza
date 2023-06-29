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
                    caballo.Velocidad = rnd.Next(50, 65);
                    caballo.EnergEsprint = rnd.Next(50, 65);
                    caballo.Aceleracion = rnd.Next(50, 65);
                    caballo.Agilidad = rnd.Next(50, 65);
                    caballo.Salto = rnd.Next(50, 65);
                    break;
                case 4:
                    caballo.Velocidad = rnd.Next(65, 85);
                    caballo.EnergEsprint = rnd.Next(65, 85);
                    caballo.Aceleracion = rnd.Next(65, 85);
                    caballo.Agilidad = rnd.Next(65, 85);
                    caballo.Salto = rnd.Next(65, 85);
                    break;
                case 5:
                    caballo.Velocidad = rnd.Next(85, 105);
                    caballo.EnergEsprint = rnd.Next(85, 105);
                    caballo.Aceleracion = rnd.Next(85, 105);
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

            int cantCaballos = 5;

            List<Caballo> listaCaballos = new List<Caballo>();
            for (int i = 0; i < cantCaballos; i++)
            {
                listaCaballos.Add(CrearCaballo());
            }

            return listaCaballos;
        }
    }
}