USE CRUD
GO

CREATE PROCEDURE SP_ActualizarInventario
	@sku VARCHAR(10),
	@nombre VARCHAR(250),
	@cantidad INT
AS
BEGIN
	
	UPDATE Inventario
	SET Nombre = @nombre
		, Cantidad = @cantidad
	WHERE SKU = @sku

END
GO