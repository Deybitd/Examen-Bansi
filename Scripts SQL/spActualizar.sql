USE [BdiExamen]
GO

CREATE PROCEDURE [dbo].[spActualizar] (@Id INT,@Nombre VARCHAR(255),@Descripcion VARCHAR(255))
AS
DECLARE @DescripcionDeRetorno VARCHAR(255);
	DECLARE @Codigo INT;
IF NOT EXISTS(SELECT 1 FROM tblExamen WHERE idExamen = @Id)
BEGIN
	
	SET @DescripcionDeRetorno = 'Error No existe un registro con ese ID';
	SET @Codigo = 1;
	SELECT	@Codigo as N'Codigo', @DescripcionDeRetorno as N'Descripcion';
		
END
ELSE
BEGIN
	UPDATE tblExamen SET Nombre =@Nombre,Descripcion = @Descripcion WHERE idExamen = @id;
	SET @DescripcionDeRetorno = 'Registro Modificado Satisfactoriamente';
	SET @Codigo = 0;
	SELECT	@Codigo as N'Codigo', @DescripcionDeRetorno as N'Descripcion';
END
GO

