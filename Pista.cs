using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller
{
    public class Pista
    {
        public enum TipoDeSuelo
        {
            MuyBlanda,
            Blanda,
            Media,
            Firma,
            Dura,
            MuyDura
        }

        // Propiedades de la pista
        public TipoDeSuelo Suelo { get; private set; }
        public int Longitud { get; private set; }
        public string Clima { get; private set; }

        // Constructor de la clase Pista con datos aleatorios
        public Pista()
        {
            // Generar un tipo de suelo aleatorio
            Array tiposDeSuelo = Enum.GetValues(typeof(TipoDeSuelo));
            Suelo = (TipoDeSuelo)tiposDeSuelo.GetValue(new Random().Next(tiposDeSuelo.Length));

            // Generar una longitud aleatoria entre 800 y 3200 con saltos de 400
            Longitud = new Random().Next(800, 3201) / 400 * 400;

            // Generar un clima aleatorio (puedes agregar más opciones si lo deseas)
            string[] climas = { "Soleado", "Nublado", "Lluvioso", "Viento fuerte" };
            Clima = climas[new Random().Next(climas.Length)];
        }
    }
}
