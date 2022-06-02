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
		private string Nombre;
		private ArrayList _servicios = new ArrayList();
		
		public Clinica(string Nombre)
		{
			this.Nombre = Nombre;
		}
		
		public string nombre{
			get{
				return Nombre;
			}
		}
		
			public ArrayList servicios{
				get{
					return _servicios;
				}
			}
		}
	}

