using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        int velocidad;  //entre 50-65(3), 65-85(4), 85-105(5)
        int energEsprint; //entre 50-65(3), 65-85(4), 85-105(5)
        int aceleracion;  //entre 50-65(3), 65-85(4), 85-105(5)
        int agilidad;   //entre 50-65(3), 65-85(4), 85-105(5)
        int salto;     //entre 50-65(3), 65-85(4), 85-105(5)
        int distancia; //entre 800 - 3200
        TipoPista pista; //MUY BLANDA/BLANDA/MEDIA/FIRMA/DURA/MUY DURA
        int estrellas; //entre 3 y 5


        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int EnergEsprint { get => energEsprint; set => energEsprint = value; }
        public int Aceleracion { get => aceleracion; set => aceleracion = value; }
        public int Agilidad { get => agilidad; set => agilidad = value; }
        public int Salto { get => salto; set => salto = value; }
        public int Distancia { get => distancia; set => distancia = value; }
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
    }


}