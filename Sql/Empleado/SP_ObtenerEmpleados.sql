USE CRUD
GO

CREATE PROCEDURE SP_ObtenerEmpleados
AS
BEGIN
	
	SELECT IdEmpleado, Nombre, Apellido, IdPuesto, Contraseņa
	FROM Empleado

END
GO
