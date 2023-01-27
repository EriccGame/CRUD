USE CRUD
GO

CREATE PROCEDURE SP_ObtenerEmpleadoPorNombre
	@nombre VARCHAR(250)
AS
BEGIN
	
	SELECT IdEmpleado, Nombre, Apellido, IdPuesto, Contrase�a
	FROM Empleado
	WHERE Nombre LIKE '%' + @nombre + '%'

END
GO
