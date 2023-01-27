USE CRUD
GO

CREATE PROCEDURE SP_EliminarCliente
	@idCliente VARCHAR(10)
AS
BEGIN

	DELETE FROM Cliente
	WHERE IdCliente = @idCliente

END
GO
