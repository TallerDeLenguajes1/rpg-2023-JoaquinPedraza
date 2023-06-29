using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller
{
    public class FechaDeNacimiento
    {
        public DateTime Obtener(int edad)
        {

            //para usar el formato "dd/MM/yyyy";
            System.Globalization.DateTimeFormatInfo dInfo = new System.Globalization.DateTimeFormatInfo();
            dInfo.ShortDatePattern = "dd/MM/yyyy";

            //para pasar la info de un par de textbox string a datetime
            DateTime thisDay = DateTime.Today;
            string dtMinS = Convert.ToString(thisDay.Day) + "/" + Convert.ToString(thisDay.Month) + "/" + Convert.ToString(thisDay.Year - edad);
            string dtMaxS = Convert.ToString(thisDay.Day + 1) + "/" + Convert.ToString(thisDay.Month) + "/" + Convert.ToString(thisDay.Year - (edad+1));
            DateTime dtMin = Convert.ToDateTime(dtMaxS, dInfo);
            DateTime dtMax = Convert.ToDateTime(dtMinS, dInfo);

            //para calcular la diferencia de días entre fechas
            TimeSpan tsMax = dtMax - dtMin;

            // para crear el random
            Random rn = new Random();

            //dias aleatorios que generarán la proxima fecha
            int rnDays = new Random().Next(1, tsMax.Days);

            //fecha aleatoria resultante de los dias sumados a la fecha minima
            return  dtMin.AddDays(rnDays);

        }
    }
}
