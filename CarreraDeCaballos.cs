using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller
{
    public class CarreraDeCaballos
    {
       
        private List<Caballo>? participantes;
        private Pista pista = new Pista();
        private Random rnd = new Random();

        public void ObtenerParticipantes()
        {
            FabricaDeCaballos fabrica = new FabricaDeCaballos();
            participantes = fabrica.CrearCaballos();

        }

        public Caballo Competir(Caballo caballo1, Caballo caballo2)
        {
            Console.WriteLine($"¡Comienza la carrera entre {caballo1.Nombre} y {caballo2.Nombre}!");

            int horsePosition1 = 0;
            int horsePosition2 = 0;
            int trackLength = pista.Longitud/4;
            int animationSpeed = 300; // Miliseconds between frames (adjust for desired speed)

            bool isHorse1Win = false;
            bool isHorse2Win = false;

            bool isSprintHorse1 = false;
            bool isSprintHorse2 = false;

            bool isAceleratedHorse1 = false;
            bool isAceleratedHorse2 = false;

            while (!isHorse1Win && !isHorse2Win)
            {
                Console.Clear();
                Console.WriteLine($"¡Comienza la carrera entre {caballo1.Nombre} y {caballo2.Nombre}!");
                DrawHorses(horsePosition1, horsePosition2, trackLength);

                // Move the horse forward
                horsePosition1 += caballo1.Avanzar(pista, isSprintHorse1, isAceleratedHorse1)/4;
                horsePosition2 += caballo2.Avanzar(pista, isSprintHorse2, isAceleratedHorse2)/4;

                //horsePosition1 += rnd.Next(20, 101)/20;
                //horsePosition2 += rnd.Next(20, 101)/20;

                // Check if the horse reached the end of the track

                if (horsePosition1 > trackLength || horsePosition2 > trackLength)
                {
                    if(horsePosition1 > trackLength && horsePosition1 > horsePosition2)
                    {
                        isHorse1Win = true;
                    }
                    else if (horsePosition2 > trackLength && horsePosition2 > horsePosition1)
                    {
                        isHorse2Win = true;
                    }
                    else if (horsePosition1 == horsePosition2)
                    {
                        horsePosition1 = 0;
                        horsePosition2 = 0;
                    }
                }

                Thread.Sleep(animationSpeed);
            }



            // Simular el tiempo de carrera (se puede ajustar para hacerlo más realista)
            //int tiempoCaballo1 = rnd.Next(1000, 2000);
            //int tiempoCaballo2 = rnd.Next(1000, 2000);

            //Console.WriteLine($"Tiempo de {caballo1.Nombre}: {tiempoCaballo1} ms");
            //Console.WriteLine($"Tiempo de {caballo2.Nombre}: {tiempoCaballo2} ms");

            return isHorse1Win ? caballo1 : caballo2;
        }

        public Caballo ObtenerGanador()
        {
            if (participantes.Count == 0)
                return null;

            return participantes[0];
        }

        public void RealizarTorneo()
        {
            int rondas = (int)Math.Ceiling(Math.Log(participantes.Count, 2));

            for (int ronda = 1; ronda <= rondas; ronda++)
            {


                Console.WriteLine($"===== Ronda {ronda} =====");
                switch (rondas)
                {
                    case 1:
                        Console.WriteLine("¡Comienza la final!");
                        break;
                    case 2:
                        if (ronda == 1)
                        {

                            Console.WriteLine("¡Comienzan las semifinales!");
                        } else
                        {

                            Console.WriteLine("¡Comienza la final!");
                        }
                        break;

                    case 3:
                        if(ronda == 1)
                        {
                            Console.WriteLine("¡Comienzan los cuartos de final!");
                        } else if (ronda == 2)
                        {
                            Console.WriteLine("¡Comienzan las semifinales!");
                        } else
                        {
                            Console.WriteLine("¡Comienza la final!");
                        }
                        break;
                    case 4:
                        if (ronda == 1)
                        {
                            Console.WriteLine("¡Comienzan los octavos de final!");
                        } else if (ronda == 2)
                        {
                            Console.WriteLine("¡Comienzan los cuartos de final!");
                        } else if (ronda == 3)
                        {
                            Console.WriteLine("¡Comienzan las semifinales!");
                        } else
                        {
                            Console.WriteLine("¡Comienza la final!");
                        }
                        break;
                    default:
                        break;
                }

                List<Caballo> ganadoresRonda = new List<Caballo>();

                for (int i = 0; i < participantes.Count; i += 2)
                {
                    if (i + 1 < participantes.Count)
                    {
                        Caballo ganadorRonda = Competir(participantes[i], participantes[i + 1]);
                        ganadoresRonda.Add(ganadorRonda);
                    }
                    else
                    {
                        ganadoresRonda.Add(participantes[i]);
                    }
                }

                participantes = ganadoresRonda;
            }

            Console.WriteLine($"El ganador del torneo es: {participantes[0].Nombre}!");
        }
        static void DrawHorses(int position1, int position2, int trackLength)
        {
            int positionRelative1 = position1;
            if (positionRelative1 >= 160)
            {
                while (positionRelative1 >= 160)
                {
                    positionRelative1 -= 160;
                }
            }

            int positionRelative2 = position2;
            if (positionRelative2 >= 160)
            {
                while (positionRelative2 >= 160)
                {
                    positionRelative2 -= 160;
                }
            }
            if (trackLength - position1 <= 160 || trackLength - position2 <= 160)
            {
                // Draw the track
                Console.WriteLine(new string('-', 160));

                // Draw the horse at the current position
                Console.WriteLine(new string(' ', positionRelative1) + "|01|" + new string(' ', 160 - positionRelative1)+"||");
                Console.WriteLine(new string(' ', positionRelative2) + "|02|" + new string(' ', 160 - positionRelative2) +"||");

                // Draw the track
                Console.WriteLine(new string('-', 160));
            } else
            {
                // Draw the track
                Console.WriteLine(new string('-', 160));

                // Draw the horse at the current position
                Console.WriteLine(new string(' ', positionRelative1) + "|01|");
                Console.WriteLine(new string(' ', positionRelative2) + "|02|");

                // Draw the track
                Console.WriteLine(new string('-', 160));
            }
        }
    }
}
