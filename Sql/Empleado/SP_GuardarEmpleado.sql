USE CRUD
GO

CREATE PROCEDURE SP_GuardarEmpleado
	@idEmpleado VARCHAR(10),
	@nombre VARCHAR(250),
	@apellido VARCHAR(250),
	@idPuesto INT,
	@contraseña VARCHAR(250)
AS
BEGIN

	INSERT INTO Empleado (IdEmpleado, Nombre, Apellido, IdPuesto, Contraseña)
	VALUES (@idEmpleado, @nombre, @apellido, @idPuesto, @contraseña)

END
GO
