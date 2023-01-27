USE CRUD
GO

CREATE PROCEDURE SP_EliminarEmpleado
	@idEmpleado VARCHAR(10)
AS
BEGIN

	DELETE FROM Empleado
	WHERE IdEmpleado = @idEmpleado

END
GO
