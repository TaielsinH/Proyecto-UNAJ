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
		
		public void agregarAbogado(){
			if (cant < 5) { //si hay menos de 5 abogados
				Console.Write("Ingrese DNI del abogado: ");
				int dni = int.Parse(Console.ReadLine());
				int i = 0;
				bool verificar = false;
				while((i<cant)&&(verificar == false)){
					if (abogadosContratados[i].Dni == dni){
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
					Console.WriteLine("");
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

        public void agregarExpediente(){
        	Console.Write("ingrese numero de expediente: ");
        	int numExp = int.Parse(Console.ReadLine()); //verifico si ya existe el expediente
        	bool saber = verificarExpediente(numExp);
            if (saber == false){
        		Console.Write("ingrese nombre del titular: ");
        		string titular = Console.ReadLine();
        		Console.Write("ingrese nombre del tramite: ");
        		string tramite = Console.ReadLine();
        		Console.Write("Ingrese la fecha en formato aaaa/mm/dd solo con numeros: ");
        		string ingresoFecha = Console.ReadLine();
        		char separador = '/'; //defino caracter que es criterio de division de string
        		string [] partes = ingresoFecha.Split(separador); //divido el string ingresado y lo pongo en un vector
        		int año = int.Parse(partes[0]);
        		int mes = int.Parse(partes[1]);
        		int dia = int.Parse(partes[2]);      //defino variables con partes del vector
        		DateTime fecha = new DateTime(año, mes, dia); //Acá termina el código para la fecha
        		Expediente exp = new Expediente(numExp, titular, tramite, fecha); //creo el expediente
        		bool salir = false;
        		int aux;
        		while (!salir){ 
                    try{
        				if (cant != 0){
        					Console.Write("seleccione el abogado al que desea asignarle (0 - " + (cant - 1) + ")el expediente o ingrese -1 para salir: ");
        					aux = int.Parse(Console.ReadLine());
        					if (aux > -1 && aux < cant){
        						if (abogadosContratados[aux].CantExpedientes < 6){    //asignacion del expediente
        							exp.DNIAbogado = abogadosContratados[aux].Dni;
        							abogadosContratados[aux].asignarExpediente(exp.Numero);
        							salir = true;
        							listaExpediente.Add(exp);
        							Console.WriteLine("\nse asigno con exito el expediente \n");
        						}
        						else{
        							throw new ExcepcionExpedientes();
        						}
        					}
        					else{
        						if (aux == -1){ //si elijo salir
        							salir = true;
        						}
        						else{
        							Console.WriteLine("la opcion ingresada no es valida, trate de nuevo \n");
        						}
        					}
        				}
        				else{        //si no se agregaron abogados al buffet
        					Console.WriteLine("no hay abogados contratados, se aborta la asignacion \n");
        					salir = true;
        				}
                    }
                    catch (ExcepcionExpedientes){
        				Console.WriteLine("el abogado ya tiene 6 expedientes, trate con otro \n");
                    }
        			catch (Exception){
        				Console.WriteLine("se produjo una excepcion desconocida \n");
        			}
                }
            }
            else {
            	Console.WriteLine("El expediente ya existe \n");
            }
        }
        
        public bool verificarExpediente(int numExp)//controla si existe el expediente
        {
        	bool verificar = false;
        	Expediente e;
        	for(int i = 0; i<listaExpediente.Count ; i++){
        		e = (Expediente)listaExpediente[i];
        		if (e.Numero == numExp){
        			verificar = true;
        			break;
        		}
            }
            return verificar;
        }
        
        public void modificar_estado_expediente(){
        	Console.Write("ingrese el numero de expediente que desea modificar: ");
        	int num = int.Parse(Console.ReadLine());
        	int pos;
        	bool tiene = false;
        	Expediente aux = new Expediente();
			for (int i = 0; i < listaExpediente.Count; i++){
        		aux = (Expediente)listaExpediente[i];
        		if (num == aux.Numero){
					tiene = true;
					pos = i;
					break;
				}
			}
        	if (tiene){
        		aux.Estado = !(aux.Estado);
        		Console.WriteLine("se modifico el expediente correctamente\n");
        	}
        	else{
        		Console.WriteLine("no existe el numero de expediente ingresado\n");
        	}        	
        }
		public void Eliminar_Expediente_Por_Numero()
		{
			Console.Write("Ingrese el número e expediente a eliminar: ");
			int numE = int.Parse(Console.ReadLine());
			Expediente aux = new Expediente();
			bool encontrado = false; //true = encontró el elemento con el numero. false = no lo encontró
			
			
			for (int i = 0; i< listaExpediente.Count; i++)
			{
				
				aux = (Expediente)listaExpediente[i];
				if (numE == aux.Numero){
					auxiliarEliminar(aux);
					listaExpediente.RemoveAt(i);
					encontrado = true;
					
				}
			}
			if (encontrado){
				Console.WriteLine("Se borró el expediente pedido\n");
			}
			else{
				Console.WriteLine("No existe el expediente con el número ingresado\n");
			}
		}
		public void auxiliarEliminar(Expediente aux)
		{
			for (int i = 0; i<abogadosContratados.Length; i++)
			{
//				Abogado abo = new Abogado();
//				abo = abogadosContratados[i];
				int dni1 = (int) aux.DNIAbogado;
				
				if (dni1 == (int)abogadosContratados[i].Dni)
				{
					int expedientePedido = (int) aux.Numero;
					abogadosContratados[i].eliminarExpediente(expedientePedido);
					break;
						
				}
			}
		}
	
	}
}
