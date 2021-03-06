/*
 * Created by SharpDevelop.
 * User: accia
 * Date: 26/5/2022
 * Time: 12:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * 
 * 
 * Cada médico tiene un dni, legajo, nombre, especialidad, horario que cumple en el servicio (mañana, tarde o noche). 
 * 
 */
using System;
using System.Collections;

namespace Clinica
{
	/// <summary>
	/// Description of Medico.
	/// </summary>
	public class Medico : Persona
	{	
		private string Especialidad, Legajo, Horario;

		
		//CONSTRUCTOR
		public Medico(String No, String Ap, int dni, string legajo, string especialidad, string horario) : base (No,Ap,dni)
		{
			this.Legajo = legajo;
			this.Especialidad = especialidad;
			this.Horario = horario;
		}
		
		//METODOS
		public override void imprimir(){
			Console.WriteLine("-----------------------");
			Console.WriteLine("legajo: " + Legajo);
			Console.WriteLine("Dni: " + base.dni);
			Console.WriteLine("Nombre: " + base.nombre);
			Console.WriteLine(base.apellido);
			Console.WriteLine("-----------------------");
		}
		
		/*SETTER Y GETTER*/
		public string especialidad{
			get{return Especialidad;}
		}
		public string horario{
			get{return Horario;}
		}
		public string legajo{
			get{return Legajo;}
		}

		}
	}

