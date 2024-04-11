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
 @Activo bit,
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

            SET @MensajeSucess = 'Registro actualizado';
            
        END
        ELSE
        BEGIN
              INSERT INTO Empleados (Nombre,ApellidoPaterno,ApellidoMaterno,Cargo,Activo)
              VALUES (@Nombre, @Ap_paterno,@Ap_materno, @Cargo, @Activo);
              SET @MensajeSucess = 'Registro actualizado';
        END

        SELECT @MensajeSucess as MensajeSucess;
        
    END TRY
    BEGIN CATCH
        -- Capturar y manejar errores
        DECLARE @ErrorMessage NVARCHAR(MAX);
        SET @ErrorMessage =  'Error al obtener empleados activos: ' + ERROR_MESSAGE();
        THROW 50000,  @ErrorMessage, 1;
    END CATCH
END;

EXEC UpdateEmpleados 1,'','','','','';



-- 2. Actualizar la tabla de empleados
ALTER TABLE Empleados
ADD UsuarioId INT,
CONSTRAINT FK_Empleados_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(ID);

-- 3. Establecer la relaci�n uno a uno entre Empleados y Usuarios
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



ALTER PROCEDURE GetEmpleados
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Seleccionar empleados activos
        SELECT E.Id, E.Nombre, E.ApellidoPaterno, E.ApellidoMaterno, E.Cargo, E.Activo, USR.Usuario
        FROM Empleados E
        INNER JOIN Usuarios USR ON E.Id = USR.EmpleadoId
        WHERE Activo = 1;
    END TRY
    BEGIN CATCH
        -- Capturar y manejar errores
        DECLARE @ErrorMessage NVARCHAR(MAX);
        SET @ErrorMessage =  'Error al obtener empleados activos: ' + ERROR_MESSAGE();
        THROW 50000,  @ErrorMessage, 1;
    END CATCH
END;



SELECT E.Id, E.Nombre, E.ApellidoPaterno, E.ApellidoMaterno, E.Cargo, E.Activo, USR.Usuario
        FROM Empleados E
        INNER JOIN Usuarios USR ON E.Id = USR.EmpleadoId
        WHERE Activo = 1;
