IF DB_ID(N'piamad_db') IS NOT NULL
BEGIN
    USE piamad_db;
    
    -- Usuario
    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de cada usuario, es auto generado.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Usuario',
        @level2type = N'Column', @level2name = 'IDUsuario';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Nombre completo del usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Usuario',
        @level2type = N'Column', @level2name = 'nombre_completo';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Género del usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Usuario',
        @level2type = N'Column', @level2name = 'genero';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Correo electrónico del usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Usuario',
        @level2type = N'Column', @level2name = 'email';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Contraseña del usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Usuario',
        @level2type = N'Column', @level2name = 'contraseña';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Fecha de nacimiento del usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Usuario',
        @level2type = N'Column', @level2name = 'fecha_nacimiento';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Rol del usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Usuario',
        @level2type = N'Column', @level2name = 'rol';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Fecha y hora de creación del usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Usuario',
        @level2type = N'Column', @level2name = 'fechahora_registro';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Activo o Inactivo Usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Usuario',
        @level2type = N'Column', @level2name = 'activo';

    -- SeguridadUsuario
    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de seguridad para cada usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'SeguridadUsuario',
        @level2type = N'Column', @level2name = 'IDSeguridad';
		
    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'SeguridadUsuario',
        @level2type = N'Column', @level2name = 'IDUsuario';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Intentos fallidos de inicio de sesión.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'SeguridadUsuario',
        @level2type = N'Column', @level2name = 'intentos_fallidos';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Contraseña temporal del usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'SeguridadUsuario',
        @level2type = N'Column', @level2name = 'contraseña_temporal';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Última contraseña registrada por el usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'SeguridadUsuario',
        @level2type = N'Column', @level2name = 'ultima_contraseña1';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Penúltima contraseña registrada por el usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'SeguridadUsuario',
        @level2type = N'Column', @level2name = 'ultima_contraseña2';

    --Idiomas
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador del idioma, generado automáticamente.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Idiomas',
        @level2type = N'Column', @level2name = 'Id_Idioma';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Nombre del idioma.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Idiomas',
        @level2type = N'Column', @level2name = 'Nombre';

    --Testamento
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador del testamento, generado automáticamente.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Testamentos',
        @level2type = N'Column', @level2name = 'Id_Testamento';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Nombre del testamento.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Testamentos',
        @level2type = N'Column', @level2name = 'Nombre';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Orden del testamento.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Testamentos',
        @level2type = N'Column', @level2name = 'OrdenTest';
	
	EXEC sp_addextendedproperty
	    @name = N'MS_Description', @value = 'Identificador del idioma.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Testamentos',
        @level2type = N'Column', @level2name = 'Id_Idioma';

	--Libros
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador del libro, generado automáticamente.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Libros',
        @level2type = N'Column', @level2name = 'Id_Libro';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Nombre del libro.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Libros',
        @level2type = N'Column', @level2name = 'Nombre';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Orden del libro.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Libros',
        @level2type = N'Column', @level2name = 'OrdenLibro';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Cantidad total de capítulos en el libro.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Libros',
        @level2type = N'Column', @level2name = 'CapitulosTot';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Nombre del autor del libro.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Libros',
        @level2type = N'Column', @level2name = 'Autor';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Año de publicación del libro.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Libros',
        @level2type = N'Column', @level2name = 'Año';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador del testamento.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Libros',
        @level2type = N'Column', @level2name = 'Id_Testamento';

	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador del idioma.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Libros',
        @level2type = N'Column', @level2name = 'Id_Idioma';

	--Versiones
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de la versión, generado automáticamente.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiones',
        @level2type = N'Column', @level2name = 'Id_Version';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Nombre de la versión de la Biblia.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiones',
        @level2type = N'Column', @level2name = 'NombreVersion';

	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Siglas de la versión.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiones',
        @level2type = N'Column', @level2name = 'SiglasVersion';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Traductor de la versión de la Biblia.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiones',
        @level2type = N'Column', @level2name = 'Traductor';

	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de la versión, generado automáticamente.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiones',
        @level2type = N'Column', @level2name = 'FechaVersion';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Idioma de la versión de la Biblia.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiones',
        @level2type = N'Column', @level2name = 'Id_Idioma';

	--Versículos
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador del versículo, generado automáticamente.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiculos',
        @level2type = N'Column', @level2name = 'Id_Vers';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Número de capítulo del versículo.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiculos',
        @level2type = N'Column', @level2name = 'NumeroCap';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Número del versículo dentro del capítulo.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiculos',
        @level2type = N'Column', @level2name = 'NumeroVers';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Texto del versículo.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Versiculos',
        @level2type = N'Column', @level2name = 'Texto';

	EXEC sp_addextendedproperty
	    @name = N'MS_Description', @value = 'Identificador del libro.',
		@level0type = N'Schema', @level0name = 'dbo',
		@level1type = N'Table', @level1name = 'Versiculos',
		@level2type = N'Column', @level2name = 'Id_Libro';

	EXEC sp_addextendedproperty
	    @name = N'MS_Description', @value = 'Identificador de versión.',
		@level0type = N'Schema', @level0name = 'dbo',
		@level1type = N'Table', @level1name = 'Versiculos',
		@level2type = N'Column', @level2name = 'Id_Version';

	--Búsqueda
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de la búsqueda, generado automáticamente.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Busqueda',
        @level2type = N'Column', @level2name = 'IDBusqueda';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Fecha y hora de la búsqueda.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Busqueda',
        @level2type = N'Column', @level2name = 'fecha_hora';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Texto ingresado para la búsqueda.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Busqueda',
        @level2type = N'Column', @level2name = 'texto_busqueda';

	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador del usuario.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Busqueda',
        @level2type = N'Column', @level2name = 'UsuarioFK';

	--Consultas
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de la consulta, generado automáticamente.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Consulta',
        @level2type = N'Column', @level2name = 'IDConsulta';

	EXEC sp_addextendedproperty
	    @name = N'MS_Description', @value = 'Identificador del usuario.',
		@level0type = N'Schema', @level0name = 'dbo',
		@level1type = N'Table', @level1name = 'Consulta',
		@level2type = N'Column', @level2name = 'UsuarioFK';

	EXEC sp_addextendedproperty
	    @name = N'MS_Description', @value = 'Identificador del libro.',
		@level0type = N'Schema', @level0name = 'dbo',
		@level1type = N'Table', @level1name = 'Consulta',
		@level2type = N'Column', @level2name = 'LibroFK';
    
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de versión.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Consulta',
        @level2type = N'Column', @level2name = 'VersionFK';

	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Número de capítulo del versículo.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Consulta',
        @level2type = N'Column', @level2name = 'NumeroCap';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Número del versículo dentro del capítulo.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Consulta',
        @level2type = N'Column', @level2name = 'NumeroVers';

	--Favoritos
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de favoritos, generado automáticamente.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Favoritos',
        @level2type = N'Column', @level2name = 'IDFavorito';

	EXEC sp_addextendedproperty
	    @name = N'MS_Description', @value = 'Identificador del usuario.',
		@level0type = N'Schema', @level0name = 'dbo',
		@level1type = N'Table', @level1name = 'Favoritos',
		@level2type = N'Column', @level2name = 'UsuarioFK';

	EXEC sp_addextendedproperty
	    @name = N'MS_Description', @value = 'Identificador del libro.',
		@level0type = N'Schema', @level0name = 'dbo',
		@level1type = N'Table', @level1name = 'Favoritos',
		@level2type = N'Column', @level2name = 'LibroFK';
    
	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Identificador de versión.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Favoritos',
        @level2type = N'Column', @level2name = 'VersionFK';

	EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Número de capítulo del versículo.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Favoritos',
        @level2type = N'Column', @level2name = 'NumeroCap';

    EXEC sp_addextendedproperty
        @name = N'MS_Description', @value = 'Número del versículo dentro del capítulo.',
        @level0type = N'Schema', @level0name = 'dbo',
        @level1type = N'Table', @level1name = 'Favoritos',
        @level2type = N'Column', @level2name = 'NumeroVers';
END
GO
