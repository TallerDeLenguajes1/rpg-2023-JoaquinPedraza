// See https://aka.ms/new-console-template for more information
using ProyectoTaller;

Console.WriteLine("Hello, World!");

FabricaDeCaballos fabrica = new FabricaDeCaballos();

List<Caballo> participantes = fabrica.CrearCaballos();

Caballo caballo = fabrica.CrearCaballo();


Console.WriteLine("Helloworld!");