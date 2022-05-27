/*
 * Created by SharpDevelop.
 * User: accia
 * Date: 26/5/2022
 * Time: 12:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * Una clínica tiene varios servicios. 
 * 
 * 
 * Utilizando las clases que crea necesarias:
 * 	Se deberá desarrollar una aplicación, que resuelva las funcionalidades que se muestran en el siguiente menú:
 * 
 */
using System;

namespace Clinica
{
	class Program
	{
		public static void Main(string[] args)
		{
			Medico m1,m2,m3,m4;
			m1 = new Medico("Matias", "Acciaio",36522124,1,"Traumatologia","Tarde");
			m2 = new Medico("Patricio", "Medina",1235,2,"Guardia","Noche");
			m3 = new Medico("Agustin", "Acciaio",58522124,3,"Pediatria","Manana");
			Paciente p1,p2,p3,p4;
			Servicio Traumatologia, Guardia, Pediatria;
			
			Traumatologia = new Servicio(m1,"Traumatologia",15);
			Guardia = new Servicio(m2, "Guardia", 5);
			Pediatria = new Servicio(m3,"Pediatria",1);
			
			Console.WriteLine(Guardia.jefe.nombre);
			
			Console.WriteLine();
			Console.WriteLine("* a) Agregar un médico en el servicio correspondiente a su especialidad");
			Console.WriteLine("* b) Eliminar un médico dado.");
			Console.WriteLine("* c) Internar un paciente en un servicio dado y a cargo de un médico determinado");
			Console.WriteLine("*  	(Se modifica el cupo de camas libres y se agrega el paciente a la lista del servicio).");
			Console.WriteLine("*   	 En caso de no haber camas libres en dicho servicio, se debe levantar una excepción indicando lo sucedido (“No hay cama disponible”).");
			Console.WriteLine("* d) Listado de los servicios que tienen médicos de guardia en horario nocturno");
			Console.WriteLine("* e) Dar el alta (egreso) a un paciente internado en un servicio dado y a cargo de un médico determinado.");
			Console.WriteLine("* f) Listado de servicios");
			Console.WriteLine("* g) Listado de médicos");
			Console.WriteLine("* h) Listado de pacientes de un servicio");
			Console.WriteLine("");
			Console.WriteLine("Ingrese una opcion");
			string opcion = Console.ReadLine();
			switch (opcion){
					case "a":{Console.WriteLine("A");
					break; }
					case "b":{Console.WriteLine("B");
					break;}
					case "c":{Console.WriteLine("C");
					break;}
					case "d":{Console.WriteLine("D");
					break;}
					case "e":{Console.WriteLine("E");
					break;}
					case "f":{Console.WriteLine("F");
					break;}
					case "g":{Console.WriteLine("G");
					break;}
					case "h":{Console.WriteLine("H");
					break;}
			}
			
			
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}