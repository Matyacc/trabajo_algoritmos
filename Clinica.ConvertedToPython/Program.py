# 
# * Created by SharpDevelop.
# * User: accia
# * Date: 26/5/2022
# * Time: 12:48
# *
# * To change this template use Tools | Options | Coding | Edit Standard Headers.
# * Una clínica tiene varios servicios.
# *
# *
# * Utilizando las clases que crea necesarias:
# * 	Se deberá desarrollar una aplicación, que resuelva las funcionalidades que se muestran en el siguiente menú:
# *
# 
from System import *
from System.Collections import *

class Program(object):
	def contratarMedico(med, CL):
		CL.medicos.Add(med)
		enumerator = CL.servicios.GetEnumerator()
		while enumerator.MoveNext():
			servi = enumerator.Current
			if med.especialidad == servi.especialidad:
				servi.plantel.Add(med)

	contratarMedico = staticmethod(contratarMedico)

	def despedirMedico(med):
		pass

	despedirMedico = staticmethod(despedirMedico)

	def volverAlMenu():
		Console.WriteLine("")
		Console.WriteLine("Precione cualquier tecla para volver al menu")
		Console.ReadKey()
		Console.Clear()

	volverAlMenu = staticmethod(volverAlMenu)

	def Menu():
		Console.Clear()
		Console.WriteLine()
		Console.WriteLine("* a) Agregar un médico en el servicio correspondiente a su especialidad")
		Console.WriteLine("* b) Eliminar un médico dado.")
		Console.WriteLine("* c) Internar un paciente en un servicio dado y a cargo de un médico determinado")
		Console.WriteLine("* d) Listado de los servicios que tienen médicos de guardia en horario nocturno")
		Console.WriteLine("* e) Dar el alta (egreso) a un paciente internado en un servicio dado y a cargo de un médico determinado.")
		Console.WriteLine("* f) Listado de servicios")
		Console.WriteLine("* g) Listado de médicos")
		Console.WriteLine("* h) Listado de pacientes de un servicio")
		Console.WriteLine("")
		Console.WriteLine("Ingrese una opcion")
		opcion = Console.ReadLine()
		Console.Clear()
		return opcion

	Menu = staticmethod(Menu)

	def Main(args):
		clinicaActiva = Clinica("Monte Grande")
		m0 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		m1 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		m2 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		m3 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		m4 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		m5 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		m6 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		m7 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		m8 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		m9 = Medico("Marta", "AO", 1, 2, "Guardia", "Noche")
		Traumatologia = Servicio(Persona("Jefe", "Traumatologia", 123), "Traumatologia", 15)
		Guardia = Servicio(Persona("Jefe", "Guardia", 123), "Guardia", 5)
		Pediatria = Servicio(Medico("Jefe", "Pediatria", 123, 2341, "Pediatria", "Noche"), "Pediatria", 1)
		Oftalmologia = Servicio(Persona("Jefe", "Oftalmologia", 123), "Oftalmologia", 2)
		clinicaActiva.servicios.Add(Traumatologia)
		clinicaActiva.servicios.Add(Guardia)
		clinicaActiva.servicios.Add(Pediatria)
		clinicaActiva.servicios.Add(Oftalmologia)
		Program.contratarMedico(m0, clinicaActiva)
		Program.contratarMedico(m1, clinicaActiva)
		Program.contratarMedico(m2, clinicaActiva)
		Program.contratarMedico(m3, clinicaActiva)
		Program.contratarMedico(m4, clinicaActiva)
		Program.contratarMedico(m5, clinicaActiva)
		Program.contratarMedico(m6, clinicaActiva)
		Program.contratarMedico(m7, clinicaActiva)
		Program.contratarMedico(m8, clinicaActiva)
		Program.contratarMedico(m9, clinicaActiva)
		opcion = Program.Menu()
		while opcion != "fin":
			if opcion == "a":
				Console.WriteLine("Ingrese el nombre del medico")
				nombreMedico = Console.ReadLine()
				Console.Clear()
				Console.WriteLine("Ingrese el apellido del medico")
				apellidoMedico = Console.ReadLine()
				Console.Clear()
				Console.WriteLine("Ingrese el dni del medico")
				dniMedico = int.Parse(Console.ReadLine())
				Console.Clear()
				Console.WriteLine("Ingrese el numero de legajo del medico")
				legajoMedico = int.Parse(Console.ReadLine())
				Console.Clear()
				contador = 1
				enumerator = clinicaActiva.servicios.GetEnumerator()
				while enumerator.MoveNext():
					srv = enumerator.Current
					Console.WriteLine(contador + ") " + srv.especialidad)
				opcionEspecialidadMedico = Console.ReadLine()
				Console.Clear()
				especialidadMedico = ""
				if opcionEspecialidadMedico == "1":
					especialidadMedico = "Traumatologia"
					break
				elif opcionEspecialidadMedico == "2":
					especialidadMedico = "Guardia"
					break
				elif opcionEspecialidadMedico == "3":
					especialidadMedico = "Pediatria"
					break
				elif opcionEspecialidadMedico == "4":
					especialidadMedico = "Oftalmologia"
					break
				Console.WriteLine("Seleccione el horario laboral del medico")
				Console.WriteLine("1 para turno manana")
				Console.WriteLine("2 para turno tarde")
				Console.WriteLine("3 para turno noche")
				horario = ""
				opcionHorario = Console.ReadLine()
				Console.Clear()
				if opcionHorario == "1":
					horario = "Manana"
					break
				elif opcionHorario == "2":
					horario = "Tarde"
					break
				elif opcionHorario == "3":
					horario = "Noche"
					break
				Program.contratarMedico(Medico(nombreMedico, apellidoMedico, dniMedico, legajoMedico, especialidadMedico, horario), clinicaActiva)
				break
			elif opcion == "b":
				Console.WriteLine("B")
				break
			elif opcion == "c":
				contador = 0
				medACargo = Medico("asd", "asd", 123, 123, "especial", "Noche")
				enumerator = clinicaActiva.servicios.GetEnumerator()
				while enumerator.MoveNext():
					servicioprueba = enumerator.Current
					contador = contador + 1
					Console.WriteLine(contador + ") " + servicioprueba.especialidad)
				opcionServicioInternacion = int.Parse(Console.ReadLine()) - 1
				conInt = 0
				enumerator = clinicaActiva.servicios.GetEnumerator()
				while enumerator.MoveNext():
					servicioInternar = enumerator.Current
					if conInt == opcionServicioInternacion:
						if servicioInternar.plantel.Count == 0:
							Console.WriteLine("No hay medicos disponibles en este servicio")
						else:
							contadorMedico = 0
							enumerator = servicioInternar.plantel.GetEnumerator()
							while enumerator.MoveNext():
								aCargo = enumerator.Current
								contadorMedico = contadorMedico + 1
								Console.WriteLine(contadorMedico + ") " + aCargo.nombre + " " + aCargo.apellido)
							opcionMedico = int.Parse(Console.ReadLine()) - 1
							contadorMedico = 0
							enumerator = servicioInternar.plantel.GetEnumerator()
							while enumerator.MoveNext():
								medicoAcargo = enumerator.Current
								if opcionMedico == contadorMedico:
									medACargo = medicoAcargo
								else:
									contadorMedico = contadorMedico + 1
							if servicioInternar.camas == 0:
								Console.WriteLine("No hay camas libres")
							else:
								Console.WriteLine("Ingrese el nombre del paciente")
								nombre = Console.ReadLine()
								Console.Clear()
								Console.WriteLine("Ingrese el apellido del paciente")
								apellido = Console.ReadLine()
								Console.Clear()
								Console.WriteLine("Ingrese el dni del paciente")
								dni = int.Parse(Console.ReadLine())
								Console.Clear()
								servicioInternar.agregarPaciente(Paciente(nombre, apellido, dni, "Ingreso", medACargo))
								servicioInternar.camas = servicioInternar.camas - 1
								Console.WriteLine("Internacion registrada")
					conInt = conInt + 1
				break
			elif opcion == "d":
				enumerator = clinicaActiva.servicios.GetEnumerator()
				while enumerator.MoveNext():
					servicioNocturno = enumerator.Current
					enumerator = servicioNocturno.plantel.GetEnumerator()
					while enumerator.MoveNext():
						medicoNocturno = enumerator.Current
						if medicoNocturno.horario == "Noche":
							Console.WriteLine(servicioNocturno.especialidad)
							break
				break
			elif opcion == "e":
				Console.WriteLine("E")
				break
			elif opcion == "f":
				contServicios = 0
				enumerator = clinicaActiva.servicios.GetEnumerator()
				while enumerator.MoveNext():
					serv = enumerator.Current
					contServicios = contServicios + 1
					Console.WriteLine(contServicios + ") " + serv.especialidad + " (" + serv.camas + " camas disponibles)")
				Program.volverAlMenu()
				break
			elif opcion == "g":
				Console.Clear()
				enumerator = clinicaActiva.medicos.GetEnumerator()
				while enumerator.MoveNext():
					med = enumerator.Current
					Console.WriteLine(med.legajo + ") " + med.nombre + " " + med.apellido)
				Program.volverAlMenu()
				break
			elif opcion == "h":
				contador = 0
				Console.WriteLine("Seleccione el servicio")
				enumerator = clinicaActiva.servicios.GetEnumerator()
				while enumerator.MoveNext():
					servicioprueba = enumerator.Current
					contador = contador + 1
					Console.WriteLine(contador + ") " + servicioprueba.especialidad)
				opcionServicio = int.Parse(Console.ReadLine()) - 1
				contServi = 0
				enumerator = clinicaActiva.servicios.GetEnumerator()
				while enumerator.MoveNext():
					servi = enumerator.Current
					if opcionServicio == contServi:
						enumerator = servi.pacientes.GetEnumerator()
						while enumerator.MoveNext():
							paciente = enumerator.Current
							Console.WriteLine(paciente.nombre + " " + paciente.apellido)
					contServi = contServi + 1
				break
			opcion = Program.Menu()
		# TODO: Implement Functionality Here
		Console.Write("Hasta luego. . . ")
		Console.ReadKey(True)

	Main = staticmethod(Main)

Program.Main(None)