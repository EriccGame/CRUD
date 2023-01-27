USE CRUD
GO

CREATE PROCEDURE SP_ObtenerInventarioPorNombre
	@nombre VARCHAR(250)
AS
BEGIN
	
	SELECT SKU, Nombre, Cantidad
	FROM  Inventario
	WHERE Nombre LIKE '%' + @nombre + '%'

END
GO
