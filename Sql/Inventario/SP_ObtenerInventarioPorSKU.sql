USE CRUD
GO

CREATE PROCEDURE SP_ObtenerInventarioPorSKU
	@sku VARCHAR(10)
AS
BEGIN
	
	SELECT SKU, Nombre, Cantidad
	FROM Inventario
	WHERE SKU = @sku

END
GO
