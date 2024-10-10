CREATE PROCEDURE USP_Insert_Reproduccion
    @nIdUsuario INT,
    @nIdCancion INT
AS
BEGIN
    INSERT INTO Reproduccion (nIdUsuario, nIdCancion)
    VALUES (@nIdUsuario, @nIdCancion);

    -- Retornar el ID de la reproducci�n insertada
    SELECT SCOPE_IDENTITY();
END
GO