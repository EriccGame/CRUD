USE CRUD
GO

CREATE PROCEDURE SP_ObtenerPolizas
AS
BEGIN

	SELECT IdPolizas
		, EmpleadoGenero
		, SKU
		, Cantidad
		, Fecha
		, IdCliente
	FROM Polizas

END
GO
