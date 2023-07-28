// See https://aka.ms/new-console-template for more information
using ProyectoTaller;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;


CarreraDeCaballos carrera = new CarreraDeCaballos();


carrera.Bienvenida();
carrera.ObtenerParticipantes();
carrera.RealizarTorneo();
carrera.ObtenerGanador();

Console.WriteLine("Helloworld!");

