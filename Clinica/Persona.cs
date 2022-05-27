/*
 * Created by SharpDevelop.
 * User: accia
 * Date: 26/5/2022
 * Time: 12:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Clinica
{
	/// <summary>
	/// Description of Persona.
	/// </summary>
	public class Persona
	{
		private string Nombre, Apellido;
		private int Dni;
		
		public Persona(string Nombre,string Apellido,int Dni)
		{
			this.Nombre = Nombre;
			this.Apellido = Apellido;
			this.Dni = Dni;
		}
		
		
		public string nombre{
			get{
				return Nombre;
			}
		}
		
		public string apellido{
			get{
				return Apellido;
			}
		}
		
		public int dni{
			get{
				return Dni;
			}
		}
	}
}
