USE [BdiExamen]
GO

CREATE PROCEDURE [dbo].[spEliminar] (@Id INT)
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
	DELETE FROM tblExamen WHERE idExamen = @id;
	SET @DescripcionDeRetorno = 'Registro Eliminado Satisfactoriamente';
	SET @Codigo = 0;
	SELECT	@Codigo as N'Codigo', @DescripcionDeRetorno as N'Descripcion';
END
GO
