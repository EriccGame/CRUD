USE CRUD
GO

CREATE PROCEDURE SP_ObtenerEmpleados
AS
BEGIN
	
	SELECT IdEmpleado, Nombre, Apellido, IdPuesto, Contraseña
	FROM Empleado

END
GO
