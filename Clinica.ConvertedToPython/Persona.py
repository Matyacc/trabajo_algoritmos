# 
# * Created by SharpDevelop.
# * User: accia
# * Date: 26/5/2022
# * Time: 12:56
# *
# * To change this template use Tools | Options | Coding | Edit Standard Headers.
# 
from System import *

class Persona(object):
	""" <summary>
	 Description of Persona.
	 </summary>
	"""
	def __init__(self, Nombre, Apellido, Dni):
		self._Nombre = Nombre
		self._Apellido = Apellido
		self._Dni = Dni

	def get_nombre(self):
		return Nombre

	nombre = property(fget=get_nombre)

	def get_apellido(self):
		return Apellido

	apellido = property(fget=get_apellido)

	def get_dni(self):
		return Dni

	dni = property(fget=get_dni)