
```sh
## Crear Esquema de BD
## Ejecutar -> Script de la base de Datos.sql
## Ejecutar -> Script de los Stored Procedures.sql
````

```sh
## Configuración Requerida
> Instalar .Net 6 - https://dotnet.microsoft.com/download/dotnet
> dotnet tool install --global dotnet-ef
````


```sh
## User Secret
Comandos user-secrets (beneficio de no exponer los datos de la cadena de conexion)

> dotnet user-secrets init                      -> inicializar user-secrets
> dotnet user-secrets list						-> consultar las variables de configuracion
```

```sh
##Agregar user-secrets de proyecto WsApiexamen
> dotnet user-secrets init --project WsApiexamen
> dotnet user-secrets set "ConnectionStrings:ExamenConnection" "Data Source=[server];Initial Catalog=BdiExamen;User ID=[userDB];Password=[passwordDB];Encrypt=False" --project WsApiexamen
```

```sh
https://localhost:5012/swagger
```