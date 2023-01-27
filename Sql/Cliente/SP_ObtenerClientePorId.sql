USE CRUD
GO

CREATE PROCEDURE SP_ObtenerClientePorId
	@idCliente VARCHAR(10)
AS
BEGIN
	
	SELECT IdCliente, Nombre, Apellido, FechaNacimiento
	FROM Cliente
	WHERE IdCliente = @idCliente

END
GO
