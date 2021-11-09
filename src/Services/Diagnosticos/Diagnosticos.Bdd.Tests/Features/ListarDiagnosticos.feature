Feature: ListarDiagnosticos
	Permite al empleado listar los diagnosticos registrados
	en la base de datos

Scenario: Listar los primeros diagnosticos
	Given más de 2 diagnosticos registrados en la base de datos
	And se especifica que se quieren listar 2 diagnosticos
	When se listan los diagnosticos
	Then se pueden ver los datos de los 2 diagnosticos