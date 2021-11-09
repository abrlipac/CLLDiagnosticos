Feature: CrearDiagnostico
	Permite al empleado crear un nuevo diagnostico
	para determinar la posible enfermedad y para
	guardarlo en la base de datos

Scenario: Crear un diagnostico correctamente
	Given un diagnostico con detalles de diagnostico válidos
	When se intenta agregar el diagnostico a la base de datos
	Then se puede encontrar el diagnostico en la base de datos

Scenario: Crear un diagnostico con errores
	Given un diagnostico con detalles de diagnostico inválidos
	When se intenta agregar el diagnostico a la base de datos
	Then muestra un mensaje de error