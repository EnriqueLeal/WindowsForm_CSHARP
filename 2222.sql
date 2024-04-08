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



SELECT *
FROM Empleados;

