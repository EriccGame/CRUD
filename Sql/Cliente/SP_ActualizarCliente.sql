USE CRUD
GO

CREATE PROCEDURE SP_ActualizarCliente
	@idCliente VARCHAR(10),
	@nombre VARCHAR(250),
	@apellido VARCHAR(250),
	@fechaNacimiento DATE
AS
BEGIN

	UPDATE Cliente
	SET Nombre = @nombre
		, Apellido = @apellido
		, FechaNacimiento = @fechaNacimiento
	WHERE IdCliente = @idCliente

END
GO
