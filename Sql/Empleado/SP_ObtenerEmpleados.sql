USE CRUD
GO

CREATE PROCEDURE SP_ObtenerEmpleados
AS
BEGIN
	
	SELECT IdEmpleado, Nombre, Apellido, IdPuesto, Contrase�a
	FROM Empleado

END
GO
