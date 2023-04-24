USE [BdiExamen]
GO
/****** Object:  StoredProcedure [dbo].[spActualizar]    Script Date: 22/04/2023 01:18:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spActualizar]
@IdExamen int,
@Codigo varchar(255),
@Nombre varchar(255),
@Descripcion varchar(255),
@Resultado int OUTPUT
AS
BEGIN 
	BEGIN TRAN

	UPDATE tblExamen 
	SET Nombre = @Nombre, Descripcion = @Descripcion, Codigo =  @Codigo
	WHERE IdExamen =  @IdExamen

	IF @@ERROR = 0
	BEGIN 
		COMMIT
		SELECT 'Registro actualizado satisfactoriamente'
	END ELSE BEGIN ROLLBACK
	    SELECT 'Registro no actualizado'
		RETURN @@ERROR
	END 
END 

GO

CREATE   PROCEDURE [dbo].[spAgregar] --'', '' , '',0
@Codigo varchar(255),
@Nombre varchar(255),
@Descripcion varchar(255),
@Resultado int OUTPUT
AS
BEGIN 
	BEGIN TRAN

	INSERT INTO tblExamen (Nombre, Descripcion, Codigo , Activo) 
	values(@Nombre,@Descripcion, @Codigo, 1)

	IF @@ERROR = 0
	BEGIN 
		COMMIT
		SELECT 'Registro insertado satisfactoriamente'
		RETURN SCOPE_IDENTITY()
	END ELSE BEGIN ROLLBACK
	    SELECT 'Registro no insertado'
		RETURN @@ERROR
	END 
END 


GO

CREATE PROCEDURE [dbo].[spConsultar]  
@Codigo VARCHAR(25),
@Nombre VARCHAR(255),
@Descripcion VARCHAR(255)
AS
BEGIN 
	
	Declare @QRYCOMMAND NVARCHAR(max) = ''
	

	set @QRYCOMMAND = 'Select IdExamen, Codigo, Nombre, Descripcion, Activo  from tblExamen WHERE 1=1'
	
	IF @Codigo != '' BEGIN 
	 set @QRYCOMMAND += N' And Codigo = @Codigo' 
	END 
	IF @Nombre != '' BEGIN 
	 set @QRYCOMMAND += N' And Nombre = @Nombre' 
	END 
	IF @Descripcion != '' BEGIN 
	 set @QRYCOMMAND += N' And Descripcion = @Descripcion' 
	END 
	
	EXECUTE sp_executesql @QRYCOMMAND, N'@Codigo VARCHAR(25), @Nombre VARCHAR(255), @Descripcion VARCHAR(255)'
									, @Codigo , @Nombre, @Descripcion

END 

GO

CREATE PROCEDURE [dbo].[spEliminar]
@IdExamen int,
@Resultado int OUTPUT
AS
BEGIN 

	BEGIN TRAN

	UPDATE tblExamen 
	SET Activo = 0
	WHERE IdExamen =  @IdExamen

	IF @@ERROR = 0
	BEGIN 
		COMMIT
		SELECT 'Registro eliminado satisfactoriamente'
		RETURN SCOPE_IDENTITY()
	END ELSE BEGIN ROLLBACK
	    SELECT 'Registro no eliminado'
		RETURN @@ERROR
	END 
END 