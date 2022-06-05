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
		
		
		internal static void verificacionInicial(Clinica CL,Action <Clinica> funcion){
			if(CL.servicios.Count == 0){
				escribirRojo("Primero debe crear un servicio");
				volverAlMenu();
			}
			else{
				funcion(CL);
			}
		}
		
		internal static bool verificarDatos(ArrayList list){
			bool contieneDatos = true;
			if (list.Count == 0){
				contieneDatos = false;
				escribirRojo("NO HAY DATOS PARA MOSTRAR");
			}
			return contieneDatos;
		}
		
		internal static void agregarMedicoAlServicio(Clinica CL){
			string nombreMedico, apellidoMedico,legajoMedico,especialidadMedico,horario;
			int dniMedico,opcionHorario;
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
			Servicio servicioSeleccionado = seleccionarServicio(CL);
			especialidadMedico = servicioSeleccionado.especialidad;
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
			servicioSeleccionado.agregarMedico(new Medico(nombreMedico,apellidoMedico,dniMedico,legajoMedico,especialidadMedico,horario));
			horario = horario.ToLower();
			escribirVerde("El medico " + nombreMedico + " " + apellidoMedico + " se agrego al servicio " + servicioSeleccionado.especialidad + " turno " + horario);
		}
		
		internal static void despedirMedico(Clinica CL){
			Servicio servicioSeleccionado = seleccionarServicio(CL);
			if (verificarDatos(servicioSeleccionado.plantel)) {
				Medico medicoSeleccionado = seleccionarMedico(servicioSeleccionado);
				string legajo = medicoSeleccionado.legajo;
				bool tienePaciente = false;
				foreach(Servicio srv in CL.servicios){
					foreach(Medico med in srv.plantel){
						if(legajo == med.legajo){
							foreach(Paciente PA in srv.pacientes){
								if(PA.medicoAcargo == legajo){
									tienePaciente = true;
									break;
								}
							}
						}
					}
				}
				
				
				
				if (tienePaciente == false){
					servicioSeleccionado.eliminarMedico(medicoSeleccionado);
					escribirVerde("Medico eliminado");
				}
				else{
					escribirRojo("No se puede eliminar este medico porque tiene pacientes a cargo");
				}
				
				volverAlMenu();
				
			}
			else{
				escribirRojo("No hay medicos en el servicio seleccionado");
				volverAlMenu();
			}
		}
		
		internal static void internarPacienteEnServicio(Clinica CL){
			string nombre, apellido, diagnostico;
			int dni;
			Servicio servicioSeleccionado = seleccionarServicio(CL);
			try{
				if(servicioSeleccionado.plantel.Count == 0){
					escribirRojo("No hay medicos disponibles en este servicio");
				}
				else{
					if (servicioSeleccionado.camas == 0){
						throw new SinCama();
					}
					Medico medicoSeleccionado = seleccionarMedico(servicioSeleccionado);
					Console.Clear();
					Console.WriteLine("Ingrese el nombre del paciente");
					nombre = verificarIngresoString();
					Console.Clear();
					Console.WriteLine("Ingrese el apellido del paciente");
					apellido = verificarIngresoString();
					Console.Clear();
					Console.WriteLine("Ingrese el dni del paciente");
					dni = verificarIngresoInt();
					Console.Clear();
					Console.WriteLine("Ingrese el diagnostico del paciente");
					diagnostico = verificarIngresoString();
					Console.Clear();
					escribirVerde("Internacion registrada");
					servicioSeleccionado.internarPaciente(new Paciente(nombre,apellido,dni,diagnostico,medicoSeleccionado.legajo));
					
				}
			}
			catch(SinCama){
				escribirRojo("NO HAY CAMAS DISPONIBLES");
			}
			volverAlMenu();
		}
		
		internal static void darDeAltaPaciente(Clinica CL){
			int posicionPaciente;
			Servicio ServicioSeleccionado = seleccionarServicio(CL);
			if(verificarDatos(ServicioSeleccionado.plantel)){
				Medico MedicoSeleccionado = seleccionarMedico(ServicioSeleccionado);
				if(mostrarPacientesDeUnMedico(ServicioSeleccionado,MedicoSeleccionado)){
					posicionPaciente = seleccionarPaciente(ServicioSeleccionado);
					if(posicionPaciente == -1){
						escribirRojo("El paciente no se encuentra dentro de este servicio");
					}
					else{
						Paciente PacienteSeleccionado = (Paciente) ServicioSeleccionado.pacientes[posicionPaciente];
						if (PacienteSeleccionado.medicoAcargo == MedicoSeleccionado.legajo){
							ServicioSeleccionado.altaPaciente(PacienteSeleccionado);
							escribirVerde("El paciente fue dado de alta");
						}
						else if (PacienteSeleccionado.medicoAcargo != MedicoSeleccionado.legajo){
							escribirRojo("El paciente esta a cargo de otro medico");
						}
					}
				}
				else{
					escribirRojo("El medico seleccionado no tiene pacientes a cargo");
				}
			}
			volverAlMenu();
		}

		internal static void mostrarMedicos(Clinica CL){
			Console.Clear();
			int contador;
			verificarDatos(CL.servicios);
			foreach (Servicio srv in CL.servicios){
				contador = 0;
				Console.WriteLine(srv.especialidad.ToUpper());
				Console.WriteLine();
				foreach (Medico med in srv.plantel){
					contador += 1;
					Console.WriteLine("Legajo: " + med.legajo);
					Console.WriteLine("Nombre: " + med.nombre);
					Console.WriteLine("Apellido: " + med.apellido);
					Console.WriteLine();
				}
				if (contador == 0){escribirRojo("NO HAY MEDICOS DENTRO DE ESTE SERVICIO");}
				Console.WriteLine("-----------------------");
			}
			volverAlMenu();
		}
		
		internal static void mostrarServiciosNocturnos(Clinica CL){
			int contador = 0;
			foreach (Servicio servicioNocturno in CL.servicios){
				foreach(Medico medicoNocturno in servicioNocturno.plantel){
					if(medicoNocturno.horario == "Noche"){
						Console.WriteLine(servicioNocturno.especialidad);
						contador += 1;
						break;
					}
				}
			}
			if(contador == 0){escribirRojo("No hay servicios nocturnos");};
			volverAlMenu();
		}
		
		internal static void mostrarServicios(Clinica CL){
			verificarDatos(CL.servicios);
			int contServicios = 0;
			foreach (Servicio serv in CL.servicios){
				contServicios = contServicios + 1;
				Console.WriteLine(contServicios + ") " + serv.especialidad + " (" + serv.camas + " camas disponibles)");
			}
			volverAlMenu();
		}
		
		internal static void mostrarPacientesDeServicio(Clinica CL){
			Servicio servicioSeleccionado = seleccionarServicio(CL);
			verificarDatos(servicioSeleccionado.pacientes);
			foreach (Paciente pac in servicioSeleccionado.pacientes){
				pac.imprimir();
			}
			volverAlMenu();
		}
		
		internal static bool mostrarPacientesDeUnMedico(Servicio serv, Medico Med){
			bool encontrado = false;
			foreach (Paciente PA in serv.pacientes){
				if(PA.medicoAcargo == Med.legajo){
					PA.imprimir();
					encontrado = true;
				}
			}
			return encontrado;
		}
		
		internal static void nuevoServicio(Clinica CL){
			string nombreJefe,apellidoJefe,nuevaEspecialidad;
			int dniJefe,cantidadDeCamas;
			Console.Clear();
			Console.WriteLine("Ingrese el nombre del jefe de servicio");
			nombreJefe = verificarIngresoString();
			Console.Clear();
			Console.WriteLine("ingrese el apellido del jefe de servicio");
			apellidoJefe = verificarIngresoString();
			Console.Clear();
			Console.WriteLine("Ingrese el dni del jefe de servicio");
			dniJefe = verificarIngresoInt();
			Console.Clear();
			Console.WriteLine("Ingrese la especialidad del nuevo servicio");
			nuevaEspecialidad = verificarIngresoString();
			Console.Clear();
			Console.WriteLine("Ingrese la cantidad de camas del nuevo servicio");
			cantidadDeCamas = verificarIngresoInt();
			CL.nuevoServicio(new Servicio(new Persona(nombreJefe,apellidoJefe,dniJefe),nuevaEspecialidad,cantidadDeCamas));
			Console.Clear();
			escribirVerde("Servicio " + nuevaEspecialidad + " agregado exitosamente");
			volverAlMenu();
		}
		
		internal static void eliminarServicio(Clinica CL){
			string opcion;
			Servicio servicioSeleccionado = seleccionarServicio(CL);
			escribirRojo("ADVERTENCIA!!!");
			Console.WriteLine("Si elimina el servicio tambien se eliminaran todos los medicos y pacientes que contenga");
			Console.WriteLine("Escriba 'Confirmar' si desea eliminarlo o precione enter para volver al menu");
			opcion = Console.ReadLine();
			if (opcion.ToLower() == "confirmar"){
				CL.eliminarServicio(servicioSeleccionado);
				escribirVerde("Servicio eliminado");
				volverAlMenu();
			}
			
		}
		
		internal static Servicio seleccionarServicio(Clinica CL){
			Console.Clear();
			int contador = 1;
			Console.WriteLine("Seleccione el servicio");
			foreach (Servicio servicioprueba in CL.servicios){
				Console.WriteLine(contador + ") " + servicioprueba.especialidad);
				contador = contador + 1;
			}
			
			int opcionServicio = verificarIngresoInt() - 1;
			
			while (opcionServicio < 0 || opcionServicio > contador -2){
				escribirRojo("Ingreso una opcion incorrecta");
				opcionServicio = verificarIngresoInt() - 1;
			}
			
			return (Servicio) CL.servicios[opcionServicio];}

		internal static Medico seleccionarMedico(Servicio Servi){
			Console.Clear();
			int contador = 1;
			Console.WriteLine("Seleccione el medico");
			foreach (Medico Medic in Servi.plantel){
				Console.WriteLine(contador + ") " + Medic.nombre + " " + Medic.apellido);
				contador = contador + 1;
			}
			int opcionMedico = verificarIngresoInt() - 1;
			
			while (opcionMedico < 0 || opcionMedico > contador -2){
				escribirRojo("Ingreso una opcion incorrecta");
				opcionMedico = verificarIngresoInt() - 1;
			}
			return (Medico) Servi.plantel[opcionMedico];
		}
		
		internal static int seleccionarPaciente(Servicio Servi){
			int dniIngresado,posicion;
			bool encontrado = false;
			Console.WriteLine("Ingrese el dni del paciente");
			dniIngresado = verificarIngresoInt();
			posicion = 0;
			foreach(Paciente PA in Servi.pacientes){
				if(PA.dni == dniIngresado){
					encontrado = true;
					return posicion;
				}
				posicion +=1;
			}
			if (encontrado == false){
				posicion = -1;
			}
			return posicion;
		}
		
		internal static void escribirVerde(string texto){
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(texto);
			Console.ForegroundColor = ConsoleColor.Gray;
		}
		
		internal static void escribirRojo(string texto){
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(texto);
			Console.ForegroundColor = ConsoleColor.Gray;
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
					escribirRojo("(Solo puede ingresar numeros)");
					aVerificar = Console.ReadLine();
				}
			}
			return datoVerificado;
		}
		
		internal static string verificarIngresoString(){
			string aVerificar = Console.ReadLine();
			while(aVerificar.Length == 0){
				escribirRojo("No puede dejar el campo vacio");
				aVerificar = Console.ReadLine();
			}
			return aVerificar;
		}
		
		internal static  void volverAlMenu(){
			Console.WriteLine("");
			Console.WriteLine("Precione cualquier tecla para volver al menu");
			Console.ReadKey();
			Console.Clear();
		}
		
		internal static string Menu(Clinica CL){
			Console.Title = "Clinica " + CL.nombre;
			string opcion;
			Console.Clear();
			Console.WriteLine("MENU PRINCIPAL");
			Console.WriteLine();
			Console.WriteLine("* A) Agregar un médico en el servicio correspondiente a su especialidad");
			Console.WriteLine("* B) Eliminar un médico dado");
			Console.WriteLine("* C) Internar un paciente en un servicio dado y a cargo de un médico determinado");
			Console.WriteLine("* D) Dar el alta a un paciente internado en un servicio dado y a cargo de un médico determinado.");
			Console.WriteLine("* E) Listado de los servicios que tienen médicos de guardia en horario nocturno");
			Console.WriteLine("* F) Listado de servicios");
			Console.WriteLine("* G) Listado de médicos");
			Console.WriteLine("* H) Listado de pacientes de un servicio");
			Console.WriteLine("* I) Agregar un nuevo servicio");
			Console.WriteLine("* J) Eliminar un servicio");
			Console.WriteLine("* x) Salir del programa");
			Console.WriteLine("");
			Console.WriteLine("Ingrese una opcion");
			opcion = Console.ReadLine().ToLower();
			Console.Clear();
			return opcion;
		}
		
		
//		 las siguientes funciones no son necesarias para el funcionamiento del programa
//		 sirve para cargar algunos objetos de prueba
		
		internal static void cargaMedicoTest(Medico med, Clinica CL){
			foreach (Servicio srv in CL.servicios){
				if(med.especialidad == srv.especialidad){
					srv.agregarMedico(med);
				}
			}
		}
		internal static void cargaPacienteTest(Paciente PA,Servicio srv){
			srv.internarPaciente(PA);
		}
		internal static void cargarObjetosDePrueba(Clinica CL){
			CL.nuevoServicio(new Servicio(new Persona("Jefe","Traumatologia",123),"Traumatologia",3));
			CL.nuevoServicio(new Servicio(new Persona("Jefe","Guardia",123), "Guardia", 15));
			CL.nuevoServicio(new Servicio(new Medico("Jefe","Pediatria",123,"2341","Pediatria","Noche"),"Pediatria",5));
			CL.nuevoServicio(new Servicio(new Persona("Jefe","Cardiologia",123),"Cardiologia",3));
			CL.nuevoServicio(new Servicio(new Persona("Rita","Mendoza",654),"COVID19", 250));
			cargaMedicoTest(new Medico("Marcos","ayala",1,"1","Pediatria","Mañana"),CL);
			cargaMedicoTest(new Medico("Maria","Rodriguez",2,"2","Cardiologia","Mañana"),CL);
			cargaMedicoTest(new Medico("Patricio","Gonzalez",3,"3","Traumatologia","Mañana"),CL);
			cargaMedicoTest(new Medico("Agustin","Lopez",4,"4","Traumatologia","Tarde"),CL);
			cargaMedicoTest(new Medico("Tomas","Medina",5,"5","Guardia","Mañana"),CL);
			cargaMedicoTest(new Medico("Maira","Rodriguez",8,"8","Pediatria","Tarde"),CL);
			cargaMedicoTest(new Medico("Melany","acosta",9,"9","Guardia","Tarde"),CL);
			cargaMedicoTest(new Medico("Milton","gerez",10,"10","Guardia","Noche"),CL);
			cargaMedicoTest(new Medico("Emanuel","Gonzalez",11,"11","Guardia","Noche"),CL);
			cargaMedicoTest(new Medico("Tomas","Valenzuela",12,"12","COVID19","Tarde"),CL);
			cargaPacienteTest(new Paciente("Pablo","Marimar",123,"COVID POSITIVO","12"),(Servicio) CL.servicios[4]);
			cargaPacienteTest(new Paciente("Maria","Perez",124,"COVID POSITIVO","12"),(Servicio) CL.servicios[4]);
			cargaPacienteTest(new Paciente("Juan","Mamani",125,"COVID POSITIVO","12"),(Servicio) CL.servicios[4]);
			cargaPacienteTest(new Paciente("Graciela","Acosta",126,"fractura de femur","3"),(Servicio) CL.servicios[0]);
			cargaPacienteTest(new Paciente("Melina","Salvatierra",127,"Rehabilitacion","4"),(Servicio) CL.servicios[0]);
			cargaPacienteTest(new Paciente("Malena","Perez",128,"Golpe en la cabeza","3"),(Servicio) CL.servicios[0]);
			cargaPacienteTest(new Paciente("Matias","Gerez",129,"Preinfarto","2"),(Servicio) CL.servicios[3]);
			cargaPacienteTest(new Paciente("Pablo","Mamani",130,"cirugia programada","2"),(Servicio) CL.servicios[3]);
			cargaPacienteTest(new Paciente("Emiliano","Corvalan",131,"Sin diagnosticar","9"),(Servicio) CL.servicios[2]);
			cargaPacienteTest(new Paciente("Pablo","Escobar",132,"Sin diagnosticar","10"),(Servicio) CL.servicios[2]);
		}
		
		
		public static void Main(string[] args)
		{
			Clinica clinicaActiva = new Clinica("Monte Grande");
			cargarObjetosDePrueba(clinicaActiva);
			
			string opcion;
			opcion = Menu(clinicaActiva);
			while (opcion != "x"){
				switch (opcion){
						case "a":{
							verificacionInicial(clinicaActiva,agregarMedicoAlServicio);
							break; }
						case "b":{
							verificacionInicial(clinicaActiva,despedirMedico);
							break;}
						case "c":{
							verificacionInicial(clinicaActiva,internarPacienteEnServicio);
							break;}
						case "d":{
							verificacionInicial(clinicaActiva,darDeAltaPaciente);
							break;}
						case "e":{
							mostrarServiciosNocturnos(clinicaActiva);
							break;}
						case "f":{
							mostrarServicios(clinicaActiva);
							break;}
						case "g":{
							mostrarMedicos(clinicaActiva);
							break;}
						case "h":{
							verificacionInicial(clinicaActiva,mostrarPacientesDeServicio);
							break;}
						case "i":{
							nuevoServicio(clinicaActiva);
							break;}
						case "j":{
							verificacionInicial(clinicaActiva,eliminarServicio);
							break;
						}
				}

				opcion = Menu(clinicaActiva);
			}

		}
	}
}