USE CRUD
GO

CREATE PROCEDURE SP_ObtenerCliente
AS
BEGIN
	
	SELECT IdCliente, Nombre, Apellido, FechaNacimiento
	FROM Cliente

END
GO
