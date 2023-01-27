CREATE DATABASE CRUD
GO

USE CRUD
GO

CREATE TABLE Inventario
(	
	SKU VARCHAR(10),
	Nombre VARCHAR(250),
	Cantidad INTEGER,
    CONSTRAINT PK_Inventario PRIMARY KEY (SKU)
)
GO

CREATE TABLE Puesto
(	
	IdPuesto INT IDENTITY(1,1),
	Nombre VARCHAR(250)
    CONSTRAINT PK_Puesto PRIMARY KEY (IdPuesto)
)
GO

CREATE TABLE Empleado
(	
	IdEmpleado VARCHAR(10),
	Nombre VARCHAR(250),
	Apellido VARCHAR(250),
	IdPuesto INT,
	Contraseña VARCHAR(250)
    CONSTRAINT PK_Empleado PRIMARY KEY (IdEmpleado)
    CONSTRAINT FK_Empleado_Puesto FOREIGN KEY (IdPuesto) REFERENCES Puesto(IdPuesto)
)
GO

CREATE TABLE Cliente
(
	IdCliente VARCHAR(10),
	Nombre VARCHAR(250),
	Apellido VARCHAR(250),
	FechaNacimiento DATE,
    CONSTRAINT PK_Cliente PRIMARY KEY (IdCliente)
)
GO

CREATE TABLE Polizas
(	
	IdPolizas INT IDENTITY(1,1),
	EmpleadoGenero VARCHAR(10),
	SKU VARCHAR(10),
	Cantidad INT,
	Fecha DATETIME,
	IdCliente VARCHAR(10),
    CONSTRAINT PK_Polizas PRIMARY KEY (IdPolizas),
    CONSTRAINT FK_Polizas_IdEmpleado FOREIGN KEY (EmpleadoGenero) REFERENCES Empleado(IdEmpleado),
    CONSTRAINT FK_Polizas_SKU FOREIGN KEY (SKU) REFERENCES Inventario(SKU),
    CONSTRAINT FK_Polizas_IdCliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
)
GO

CREATE TABLE LogCrud
(	
	IdLog INT IDENTITY(1,1),
	Sistema VARCHAR(250),
	Metodo VARCHAR(250),
	Tipo VARCHAR(MAX),
	Descripcion VARCHAR(MAX),
	Fecha DATETIME,
    CONSTRAINT PK_LogCrud PRIMARY KEY (IdLog)
)
GO

INSERT INTO Puesto (Nombre) VALUES ('Programador')
INSERT INTO Puesto (Nombre) VALUES ('Tester')
INSERT INTO Puesto (Nombre) VALUES ('Analista')

SELECT * FROM Puesto
SELECT * FROM Empleado
SELECT * FROM Inventario
SELECT * FROM Cliente
SELECT * FROM Polizas
SELECT * FROM LogCrud