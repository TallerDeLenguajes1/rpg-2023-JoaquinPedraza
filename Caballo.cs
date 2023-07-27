using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoTaller.Pista;

namespace ProyectoTaller
{
    public class Caballo
    {
        public enum TipoPista
        {
            MuyBlanda,
            Blanda,
            Media,
            Firma,
            Dura,
            MuyDura
        }

        public enum TipoPelaje
        {
            Abayado,
            Acebrunado,
            Alazán,
            Arrosillado,
            Azabache,
            Azafranado,
            Barroso,
            Bayo,
            Bocifuego,
            Cebruno,
            Cenizo,
            Colorado,
            Congo,
            Doradillo,
            Dorado,
            Entrecano,
            Entrepelado,
            Isabelo,
            Lobuno,
            Alobunado,
            Pizarra,
            Porcelano,
            Ruano,
            Tordillo,
            Tordo,
            Zaino,
        }

        public enum eRaza
        {
            Akhal_Teke,
            Apaloosa,
            AraApaloosa,
            Árabe,
            Árabe_portugués,
            Asturcón,
            Aveliñés,
            Azteca,
            Albino,
            Alter_Real,
            AngloArgentino,
            Bardigiano,
            Basuto,
            Bereber,
            Bretón,
            Buckskin,
            Budyonny,
            Beunza,
            Altái,
            andaluz,
            ibérico,
            Pirenaico_Catalán,
            catalán,
            CDE,
            Mallorquín,
            Marismeño,
            Marwari,
            Menorquín,
            Morab,
            Colombiano,
            Costarricense,
            Criollo,
            Camargués,
            Darashouri,
            Don,
            Dülmener_Wildpferd,
            Falabella,
            Francés,
            Freiberg,
            Frisón,
            Gelder,
            Genêt_dEspagne,
            Gotland,
            Hackney,
            Haflinger,
            Hannoveriano,
            Hispano_Árabe,
            Hispano_Bretón,
            Holstein,
            Iberoamericano,
            Irish_Cob,
            Irish_Hunter,
            Islandés,
            Jaca_navarra,
            Jomud,
            Karabakh,
            Kentucky_mountain,
            Kustanair,
            Konik,
            Lipizzano,
            Lokai,
            Losino,
            Monchino,
            Mongol,
            Morgan,
            Mustang,
            Nonius,
            Oldenburgues,
            Palomino,
            CPP,
            Percherón,
            Piebald,
            Pinto,
            Pottoka,
            Petramo,
            Przewalski,
            Quarter_Horse,
            Rocky_Mountain,
            Salernitano,
            San_Fratelano,
            Poni_Shetland,
            Silla_americano,
            Tennessee_Walking,
            Tersk,
            Tinker,
            Torik,
            Trakehner,
            Trotador_Español,
            Ucraniano
        }

        double velocidad;  //entre 50-65(3), 65-85(4), 85-105(5)
        double energEsprint; //entre 50-65(3), 65-85(4), 85-105(5)
        double aceleracion;  //entre 50-65(3), 65-85(4), 85-105(5)
        double agilidad;   //entre 50-65(3), 65-85(4), 85-105(5)
        double salto;     //entre 50-65(3), 65-85(4), 85-105(5)
        double distancia; //entre 800 - 3200
        TipoPista pista; //MUY BLANDA/BLANDA/MEDIA/FIRMA/DURA/MUY DURA
        int estrellas; //entre 3 y 5


        public double Velocidad { get => velocidad; set => velocidad = value; }
        public double EnergEsprint { get => energEsprint; set => energEsprint = value; }
        public double Aceleracion { get => aceleracion; set => aceleracion = value; }
        public double Agilidad { get => agilidad; set => agilidad = value; }
        public double Salto { get => salto; set => salto = value; }
        public double Distancia { get => distancia; set => distancia = value; }
        public int Estrellas { get => estrellas; set => estrellas = value; }


        int edad;
        string? nombre;
        eRaza raza;
        TipoPelaje pelaje;
        DateTime fechaDeNacimiento;

        public int Edad { get => edad; set => edad = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public eRaza Raza { get => raza; set => raza = value; }
        public TipoPelaje Pelaje { get => pelaje; set => pelaje = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public TipoPista Pista { get => pista; set => pista = value; }

        public int Avanzar(Pista pistaC, bool isSprint, bool isAcelerated)
        {
            double avance;
            if (!isSprint)
            {
                if (isAcelerated)
                {   
                    avance = velocidad / 10.00 * aceleracion * buffForPista(pista, pistaC) * buffForDistancia(distancia, pistaC) * (salto / 100.00 + 1.00) * (agilidad / 100.00 + 1.00);
                    return (int)Math.Round(avance);
                }
                else
                {
                    avance = velocidad / 10.00 * buffForPista(pista, pistaC) * buffForDistancia(distancia, pistaC) * (salto / 100.00 + 1) * (agilidad / 100.00 + 1);
                    return (int)Math.Round(avance);

                }
            }
            else
            {
                if (isAcelerated)
                {
                    avance = energEsprint / 10 * aceleracion * buffForPista(pista, pistaC) * buffForDistancia(distancia, pistaC) * (salto / 100 + 1) * (agilidad / 100 + 1);
                    return (int)Math.Round(avance);
                }
                else
                {
                    avance = energEsprint / 10 * buffForPista(pista, pistaC) * buffForDistancia(distancia, pistaC) * (salto / 100 + 1) * (agilidad / 100 + 1);
                    return (int)Math.Round(avance);
                }
            }

            double buffForPista(TipoPista pista, Pista pistaC)
            {
                switch (pista)
                {
                    case TipoPista.MuyBlanda:
                        switch (pistaC.Suelo)
                        {
                            case 0:
                                return 1.25;
                            case (TipoDeSuelo)1:
                                return 1.20;
                            case (TipoDeSuelo)2:
                                return 1.15;
                            case (TipoDeSuelo)3:
                                return 1.10;
                            case (TipoDeSuelo)4:
                                return 1.05;
                            case (TipoDeSuelo)5:
                                return 1;
                            default:
                                return 1;
                        }
                    case TipoPista.Blanda:
                        switch (pistaC.Suelo)
                        {
                            case 0:
                                return 1.20;
                            case (TipoDeSuelo)1:
                                return 1.25;
                            case (TipoDeSuelo)2:
                                return 1.20;
                            case (TipoDeSuelo)3:
                                return 1.15;
                            case (TipoDeSuelo)4:
                                return 1.10;
                            case (TipoDeSuelo)5:
                                return 1.05;
                            default:
                                return 1;
                        }
                    case TipoPista.Media:
                        switch (pistaC.Suelo)
                        {
                            case 0:
                                return 1.15;
                            case (TipoDeSuelo)1:
                                return 1.20;
                            case (TipoDeSuelo)2:
                                return 1.25;
                            case (TipoDeSuelo)3:
                                return 1.20;
                            case (TipoDeSuelo)4:
                                return 1.15;
                            case (TipoDeSuelo)5:
                                return 1.10;
                            default:
                                return 1;
                        }
                    case TipoPista.Firma:
                        switch (pistaC.Suelo)
                        {
                            case 0:
                                return 1.10;
                            case (TipoDeSuelo)1:
                                return 1.15;
                            case (TipoDeSuelo)2:
                                return 1.20;
                            case (TipoDeSuelo)3:
                                return 1.25;
                            case (TipoDeSuelo)4:
                                return 1.20;
                            case (TipoDeSuelo)5:
                                return 1.15;
                            default:
                                return 1;
                        }
                    case TipoPista.Dura:
                        switch (pistaC.Suelo)
                        {
                            case 0:
                                return 1.05;
                            case (TipoDeSuelo)1:
                                return 1.10;
                            case (TipoDeSuelo)2:
                                return 1.15;
                            case (TipoDeSuelo)3:
                                return 1.20;
                            case (TipoDeSuelo)4:
                                return 1.25;
                            case (TipoDeSuelo)5:
                                return 1.20;
                            default:
                                return 1;
                        }
                    case TipoPista.MuyDura:
                        switch (pistaC.Suelo)
                        {
                            case 0:
                                return 1.00;
                            case (TipoDeSuelo)1:
                                return 1.05;
                            case (TipoDeSuelo)2:
                                return 1.10;
                            case (TipoDeSuelo)3:
                                return 1.15;
                            case (TipoDeSuelo)4:
                                return 1.20;
                            case (TipoDeSuelo)5:
                                return 1.25;
                            default:
                                return 1;
                        }
                    default:
                        return 1;
                }
            }

            double buffForDistancia(double distancia, Pista pistaC)
            {
                switch (distancia)
                {
                    case 800:
                        switch (pistaC.Longitud)
                        {
                            case 800:
                                return 1.30;
                            case 1200:
                                return 1.25;
                            case 1600:
                                return 1.20;
                            case 2000:
                                return 1.15;
                            case 2400:
                                return 1.10;
                            case 2800:
                                return 1.05;
                            case 3200:
                                return 1.00;
                            default:
                                return 1;
                        }
                    case 1200:
                        switch (pistaC.Longitud)
                        {
                            case 800:
                                return 1.25;
                            case 1200:
                                return 1.30;
                            case 1600:
                                return 1.25;
                            case 2000:
                                return 1.20;
                            case 2400:
                                return 1.15;
                            case 2800:
                                return 1.10;
                            case 3200:
                                return 1.05;
                            default:
                                return 1;
                        }
                    case 1600:
                        switch (pistaC.Longitud)
                        {
                            case 800:
                                return 1.20;
                            case 1200:
                                return 1.25;
                            case 1600:
                                return 1.30;
                            case 2000:
                                return 1.25;
                            case 2400:
                                return 1.20;
                            case 2800:
                                return 1.15;
                            case 3200:
                                return 1.10;
                            default:
                                return 1;
                        }
                    case 2000:
                        switch (pistaC.Longitud)
                        {
                            case 800:
                                return 1.10;
                            case 1200:
                                return 1.15;
                            case 1600:
                                return 1.20;
                            case 2000:
                                return 1.30;
                            case 2400:
                                return 1.25;
                            case 2800:
                                return 1.20;
                            case 3200:
                                return 1.15;
                            default:
                                return 1;
                        }
                    case 2400:
                        switch (pistaC.Longitud)
                        {
                            case 800:
                                return 1.10;
                            case 1200:
                                return 1.15;
                            case 1600:
                                return 1.20;
                            case 2000:
                                return 1.25;
                            case 2400:
                                return 1.30;
                            case 2800:
                                return 1.25;
                            case 3200:
                                return 1.20;
                            default:
                                return 1;
                        }
                    case 2800:
                        switch (pistaC.Longitud)
                        {
                            case 800:
                                return 1.05;
                            case 1200:
                                return 1.10;
                            case 1600:
                                return 1.15;
                            case 2000:
                                return 1.20;
                            case 2400:
                                return 1.25;
                            case 2800:
                                return 1.30;
                            case 3200:
                                return 1.25;
                            default:
                                return 1;
                        }
                    case 3200:
                        switch (pistaC.Longitud)
                        {
                            case 800:
                                return 1.00;
                            case 1200:
                                return 1.05;
                            case 1600:
                                return 1.10;
                            case 2000:
                                return 1.15;
                            case 2400:
                                return 1.20;
                            case 2800:
                                return 1.25;
                            case 3200:
                                return 1.30;
                            default:
                                return 1;
                        }
                    default:
                        return 1;
                }

            }
        }
    }
}