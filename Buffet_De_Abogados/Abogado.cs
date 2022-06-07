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
	/// <summary>
	/// Description of Abogado.
	/// </summary>
	public class Abogado
	{
		private string nombre;
		private string apellido;
		private int dni;
		private string especialidad;
		private int cantExpediente;
		private int? [] vectorExpedientes;
		
		public Abogado (){}
		
		public Abogado(string nombre,string apellido,int dni, string especialidad)
		{
			this.nombre=nombre;
			this.apellido=apellido;
			this.dni=dni;
			this.especialidad=especialidad;
			cantExpediente = 0;	
			vectorExpedientes = new int?[6];
		}
		
		public string Nombre{
			set{nombre = value;}
			get{return nombre;}
		}
		
		public string Apellido{
			set{apellido = value;}
			get{return apellido;}
		}
		
		public int Dni{
			set{dni = value;}
			get{return dni;}
		}
		
		public string Especialidad{
			set{especialidad = value;}
			get{return especialidad;}
		}
		
		public int CantExpedientes{
			set {cantExpediente = value;}
			get{return cantExpediente;}
		}
		
		public bool tieneExpediente (int f1){
			bool tiene = false;
			for (int i = 0; i < cantExpediente; i++){
				if (f1 == vectorExpedientes[i]){
					tiene = true;
					break;
				}
			}
			return tiene;
		}
		
		public void mostrarInfoAbg()
        {
            Console.WriteLine("Nombre: {0}, Apellido: {1}, DNI: {2}, Especialidad: {3}, Expedientes a Cargo: {4} \n", nombre, apellido, dni, especialidad, cantExpediente);
        }

        public void asignarExpediente(int exp)
        {
        	vectorExpedientes[cantExpediente] = exp;
        	cantExpediente++;
        }
        
        public void eliminarExpediente(int exp)
        {
        	for (int i = 0; i<vectorExpedientes.Length; i++)
        	{
        		if (vectorExpedientes[i] == exp)
        		{
        			vectorExpedientes[i] = null;
        			cantExpediente = cantExpediente - 1;
        		}
        	}
        }
        
	}
}
