USE CRUD
GO

CREATE PROCEDURE SP_GuardarPolizas
	@idEmpleado VARCHAR(10),
	@sku VARCHAR(10),
	@cantidad INT,
	@fecha DATE,
	@idCliente VARCHAR(10)
AS
BEGIN

	DECLARE @idPoliza INT

	INSERT INTO Polizas (EmpleadoGenero, SKU, Cantidad, Fecha, IdCliente)
	VALUES (@idEmpleado, @sku, @cantidad, @fecha, @idCliente)

	SET @idPoliza = SCOPE_IDENTITY()

	SELECT P.IdPolizas, P.Cantidad, E.Nombre, E.Apellido, I.SKU, I.Nombre AS NombreArticulo
	FROM Polizas AS P
	INNER JOIN Empleado AS E
		ON P.EmpleadoGenero = E.IdEmpleado
	INNER JOIN Inventario I
		ON P.SKU = I.SKU
	WHERE P.IdPolizas = @idPoliza

END
GO
