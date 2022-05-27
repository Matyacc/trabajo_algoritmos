/*
 * Created by SharpDevelop.
 * User: accia
 * Date: 27/5/2022
 * Time: 09:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace Clinica
{
	/// <summary>
	/// Description of Clinica.
	/// </summary>
	public class Clinica
	{	
		string nombre;
		private ArrayList _medicos = new ArrayList(); 
		private ArrayList _pacientes = new ArrayList();
		private ArrayList _servicios = new ArrayList();
		
		public Clinica(string nombre)
		{
			this.nombre = nombre;
		}
		
		
		public ArrayList  medicos{
			get{
				return _medicos;
			}}
			
			public ArrayList servicios{
				get{
					return _servicios;
				}
			}
		}
	}

