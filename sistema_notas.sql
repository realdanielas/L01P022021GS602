CREATE DATABASE db_notas;
GO
USE db_notas;
GO

CREATE TABLE facultad
(id       INT IDENTITY(1, 1) PRIMARY KEY,
 facultad VARCHAR(100)
);

CREATE TABLE materias
(id                   INT IDENTITY(1, 1) PRIMARY KEY,
 materia              VARCHAR(100),
 unidades_valorativas INT,
 estado               CHAR(1)
);

CREATE TABLE departamentos
(id           INT IDENTITY(1, 1) PRIMARY KEY,
 departamento VARCHAR(50)
);

CREATE TABLE alumnos
(id           INT IDENTITY(1, 1) PRIMARY KEY,
 codigo       VARCHAR(10),
 nombre       VARCHAR(50),
 apellidos    VARCHAR(50),
 dui          INT,
 estado       INT
);