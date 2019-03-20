use master
go

create database SARHU collate Modern_Spanish_CI_AS
GO

use SARHU
GO

/* TABLAS --- SARHU */

create table SARHU_MODULOS
(
	modulo_id int identity
		constraint [ SARHU_MODULOS_pk]
			primary key clustered,
	modulo_nombre varchar(20) not null,
	modulo_descripcion varchar(150)
)
GO

create unique index SARHU_MODULOS_modulo_id_uindex
	on [SARHU_MODULOS] (modulo_id)
GO

create table SARHU_FUNCIONALIDADES
(
	funcionalidad_id int identity
		constraint SARHU_FUNCIONALIDADES_pk
			primary key clustered,
	modulo_id int not null
		constraint SARHU_FUNCIONALIDADES_SARHU_MODULOS_modulo_id_fk
			references SARHU_MODULOS,
	funcionalidad_descripcion varchar(150),
	funcionalidad_url varchar(100) not null
)
GO

create unique index SARHU_FUNCIONALIDADES_funcionalidad_id_uindex
	on SARHU_FUNCIONALIDADES (funcionalidad_id)
GO

create table SARHU_ROLES
(
	rol_id int identity
		constraint SARHU_ROLES_pk
			primary key clustered,
	rol_nombre varchar(20) not null,
	rol_descripcion varchar(50),
	rol_estado bit default 1 not null
)
GO

create unique index SARHU_ROLES_rol_id_uindex
	on SARHU_ROLES (rol_id)
GO

create table SARHU_PERMISOS
(
	rol_id int not null
		constraint SARHU_PERMISOS_SARHU_ROLES_rol_id_fk
			references SARHU_ROLES,
	funcionalidad_id int not null
		constraint SARHU_PERMISOS_SARHU_FUNCIONALIDADES_funcionalidad_id_fk
			references SARHU_FUNCIONALIDADES
)
GO

create table SARHU_USUARIOS
(
	usuario_id int identity
		constraint SARHU_USUARIOS_pk
			primary key clustered,
	rol_id int not null
		constraint SARHU_USUARIOS_SARHU_ROLES_rol_id_fk
			references SARHU_ROLES,
	colaborador_id int,
	usuario_nombre varchar(20) not null,
	usuario_clave varchar(75) not null,
	usuario_correo varchar(50),
	usuario_estado bit default 1 not null
)
GO

create unique index SARHU_USUARIOS_usuario_id_uindex
	on SARHU_USUARIOS (usuario_id)
GO

create table SARHU_OPERACIONES
(
	operacion_id int identity
		constraint SARHU_OPERACIONES_pk
			primary key clustered,
	operacion_nombre varchar(20) not null
)
GO

create unique index SARHU_OPERACIONES_operacion_id_uindex
	on [SARHU_OPERACIONES] (operacion_id)
GO

create table SARHU_BITACORA
(
	bitacora_id int identity
		constraint SARHU_BITACORA_pk
			primary key clustered,
	usuario_id int not null
		constraint SARHU_BITACORA_SARHU_USUARIOS_usuario_id_fk
			references SARHU_USUARIOS,
	operacion_id int not null
		constraint SARHU_BITACORA_SARHU_OPERACIONES_operacion_id_fk
			references SARHU_OPERACIONES,
	bitacora_tabla varchar(20) not null,
	bitacora_comentario varchar(150),
	bitacora_usuario_bd varchar(20) default suser_sname(),
	bitacora_fecha_registro datetime default getdate()
)
GO

create unique index SARHU_BITACORAS_bitacora_id_uindex
	on SARHU_BITACORA (bitacora_id)
GO

create table SARHU_DEPARTAMENTOS
(
	departamento_id int identity
		constraint SARHU_DEPARTAMENTOS_pk
			primary key clustered,
	departamento_nombre varchar(20)
)
GO

create unique index SARHU_DEPARTAMENTOS_departamento_id_uindex
	on SARHU_DEPARTAMENTOS (departamento_id)
GO

create table SARHU_MUNICIPIOS
(
	municipio_id int identity
		constraint SARHU_MUNICIPIOS_pk
			primary key clustered,
	departamento_id int not null
		constraint SARHU_MUNICIPIOS_SARHU_DEPARTAMENTOS_departamento_id_fk
			references SARHU_DEPARTAMENTOS,
	municipio_nombre varchar(30) not null
)
GO

create unique index SARHU_MUNICIPIOS_municipio_id_uindex
	on SARHU_MUNICIPIOS (municipio_id)
GO

create table SARHU_INSS
(
  	inss_id int identity
		constraint SARHU_INSS_pk
			primary key clustered,
	inss_porcentaje decimal(5,2) not null,
	inss_patronal bit not null,
	inss_ultima_actualizacion datetime not null
)
GO

create unique index SARHU_INSS_inss_id_uindex
	on SARHU_INSS (inss_id)
GO

create table SARHU_IR
(
	ir_id int identity
		constraint SARHU_IR_pk
			primary key clustered,
	ir_desde decimal(9,2) not null,
	ir_hasta decimal(9,2) not null,
	ir_base decimal(9,2) not null,
	ir_exceso decimal(9,2) not null,
	ir_porcentaje_aplicable decimal(5,2) not null,
	ir_ultima_actualizacion datetime not null
)
GO

create unique index SARHU_IR_ir_id_uindex
	on SARHU_IR (IR_id)
GO

create table SARHU_VARIABLES
(
	variable_id int identity
		constraint SARHU_VARIABLES_pk
			primary key clustered,
	variable_nombre varchar(50) not null,
	variable_valor decimal(18,2) not null,
	variable_ultima_actualizacion datetime not null
)
GO

create unique index SARHU_VARIABLES_variable_id_uindex
	on SARHU_VARIABLES (variable_id)
GO


/* TABLAS --- SOS */

create table SOS_PROGRAMAS
(
	programa_id int identity
		constraint SOS_PROGRAMAS_pk
			primary key clustered,
	programa_nombre varchar(50) not null,
	programa_descripcion varchar(150) not null,
	programa_estado bit default 1 not null
)
GO

create unique index SOS_PROGRAMAS_programa_id_uindex
	on SOS_PROGRAMAS (programa_id)
GO

create table SOS_LOCALIDADES
(
	localidad_id int identity
		constraint SOS_LOCALIDADES_pk
			primary key clustered,
	programa_id int not null
		constraint SOS_LOCALIDADES_SOS_PROGRAMAS_programa_id_fk
			references SOS_PROGRAMAS,
	municipio_id int not null
		constraint SOS_LOCALIDADES_SARHU_MUNICIPIOS_municipio_id_fk
			references SARHU_MUNICIPIOS,
	director_id int,
	localidad_alias varchar(100),
	localidad_telefono varchar(9),
	localidad_direccion varchar(200),
	localidad_estado bit default 1 not null
)
GO

create unique index SOS_LOCALIDADES_local_id_uindex
	on SOS_LOCALIDADES (localidad_id)
GO

create table SOS_ORGANIZACION
(
	organizacion_pais int
		constraint SOS_ORGANIZACION_pk
			primary key clustered,
	organizacion_nombre varchar(100) not null,
	organizacion_mision varchar(200),
	organizacion_vision varchar(200),
	organizacion_descripcion text,
	localidad_id int
)
GO

create unique index SOS_ORGANIZACION_organizacion_pais_uindex
	on SOS_ORGANIZACION (organizacion_pais)
GO

create table SOS_AREAS
(
	area_id int identity
		constraint SOS_AREAS_pk
			primary key clustered,
	area_nombre varchar(50) not null,
	area_descripcion varchar(150),
	area_estado bit default 1 not null
)
GO

create unique index SOS_AREAS_area_id_uindex
	on SOS_AREAS (area_id)
GO


create table SOS_PUESTOS
(
	puesto_id int identity
		constraint SOS_PUESTOS_pk
			primary key clustered,
	puesto_nombre varchar(50) not null,
	puesto_descripcion varchar(150),
	cuenta_id int not null,
	area_id int not null
		constraint SOS_PUESTOS_SOS_AREAS_area_id_fk
			references SOS_AREAS,
	puesto_salario_base decimal(9,2),
	puesto_estado bit default 1 not null
)
GO

create unique index SOS_PUESTOS_puesto_id_uindex
	on SOS_PUESTOS (puesto_id)
GO

create table SOS_FUNCIONES
(
	funcion_id int identity
		constraint SOS_FUNCIONES_pk
			primary key clustered,
	funcion_nombre varchar(50) not null,
	funcion_descripcion varchar(150),
	funcion_estado bit default 1 not null
)
GO

create unique index SOS_FUNCIONES_funcion_id_uindex
	on SOS_FUNCIONES (funcion_id)
GO

create table SOS_PUESTOS_FUNCIONES
(
	puesto_id int not null
		constraint SOS_PUESTOS_FUNCIONES_SOS_PUESTOS_puesto_id_fk
			references SOS_PUESTOS,
	funcion_id int not null
		constraint SOS_PUESTOS_FUNCIONES_SOS_FUNCIONES_funcion_id_fk
			references SOS_FUNCIONES
)
GO

create table SOS_BONOS
(
	bono_id int identity
		constraint SOS_BONOS_pk
			primary key clustered,
	bono_nombre varchar(30) not null,
	bono_descripcion varchar(150) not null,
	bono_monto decimal(8,2),
	bono_estado bit default 1 not null
)
GO

create unique index SOS_BONOS_bono_id_uindex
	on SOS_BONOS (bono_id)
GO

/* ------------ fin tablas ------------ */

/* PROCEDIMIENTOS ALMACENADOS ---SARHU */

--SARHU_MODULOS

CREATE PROCEDURE sp_modulos_list
AS
	SELECT modulo_id, modulo_nombre, modulo_descripcion
	FROM SARHU.dbo.SARHU_MODULOS;
GO

--SARHU_FUNCIONALIDADES

CREATE PROCEDURE sp_funcionalidades_list
AS
	SELECT funcionalidad_id, modulo_id, funcionalidad_descripcion, funcionalidad_url
	FROM SARHU.dbo.SARHU_FUNCIONALIDADES
GO

--SARHU_ROLES

CREATE PROCEDURE sp_roles_list
AS
	SELECT rol_id, rol_nombre, rol_descripcion, rol_estado
	FROM SARHU.dbo.SARHU_ROLES;
GO

CREATE PROCEDURE sp_roles_consult
(@rol_id int)
AS
	SELECT rol_nombre, rol_descripcion, rol_estado
	FROM SARHU.dbo.SARHU_ROLES
	WHERE rol_id = @rol_id;
GO

CREATE PROCEDURE sp_roles_insert
(@rol_nombre varchar(20), @rol_descripcion varchar(50))
AS
	INSERT INTO SARHU.dbo.SARHU_ROLES(rol_nombre, rol_descripcion)
	VALUES (@rol_nombre, @rol_descripcion);
	SELECT SCOPE_IDENTITY();
GO

CREATE PROCEDURE sp_roles_update
(@rol_id int, @rol_nombre varchar(20), @rol_descripcion varchar(50))
AS
	UPDATE SARHU.dbo.SARHU_ROLES
	SET	rol_nombre = @rol_nombre, rol_descripcion = @rol_descripcion
    WHERE rol_id = @rol_id;
GO

CREATE PROCEDURE sp_roles_delete
(@rol_id int)
AS
	UPDATE SARHU.dbo.SARHU_ROLES
	SET	rol_estado = 0
	WHERE rol_id = @rol_id;
GO

--SARHU_PERMISOS

CREATE PROCEDURE sp_permisos_list
AS
	SELECT rol_id, funcionalidad_id
	FROM SARHU.dbo.SARHU_PERMISOS;
GO

CREATE PROCEDURE sp_permisos_insert
(@rol_id int, @funcionalidad_id int)
AS
	INSERT INTO SARHU.dbo.SARHU_PERMISOS(rol_id, funcionalidad_id)
	VALUES (@rol_id, @funcionalidad_id);
GO

CREATE PROCEDURE sp_permisos_delete
(@rol_id int, @funcionalidad_id int)
AS
	DELETE FROM SARHU.dbo.SARHU_PERMISOS
	WHERE rol_id = @rol_id AND funcionalidad_id = @funcionalidad_id;
GO

--SARHU_USUARIOS

CREATE PROCEDURE sp_usuarios_list
AS
	SELECT usuario_id, rol_id, colaborador_id, usuario_nombre, usuario_clave, usuario_correo, usuario_estado
	FROM SARHU.dbo.SARHU_USUARIOS;
GO

CREATE PROCEDURE sp_usuarios_consult
(@usuario_id int)
AS
	SELECT rol_id, colaborador_id, usuario_nombre, usuario_clave, usuario_correo, usuario_estado
	FROM SARHU.dbo.SARHU_USUARIOS
	WHERE usuario_id = @usuario_id;
GO

CREATE PROCEDURE sp_usuarios_insert
(@rol_id int, @colaborador_id int, @usuario_nombre varchar(20), @usuario_clave varchar(75), @usuario_correo varchar(50))
AS
	INSERT INTO SARHU.dbo.SARHU_USUARIOS(rol_id, colaborador_id, usuario_nombre, usuario_clave, usuario_correo)
	VALUES (@rol_id, @colaborador_id, @usuario_nombre, @usuario_clave, @usuario_correo);
	SELECT SCOPE_IDENTITY();
GO

CREATE PROCEDURE sp_usuarios_update
(@usuario_id int, @rol_id int, @colaborador_id int, @usuario_nombre varchar(20), @usuario_clave varchar(75), @usuario_correo varchar(50))
AS
	UPDATE SARHU.dbo.SARHU_USUARIOS
	SET	rol_id = @rol_id, colaborador_id = @colaborador_id, usuario_nombre = @usuario_nombre, usuario_clave = @usuario_clave, usuario_correo = @usuario_correo
    WHERE usuario_id = @usuario_id;
GO

CREATE PROCEDURE sp_usuarios_delete
(@usuario_id int)
AS
	UPDATE SARHU.dbo.SARHU_USUARIOS
	SET	usuario_estado = 0
	WHERE usuario_id = @usuario_id;
GO

--SARHU_OPERACIONES
CREATE PROCEDURE sp_operaciones_list
AS
	SELECT operacion_id, operacion_nombre
	FROM SARHU.dbo.SARHU_OPERACIONES;
GO

--SARHU_BITACORA
CREATE PROCEDURE sp_bitacora_list
AS
	SELECT bitacora_id, usuario_id, operacion_id, bitacora_tabla, bitacora_comentario, bitacora_usuario_bd, bitacora_fecha_registro
	FROM SARHU.dbo.SARHU_BITACORA;
GO

CREATE PROCEDURE sp_bitacora_insert
(@usuario_id int, @operacion_id int, @bitacora_tabla varchar(20), @bitacora_comentario varchar(150))
AS
	INSERT INTO SARHU.dbo.SARHU_BITACORA(usuario_id, operacion_id, bitacora_tabla, bitacora_comentario)
	VALUES (@usuario_id, @operacion_id, @bitacora_tabla, @bitacora_comentario);
	SELECT SCOPE_IDENTITY();
GO

--SARHU_DEPARTAMENTOS
CREATE PROCEDURE sp_departamentos_list
AS
	SELECT departamento_id, departamento_nombre
	FROM SARHU.dbo.SARHU_DEPARTAMENTOS;
GO

--SARHU_MUNICIPIOS
CREATE PROCEDURE sp_municipios_list
AS
	SELECT municipio_id, departamento_id, municipio_nombre
	FROM SARHU.dbo.SARHU_MUNICIPIOS;
GO

--SARHU_INSS
CREATE PROCEDURE sp_inss_list
AS
SELECT inss_id, inss_porcentaje, inss_patronal, inss_ultima_actualizacion
FROM SARHU.dbo.SARHU_INSS;
GO

CREATE PROCEDURE sp_inss_update
(@inss_id int, @inss_porcentaje decimal(5,2), @ultima_actualizacion datetime)
AS
	UPDATE SARHU.dbo.SARHU_INSS
	SET	inss_porcentaje = @inss_porcentaje, inss_ultima_actualizacion = @ultima_actualizacion
    WHERE inss_id = @inss_id;
GO

CREATE PROCEDURE sp_inss_consult
(@inss_id int)
AS
	SELECT inss_porcentaje, inss_patronal, inss_ultima_actualizacion
	FROM SARHU.dbo.SARHU_INSS
	WHERE inss_id = @inss_id;
GO

--SARHU_IR

CREATE PROCEDURE sp_ir_list
AS
SELECT ir_id, ir_desde, ir_hasta, ir_base, ir_exceso, ir_porcentaje_aplicable, ir_ultima_actualizacion
FROM SARHU.dbo.SARHU_IR;
GO

CREATE PROCEDURE sp_ir_update
(@ir_id int, @ir_desde decimal(9,2), @ir_hasta decimal(9,2), @ir_base decimal(9,2), @ir_exceso decimal(9,2), @ir_porcentaje_aplicable decimal(5,2), @ir_ultima_actualizacion datetime)
AS
	UPDATE SARHU.dbo.SARHU_IR
	SET	ir_desde = @ir_desde, ir_hasta = @ir_hasta, ir_base = @ir_base, ir_exceso = @ir_exceso, ir_porcentaje_aplicable = @ir_porcentaje_aplicable, ir_ultima_actualizacion = @ir_ultima_actualizacion
    WHERE ir_id = @ir_id;
GO

CREATE PROCEDURE sp_ir_consult
(@ir_id int)
AS
	SELECT ir_desde, ir_hasta, ir_base, ir_exceso, ir_porcentaje_aplicable, ir_ultima_actualizacion
	FROM SARHU.dbo.SARHU_IR
	WHERE ir_id = @ir_id;
GO

--SARHU_VARIABLES
CREATE PROCEDURE sp_variables_list
AS
SELECT variable_id, variable_nombre, variable_valor, variable_ultima_actualizacion
FROM SARHU.dbo.SARHU_VARIABLES;
GO

CREATE PROCEDURE sp_variables_update
(@variable_id int, @variable_nombre varchar(50), @variable_valor decimal(9,2), @variable_ultima_actualizacion datetime)
AS
	UPDATE SARHU.dbo.SARHU_VARIABLES
	SET	variable_nombre = @variable_nombre, variable_valor = @variable_valor, variable_ultima_actualizacion = @variable_ultima_actualizacion
    WHERE variable_id = @variable_id;
GO

CREATE PROCEDURE sp_variables_consult
(@variable_id int)
AS
	SELECT variable_nombre, variable_valor, variable_ultima_actualizacion
	FROM SARHU.dbo.SARHU_VARIABLES
	WHERE variable_id = @variable_id;
GO

/* PROCEDIMIENTOS ALMACENADOS ---SOS */

--SOS_ORGANIZACION
CREATE PROCEDURE sp_organizacion_consult
(@organizacion_pais int)
AS
	SELECT organizacion_nombre, organizacion_mision, organizacion_vision, organizacion_descripcion, localidad_id
	FROM SARHU.dbo.SOS_ORGANIZACION
	WHERE organizacion_pais = @organizacion_pais
GO

CREATE PROCEDURE sp_organizacion_update
(@organizacion_pais int, @organizacion_nombre varchar(100), @organizacion_mision varchar(200),
@organizacion_vision varchar(200), @organizacion_descripcion varchar(250), @localidad_id int)
AS
	UPDATE SARHU.dbo.SOS_ORGANIZACION
	SET organizacion_nombre = @organizacion_nombre, organizacion_mision = @organizacion_mision, organizacion_vision = @organizacion_vision, organizacion_descripcion = @organizacion_descripcion,
		localidad_id = @localidad_id
	WHERE organizacion_pais = @organizacion_pais;
GO

--SOS_PROGRAMAS
CREATE PROCEDURE sp_programas_list
AS
	SELECT programa_id, programa_nombre, programa_descripcion, programa_estado
	FROM SARHU.dbo.SOS_PROGRAMAS;
GO

CREATE PROCEDURE sp_programas_insert
(@programa_nombre varchar(50), @programa_descripcion varchar(150))
AS
	INSERT INTO SARHU.dbo.SOS_PROGRAMAS(programa_nombre, programa_descripcion)
	VALUES (@programa_nombre, @programa_descripcion);
	SELECT SCOPE_IDENTITY();
GO

CREATE PROCEDURE sp_programas_consult
(@programa_id int)
AS
	SELECT programa_nombre, programa_descripcion, programa_estado
	FROM SARHU.dbo.SOS_PROGRAMAS
	WHERE programa_id = @programa_id;
GO

CREATE PROCEDURE sp_programas_update
(@programa_id int, @programa_nombre varchar(50), @programa_descripcion varchar(150))
AS
	UPDATE SARHU.dbo.SOS_PROGRAMAS
	SET	programa_nombre = @programa_nombre, programa_descripcion = @programa_descripcion
    WHERE programa_id = @programa_id;
GO

CREATE PROCEDURE sp_programas_delete
(@programa_id int)
AS
	UPDATE SARHU.dbo.SOS_PROGRAMAS
	SET programa_estado = 0 
	WHERE programa_id = @programa_id
GO

--SOS_LOCALIDADES
CREATE PROCEDURE sp_localidades_list
AS
	SELECT localidad_id, programa_id, municipio_id, director_id, localidad_alias, localidad_telefono, localidad_direccion, localidad_estado
	FROM SARHU.dbo.SOS_LOCALIDADES
GO

CREATE PROCEDURE sp_localidades_insert
(@programa_id int, @municipio_id int, @director_id int, @localidad_alias varchar(100),
 @localidad_telefono varchar(9), @localidad_direccion varchar(200))
AS
	INSERT INTO SARHU.dbo.SOS_LOCALIDADES(programa_id, municipio_id, director_id, localidad_alias, localidad_telefono, localidad_direccion)
	VALUES (@programa_id, @municipio_id, @director_id, @localidad_alias,
	        @localidad_telefono, @localidad_direccion);
	SELECT SCOPE_IDENTITY();
GO

CREATE PROCEDURE sp_localidades_consult
(@localidad_id int)
AS
	SELECT programa_id, municipio_id, director_id, localidad_alias, localidad_telefono, localidad_direccion, localidad_estado
	FROM SARHU.dbo.SOS_LOCALIDADES
	WHERE localidad_id = @localidad_id
GO

CREATE PROCEDURE sp_localidades_update
(@localidad_id int, @programa_id int, @municipio_id int, @director_id int,
@localidad_alias varchar(100), @localidad_telefono varchar(9), @localidad_direccion varchar(200))
  AS
	UPDATE SARHU.dbo.SOS_LOCALIDADES
	SET programa_id = @programa_id, municipio_id  = @municipio_id, director_id = @director_id, localidad_alias = @localidad_alias, localidad_telefono = @localidad_telefono, localidad_direccion = @localidad_direccion
    WHERE localidad_id = @localidad_id;
GO

CREATE PROCEDURE sp_localidades_delete
(@localidad_id int)
AS
	UPDATE SARHU.dbo.SOS_LOCALIDADES
	SET localidad_estado = 0
	WHERE localidad_id = @localidad_id;
GO

--SOS_AREAS
CREATE PROCEDURE sp_areas_list
AS
	SELECT area_id, area_nombre, area_descripcion, area_estado
	FROM SARHU.dbo.SOS_AREAS
GO

CREATE PROCEDURE sp_areas_insert
(@area_nombre varchar(50), @area_descripcion varchar(150))
AS
	INSERT INTO SARHU.dbo.SOS_AREAS(area_nombre, area_descripcion)
	VALUES (@area_nombre, @area_descripcion);
	SELECT SCOPE_IDENTITY();
GO

CREATE PROCEDURE sp_areas_consult
(@area_id int)
AS
	SELECT area_nombre, area_descripcion, area_estado
	FROM SARHU.dbo.SOS_AREAS
	WHERE area_id = @area_id;
GO

CREATE PROCEDURE sp_areas_update
(@area_id int, @area_nombre varchar(50), @area_descripcion varchar(150))
AS
	UPDATE SARHU.dbo.SOS_AREAS
	SET	area_nombre = @area_nombre, area_descripcion = @area_descripcion
    WHERE area_id = @area_id;
GO

CREATE PROCEDURE sp_areas_delete
(@area_id int)
AS
	UPDATE SARHU.dbo.SOS_AREAS
	SET area_estado = 0
	WHERE area_id = @area_id
GO

--SOS_PUESTOS
CREATE PROCEDURE sp_puestos_list
AS
	SELECT puesto_id, puesto_nombre, puesto_descripcion, cuenta_id, area_id, puesto_salario_base, puesto_estado
	FROM SARHU.dbo.SOS_PUESTOS
GO

CREATE PROCEDURE sp_puestos_insert
(@puesto_nombre varchar(50), @puesto_descripcion varchar(150), @cuenta_id int, @area_id int, @puesto_salario_base decimal(9,2))
AS
	INSERT INTO SARHU.dbo.SOS_PUESTOS(puesto_nombre, puesto_descripcion, cuenta_id, area_id, puesto_salario_base)
	VALUES (@puesto_nombre, @puesto_descripcion, @cuenta_id, @area_id, @puesto_salario_base);
	SELECT SCOPE_IDENTITY();
GO

CREATE PROCEDURE sp_puestos_consult
(@puesto_id int)
AS
	SELECT puesto_nombre, puesto_descripcion, cuenta_id, area_id, puesto_salario_base, puesto_estado
	FROM SARHU.dbo.SOS_PUESTOS
	WHERE puesto_id = @puesto_id;
GO

CREATE PROCEDURE sp_puestos_update
(@puesto_id int, @puesto_nombre varchar(50), @puesto_descripcion varchar(150), @cuenta_id int, @area_id int, @puesto_salario_base decimal(9,2))
AS
	UPDATE SARHU.dbo.SOS_PUESTOS
	SET	puesto_nombre = @puesto_nombre, puesto_descripcion = @puesto_descripcion, cuenta_id = @cuenta_id, area_id = @area_id, puesto_salario_base = @puesto_salario_base
    WHERE puesto_id = @puesto_id;
GO

CREATE PROCEDURE sp_puestos_delete
(@puesto_id int)
AS
	UPDATE SARHU.dbo.SOS_PUESTOS
	SET puesto_estado = 0
	WHERE puesto_id = @puesto_id
GO

--SOS_FUNCIONES
CREATE PROCEDURE sp_funciones_list
AS
	SELECT funcion_id, funcion_nombre, funcion_descripcion, funcion_estado
	FROM SARHU.dbo.SOS_FUNCIONES
GO

CREATE PROCEDURE sp_funciones_insert
(@funcion_nombre varchar(50), @funcion_descripcion varchar(150))
AS
	INSERT INTO SARHU.dbo.SOS_FUNCIONES(funcion_nombre, funcion_descripcion)
	VALUES (@funcion_nombre, @funcion_descripcion);
	SELECT SCOPE_IDENTITY();
GO

CREATE PROCEDURE sp_funciones_consult
(@funcion_id int)
AS
	SELECT funcion_nombre, funcion_descripcion, funcion_estado
	FROM SARHU.dbo.SOS_FUNCIONES
	WHERE funcion_id = @funcion_id;
GO

CREATE PROCEDURE sp_funciones_update
(@funcion_id int, @funcion_nombre varchar(50), @funcion_descripcion varchar(150))
AS
	UPDATE SARHU.dbo.SOS_FUNCIONES
	SET funcion_nombre = @funcion_nombre, funcion_descripcion = @funcion_descripcion
    WHERE funcion_id = @funcion_id;
GO

CREATE PROCEDURE sp_funciones_delete
(@funcion_id int)
AS
	UPDATE SARHU.dbo.SOS_FUNCIONES
	SET  funcion_estado = 0
	WHERE funcion_id = @funcion_id;
GO

--SOS_PUESTOS_FUNCIONES
CREATE PROCEDURE sp_puesto_funcion_list
AS
	SELECT puesto_id, funcion_id
	FROM SARHU.dbo.SOS_PUESTOS_FUNCIONES
GO

CREATE PROCEDURE sp_puesto_funcion_insert
(@puesto_id int, @funcion_id int)
AS
	INSERT INTO SARHU.dbo.SOS_PUESTOS_FUNCIONES(puesto_id, funcion_id)
	VALUES (@puesto_id, @funcion_id);
GO

CREATE PROCEDURE sp_puesto_funcion_delete
(@puesto_id int, @funcion_id int)
AS
	DELETE FROM SARHU.dbo.SOS_PUESTOS_FUNCIONES
	WHERE puesto_id = @puesto_id AND funcion_id = @funcion_id;
GO

--SOS_BONOS
CREATE PROCEDURE sp_bonos_list
AS
	SELECT bono_id, bono_nombre, bono_descripcion, bono_monto, bono_estado
	FROM SOS_BONOS;
GO

CREATE PROCEDURE sp_bonos_insert
(@bono_nombre varchar(30), @bono_descripcion varchar(150), @bono_monto decimal(8,2))
AS
	INSERT INTO SARHU.dbo.SOS_BONOS(bono_nombre, bono_descripcion, bono_monto)
	VALUES (@bono_nombre, @bono_descripcion, @bono_monto);
	SELECT SCOPE_IDENTITY();
GO

CREATE PROCEDURE sp_bonos_consult
(@bono_id int)
AS
	SELECT bono_nombre, bono_descripcion, bono_monto, bono_estado
	FROM SARHU.dbo.SOS_BONOS
	WHERE bono_id = @bono_id;
GO

CREATE PROCEDURE sp_bonos_update
(@bono_id int, @bono_nombre varchar(30), @bono_descripcion varchar(150), @bono_monto decimal(8,2))
AS
	UPDATE SARHU.dbo.SOS_BONOS
	SET bono_nombre = @bono_nombre, bono_descripcion = @bono_descripcion, bono_monto = @bono_monto
    WHERE bono_id = @bono_id;
GO

CREATE PROCEDURE sp_bonos_delete
(@bono_id int)
AS
	UPDATE SARHU.dbo.SOS_BONOS
	SET bono_estado = 0
	WHERE bono_id = @bono_id;
GO

/* ------------ fin procedimientos almacenados ------------ */

/* REGISTROS DE TABLAS */

SET IDENTITY_INSERT [dbo].[SARHU_DEPARTAMENTOS] ON 
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (1, N'Managua')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (2, N'Masaya')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (3, N'León')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (4, N'Granada')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (5, N'Carazo')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (6, N'Chinandega')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (7, N'Rivas')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (8, N'Matagalpa')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (9, N'Chontales')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (10, N'Jinotega')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (11, N'Boaco')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (12, N'Estelí')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (13, N'Nueva Segovia')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (14, N'Madriz')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (15, N'Río San Juan')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (16, N'Caribe Norte')
GO
INSERT [dbo].[SARHU_DEPARTAMENTOS] ([departamento_id], [departamento_nombre]) VALUES (17, N'Caribe Sur')
GO
SET IDENTITY_INSERT [dbo].[SARHU_DEPARTAMENTOS] OFF
GO
SET IDENTITY_INSERT [dbo].[SARHU_MUNICIPIOS] ON 
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (1, 1, N'Ciudad Sandino')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (2, 1, N'El Crucero')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (3, 1, N'Managua')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (4, 1, N'Mateare')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (5, 1, N'San Francisco Libre')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (6, 1, N'San Rafael del Sur')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (7, 1, N'Ticuantepe')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (8, 1, N'Tipitapa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (9, 1, N'Villa El Carmen')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (11, 2, N'Catarina')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (12, 2, N'La Concepción')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (13, 2, N'Masatepe')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (14, 2, N'Masaya')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (15, 2, N'Nandasmo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (16, 2, N'Nindirí')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (17, 2, N'Niquinohomo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (18, 2, N'San Juan de Oriente')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (19, 2, N'Tisma')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (20, 3, N'Achuapa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (21, 3, N'El Jicaral')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (22, 3, N'El Sauce')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (23, 3, N'La Paz Centro')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (24, 3, N'León')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (25, 3, N'Larreynaga')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (26, 3, N'Nagarote')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (27, 3, N'Quezalguaque')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (28, 3, N'Telica')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (29, 4, N'Diriá')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (30, 4, N'Diriomo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (31, 4, N'Granada')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (32, 4, N'Nandaime')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (33, 5, N'Diriamba')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (34, 5, N'Dolores')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (35, 5, N'El Rosario')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (36, 5, N'La Conquista')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (37, 5, N'La Paz de Oriente')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (38, 5, N'San Marcos')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (39, 5, N'Santa Teresa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (40, 6, N'Chichigalpa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (41, 6, N'Chinandega')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (42, 6, N'Cinco Pinos')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (43, 6, N'Corinto')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (44, 6, N'El Realejo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (45, 6, N'El Viejo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (46, 6, N'Posoltega')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (47, 6, N'San Francisco del Norte')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (48, 6, N'San Pedro del Norte')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (49, 6, N'Santo Tomás del Norte')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (50, 6, N'Somotillo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (51, 6, N'Puerto Morazán')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (52, 6, N'Villanueva')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (53, 7, N'Altagracia')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (54, 7, N'Belén')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (55, 7, N'Buenos Aires')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (56, 7, N'Cárdenas')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (57, 7, N'Potosí')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (58, 7, N'San Jorge')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (59, 7, N'San Juan del Sur')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (60, 7, N'Tola')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (61, 8, N'Ciudad Darío')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (62, 8, N'Esquipulas')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (63, 8, N'El Tuma - La Dalia')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (64, 8, N'Matagalpa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (65, 8, N'Matiguás')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (66, 8, N'Muy Muy')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (67, 8, N'Rancho Grande')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (68, 8, N'Río Blanco')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (69, 8, N'San Dionisio')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (70, 8, N'San Ramón')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (71, 8, N'Sébaco')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (72, 8, N'Terrabona')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (73, 9, N'Acoyapa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (75, 9, N'Camolapa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (76, 9, N'San Francisco de Cuapa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (77, 9, N'El Coral')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (78, 9, N'San Pedro de Lóvago')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (79, 9, N'Santo Domingo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (80, 9, N'Santo Tomás')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (81, 9, N'Villa Sandino')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (82, 10, N'San José de Bocay')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (83, 10, N'El Cuá')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (84, 10, N'Jinotega')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (85, 10, N'La Concordia')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (86, 10, N'Santa María de Pantasma')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (87, 10, N'San Rafael del Norte')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (88, 10, N'Wiwilí de Jinotega')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (89, 10, N'San Sebastián de Yalí')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (90, 11, N'Boaco')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (91, 11, N'Camoapa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (92, 11, N'San José de los Remates')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (93, 11, N'San Lorenzo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (94, 11, N'Santa Lucía')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (95, 11, N'Teustepe')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (96, 12, N'Condega')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (97, 12, N'Estelí')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (98, 12, N'La Trinidad')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (99, 12, N'Pueblo Nuevo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (100, 12, N'San Juan de Limay')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (101, 12, N'San Nicolás')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (102, 13, N'Ciudad Antigua')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (103, 13, N'Dipilto')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (104, 13, N'El Jícaro')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (105, 13, N'Jalapa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (107, 13, N'Macuelizo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (108, 13, N'Mozonte')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (109, 13, N'Murra')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (110, 13, N'Ocotal')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (111, 13, N'Quilalí')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (112, 13, N'San Fernando')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (113, 13, N'Santa María')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (114, 13, N'Güigüilí')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (115, 14, N'San José de Cusmapa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (116, 14, N'Las Sabanas')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (117, 14, N'Palacagüina')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (118, 14, N'San Juan de Río Coco')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (119, 14, N'San Lucas')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (120, 14, N'Somoto')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (121, 14, N'Telpaneca')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (122, 14, N'Totogalpa')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (123, 14, N'Yalagüina')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (124, 15, N'El Castillo')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (125, 15, N'El Almendro')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (126, 15, N'Morrito')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (127, 15, N'San Carlos')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (128, 15, N'San Juan del Norte')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (129, 15, N'San Miguelito')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (130, 16, N'Bilwi')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (131, 16, N'Bonanza')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (132, 16, N'Mulukukú')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (133, 16, N'Prinzapolka')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (134, 16, N'Rosita')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (135, 16, N'Siuna')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (136, 16, N'Waslala')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (137, 16, N'Waspán')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (138, 17, N'Bluefields')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (139, 17, N'Corn Island')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (140, 17, N'El Ayote')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (141, 17, N'El Rama')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (142, 17, N'El Tortuguero')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (143, 17, N'Desembocadura de Río Grande')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (144, 17, N'Kukra Hill')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (145, 17, N'La Cruz de Río Grande')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (146, 17, N'Laguna de Perlas')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (147, 17, N'Muelle de los Bueyes')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (148, 17, N'Nueva Guinea')
GO
INSERT [dbo].[SARHU_MUNICIPIOS] ([municipio_id], [departamento_id], [municipio_nombre]) VALUES (149, 17, N'Paiwas')
GO
SET IDENTITY_INSERT [dbo].[SARHU_MUNICIPIOS] OFF
GO

SET IDENTITY_INSERT [dbo].[SOS_PROGRAMAS] ON 
GO
INSERT [dbo].[SOS_PROGRAMAS] ([programa_id], [programa_nombre], [programa_descripcion], [programa_estado]) VALUES (1, N'Aldea SOS', N'Aldea SOS', 0)
GO
INSERT [dbo].[SOS_PROGRAMAS] ([programa_id], [programa_nombre], [programa_descripcion], [programa_estado]) VALUES (2, N'Centro Social SOS', N'Centro Social SOS', 1)
GO
INSERT [dbo].[SOS_PROGRAMAS] ([programa_id], [programa_nombre], [programa_descripcion], [programa_estado]) VALUES (3, N'Colegio SOS', N'Colegio SOS', 1)
GO
INSERT [dbo].[SOS_PROGRAMAS] ([programa_id], [programa_nombre], [programa_descripcion], [programa_estado]) VALUES (4, N'Centro de Formación', N'Centro de Formación', 1)
GO
INSERT [dbo].[SOS_PROGRAMAS] ([programa_id], [programa_nombre], [programa_descripcion], [programa_estado]) VALUES (5, N'Programa de Fortalecimiento Familiar', N'Programa de Fortalecimiento Familiar', 1)
GO
SET IDENTITY_INSERT [dbo].[SOS_PROGRAMAS] OFF
GO

SET IDENTITY_INSERT [dbo].[SARHU_OPERACIONES] ON 
GO
INSERT [dbo].[SARHU_OPERACIONES] ([operacion_id], [operacion_nombre]) VALUES (1, N'Agregar')
GO
INSERT [dbo].[SARHU_OPERACIONES] ([operacion_id], [operacion_nombre]) VALUES (2, N'Editar')
GO
INSERT [dbo].[SARHU_OPERACIONES] ([operacion_id], [operacion_nombre]) VALUES (3, N'Borrar')
GO
SET IDENTITY_INSERT [dbo].[SARHU_OPERACIONES] OFF
GO

INSERT [dbo].[SOS_ORGANIZACION] ([organizacion_pais], [organizacion_nombre], [organizacion_mision], [organizacion_vision], [organizacion_descripcion], [localidad_id]) VALUES (505, N'ALDEAS INFANTILES SOS NICARAGUA', N'Trabajamos por el derecho de los Niños a vivir en familia.', N'Cada niño y cada niña pertenecen a una familia y crece con amor.', N'Somos una organización no gubernamental sin fines de lucro presentes en 133 países del mundo, siendo la organización más grande en atención directa a niños, niñas, adolescentes y familias.', 1)
GO

/* ------------ fin registros tablas ------------ */