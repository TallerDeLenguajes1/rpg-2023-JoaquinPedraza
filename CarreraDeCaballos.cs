using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            HandlerDePersonajes handler = new HandlerDePersonajes();

            participantes = handler.LeerCaballos("../../../Caballos.json");

            if (!participantes.Any())
            {
                FabricaDeCaballos fabrica = new FabricaDeCaballos();
                participantes = fabrica.CrearCaballos();
                handler.GuardarCaballos("../../../Caballos.json", participantes);
            }

        }

        public Caballo Competir(Caballo caballo1, Caballo caballo2, List<string> dialogos)
        {

            var rnd = new Random();
            int trackLength = pista.Longitud / 4;
            int animationSpeed = 300; // Miliseconds between frames (adjust for desired speed)

            int horsePosition1 = 0;
            int horsePosition2 = 0;


            bool isHorse1Win = false;
            bool isHorse2Win = false;

            bool isSprintHorse1 = false;
            bool isSprintHorse2 = false;

            int movesWithSprint1 = 0;
            int movesWithSprint2 = 0;

            int firstmoves1 = 0;
            int firstmoves2 = 0;

            bool isAceleratedHorse1 = false;
            bool isAceleratedHorse2 = false;

            int comienzaSprintHorse1 = rnd.Next(1, pista.Longitud/4+1);
            int comienzaSprintHorse2 = rnd.Next(200, pista.Longitud/4+1);

            while (!isHorse1Win && !isHorse2Win)
            {
                Console.Clear();
                foreach (string dialogo in dialogos)
                {
                    Console.WriteLine(dialogo);
                }
                Console.WriteLine($"¡Comienza la carrera entre {caballo1.Nombre} y {caballo2.Nombre}!");
                Console.WriteLine("PISTA");
                Console.WriteLine("Longitud: " + pista.Longitud);
                Console.WriteLine("Clima: " + pista.Clima);

                if (horsePosition1 >= comienzaSprintHorse1)
                {
                    isSprintHorse1 = true;
                    movesWithSprint1++;
                    Console.WriteLine($"{caballo1.Nombre} comienza a correr a toda velocidad");
                }

                if(movesWithSprint1 == 10)
                {
                    isSprintHorse1 = false;
                    movesWithSprint1 = 0;
                    comienzaSprintHorse1 = pista.Longitud+200;
                }

                if (horsePosition2 >= comienzaSprintHorse1)
                {
                    isSprintHorse2 = true;
                    movesWithSprint2++;
                    Console.WriteLine($"{caballo2.Nombre} comienza a correr a toda velocidad");
                }

                if (movesWithSprint2 == 10)
                {
                    isSprintHorse2 = false;
                    movesWithSprint2 = 0;
                    comienzaSprintHorse1 = pista.Longitud + 200;
                }

                if(firstmoves1 <= 10)
                {
                    isAceleratedHorse1 = true;
                    firstmoves1++;
                    Console.WriteLine($"{caballo1.Nombre} comienza a acelerarce");
                } else
                {
                    isAceleratedHorse1 = false;
                }

                if (firstmoves2 <= 10)
                {
                    isAceleratedHorse2 = true;
                    firstmoves2++;
                    Console.WriteLine($"{caballo2.Nombre} comienza a acelerarce");
                } else
                {
                    isAceleratedHorse2 = false;
                }

                // Move the horse forward
                horsePosition1 += caballo1.Avanzar(pista, isSprintHorse1, isAceleratedHorse1) / 4;
                horsePosition2 += caballo2.Avanzar(pista, isSprintHorse2, isAceleratedHorse2) / 4;

                DrawHorses(horsePosition1, horsePosition2, trackLength, dialogos);

                // Check if the horse reached the end of the track

                if (horsePosition1 > trackLength || horsePosition2 > trackLength)
                {
                    if (horsePosition1 > trackLength && horsePosition1 > horsePosition2)
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

            //Console.ReadKey();

            // Simular el tiempo de carrera (se puede ajustar para hacerlo más realista)
            //int tiempoCaballo2 = rnd.Next(1000, 2000);

            //Console.WriteLine($"Tiempo de {caballo1.Nombre}: {tiempoCaballo1} ms");
            //Console.WriteLine($"Tiempo de {caballo2.Nombre}: {tiempoCaballo2} ms");

            Console.WriteLine($"¡{caballo1.Nombre} ha ganado la carrera!");
            dialogos.Add($"¡{caballo1.Nombre} ha ganado la carrera!");

            return isHorse1Win ? caballo1 : caballo2;
        }

        public Caballo ObtenerGanador()
        {

            if (participantes.Count == 0)
                return null;

            return participantes[0];
            Console.WriteLine("¡Felicidades al ganador!");
            return participantes[0];
        }

        public void RealizarTorneo()
        {


            int rondas = (int)Math.Ceiling(Math.Log(participantes.Count, 2));
            List<string> dialogos = new List<string>();
             
            for (int ronda = 1; ronda <= rondas; ronda++)
            {

                Console.WriteLine($"===== Ronda {ronda} =====");
                switch (rondas)
                {
                    case 1:
                        Console.WriteLine("¡Comienza la final!");
                        dialogos.Add("¡Comienza la final!");
                        break;
                    case 2:
                        if (ronda == 1)
                        {
                            Console.WriteLine("¡Comienzan las semifinales!");
                            dialogos.Add("¡Comienzan las semifinales!");
                        }
                        else
                        {
                            Console.WriteLine("¡Comienza la final!");
                            dialogos.Add("¡Comienza la final!");
                        }
                        break;

                    case 3:
                        if (ronda == 1)
                        {
                            Console.WriteLine("¡Comienzan los cuartos de final!");
                            dialogos.Add("¡Comienzan los cuartos de final!");
                        }
                        else if (ronda == 2)
                        {
                            Console.WriteLine("¡Comienzan las semifinales!");
                            dialogos.Add("¡Comienzan las semifinales!");
                        }
                        else
                        {
                            Console.WriteLine("¡Comienza la final!");
                            dialogos.Add("¡Comienza la final!");
                        }
                        break;
                    case 4:
                        if (ronda == 1)
                        {
                            Console.WriteLine("¡Comienzan los octavos de final!");
                            dialogos.Add("¡Comienzan los octavos de final!");
                        }
                        else if (ronda == 2)
                        {
                            Console.WriteLine("¡Comienzan los cuartos de final!");
                            dialogos.Add("¡Comienzan los cuartos de final!");
                        }
                        else if (ronda == 3)
                        {
                            Console.WriteLine("¡Comienzan las semifinales!");
                            dialogos.Add("¡Comienzan las semifinales!");
                        }
                        else
                        {
                            Console.WriteLine("¡Comienza la final!");
                            dialogos.Add("¡Comienza la final!");
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
                        Caballo ganadorRonda = Competir(participantes[i], participantes[i + 1], dialogos);
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
            dialogos.Add($"El ganador del torneo es: {participantes[0].Nombre}!");
        }
        public void DrawHorses(int position1, int position2, int trackLength, List<string> dialogos)
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

            if (trackLength - position1 <= 160 && (trackLength - position1) <= 160 - positionRelative1)
            {

                if ((trackLength - position1 - 4) >= 0)
                {
                    Console.WriteLine(new string('-', 160));
                    Console.WriteLine(new string(' ', positionRelative1) + "|01|" + new string(' ', trackLength - position1 - 4) + "||");
                    Console.WriteLine(new string('-', 160));
                }
                else
                {
                    Console.WriteLine(new string('-', 160));
                    Console.WriteLine(new string(' ', positionRelative1 - Math.Abs(trackLength - position1 - 4) - 2) + "||" + "  " + "|01|");
                    Console.WriteLine(new string('-', 160));

                    //dialogos.Add(new string('-', 160));
                    //dialogos.Add(new string(' ', positionRelative1 - Math.Abs(trackLength - position1 - 4) - 2) + "||" + "  " + "|01|");
                    //dialogos.Add(new string('-', 160));
                }
            }
            else
            {
                Console.WriteLine(new string('-', 160));
                Console.WriteLine(new string(' ', positionRelative1) + "|01|");
                Console.WriteLine(new string('-', 160));
            }
            if (trackLength - position2 <= 160 && (trackLength - position2) <= 160 - positionRelative2)
            {
                if ((trackLength - position2 - 4) >= 0)
                {
                    Console.WriteLine(new string('-', 160));
                    Console.WriteLine(new string(' ', positionRelative2) + "|02|" + new string(' ', trackLength - position2 - 4) + "||");
                    Console.WriteLine(new string('-', 160));
                } else
                {
                    Console.WriteLine(new string('-', 160));
                    Console.WriteLine(new string(' ', positionRelative2- Math.Abs(trackLength - position2 - 4)-2)+"||"+ "  " + "|02|");
                    Console.WriteLine(new string('-', 160));

                    //dialogos.Add(new string('-', 160));
                    //dialogos.Add(new string(' ', positionRelative2 - Math.Abs(trackLength - position2 - 4) - 2) + "||" + "  " + "|02|");
                    //dialogos.Add(new string('-', 160));
                }
            }
            else
            {
                Console.WriteLine(new string('-', 160));
                Console.WriteLine(new string(' ', positionRelative2) + "|02|");
                Console.WriteLine(new string('-', 160));
            }
        }


    }
}
