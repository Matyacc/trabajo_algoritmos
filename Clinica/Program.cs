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
		public static void contratarMedico(Medico med,Clinica CL){
			CL.medicos.Add(med);
			foreach(Servicio servi in CL.servicios){
				if(med.especialidad == servi.especialidad){
					servi.plantel.Add(med);
				}
			}
		}
		public static void despedirMedico(Medico med){
		
		}
		
		
		public static void Main(string[] args)
		{	
			string nombreMedico,apellidoMedico,opcion,opcionEspecialidadMedico,especialidadMedico,opcionHorario,horario;
			int dniMedico, legajoMedico;
			Clinica MG = new Clinica("Monte Grande");
			Servicio Traumatologia, Guardia, Pediatria, Oftalmologia;
			
			Traumatologia = new Servicio(new Persona("Jefe","traumatologia",123),"Traumatologia",15);
			Guardia = new Servicio(new Persona("Jefe","Guardia",123), "Guardia", 5);
			Pediatria = new Servicio(new Persona("Jefe","Pediatria",123),"Pediatria",1);
			Oftalmologia = new Servicio(new Persona("Jefe","Oftalmologia",123),"Oftalmologia",2);
			MG.servicios.Add(Traumatologia);
			MG.servicios.Add(Guardia);
			MG.servicios.Add(Pediatria);
			MG.servicios.Add(Oftalmologia);
			


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
			opcion = Console.ReadLine();
			Console.Clear();
			while (opcion != ""){
			switch (opcion){
					case "a":{
							Console.WriteLine("Ingrese el nombre del medico");
							nombreMedico = Console.ReadLine();
							Console.Clear();
							Console.WriteLine("Ingrese el apellido del medico");
							apellidoMedico = Console.ReadLine();
							Console.Clear();
							Console.WriteLine("Ingrese el dni del medico");
							dniMedico = int.Parse(Console.ReadLine());
							Console.Clear();
							Console.WriteLine("Ingrese el numero de legajo del medico");
							legajoMedico = int.Parse(Console.ReadLine());
							Console.Clear();
							Console.WriteLine("Seleccione la especialidad del medico");
							Console.WriteLine("1 para Traumatologia");
							Console.WriteLine("2 para Guardia");
							Console.WriteLine("3 para Pediatria");
							Console.WriteLine("4 para Oftalmologia");
							opcionEspecialidadMedico = Console.ReadLine();
							Console.Clear();
							especialidadMedico = "";
							switch (opcionEspecialidadMedico){
									case "1":{
										especialidadMedico = "Traumatologia";
										break;
									}
									case "2":{
										especialidadMedico = "Guardia";
										break;
									}
									case "3":{
										especialidadMedico = "Pediatria";
										break;
									}
									case "4":{
										especialidadMedico = "Oftalmologia";
										break;
									}
							}
							Console.WriteLine("Seleccione el horario laboral del medico");
							Console.WriteLine("1 para turno manana");
							Console.WriteLine("2 para turno tarde");
							Console.WriteLine("3 para turno noche");
							horario = "";
							opcionHorario = Console.ReadLine();
							Console.Clear();
							switch (opcionHorario){
									case "1":{
										horario = "Manana";
										break;
									}
									case "2":{
										horario = "Tarde";
										break;
									}
									case "3":{
										horario = "Noche";
										break;
									}
							}
							contratarMedico(new Medico(nombreMedico,apellidoMedico,dniMedico,legajoMedico,especialidadMedico,horario),MG);
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
				opcion = Console.ReadLine();
				Console.Clear();
			}
			foreach (Servicio servi in MG.servicios){Console.WriteLine(servi.especialidad);
				foreach(Medico med in servi.plantel){
					Console.WriteLine(med.nombre);
				}
				Console.WriteLine("");
			}
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}