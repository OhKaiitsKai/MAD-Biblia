USE piamad_db;
EXEC dbo.sp_GestionarUsuario @op = 'i', @IDUsuario = '1000', @email = 'admin@gmail.com', @contraseña = "PiaMAD023.", 
@nombre_completo = "Admin Mad",@genero = 'F', @fecha_nacimiento = '1999-01-01', @rol = 'Administrador', @activo = 1
