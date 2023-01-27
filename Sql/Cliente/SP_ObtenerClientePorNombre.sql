USE CRUD
GO

CREATE PROCEDURE SP_ObtenerClientePorNombre
	@nombre VARCHAR(250)
AS
BEGIN
	
	SELECT IdCliente, Nombre, Apellido, FechaNacimiento
	FROM Cliente
	WHERE Nombre LIKE '%' + @nombre + '%'

END
GO
