/*USP_ DE REPRODUCCION*/

/*UPDATE-REPRODUCCION*/
CREATE PROCEDURE USP_Actualizar_Reproduccion
    @nIdReproduccion INT,
    @nIdUsuario INT,
    @nIdCancion INT
AS
BEGIN
    UPDATE Reproduccion
    SET nIdUsuario = @nIdUsuario,
        nIdCancion = @nIdCancion
    WHERE nIdReproduccion = @nIdReproduccion;
	select cast(@@ROWCOUNT as int)
END
GO

/*ELIMINAR- REPRODUCCION*/
CREATE PROCEDURE USP_Eliminar_Reproduccion
    @nIdReproduccion INT
AS
BEGIN
    DELETE FROM Reproduccion
    WHERE nIdReproduccion = @nIdReproduccion;
	select cast(@@ROWCOUNT as int)
END
GO

/*SELECCIONAR-TODOS-REPRODUCCION*/
CREATE PROCEDURE USP_GET_Reproduccion_Todos
AS
BEGIN
    SELECT *
    FROM Reproduccion;
END
GO

/*SELECCIONAR-ID-REPRODUCCION*/
CREATE PROCEDURE USP_Obtener_Reproduccion_Por_Id
    @nIdReproduccion INT
AS
BEGIN
    SELECT *
    FROM Reproduccion
    WHERE nIdReproduccion = @nIdReproduccion;
END
GO

/*INSERTAR-REPRODUCCION*/
CREATE PROCEDURE USP_Insert_Reproduccion
    @nIdUsuario INT,
    @nIdCancion INT
AS
BEGIN
    INSERT INTO Reproduccion (nIdUsuario, nIdCancion)
    VALUES (@nIdUsuario, @nIdCancion);

    -- Retornar el ID de la reproducción insertada
    SELECT SCOPE_IDENTITY();
	select cast(SCOPE_IDENTITY() as int)

END
GO