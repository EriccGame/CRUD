USE CRUD
GO

CREATE PROCEDURE SP_ObtenerLogCrud
AS
BEGIN

	SELECT Sistema, Metodo, Tipo, Descripcion, Fecha
	FROM LogCrud (NOLOCK)

END
GO
