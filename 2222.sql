-- =============================================
-- Descripci?n: GetEmpleados
-- Par?metros: Ninguno.
-- Autor: Enrique Leal Isla G.
-- Fecha de creaci?n: 2024
-- =============================================
ALTER PROCEDURE UpdateEmpleados
 @ID INT,
 @Nombre NVARCHAR(50),
 @Ap_paterno NVARCHAR(50),
 @Ap_materno NVARCHAR(50),
 @Cargo NVARCHAR(50),
 @Activo BIT,
 @Usuario NVARCHAR(50),
 @Pass NVARCHAR(50),
 @MensajeSucess NVARCHAR(1000) OUTPUT

AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Seleccionar empleados activos
        IF(@ID >= 1)
        BEGIN
            UPDATE Empleados
            SET Nombre = @Nombre, ApellidoPaterno = @Ap_paterno, ApellidoMaterno = @Ap_materno, Cargo = @Cargo, Activo = @Activo
            WHERE Id = @ID;

            IF EXISTS (SELECT * FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Pass)
            BEGIN
                PRINT '';
            END
            ELSE
            BEGIN
                UPDATE Usuarios
                SET Contraseña = @Pass
                WHERE Usuario = @Usuario;
            END

            SET @MensajeSucess = 'Registro actualizado';
            
        END
        ELSE
        BEGIN
              INSERT INTO Empleados (Nombre, ApellidoPaterno, ApellidoMaterno, Cargo, Activo)
              VALUES (@Nombre, @Ap_paterno, @Ap_materno, @Cargo, @Activo);

              DECLARE @_ID INT = IDENT_CURRENT('Empleados');  -- Cambiado a SCOPE_IDENTITY() para obtener el último ID insertado en el mismo ámbito.

              IF EXISTS (SELECT * FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Pass)
              BEGIN
                  PRINT '';
              END
              ELSE
              BEGIN
                  INSERT INTO Usuarios (Usuario, Contraseña, EmpleadoId)
                  VALUES (@Nombre, @Pass,@_ID);

                  UPDATE Empleados
                  SET UsuarioId = @_ID
                  WHERE Id = @_ID; -- Agregado WHERE Id = @_ID para especificar el empleado al que se asignará el usuario.
              END

              SET @MensajeSucess = 'Registro actualizado';
        END

        SELECT @MensajeSucess AS MensajeSucess;
        
    END TRY
    BEGIN CATCH
        -- Capturar y manejar errores
        DECLARE @ErrorMessage NVARCHAR(MAX);
        SET @ErrorMessage = 'Error al obtener empleados activos: ' + @_ID + ' ' + ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;


EXEC UpdateEmpleados 1,'','','','','';



-- 2. Actualizar la tabla de empleados
ALTER TABLE Empleados
ADD UsuarioId INT,
CONSTRAINT FK_Empleados_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(ID);

-- 3. Establecer la relación uno a uno entre Empleados y Usuarios
ALTER TABLE Usuarios
ADD EmpleadoId INT,
CONSTRAINT FK_Usuarios_Empleados FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id);


--SELECT *
--FROM 
--UPDATE Empleados
--SET UsuarioID = 1
--WHERE Id=1


--SELECT *
--FROM 
--UPDATE Usuarios
--SET EmpleadoId = 1



--ALTER PROCEDURE GetEmpleados
--AS
--BEGIN
--    SET NOCOUNT ON;

--    BEGIN TRY
--        -- Seleccionar empleados activos
--        SELECT E.Id, E.Nombre, E.ApellidoPaterno, E.ApellidoMaterno, E.Cargo, E.Activo, USR.Usuario, USR.Contraseña as Pass
--        FROM Empleados E
--        INNER JOIN Usuarios USR ON E.Id = USR.EmpleadoId
--        WHERE Activo = 1;
--    END TRY
--    BEGIN CATCH
--        -- Capturar y manejar errores
--        DECLARE @ErrorMessage NVARCHAR(MAX);
--        SET @ErrorMessage =  'Error al obtener empleados activos: ' + ERROR_MESSAGE();
--        THROW 50000,  @ErrorMessage, 1;
--    END CATCH
--END;



SELECT E.Id, E.Nombre, E.ApellidoPaterno, E.ApellidoMaterno, E.Cargo, E.Activo, USR.Usuario, USR.Contraseña
        FROM Empleados E
        INNER JOIN Usuarios USR ON E.Id = USR.EmpleadoId
        WHERE Activo = 1;

        SELECT *
        FROM Usuarios

        SELECT *
        DELETE FROM Empleados
        WHERE Id = 1002