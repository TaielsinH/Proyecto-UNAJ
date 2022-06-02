/*
 * Creado por SharpDevelop.
 * Usuario: Emi
 * Fecha: 21/05/2022
 * Hora: 18:07
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Buffet_De_Abogados
{
	class Program
	{
		public static void Main(string[] args)
		{
			Buffet b1 = new Buffet("Buffet Abogados"); //creo el buffet
			bool condicion = false;
			string r; //condicion para el bucle
//			DateTime fecha_main = new DateTime(2022, 5, 22); //fecha entrega
//			Console.WriteLine(fecha_main);
//          Expediente exp1 = new Expediente(2, "D", "P", fecha_main);
//          Abogado a1 = new Abogado("g", "r", 3, "l");
			while (!condicion){
				Console.WriteLine("MENU:");
				Console.WriteLine("a) Agregar abogado");
				Console.WriteLine("b) Eliminar abogado");
				Console.WriteLine("c) Listado de abogados");
				Console.WriteLine("d) Listado de expedientes");
				Console.WriteLine("e) Agregar un nuevo expediente al estudio y asignárselo a un abogado dado");
				Console.WriteLine("f) Modificar el estado de un expediente determinado");
				Console.WriteLine("g) Eliminar expediente por numero");
				Console.WriteLine("h) Listado de expedientes de tipo ‘audiencia’ que se hayan presentado en un mes determinado indicando en cada caso quién es el abogado encargado del mismo");
				Console.WriteLine("i) Salir del programa");
				Console.Write("seleccione una opcion del menu: ");
				r = Console.ReadLine();
				switch(r){
					case "a":
						b1.agregarAbogado();
						break;
					case "b":
						b1.eliminarAbogado();
						break;
					case "c":
						b1.listadoAbogados();
						break;
					case "d":
						b1.listadoExpediente();
						break;
//					case "e":
//						b1.agregarExpediente(exp1, a1);
//						break;
//					case "f":
//						b1.Modificar_expediente();
//						break;
//					case "g":
//						b1.Eliminar_Expediente_Por_Numero();
//						break;
//					case "h":
//						b1.Imprimir_Audiencias_mes();
//					break;
					case "i":
						condicion = true; //salgo del bucle
						break;
					default:
						Console.WriteLine("no existe la opcion ingresada");
						break;
				}
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public class ExcepcionExpedientes : Exception {}
	}
}