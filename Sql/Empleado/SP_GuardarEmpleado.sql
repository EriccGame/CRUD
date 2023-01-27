USE CRUD
GO

CREATE PROCEDURE SP_GuardarEmpleado
	@idEmpleado VARCHAR(10),
	@nombre VARCHAR(250),
	@apellido VARCHAR(250),
	@idPuesto INT,
	@contrase�a VARCHAR(250)
AS
BEGIN

	INSERT INTO Empleado (IdEmpleado, Nombre, Apellido, IdPuesto, Contrase�a)
	VALUES (@idEmpleado, @nombre, @apellido, @idPuesto, @contrase�a)

END
GO
