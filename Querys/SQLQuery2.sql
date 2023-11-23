USE piamad_db;
IF OBJECT_ID('sp_GestionarUsuario') IS NOT NULL
	DROP PROCEDURE sp_GestionarUsuario;
GO

CREATE PROCEDURE sp_GestionarUsuario(
	@op				CHAR(1),
	@IDUsuario		SMALLINT = NULL,
	@email VARCHAR(50) = NULL,
	@contraseña		VARCHAR(20) = NULL,
	@nombre_completo	VARCHAR(100) = NULL,
	@genero			CHAR(1) = NULL,
	@fecha_nacimiento	DATE = NULL,
	@rol VARCHAR(20) = NULL,
	@activo			BIT = NULL
)
AS
BEGIN
	DECLARE @hoy DATETIME;
	SET @hoy = GETDATE();

	IF @op = 'I'
	BEGIN
		INSERT INTO dbo.Usuario(email, contraseña, nombre_completo, genero, fecha_nacimiento, rol, activo, fechahora_registro)
		VALUES(@email, @contraseña, @nombre_completo, @genero, @fecha_nacimiento, @rol, @activo, @hoy);
	END

	IF @op = 'E'
	BEGIN
		UPDATE dbo.Usuario SET
		    email = ISNULL(@email, email),
			contraseña = ISNULL(@contraseña, contraseña),
			nombre_completo = ISNULL(@nombre_completo, nombre_completo),
			genero = ISNULL(@genero, genero),
			fecha_nacimiento = ISNULL(@fecha_nacimiento, fecha_nacimiento),
			rol= ISNULL(@rol, rol),
			activo = ISNULL(@activo, activo)
		WHERE IDUsuario = @IDUsuario;
	END

	IF @op = 'D'
	BEGIN
		UPDATE dbo.Usuario SET
			activo = 0
		WHERE IDUsuario = @IDUsuario;
	END

	IF @op = 'S'
	BEGIN
		SELECT IDUsuario, email, contraseña, nombre_completo, genero, fecha_nacimiento, rol, activo, fechahora_registro
		FROM dbo.Vista_Usuario
	END
END
GO
