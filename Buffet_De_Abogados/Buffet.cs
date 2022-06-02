/*
 * Creado por SharpDevelop.
 * Usuario: Emi
 * Fecha: 21/05/2022
 * Hora: 18:08
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace Buffet_De_Abogados
{
	/// <summary>
	/// Description of Buffet.
	/// </summary>
	public class Buffet
	{
		private string name; //nombre buffet
		private Abogado [] abogadosContratados; //vector de abogados
		private int cant; // cantidad de abogados
		private ArrayList listaExpediente = new ArrayList(); 
		
		public Buffet(string name)
		{
			this.name = name;
			abogadosContratados = new Abogado[5];
			cant = 0;
		}
		
		public string Name{
			set{name = value;}
			get{return name;}
		}
		
//		public Abogado [] AbogadosContratados{
//			get{return abogadosContratados;}
//		}
		
		public void agregarAbogado(){
			if (cant < 5) { //si hay menos de 5 abogados
				Console.Write("Ingrese DNI del abogado: ");
				int dni = int.Parse(Console.ReadLine());
				int i = 0;
				bool verificar = false;
				while((i<cant)&&(verificar == false)){
					if(abogadosContratados[i].Dni == dni){
						verificar = true;
					}
					i++;
				}
				if(verificar == false){
					Console.Write("Ingrese nombre del abogado: ");
					string nombre = Console.ReadLine();
					Console.Write("Ingrese apellido del abogado: ");
					string apellido = Console.ReadLine();
					Console.Write("Ingrese especialidad del abogado: ");
					string especialidad = Console.ReadLine();
					Abogado a1 = new Abogado (nombre, apellido, dni, especialidad);
					abogadosContratados[cant] = a1;
					a1.mostrarInfoAbg();
					cant++;
				}
				else 
					Console.WriteLine("El abogado ya existe: ");
			} 
			else
				Console.WriteLine("ya no se pueden agregar mas abogados");	
		}
		
		public void eliminarAbogado(){
			int k = 0;
			bool existe = false;
			Console.Write("Ingrese DNI del abogado a eliminar: ");
			int dni = int.Parse(Console.ReadLine());
			for(int i = 0; i<cant; i++){
				if(abogadosContratados[i].Dni == dni){ //si el dni del abogado es igual al que buscamos guardo la posicion y salgo
					k = i;
					existe = true; //existe el dni ingresado
					break;
				}
			}
			if (existe){ //nesecito tomar en cuenta el caso de que el dni ingresado no exista
				for (int j = k; j < cant; j++){
					abogadosContratados[j] = abogadosContratados[j+1]; //desplazo el vector para pisar el dato a eliminar
				}
				abogadosContratados[cant] = null; //guardo en el lugar del ultimo abogado un null
				cant--; //disminuyo la cantidad de abogados
				Console.WriteLine("Se ha eliminado el abogado correctamente");
			}
			else{
				Console.WriteLine("el dni ingresado no existe");
			}	
		}
		
		public void listadoAbogados()
        {
			Console.WriteLine("");
            for (int i = 0; i < cant; i++)
            {
                abogadosContratados[i].mostrarInfoAbg();
            }
        }
		
        public void listadoExpediente()
        {
            foreach (Expediente exp in listaExpediente)
            {
                exp.mostrarInfoExp();
            }
        }

//        public void agregarExpediente(){
//        	Console.WriteLine("ingrese numero de expediente: ");
//        	int numExp = int.Parse(Console.ReadLine()); //verifico si ya existe el expediente
//        	bool saber = verificarExpediente(numExp);
//            if (saber == false){
//        		Console.WriteLine("ingrese nombre del titular: ");
//        		string titular = Console.ReadLine();
//        		Console.WriteLine("ingrese nombre del tramite: ");
//        		string tramite = Console.ReadLine();
//        		Expediente exp = new Expediente(numExp, titular, tramite, DateTime.Today);
//                for (int i = 0; i<cant; i++){
//                    try{
//                        if (abogadosContratados[i].Dni == ab.Dni){
//                            if (abogadosContratados[i].CantExpedientes <= 6){
//                                ab.CantExpedientes++;
//                                ab.asignarExpediente(exp);
//                                Console.WriteLine("El expediente fue asignado con exito");
//                            }
//
//                            else{
//                                throw new ExcepcionExpedientes();
//                            }
//                        }
//                    }
//
//                    catch (ExcepcioExpedientes){
//                        Console.WriteLine("El abogado ya tiene 6 expedientes a cargo, los abogados que pueden tienen disponibilidad son: ");
//                        int j = 0;
//                        for (int k = 0; k<cant; i++){
//                            if (abogadosContratados[i].CantExpedientes <= 6){
//                                abogadosContratados[i].mostrarInfoAbg();
//                                j++;
//                            }
//                        }
//                        if (j >= 1){
//                            Console.WriteLine("Que abogado deseas elegir de los disponibles: (Ingresa du DNI)");
//                            int dni1 = int.Parse(Console.ReadLine());
//                            for (int q = 0; q < abogadosContratados.Length; q++){
//                                if (abogadosContratados[q].Dni == dni1){
//                                    abogadosContratados[q].asignarExpediente(exp);
//                                    abogadosContratados[q].CantExpedientes++;
//                                    break;
//                                }
//                            }
//                        }
//                        else{
//                            Console.WriteLine("Lo sentimos, no tenemos abogados disponibles por el momento");
//                        }
//                    }
//                }
//            }
//            else {
//            	Console.WriteLine("El expediente ya existe");
//            }
//        }
//        
//        public bool verificarExpediente(int numExp)//controla si existe el expediente
//        {
//        	bool verificar;
//        	for(int i = 0; i<listaExpediente.Count ; i++){
//        		verificar = abogadosContratados[i].tieneExpediente(numExp);
//        		if(!verificar){
//        			break;
//        		}
//            }
//            return verificar;
//        }
	}
}
