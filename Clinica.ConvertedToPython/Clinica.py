# 
# * Created by SharpDevelop.
# * User: accia
# * Date: 27/5/2022
# * Time: 09:16
# *
# * To change this template use Tools | Options | Coding | Edit Standard Headers.
# 
from System import *
from System.Collections import *

class Clinica(object):
	""" <summary>
	 Description of Clinica.
	 </summary>
	"""
	def __init__(self, Nombre):
		self.__medicos = ArrayList()
		self.__pacientes = ArrayList()
		self.__servicios = ArrayList()
		self._Nombre = Nombre

	def get_nombre(self):
		return Nombre

	nombre = property(fget=get_nombre)

	def get_medicos(self):
		return self.__medicos

	medicos = property(fget=get_medicos)

	def get_pacientes(self):
		return self.__pacientes

	pacientes = property(fget=get_pacientes)

	def get_servicios(self):
		return self.__servicios

	servicios = property(fget=get_servicios)