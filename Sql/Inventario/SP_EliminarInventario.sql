USE CRUD
GO

CREATE PROCEDURE SP_EliminarInventario
	@sku VARCHAR(10)
AS
BEGIN

	DELETE FROM Inventario
	WHERE SKU = @sku

END
GO
