USE CRUD
GO

CREATE PROCEDURE SP_ObtenerPolizasPorId
	@idPolizas INT
AS
BEGIN

	SELECT P.IdPolizas, P.Cantidad, E.Nombre, E.Apellido, I.SKU, I.Nombre AS NombreArticulo
	FROM Polizas AS P
	INNER JOIN Empleado AS E
		ON P.EmpleadoGenero = E.IdEmpleado
	INNER JOIN Inventario I
		ON P.SKU = I.SKU
	WHERE P.IdPolizas = @idPolizas

END
GO
