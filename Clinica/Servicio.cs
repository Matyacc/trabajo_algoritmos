﻿/*
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
		
		
		public Servicio(Persona jf, string esp, int cantCamas)
		{
			this.Jefe = jf;
			this.Especialidad = esp;
			this.Camas =  cantCamas;
		}

		public Persona jefe{
			get{return Jefe;}
		}
	
	}
}