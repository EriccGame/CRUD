USE CRUD
GO

CREATE PROCEDURE SP_ActualizarEmpleado
	@idEmpleado VARCHAR(10),
	@nombre VARCHAR(250),
	@apellido VARCHAR(250),
	@idPuesto INT,
	@contraseña VARCHAR(250)
AS
BEGIN

	UPDATE Empleado
	SET Nombre = @nombre
		, Apellido = @apellido
		, IdPuesto = @idPuesto
		, Contraseña = @contraseña
	WHERE IdEmpleado = @idEmpleado

END
GO
