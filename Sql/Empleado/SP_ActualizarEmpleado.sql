USE CRUD
GO

CREATE PROCEDURE SP_ActualizarEmpleado
	@idEmpleado VARCHAR(10),
	@nombre VARCHAR(250),
	@apellido VARCHAR(250),
	@idPuesto INT,
	@contraseņa VARCHAR(250)
AS
BEGIN

	UPDATE Empleado
	SET Nombre = @nombre
		, Apellido = @apellido
		, IdPuesto = @idPuesto
		, Contraseņa = @contraseņa
	WHERE IdEmpleado = @idEmpleado

END
GO
