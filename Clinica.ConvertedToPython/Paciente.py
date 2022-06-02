# 
# * Created by SharpDevelop.
# * User: accia
# * Date: 26/5/2022
# * Time: 13:03
# *
# * To change this template use Tools | Options | Coding | Edit Standard Headers.
# *
# * De cada paciente se conoce su dni, nombre y apellido, diagnostico .
# *
# 
from System import *

class Paciente(Persona):
	""" <summary>
	 Description of Paciente.
	 </summary>
	"""
	def __init__(self, no, ap, dni, diag, medicoACargo):
		self._Diagnostico = diag
		self._MedicoACargo = medicoACargo

	def get_diagnostico(self):
		return self._Diagnostico

	diagnostico = property(fget=get_diagnostico)