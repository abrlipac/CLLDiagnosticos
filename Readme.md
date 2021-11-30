# Aplicación web para la gestión de  diagnósticos automatizados

## Diagnósticos automatizados | .NET Core | Microservicios

### Integrantes:

* LIPA CALABILLA, Abraham
* LLANQUE ARISACA, Miguel
* TICONA, Alex

### Configurar la cadena de conexión

En los archivos `appsettings.json` ubicados en cada proyecto `<Microservicio>.Api`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=ABRAHAM-PC\\SQLEXPRESS;Database=Diagnostico;Trusted_Connection=True;MultipleActiveResultSets=true"
},
```

### Migración

Entity Framework Core tiene un enfoque Code-first, es decir que las tablas de la base de datos se crean a partir de las clases en el dominio de cada microservicio.

Para realizar la migración, ejecute en la consola de Package Manager (`PM>`):
```
update-database -context ApplicationDbContext
```
Seleccionando el proyecto `<Microservicio>.Persistence.Database` y eligiendo el proyecto `<Microservicio>.Api` como Startup Project.

