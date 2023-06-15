Create database proyectoEscolarUVTutorias;

Use proyectoEscolarUVTutorias;

Create table Rol(
	idRol int identity primary key not null,
	administrador bit not null,
	usuario bit not null,
	tutor bit not null,
	jefeDeCarrera bit not null,
	coordinadorDeTutoriasAcademicas bit not null,
);

--Se tiene que agregar al entidad relacion
Create Table UsuarioSesion(
	idUsuario int identity primary key not null,
	idRol int foreign key references Rol(idRol),
	username varchar(50),
	contraseña varchar(50),
	nombre varchar(75)
);

Create Table Profesor(
	idProfesor int identity primary key not null,
	idRol int foreign key references Rol(idRol),
	nombre varchar(75) not null,
	numeroDeEmpleado varchar(15) not null,
	telefono varchar(10) not null,
);

Create Table ProgramaEducativo(
	idProgramaEducativo int identity primary key not null,
	idCoordinador int foreign key references Profesor(idProfesor) not null,
	anio int not null,
	area varchar(20) not null,
	carrera varchar(50) not null,
	clave varchar(50) not null,
);

Create Table Tutorado(
	idTutorado int identity primary key not null,
	idProgramaEducativo int foreign key references ProgramaEducativo(idProgramaEducativo),
	tutorAcademico int foreign key references Profesor(idProfesor),
	estaActivo bit not null,
	estaEnRiesgo bit not null,
	nombre varchar(75) not null,
	matricula varchar(15) not null,
	telefono varchar(10) not null,
	numeroCambiosTutor int not null
);


Create Table Materia(
	idMateria int identity primary key not null,
	nombreMateria varchar(100),
);

Create Table PeriodoEscolar(
	idPeriodo int identity primary key not null,
	descripcionFecha varchar(30)
);

Create Table ExperienciaEducativa(
	idExperienciaEducativa int identity primary key not null,
	idProfesor int foreign key references Profesor(idProfesor) not null,
	idMateria int foreign key references Materia(idMateria),
	idPeriodo int foreign key references PeriodoEscolar(idPeriodo),
	nrc varchar(10) not null,
);

Create Table InformacionTutoria(
	idInformacionTutoria int Primary key Identity,
	idPeriodoEscolar int foreign key references PeriodoEscolar(idPeriodo),
	noSesion int,
	fechaSesion varchar(30),
	fechaEntrega varchar(30)
);

Create Table Tutoria(
	idTutoria int identity primary key not null,
	idTutorado int foreign key references Tutorado(idTutorado) not null,
	idInformacionTutoria int foreign key references InformacionTutoria(idInformacionTutoria),
	idTutor int foreign key references Profesor(idProfesor) not null
);

--Cuando se asignen los tipos problematica se agregaran en la BD
--Agregar Tipos Problematica
Create Table TipoProblematica(
	idTipoProblematica int primary key identity not null,
	tipoProblematica varchar(50) not null
);

Create Table ReporteTutoria(
	idReporteTutoria int primary key identity not null,
	descripcion varchar(200),
	idProgramaEducativo int foreign key references ProgramaEducativo(idProgramaEducativo) not null,
	idTutoria int foreign key references Tutoria(idTutoria) not null,
	idTutorado int foreign key references Tutorado(idTutorado) not null,
	idTutor int foreign key references Profesor(idProfesor) not null,
);

Create Table HorarioTutoria(
	idHorarioTutoria int identity primary key not null,
	horarioTutoria smalldatetime,
	idTutoria int foreign key references Tutoria(idTutoria) not null,
	idTutorado int foreign key references Tutorado(idTutorado) not null,
	idTutor int foreign key references Profesor(idProfesor) not null,
);

--Cuando se asignen los tipos problematica se agregaran en la BD

Create Table Problematica(
	idProblematica int identity primary key not null,
	idReporteTutoria int foreign key references ReporteTutoria(idReporteTutoria) not null,
	descripcion varchar(200) not null,
	noIncidencias int,
	idTipo int foreign key references TipoProblematica(idTipoProblematica) not null
);

Create Table Solucion(
	idSolucion int primary key identity not null,
	idProblematica int foreign key references Problematica(idProblematica) not null,
	idAcademico int foreign key references Profesor(idProfesor) not null,
	idTutorado int foreign key references Tutorado(idTutorado) not null,
	comentarios varchar(200),
	fechaSolucion varchar(10),
);


--Se insertan datos en la tabla Rol
--Admin
Insert Into Rol(administrador, usuario, tutor, jefeDeCarrera, coordinadorDeTutoriasAcademicas) 
Values (1,0,0,0,0);
--UsuarioLogin
Insert Into Rol(administrador, usuario, tutor, jefeDeCarrera, coordinadorDeTutoriasAcademicas) 
Values (0,1,0,0,0);
--Tutor
Insert Into Rol(administrador, usuario, tutor, jefeDeCarrera, coordinadorDeTutoriasAcademicas) 
Values (0,0,1,0,0);
--Jefe de carrera
Insert Into Rol(administrador, usuario, tutor, jefeDeCarrera, coordinadorDeTutoriasAcademicas) 
Values (0,0,0,1,0);
--CoordinadorDeTutoriasAcademicas
Insert Into Rol(administrador, usuario, tutor, jefeDeCarrera, coordinadorDeTutoriasAcademicas) 
Values (0,0,0,0,1);

--Se insertan Datos en la tabla UsuarioSesion
--admin
Insert Into UsuarioSesion(idRol, username, contraseña, nombre)
Values ((select idRol from Rol where administrador=1), 'alpha', 'picorico', 'Juan Diaz');
--usuario
Insert Into UsuarioSesion(idRol, username, contraseña, nombre)
Values ((select idRol from Rol where usuario=1), 'beta', 'Avalonic', 'Pedro Garcia');
--
Insert Into UsuarioSesion(idRol, username, contraseña, nombre)
Values ((select idRol from Rol where tutor=1), 'gamma', 'requiem01', 'Erick Sanchez');

Insert Into UsuarioSesion(idRol, username, contraseña, nombre)
Values ((select idRol from Rol where jefeDeCarrera=1), 'delta', 'lolcito23', 'Ricardo Arjona');

Insert Into UsuarioSesion(idRol, username, contraseña, nombre)
Values ((select idRol from Rol where coordinadorDeTutoriasAcademicas=1), 'epsilon', 'jhin_04', 'Adelina Murciana');


--Se insertan datos en la tabla profesor

Insert Into Profesor(idRol, nombre, numeroDeEmpleado, telefono)
Values ((select idRol from Rol where tutor=1), 'Erick Sanchez', '1523', '2281085538');

Insert Into Profesor(idRol, nombre, numeroDeEmpleado, telefono)
Values ((select idRol from Rol where tutor=1), 'Juana Osorio', '1831', '2281885534');

Insert Into Profesor(idRol, nombre, numeroDeEmpleado, telefono)
Values ((select idRol from Rol where coordinadorDeTutoriasAcademicas=1), 'Adelina Murciana', '2231', '2281885534');

Insert Into Profesor(idRol, nombre, numeroDeEmpleado, telefono)
Values ((select idRol from Rol where coordinadorDeTutoriasAcademicas=1), 'Caitlyn Rodriguez', '3015', '7881885534');

Insert Into Profesor(idRol, nombre, numeroDeEmpleado, telefono)
Values ((select idRol from Rol where coordinadorDeTutoriasAcademicas=1), 'Victoria Rojano', '8016', '7881885534');

--Se insertan datos en la tabla ProgramaEducativo

Insert Into ProgramaEducativo(idCoordinador, anio, carrera, clave, area)
Values ((select idProfesor from Profesor where numeroDeEmpleado='2231'), 2014, 'Ingenieria de Software', 'lis', 'area Dummy');

Insert Into ProgramaEducativo(idCoordinador, anio, carrera, clave, area)
Values ((select idProfesor from Profesor where numeroDeEmpleado='3015'), 2017, 'Redes', 'rsc', 'area Dummy');

Insert Into ProgramaEducativo(idCoordinador, anio, carrera, clave, area)
Values ((select idProfesor from Profesor where numeroDeEmpleado='8016'), 2009, 'Tecnologias Computacionales', 'tc', 'area Dummy');


-- Se insertan datos en la tabla Tutorado

Insert Into Tutorado(tutorAcademico, idProgramaEducativo, estaActivo, estaEnRiesgo, nombre, matricula, telefono, numeroCambiosTutor)
Values ((select idProfesor from Profesor where numeroDeEmpleado='1523'),
		(select idProgramaEducativo from ProgramaEducativo where clave='tc'),
		1, 0, 'Pedro Luna', 'S19013994', '2281184716', 3
);

Insert Into Tutorado(tutorAcademico, idProgramaEducativo, estaActivo, estaEnRiesgo, nombre, matricula, telefono, numeroCambiosTutor)
Values ((select idProfesor from Profesor where numeroDeEmpleado='1523'),
		(select idProgramaEducativo from ProgramaEducativo where clave ='lis'),
		1, 1, 'Elsa Vallejo', 'S20113894', '8945151468', 2);

Insert Into Tutorado(tutorAcademico, idProgramaEducativo, estaActivo, estaEnRiesgo, nombre, matricula, telefono, numeroCambiosTutor)
Values ((select idProfesor from Profesor where numeroDeEmpleado='1831'),
		(select idProgramaEducativo from ProgramaEducativo where clave ='rcs'),
		0, 1, 'Angel Romero', 'S17113494', '4561879454', 1);

Insert Into Tutorado(tutorAcademico, idProgramaEducativo, estaActivo, estaEnRiesgo, nombre, matricula, telefono, numeroCambiosTutor)
Values ((select idProfesor from Profesor where numeroDeEmpleado='1831'),
		(select idProgramaEducativo from ProgramaEducativo where clave ='lis'),
		0, 0, 'Jorge Luna', 'S20893948', '2195454954', 0);

-- Se insertan datos en la tabla materia

Insert Into Materia(nombreMateria)
Values ('Diseño de Software');

Insert Into Materia(nombreMateria)
Values ('Tecnologias Para la Construccion de Software');

Insert Into Materia(nombreMateria)
Values ('Bases de Datos');

Insert Into Materia(nombreMateria)
Values ('Programacion');

Insert Into Materia(nombreMateria)
Values ('Requerimientos de Software');

Insert Into PeriodoEscolar(descripcionFecha)
Values ('Febrero 2022 - Julio 2022');

Insert Into PeriodoEscolar(descripcionFecha)
Values ('Agosto 2022 - Enero 2023');


--Se insertan datos en la tabla Experiencia Educativa

Insert Into ExperienciaEducativa(idProfesor, idMateria, idPeriodo, nrc)
Values (
		(select idProfesor from Profesor where numeroDeEmpleado='1523'), 
		(select idMateria from Materia where nombreMateria='Programacion'),
		(select idPeriodo from PeriodoEscolar where descripcionFecha='Agosto 2022 - Enero 2023'),
		'41156'
);

Insert Into ExperienciaEducativa(idProfesor, idMateria, idPeriodo, nrc)
Values (
		(select idProfesor from Profesor where numeroDeEmpleado='1831'), 
		(select idMateria from Materia where nombreMateria='Bases de Datos'),
		(select idPeriodo from PeriodoEscolar where descripcionFecha='Agosto 2022 - Enero 2023'),
		'58641'
);

Insert Into InformacionTutoria(idPeriodoEscolar, noSesion, fechaEntrega, fechaSesion)
Values (
	(Select idPeriodo from PeriodoEscolar where descripcionFecha='Febrero 2022 - Julio 2022'),
	1, '05/02/2022', '08/02/2022'
);
Insert Into Tutoria(idTutorado, idTutor, idInformacionTutoria)
Values (
		(select idTutorado from Tutorado where matricula='S20893948'),
		(select idProfesor from Profesor where numeroDeEmpleado='1831'),
		(select idInformacionTutoria from InformacionTutoria where fechaSesion='05/02/2022')
);


Insert Into TipoProblematica(tipoProblematica)
Values ('Economico');

Insert Into ReporteTutoria(descripcion, idProgramaEducativo, idTutoria, idTutorado, idTutor)
Values (
		'Existe una problematica economica con el alumno',
		(select idProgramaEducativo from ProgramaEducativo where clave ='lis'),
		(select idTutoria from Tutoria where idTutoria=1),
		(select idTutorado from Tutorado where matricula='S20113894'),
		(select idProfesor from Profesor where numeroDeEmpleado='1523')
);

Insert Into Problematica(idReporteTutoria, idTipo, descripcion, noIncidencias)
Values (
		(select idReporteTutoria from ReporteTutoria where descripcion ='Existe una problematica economica con el alumno'),
		(Select idTIpoProblematica from TipoProblematica where tipoProblematica ='Economico'),
		'Descripcion Dummy',
		1
);

Insert Into Solucion(idProblematica, idAcademico, idTutorado, comentarios, fechaSolucion)
Values(
		(Select idProblematica from Problematica where descripcion ='Descripcion Dummy'),
		(select idProfesor from Profesor where numeroDeEmpleado='1523'),
		(select idTutorado from Tutorado where matricula='S20113894'),
		'Comentarios Dummy', '21/11/2022'
);
