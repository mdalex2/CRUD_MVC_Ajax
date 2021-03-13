--BASE DE DATOS jmendoza
SET IDENTITY_INSERT Materias ON
truncate table Materias
insert into Materias (Id,Nombre_mat) VALUES
(1,'Materia 01'),
(2,'Materia 02'),
(3,'Materia 03'),
(4,'Materia 04')

SET IDENTITY_INSERT Materias OFF

truncate table alumnos
SET IDENTITY_INSERT Alumnos ON
insert into Alumnos(Id,Nombre,Direccion,Telefono,Fecha_nac) VALUES
(1,'Alumno 01','Direccion 01','Teléfono 01','01/12/1981'),
(2,'Alumno 02','Direccion 02','Teléfono 02','02/12/1982'),
(3,'Alumno 03','Direccion 03','Teléfono 03','03/12/1983'),
(4,'Alumno 04','Direccion 04','Teléfono 04','04/12/1984')

SET IDENTITY_INSERT Alumnos OFF

truncate table Notas_Alumnos
SET IDENTITY_INSERT Notas_Alumnos ON
insert into Notas_Alumnos (Id,Alumno,Materia,Nota1,Nota2,Nota3,Promedio,Estado) VALUES
(1,'Alumno 01','Materia 01',10.2,11.6,12,11,'Aprobado'),
(2,'Alumno 02','Materia 01',13,14,15,16,'Aprobado'),
(3,'Alumno 03','Materia 01',17,18,19,20,'Aprobado'),
(4,'Alumno 04','Materia 01',5.4,6,7,8,'Reprobado'),
(5,'Alumno 05','Materia 01',10,11,12,11,'Aprobado')

SET IDENTITY_INSERT Notas_Alumnos OFF

select * from Materias
select * from Alumnos
select * from Notas_Alumnos