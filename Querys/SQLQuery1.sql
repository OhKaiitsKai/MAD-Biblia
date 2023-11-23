USE piamad_db;
-- Crear la vista de la tabla Usuario
CREATE VIEW Vista_Usuario AS
SELECT 
    IDUsuario,
    nombre_completo,
    genero,
    email,
    contraseña,
    fecha_nacimiento,
    rol,
    fechahora_registro,
    activo
FROM dbo.Usuario;
