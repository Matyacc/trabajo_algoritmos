/*
 * Created by SharpDevelop.
 * User: accia
 * Date: 26/5/2022
 * Time: 13:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * 
 * De cada paciente se conoce su dni, nombre y apellido, diagnostico .
 * 
 */
using System;

namespace Clinica
{
	/// <summary>
	/// Description of Paciente.
	/// </summary>
	public class Paciente : Persona
	{
		private string Diagnostico,medicoACargo;
		
		public Paciente(string no, string ap, int dni, string diag, string legajoDelMedico) : base (no,ap,dni)
		{
			this.Diagnostico = diag;
			this.medicoACargo = legajoDelMedico;
		}
		
		public override void imprimir(){
			Console.WriteLine("--------------------------------------------------------");
			Console.WriteLine("Dni: " + base.dni);
			Console.WriteLine("Nombre del paciente: " + base.nombre + " " + base.apellido);
			Console.WriteLine("Medico a cargo: " + medicoACargo);
			Console.WriteLine("--------------------------------------------------------");
		}
		
		public string diagnostico{
			get{ return Diagnostico;}
		}
		
		public string medicoAcargo{
			get{
				return medicoACargo;
			}
		}
		
		}
	}

