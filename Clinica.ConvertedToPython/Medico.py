# 
# * Created by SharpDevelop.
# * User: accia
# * Date: 26/5/2022
# * Time: 12:59
# *
# * To change this template use Tools | Options | Coding | Edit Standard Headers.
# *
# *
# * Cada médico tiene un dni, legajo, nombre, especialidad, horario que cumple en el servicio (mañana, tarde o noche).
# *
# 
from System import *

class Medico(Persona):
	""" <summary>
	 Description of Medico.
	 </summary>
	"""
	def __init__(self, No, Ap, dni, legajo, especialidad, horario):
		self._Legajo = legajo
		self._Especialidad = especialidad
		self._Horario = horario

	def get_especialidad(self):
		return self._Especialidad

	especialidad = property(fget=get_especialidad)

	def get_horario(self):
		return self._Horario

	horario = property(fget=get_horario)

	def get_legajo(self):
		return self._Legajo

	legajo = property(fget=get_legajo)