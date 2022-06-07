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
	/// Description of Expediente.
	/// </summary>
	public class Expediente
	{
		private int numero;
		private string titular;
		private string tipo_tramite;
		private bool estado;
		private int DNIabogado;
		private DateTime fecha;
		
		public Expediente(){}
		
		public Expediente(int numero, string titular, string tipo_tramite, DateTime fecha)
		{
			this.numero = numero;
			this.titular = titular;
			this.tipo_tramite = tipo_tramite;
			estado = false;
			this.fecha = fecha;
		}
		
		public int Numero{
			set{numero = value;}
			get{return numero;}
		}
		
		public int DNIAbogado{
			set{DNIabogado = value;}
			get{return DNIabogado;}
		}
		
		public string Titular{
			set{titular = value;}
			get{return titular;}
		}
		
		public string Tipo_Tramite{
			set{titular = value;}
			get{return titular;}
		}
		
		public bool Estado{
			set{estado = value;}
			get{return estado;}
		}
		
		public void mostrarInfoExp(){
			Console.WriteLine("Número: {0}, Titular: {1}, Tipo de Tramite: {2}, Estado: {3}, DNI del abogado a cargo: {4} \n", numero, titular, tipo_tramite, estado, DNIabogado);
		}
		
	}
}