Feature: BuscarDiagnostico
	Permite al empleado buscar un diagnostico por su Id
	para ver los datos del diagnóstico y sus detalles

Scenario: Buscar un diagnostico existente
	Given un diagnostico con el Id 1 agregado en la base de datos
	When se busca el diagnostico por el Id 1
	Then se pueden ver los datos del diagnostico

Scenario: Buscar un diagnostico inexistente
	Given una base de datos que no tiene un diagnostico con Id 1
	When se busca el diagnostico por el Id 1
	Then se muestra un mensaje de error