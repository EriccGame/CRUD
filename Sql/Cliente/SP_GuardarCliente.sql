USE CRUD
GO

CREATE PROCEDURE SP_GuardarCliente
	@idCliente VARCHAR(10),
	@nombre VARCHAR(250),
	@apellido VARCHAR(250),
	@fechaNacimiento DATE
AS
BEGIN

	INSERT INTO Cliente (IdCliente, Nombre, Apellido, FechaNacimiento)
	VALUES (@idCliente, @nombre, @apellido, @fechaNacimiento)

END
GO
