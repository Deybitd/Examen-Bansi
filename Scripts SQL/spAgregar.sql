CREATE PROCEDURE spAgregar (@Id INT,@Nombre VARCHAR(255),@Descripcion VARCHAR(255))
AS
DECLARE @DescripcionDeRetorno VARCHAR(255);
	DECLARE @Codigo INT;
IF EXISTS(SELECT 1 FROM tblExamen WHERE idExamen = @Id)
BEGIN
	
	SET @DescripcionDeRetorno = 'Error ya existe un registro con ese ID';
	SET @Codigo = 2;
	SELECT	@Codigo as N'Codigo', @DescripcionDeRetorno as N'Descripcion';
		
END
ELSE
BEGIN
	INSERT INTO tblExamen(idExamen,Nombre,Descripcion)
	VALUES(@Id,@Nombre,@Descripcion)
	SET @DescripcionDeRetorno = 'Registro insertado satisfactoriamente';
	SET @Codigo = 0;
	SELECT	@Codigo as N'Codigo', @DescripcionDeRetorno as N'Descripcion';
END