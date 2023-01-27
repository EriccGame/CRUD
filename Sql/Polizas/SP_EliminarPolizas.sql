USE CRUD
GO

CREATE PROCEDURE SP_EliminarPolizas
	@idPolizas INT
AS
BEGIN

	DELETE FROM Polizas
	WHERE IdPolizas = @idPolizas

END
GO
