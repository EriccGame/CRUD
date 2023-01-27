USE CRUD
GO

CREATE PROCEDURE SP_ObtenerInventario
AS
BEGIN
	
	SELECT SKU, Nombre, Cantidad
	FROM Inventario

END
GO
