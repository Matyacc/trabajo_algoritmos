# 
# * Created by SharpDevelop.
# * User: accia
# * Date: 26/5/2022
# * Time: 12:55
# *
# * To change this template use Tools | Options | Coding | Edit Standard Headers.
# *
# *
# *  Cada servicio tiene un jefe, una especialidad, un cupo de camas
# * libres, el plantel de médicos que trabajan en él y la lista de pacientes internados.
# *
# *
# 
from System import *
from System.Collections import *

class Servicio(object):
	""" <summary>
	 Description of Servicio.
	 </summary>
	"""
	# CONSTRUCTOR
	def __init__(self, jf, esp, cantCamas):
		self._Plantel = ArrayList()
		self._Pacientes = ArrayList()
		self._Jefe = jf
		self._Especialidad = esp
		self._Camas = cantCamas

	# METODOS
	def agregarMedico(self, med):
		self._Plantel.Add(med)

	def agregarPaciente(self, pac):
		self._Pacientes.Add(pac)

	# SETTER Y GETTER
	def get_jefe(self):
		return self._Jefe

	def set_jefe(self, value):
		self._Jefe = value

	jefe = property(fget=get_jefe, fset=set_jefe)

	def get_especialidad(self):
		return self._Especialidad

	def set_especialidad(self, value):
		self._Especialidad = value

	especialidad = property(fget=get_especialidad, fset=set_especialidad)

	def get_camas(self):
		return self._Camas

	def set_camas(self, value):
		self._Camas = value

	camas = property(fget=get_camas, fset=set_camas)

	def get_plantel(self):
		return self._Plantel

	plantel = property(fget=get_plantel)

	def get_pacientes(self):
		return self._Pacientes

	pacientes = property(fget=get_pacientes)