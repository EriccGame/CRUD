USE CRUD
GO

CREATE PROCEDURE SP_GuardarLogCrud
	@sistema VARCHAR(250),
	@metodo VARCHAR(250),
	@tipo VARCHAR(MAX),
	@descripcion VARCHAR(MAX)
AS
BEGIN

	INSERT INTO LogCrud (Sistema, Metodo, Tipo, Descripcion, Fecha)
	VALUES (@sistema, @metodo, @tipo, @descripcion, GETDATE())

END
GO
