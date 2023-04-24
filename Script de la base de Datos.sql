create database BdiExamen 

create table tblExamen (
IdExamen int primary key identity(1,1),
Codigo varchar(25), -- Se agrega este campo para evitar modificar como tal el ID del registro de la tabla
Nombre varchar(255),
Descripcion varchar(255),
Activo bit -- Se agrega campo por logica no podemos eliminar datos importantes solo se debe de deshabilitar.
) 