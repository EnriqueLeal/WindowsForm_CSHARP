CREATE PROCEDURE ValidarUsuario
    @Usuario NVARCHAR(50),
    @Contrase�a NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CantidadUsuarios INT;

    SELECT @CantidadUsuarios = COUNT(*)
    FROM Usuarios
    WHERE Usuario = @Usuario AND Contrase�a = @Contrase�a;

    IF @CantidadUsuarios = 1
        SELECT 'Login exitoso' AS Mensaje;
    ELSE
        SELECT 'Usuario o contrase�a incorrectos' AS Mensaje;
END;


CREATE TABLE Aplicaciones (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(MAX),
    Detalles NVARCHAR(MAX),
    Activo BIT NOT NULL
);

update Aplicaciones
SET Detalles = 'PROYECTO_HYUNDAI\Formularios\Empleados.cs';


--CREATE PROCEDURE GetApps
--AS
--BEGIN
--    SET NOCOUNT ON;

--    DECLARE @CantidadUsuarios INT;

--    SELECT Id, Nombre, Descripcion, Detalles, Activo FROM Aplicaciones;

--END;


CREATE TABLE Empleados (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    ApellidoPaterno NVARCHAR(100),
    ApellidoMaterno NVARCHAR(100),
    Cargo NVARCHAR(100),
    Activo BIT
);

-- =============================================
-- Descripci�n: GetEmpleados
-- Par�metros: Ninguno.
-- Autor: Enrique Leal Isla G.
-- Fecha de creaci�n: 2024
-- =============================================
--CREATE PROCEDURE GetEmpleados
--AS
--BEGIN
--    SET NOCOUNT ON;

--    BEGIN TRY
--        -- Seleccionar empleados activos
--        SELECT Id, Nombre, ApellidoPaterno, ApellidoMaterno, Cargo, Activo
--        FROM Empleados
--        WHERE Activo = 1;
--    END TRY
--    BEGIN CATCH
--        -- Capturar y manejar errores
--        DECLARE @ErrorMessage NVARCHAR(MAX);
--        SET @ErrorMessage =  'Error al obtener empleados activos: ' + ERROR_MESSAGE();
--        THROW 50000,  @ErrorMessage, 1;
--    END CATCH
--END;





-- Insertar datos de ejemplo en la tabla de aplicaciones
INSERT INTO Aplicaciones (Nombre, Descripcion, Detalles, Activo) VALUES
('Aplicaci�n 1', 'Descripci�n de la Aplicaci�n 1', 'Detalles de la Aplicaci�n 1', 1),
('Aplicaci�n 2', 'Descripci�n de la Aplicaci�n 2', 'Detalles de la Aplicaci�n 2', 1),
('Aplicaci�n 3', 'Descripci�n de la Aplicaci�n 3', 'Detalles de la Aplicaci�n 3', 1);


SELECT *
FROM Empleados


INSERT INTO Empleados(Nombre,ApellidoPaterno,ApellidoMaterno,Cargo,Activo)
VALUES ('Luis Enrique','Leal Isla', 'Garcia','Desarrollador',1);




-- =============================================
-- Descripci�n: GetEmpleados
-- Par�metros: Ninguno.
-- Autor: Enrique Leal Isla G.
-- Fecha de creaci�n: 2024
-- =============================================
--ALTER PROCEDURE UpdateEmpleados
 @ID INT,
 @Nombre NVARCHAR(50),
 @Ap_paterno NVARCHAR(50),
 @Ap_materno NVARCHAR(50),
 @Cargo NVARCHAR(50),
 @Activo bit
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
    DECLARE @MensajeSucess NVARCHAR(1000);
        -- Seleccionar empleados activos
        IF(@ID > 1)
        BEGIN
            UPDATE Empleados
            SET Nombre = @Nombre, ApellidoPaterno = @Ap_paterno, ApellidoMaterno = @Ap_materno, Cargo = @Cargo, Activo = @Activo
            WHERE Id = @ID;

            SET @MensajeSucess = 'Registro actualizado';
            
        END
        ELSE
        BEGIN
              INSERT INTO Empleados (Nombre,ApellidoPaterno,ApellidoMaterno,Cargo,Activo)
              VALUES (@Nombre, @Ap_paterno,@Ap_materno, @Cargo, @Activo);
              SET @MensajeSucess = 'Registro actualizado';
        END

        SELECT @MensajeSucess;
        
    END TRY
    BEGIN CATCH
        -- Capturar y manejar errores
        DECLARE @ErrorMessage NVARCHAR(MAX);
        SET @ErrorMessage =  'Error al obtener empleados activos: ' + ERROR_MESSAGE();
        THROW 50000,  @ErrorMessage, 1;
    END CATCH
END;