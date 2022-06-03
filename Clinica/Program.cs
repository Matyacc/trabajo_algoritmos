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
using System.Collections;

namespace Clinica
{
	class Program
	{	
		
		
		
		public static Servicio seleccionarServicio(Clinica CL){
						int contador = 1;
						Console.WriteLine("Seleccione el servicio");
						foreach (Servicio servicioprueba in CL.servicios){
						Console.WriteLine(contador + ") " + servicioprueba.especialidad);
						contador = contador + 1;
						}
						Console.WriteLine(contador + ") " + "Agreagar nuevo servicio");
						
						int opcionServicio = verificarIngresoInt() - 1;
						
						while (opcionServicio < 1 || opcionServicio > contador -2){
							opcionServicio = verificarIngresoInt() - 1;
						}
						return (Servicio) CL.servicios[opcionServicio];}

		
		public static Medico seleccionarMedico(Servicio Servi){
						int contador = 1;
						Console.WriteLine("Seleccione el medico");
						foreach (Medico Medic in Servi.plantel){
						Console.WriteLine(contador + ") " + Medic.nombre + " " + Medic.apellido);
						contador = contador + 1;
						}
						int opcionMedico = verificarIngresoInt() - 1;
						
						while (opcionMedico > contador -2){
							opcionMedico = verificarIngresoInt() - 1;
						}
						return (Medico) Servi.plantel[opcionMedico];
			//			contador = 0;
			//			foreach(Medico med in Servi.plantel){
			//				while(opcionMedico != contador){
			//					contador = contador + 1;
			//					if (contador > Servi.plantel.Count){
			//					break;
			//					}
			//				}
			//					return med;
			//				}
			//			return new Medico("asd","asd",123,"asd","asd","asd");
			
		}
		
		
		public static void contratarMedico(Medico med,Clinica CL){
			foreach(Servicio servi in CL.servicios){
				if(med.especialidad == servi.especialidad){
					servi.agregarMedico(med);
					break;
				}
			}
		}
		
		
		
		public static void despedirMedico(string legajo, Clinica CL){
			bool encontrado = false;
			foreach(Servicio srv in CL.servicios){
				foreach(Medico med in srv.plantel){
					if(legajo == med.legajo){
						encontrado = true;
						if(med.pacientes.Count > 0){
							Console.WriteLine("No se puede eliminar el medico porque tiene pacientes a cargo");
						}
						else{
							srv.plantel.Remove(med);
							Console.WriteLine("Medico eliminado");
							break;
						}
					}
				}
			}
			if(encontrado == false){
				Console.WriteLine("No existe ningun medico con ese numero de legajo");
			}
			}
		
		
		internal static int verificarIngresoInt(){
			string aVerificar;
			int datoVerificado = 0;
			bool esNumero = false;
			aVerificar = Console.ReadLine();
			
			while(esNumero != true){
			try{
				datoVerificado = int.Parse(aVerificar);
				esNumero = true;
			}
			catch{
				Console.WriteLine("(Solo puede ingresar numeros)");
				aVerificar = Console.ReadLine();
			}
			}
			return datoVerificado;
		}
		
		internal static string verificarIngresoString(){
			string aVerificar = Console.ReadLine();
			while(aVerificar.Length == 0){
				Console.WriteLine("No puede dejar el campo vacio");
				aVerificar = Console.ReadLine();
			}
			return aVerificar;
		}
		
		public static void listarMedicos(Clinica CL){
			foreach (Servicio srv in CL.servicios){
				Console.WriteLine(srv.especialidad);
				Console.WriteLine();
				foreach (Medico med in srv.plantel){
				Console.WriteLine(med.legajo + ") " + med.nombre + " " + med.apellido);	
				}
				Console.WriteLine();
						}
		}
		
		internal static  void volverAlMenu(){
			Console.WriteLine("");
			Console.WriteLine("Precione cualquier tecla para volver al menu");
			Console.ReadKey();
			Console.Clear();
		}
		
		internal static string Menu(){
			string opcion;
			Console.Clear();
			Console.WriteLine("MENU PRINCIPAL");
			Console.WriteLine();
			Console.WriteLine("* a) Agregar un médico en el servicio correspondiente a su especialidad");
			Console.WriteLine("* b) Eliminar un médico dado");
			Console.WriteLine("* c) Internar un paciente en un servicio dado y a cargo de un médico determinado");
			Console.WriteLine("* d) Listado de los servicios que tienen médicos de guardia en horario nocturno");
			Console.WriteLine("* e) Dar el alta a un paciente internado en un servicio dado y a cargo de un médico determinado.");
			Console.WriteLine("* f) Listado de servicios");
			Console.WriteLine("* g) Listado de médicos");
			Console.WriteLine("* h) Listado de pacientes de un servicio");
			Console.WriteLine("* i) Salir del programa");
			Console.WriteLine("");
			Console.WriteLine("Ingrese una opcion");
			opcion = Console.ReadLine();
			Console.Clear();
			return opcion;
		}
		
		public static void Main(string[] args)
		{	
			string nombreMedico,apellidoMedico,opcion,especialidadMedico,horario, legajoMedico	;
			int dniMedico, contador,opcionEspecialidadMedico,opcionHorario;
			Medico nuevoMedico;
			Clinica clinicaActiva = new Clinica("Monte Grande");
			Servicio Traumatologia, Guardia, Pediatria, Oftalmologia;
			Medico m0,m1,m2,m3,m4,m5,m6,m7,m8,m9;
			
			m0 = new Medico("Marcos","ayala",1,"1","Pediatria","Mañana");
			m1 = new Medico("Maria","Rodriguez",2,"2","Oftalmologia","Mañana");
			m2 = new Medico("Patricio","Gonzalez",3,"3","Traumatologia","Mañana");
			m3 = new Medico("Agustin","Lopez",4,"4","Traumatologia","Tarde");
			m4 = new Medico("Tomas","Medina",5,"5","Guardia","Mañana");
			m5 = new Medico("Pepe","schel",6,"6","Traumatologia","Noche");
			m6 = new Medico("Bob","esponja",7,"7","Guardia","Noche");
			m7 = new Medico("Masha","yoso",8,"8","Pediatria","Tarde");
			m8 = new Medico("Melany","acosta",9,"9","Guardia","Tarde");
			m9 = new Medico("Milton","gerez",10,"10","Guardia","Noche");
			
			Traumatologia = new Servicio(new Persona("Jefe","Traumatologia",123),"Traumatologia",1);
			Guardia = new Servicio(new Persona("Jefe","Guardia",123), "Guardia", 5);
			Pediatria = new Servicio(new Medico("Jefe","Pediatria",123,"2341","Pediatria","Noche"),"Pediatria",1);
			Oftalmologia = new Servicio(new Persona("Jefe","Oftalmologia",123),"Oftalmologia",2);
			
			clinicaActiva.servicios.Add(Traumatologia);
			clinicaActiva.servicios.Add(Guardia);
			clinicaActiva.servicios.Add(Pediatria);
			clinicaActiva.servicios.Add(Oftalmologia);
			
			contratarMedico(m0,clinicaActiva);
			contratarMedico(m1,clinicaActiva);
			contratarMedico(m2,clinicaActiva);
			contratarMedico(m3,clinicaActiva);
			contratarMedico(m4,clinicaActiva);
			contratarMedico(m5,clinicaActiva);
			contratarMedico(m6,clinicaActiva);
			contratarMedico(m7,clinicaActiva);
			contratarMedico(m8,clinicaActiva);
			contratarMedico(m9,clinicaActiva);
			m1.agregarPaciente(new Paciente("Marta", "Gomez",12123456,"Ingreso"));
			m2.agregarPaciente(new Paciente("Mirta","Sanchez",3214567,"Ingreso"));
			

			                                          
			opcion = Menu();
			while (opcion != "i"){
			switch (opcion){
			case "a":{
				Console.WriteLine("Ingrese el nombre del medico");
				nombreMedico = verificarIngresoString();
				Console.Clear();
				Console.WriteLine("Ingrese el apellido del medico");
				apellidoMedico = verificarIngresoString();
				Console.Clear();
				Console.WriteLine("Ingrese el dni del medico");
				dniMedico = verificarIngresoInt();
				Console.Clear();
				Console.WriteLine("Ingrese el numero de legajo del medico");
				legajoMedico = verificarIngresoString();
				Console.Clear();
				contador = 1;
				foreach(Servicio srv in clinicaActiva.servicios){
					Console.WriteLine(contador + ") " + srv.especialidad);
					contador = contador + 1;
				}
				opcionEspecialidadMedico = verificarIngresoInt() - 1;
				while(opcionEspecialidadMedico < 1 || opcionEspecialidadMedico > clinicaActiva.servicios.Count){
					Console.WriteLine("Ingreso una opcion incorrecta");
					opcionEspecialidadMedico = verificarIngresoInt() - 1;
				}
				Console.Clear();
				especialidadMedico = "";
				contador = 0;
				foreach(Servicio srv in clinicaActiva.servicios){
					if(opcionEspecialidadMedico == contador){
					   	especialidadMedico = srv.especialidad;
					   }
					   contador = contador + 1;
				}

				Console.WriteLine("Seleccione el horario laboral del medico");
				Console.WriteLine("1 para turno mañana");
				Console.WriteLine("2 para turno tarde");
				Console.WriteLine("3 para turno noche");
				horario = "";
				opcionHorario = verificarIngresoInt();
				while(opcionHorario < 1 || opcionHorario > 3){
					Console.WriteLine("Opcion incorrecta");
					opcionHorario = verificarIngresoInt();
				}
				Console.Clear();
				switch (opcionHorario){
						case 1:{
							horario = "Mañana";
							break;
						}
						case 2:{
							horario = "Tarde";
							break;
						}
						case 3:{
							horario = "Noche";
							break;
						}
				}
				nuevoMedico = new Medico(nombreMedico,apellidoMedico,dniMedico,legajoMedico,especialidadMedico,horario);
				contratarMedico(nuevoMedico,clinicaActiva);
				nuevoMedico.imprimir();
				
				volverAlMenu();
				break; }
				case "b":{
					Console.WriteLine("Ingrese el numero de legajo del medico que desea eliminar");
					legajoMedico = Console.ReadLine();
					despedirMedico(legajoMedico,clinicaActiva);
					volverAlMenu();
					break;}
					
				case "c":{
					string nombre, apellido, diagnostico;
					int dni;
					Servicio servicioSeleccionado = seleccionarServicio(clinicaActiva);
					Console.WriteLine(servicioSeleccionado.especialidad);
					try{
					if(servicioSeleccionado.plantel.Count == 0){
						Console.WriteLine("No hay medicos disponibles en este servicio");
						}
					else{
						if (servicioSeleccionado.camas == 0){
							throw new SinCama();
						}
						Medico medicoSeleccionado = seleccionarMedico(servicioSeleccionado);
						Console.Clear();
						Console.WriteLine("Ingrese el nombre del paciente");
						nombre = Console.ReadLine();
						Console.Clear();
						Console.WriteLine("Ingrese el apellido del paciente");
						apellido = Console.ReadLine();
						Console.Clear();
						Console.WriteLine("Ingrese el dni del paciente");
						dni = verificarIngresoInt();
						Console.Clear();
						Console.WriteLine("Ingrese el diagnostico del paciente");
						diagnostico = Console.ReadLine();
						Console.Clear();
						servicioSeleccionado.camas = servicioSeleccionado.camas - 1;
						Console.WriteLine("Internacion registrada");
						medicoSeleccionado.agregarPaciente(new Paciente(nombre,apellido,dni,diagnostico));
						}} catch(SinCama){
						Console.WriteLine("No se puede internar al paciente porque no hay camas");
						}
					volverAlMenu();
					break;
					}
				case "d":{
						foreach (Servicio servicioNocturno in clinicaActiva.servicios){
							foreach(Medico medicoNocturno in servicioNocturno.plantel){
								if(medicoNocturno.horario == "Noche"){
									Console.WriteLine(servicioNocturno.especialidad);
									break;
								}
							}
						}
						volverAlMenu();
						break;
					}
				case "e":{
						Servicio ServicioSeleccionado = seleccionarServicio(clinicaActiva);
						Medico MedicoSeleccionado = seleccionarMedico(ServicioSeleccionado);
						
						contador = 1;
						foreach (Paciente PA in MedicoSeleccionado.pacientes){
							Console.WriteLine(contador + ") " + PA.nombre + " " + PA.apellido);
							contador = contador + 1;
							}
						
						int opcionPaciente = verificarIngresoInt() - 1;
						
						while (opcionPaciente > contador -2){
							opcionPaciente = verificarIngresoInt() - 1;
						}
						
						contador = 0;
						
						foreach (Paciente PA in MedicoSeleccionado.pacientes){
							while(opcionPaciente != contador){
								contador = contador + 1;
								if (contador > MedicoSeleccionado.pacientes.Count){
									break;
									}}
							MedicoSeleccionado.pacientes.Remove(PA);
							break; 
							}
					volverAlMenu();
					break;}
					
					
					
				case "f":{
					int contServicios = 0;
					foreach (Servicio serv in clinicaActiva.servicios){
						contServicios = contServicios + 1;
						Console.WriteLine(contServicios + ") " + serv.especialidad + " (" + serv.camas + " camas disponibles)");
						}
					volverAlMenu();
					break;}
					
				case "g":{
					Console.Clear();
					listarMedicos(clinicaActiva);
					volverAlMenu();
					break;}
				
				case "h":{
					contador = 1;
					Console.WriteLine("Seleccione el servicio");
					foreach (Servicio servicioprueba in clinicaActiva.servicios){
					Console.WriteLine(contador + ") " + servicioprueba.especialidad);
					contador = contador + 1;
					};
					int opcionServicio = verificarIngresoInt() - 1;
					contador = 0;
					foreach(Servicio servi in clinicaActiva.servicios){
						if(opcionServicio == contador){
							foreach (Medico med in servi.plantel){
								foreach(Paciente pac in med.pacientes){
								Console.WriteLine(pac.nombre + " " + pac.apellido + " (" + pac.diagnostico + ")");
								}
							}
						}
						contador = contador + 1;
					}
					volverAlMenu();
					break;}
					
				}

		
				opcion = Menu();
			}
			// TODO: Implement Functionality Here
			Console.Write("Hasta luego. . . ");
			Console.ReadKey(true);
		}
	}
}