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

namespace Clinica
{
	/// <summary>
	/// Description of Medico.
	/// </summary>
	public class Medico : Persona
	{	
		private string Especialidad, Horario;
		private int Legajo;
		
		
		public Medico(String No, String Ap, int dni, int legajo, string especialidad, string horario) : base (No,Ap,dni)
		{
			this.Legajo = legajo;
			this.Especialidad = especialidad;
			this.Horario = horario;
		}
		
		public string especialidad{
			get{return Especialidad;}
		}
		public string horario{
			get{return Horario;}
		}
		public int legajo{
			get{return legajo;}
		}
		}
	}

