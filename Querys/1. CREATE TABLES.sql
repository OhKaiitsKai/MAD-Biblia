-- Crear la base de datos

CREATE DATABASE piamad_db;

IF DB_ID(N'piamad_db')IS NOT NULL

/*DROP ALL TABLES
  DROP TABLE dbo.Usuario;
  DROP TABLE dbo.SeguridadUsuario;
  DROP TABLE dbo.Idioma;
  DROP TABLE dbo.Testamento;
  DROP TABLE dbo.Libro;
  DROP TABLE dbo.Versiones;
  DROP TABLE dbo.Versiculos;
  DROP TABLE dbo.Busqueda;
  DROP TABLE dbo.Consulta;
  DROP TABLE dbo.Favoritos;
*/

BEGIN
  USE piamad_db

--Usuario
IF OBJECT_ID(N'dbo.Usuario')IS NOT NULL
		DROP TABLE dbo.Usuario;
	CREATE TABLE  dbo.Usuario(
		 IDUsuario SMALLINT IDENTITY(10000,1),
                 nombre_completo VARCHAR(100) NOT NULL,
                 genero CHAR(1) CHECK (genero IN('M', 'F')),
                 email VARCHAR(50) UNIQUE NOT NULL,
                 contraseña VARCHAR(20) NOT NULL,
                 fecha_nacimiento DATE NOT NULL,
				 rol VARCHAR(20) NOT NULL DEFAULT 'UsuarioNormal',
				 fechahora_registro DATETIME NOT NULL,
				 activo BIT NOT NULL 
                 
                  CONSTRAINT PK_USUARIO
                    PRIMARY KEY(IDUsuario)
               );
			  
--Contraseñas
IF OBJECT_ID(N'dbo.SeguridadUsuario')IS NOT NULL
		DROP TABLE dbo.SeguridadUsuario;
	CREATE TABLE  dbo.SeguridadUsuario(
         IDSeguridad INT IDENTITY(1,1),
               IDUsuario SMALLINT NOT NULL,
               intentos_fallidos INT NOT NULL DEFAULT 0,
               contraseña_temporal VARCHAR(100),
               ultima_contraseña1 VARCHAR(100),
               ultima_contraseña2 VARCHAR(100),
				                  
                  CONSTRAINT PK_SEGURIDAD
                    PRIMARY KEY(IDSeguridad),
				  CONSTRAINT FK_SEGURIDAD_USUARIO
				    FOREIGN KEY (IDUsuario) REFERENCES Usuario(IDUsuario) 
               );
--Idioma
IF OBJECT_ID(N'dbo.Idiomas')IS NOT NULL
		DROP TABLE dbo.Idiomas;
	CREATE TABLE  dbo.Idiomas(
		 Id_Idioma SMALLINT IDENTITY(1, 1) NOT NULL, 
                 Nombre VARCHAR(20) NOT NULL
                 
                  CONSTRAINT PK_IDIOMA
                    PRIMARY KEY(Id_Idioma)
               );
--Testamentos
IF OBJECT_ID(N'dbo.Testamentos')IS NOT NULL
		DROP TABLE dbo.Testamentos;
	CREATE TABLE  dbo.Testamentos(
		 Id_Testamento SMALLINT NOT NULL IDENTITY(1,1),
                 Nombre VARCHAR(20) NOT NULL,
                 OrdenTest tinyint not null,
                 Id_Idioma SMALLINT NOT NULL,
                    
					PRIMARY KEY(Id_Testamento),
                    FOREIGN KEY (Id_Idioma) REFERENCES Idiomas(Id_Idioma)
               );
--Libros
IF OBJECT_ID(N'dbo.Libros')IS NOT NULL
		DROP TABLE dbo.Libros;
	CREATE TABLE  dbo.Libros(
		 Id_Libro SMALLINT NOT NULL IDENTITY(1,1),
                 Nombre VARCHAR(20) NOT NULL,
                 OrdenLibro TINYINT NOT NULL, 
                 CapitulosTot TINYINT NOT NULL, 
                 Autor VARCHAR(40) NULL,
                 Año SMALLINT NULL,
                 Id_Testamento SMALLINT NOT NULL,
                 Id_Idioma SMALLINT NOT NULL,

                  CONSTRAINT PK_Libro
                    PRIMARY KEY(Id_Libro),
                  CONSTRAINT FK_Libro_Test
                    FOREIGN KEY (Id_Testamento) REFERENCES Testamentos(Id_Testamento), 
                  CONSTRAINT FK_Libro_Idioma
                    FOREIGN KEY (Id_Idioma) REFERENCES Idiomas(Id_Idioma)
               );
--Versiones
IF OBJECT_ID(N'dbo.Versiones')IS NOT NULL
		DROP TABLE dbo.Versiones;
	CREATE TABLE  dbo.Versiones(
		 Id_Version SMALLINT IDENTITY(1, 1) NOT NULL, 
                 NombreVersion VARCHAR(30) NOT NULL, 
                 SiglasVersion VARCHAR(10) NOT NULL, 
                 Traductor VARCHAR(50), 
                 FechaVersion DATE, 
                 Id_Idioma SMALLINT,
                  
				  CONSTRAINT PK_Version
                    PRIMARY KEY (Id_Version),
                  CONSTRAINT FK_Idiom_Vers
                    FOREIGN KEY (Id_Idioma) REFERENCES Idiomas(Id_Idioma)

               );
--Versículos
IF OBJECT_ID(N'dbo.Versiculos')IS NOT NULL
		DROP TABLE dbo.Versiculos;
	CREATE TABLE  dbo.Versiculos(
         Id_Version SMALLINT NOT NULL,
                 Id_Libro SMALLINT NOT NULL,
                 NumeroCap TINYINT NOT NULL,
                 NumeroVers TINYINT NOT NULL,
                 Texto TEXT NOT NULL,
                 Id_Vers SMALLINT NOT NULL IDENTITY(1,1), 
                 
				  CONSTRAINT PK_Versiculos
                    PRIMARY KEY(Id_Version, Id_Libro, NumeroCap, NumeroVers), 
                  CONSTRAINT FK_Vers_Libro
                    FOREIGN KEY (Id_Libro) REFERENCES Libros(Id_Libro),
                  CONSTRAINT FK_Versiculo_Version
                    FOREIGN KEY (Id_Version) REFERENCES Versiones(Id_Version)         
               );
--Búsqueda
IF OBJECT_ID(N'dbo.Busqueda')IS NOT NULL
		DROP TABLE dbo.Busqueda;
	CREATE TABLE  dbo.Busqueda(
		 IDBusqueda SMALLINT IDENTITY(1000,1),
                 fecha_hora DATETIME NOT NULL,
                 texto_busqueda TEXT NOT NULL,
                 UsuarioFK SMALLINT NOT NULL
                 
                  CONSTRAINT PK_BUSQUEDA
                    PRIMARY KEY(IDBusqueda),
                  CONSTRAINT FK_BUSQUEDA_USUARIO
                    FOREIGN KEY (UsuarioFK) REFERENCES Usuario(IDUsuario)
                 );
--Consulta
IF OBJECT_ID(N'dbo.Consulta')IS NOT NULL
		DROP TABLE dbo.Consulta;
	CREATE TABLE  dbo.Consulta(
		 IDConsulta SMALLINT IDENTITY(1000,1),
                 UsuarioFK SMALLINT NOT NULL,
                 LibroFK SMALLINT NOT NULL,
				 VersionFK SMALLINT NOT NULL,
                 NumeroCap TINYINT NOT NULL,
                 NumeroVers TINYINT NOT NULL
                 
                  CONSTRAINT PK_CONSULTA
                    PRIMARY KEY(IDConsulta),
                  CONSTRAINT FK_CONSULTA_USUARIO
                    FOREIGN KEY (UsuarioFK) REFERENCES Usuario(IDUsuario),
                  CONSTRAINT FK_CONSULTA_VERSICULOS
				    FOREIGN KEY (VersionFK, LibroFK, NumeroCap, NumeroVers) REFERENCES Versiculos(Id_Version, Id_Libro, NumeroCap, NumeroVers)
                 );
--Favoritos
IF OBJECT_ID(N'dbo.Favoritos') IS NOT NULL
        DROP TABLE dbo.Favoritos;

    CREATE TABLE dbo.Favoritos (
        IDFavorito TINYINT IDENTITY(100, 1),
                 UsuarioFK SMALLINT NOT NULL,
                 LibroFK SMALLINT NOT NULL,
                 NumeroCap TINYINT NOT NULL, 
                 NumeroVers TINYINT NOT NULL,
                 VersionFK SMALLINT NOT NULL,
                  CONSTRAINT PK_FAVORITOS 
				    PRIMARY KEY(IDFavorito),
                  CONSTRAINT FK_FAVORITOS_USUARIO 
				    FOREIGN KEY (UsuarioFK) REFERENCES Usuario(IDUsuario),
                  CONSTRAINT FK_FAVORITOS_Versiculos 
				    FOREIGN KEY (VersionFK, LibroFK, NumeroCap, NumeroVers) REFERENCES Versiculos(Id_Version, Id_Libro, NumeroCap, NumeroVers)
);

END
GO

SELECT * FROM Usuario;
SELECT * FROM SeguridadUsuario;
SELECT * FROM Versiculos WHERE NumeroCap = 6;