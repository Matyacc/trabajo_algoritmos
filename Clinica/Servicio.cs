/*
 * Created by SharpDevelop.
 * User: accia
 * Date: 26/5/2022
 * Time: 12:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
*
* 
*  Cada servicio tiene un jefe, una especialidad, un cupo de camas
* libres, el plantel de médicos que trabajan en él y la lista de pacientes internados.
* 
* 
 */
using System;
using System.Collections;

namespace Clinica
{
	/// <summary>
	/// Description of Servicio.
	/// </summary>
	public class Servicio
	{
		private Persona Jefe;
		private string Especialidad;
		private ArrayList Plantel = new ArrayList();
		private ArrayList Pacientes = new ArrayList();
		private int Camas;
		
		/*CONSTRUCTOR*/
		public Servicio(Persona jf, string esp, int cantCamas)
		{
			this.Jefe = jf;
			this.Especialidad = esp;
			this.Camas = cantCamas;
			
		}
		
		/*METODOS*/
		public void agregarMedico(Medico med)
		{
			Plantel.Add(med);
		}
		
		
		
		public void eliminarMedico(Medico med){
			Plantel.Remove(med);
		}
		
		public void internarPaciente(Paciente pac)
		{
			Pacientes.Add(pac);
			Camas -= 1;
		}
		
		public void altaPaciente(Paciente pac){
			Pacientes.Remove(pac);
			Camas += 1;
		}
		
		
		/*SETTER Y GETTER*/
		public Persona jefe{
			set {
				Jefe = value;
			}
			get{
				return Jefe;
			}
		}
		
		public string especialidad{
			set{
				Especialidad = value;
			}
			get{
				return Especialidad;
			}
		}
		
		public int camas{
			set{Camas = value;}
			get{return Camas;}
		}
		
		public ArrayList plantel{
			get{
				return Plantel;
			}
		}
		
		public ArrayList pacientes{
			get{
				return Pacientes;
			}
		}
		
		}
	
	}

