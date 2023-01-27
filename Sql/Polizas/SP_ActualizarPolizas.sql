USE CRUD
GO

CREATE PROCEDURE SP_ActualizarPolizas
	@idPolizas INT,
	@idEmpleado VARCHAR(10),
	@sku VARCHAR(10),
	@cantidad INT,
	@fecha DATE,
	@idCliente VARCHAR(10)
AS
BEGIN

	UPDATE Polizas
	SET EmpleadoGenero = @idEmpleado
		, SKU = @sku
		, Cantidad = @cantidad
		, Fecha = @fecha
		, IdCliente = @idCliente
	WHERE IdPolizas = @idPolizas

END
GO
