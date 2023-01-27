USE CRUD
GO

CREATE PROCEDURE SP_GuardarInventario
	@sku VARCHAR(10),
	@nombre VARCHAR(250),
	@cantidad INT
AS
BEGIN

	INSERT INTO Inventario (SKU, Nombre, Cantidad)
	VALUES (@sku, @nombre, @cantidad)

END
GO