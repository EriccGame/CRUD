USE CRUD
GO

CREATE PROCEDURE SP_ObtenerEmpleadoPorId
	@idEmpleado VARCHAR(10)
AS
BEGIN
	
	SELECT IdEmpleado, Nombre, Apellido, IdPuesto, Contrase�a
	FROM Empleado
	WHERE IdEmpleado = @idEmpleado

END
GO
