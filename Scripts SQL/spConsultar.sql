USE [BdiExamen]
GO

CREATE PROCEDURE spConsultar (@Nombre VARCHAR(255),@Descripcion VARCHAR(255))
AS
BEGIN
	SELECT idExamen,Nombre,Descripcion FROM tblExamen WHERE Nombre = @Nombre AND Descripcion = @Descripcion;
END