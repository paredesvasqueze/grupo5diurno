/* CANCIONARTISTA - SELECT - TODOS */
CREATE PROCEDURE USP_Select_CancionArtista_Todos
AS
BEGIN
    SELECT *
    FROM CancionArtista;
END
GO

/* CANCIONARTISTA - INSERT */
CREATE PROCEDURE USP_Insert_CancionArtista
    @nIdCancion INT,
    @nIdArtista INT
AS
BEGIN
    INSERT INTO CancionArtista (nIdCancion, nIdArtista)
    VALUES (@nIdCancion, @nIdArtista);
    
    -- Devolver el ID de la nueva relación insertada
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NewId;
END
GO

/* CANCIONARTISTA - ACTUALIZAR */
CREATE PROCEDURE USP_Actualizar_CancionArtista
    @nIdCancionActual INT,    -- ID actual de la canción en la relación
    @nIdArtistaActual INT,    -- ID actual del artista en la relación
    @nIdCancionNuevo INT,     -- Nuevo ID de la canción (si se quiere actualizar)
    @nIdArtistaNuevo INT      -- Nuevo ID del artista (si se quiere actualizar)
AS
BEGIN
    -- Verificar si la relación actual entre la canción y el artista existe
    IF EXISTS (SELECT 1 FROM CancionArtista 
               WHERE nIdCancion = @nIdCancionActual 
                 AND nIdArtista = @nIdArtistaActual)
    BEGIN
        -- Verificar si los nuevos IDs existen en las tablas de Cancion y Artista
        IF EXISTS (SELECT 1 FROM Cancion WHERE nIdCancion = @nIdCancionNuevo)
        AND EXISTS (SELECT 1 FROM Artista WHERE nIdArtista = @nIdArtistaNuevo)
        BEGIN
            -- Actualizar la relación con los nuevos IDs
            UPDATE CancionArtista
            SET nIdCancion = @nIdCancionNuevo, 
                nIdArtista = @nIdArtistaNuevo
            WHERE nIdCancion = @nIdCancionActual 
              AND nIdArtista = @nIdArtistaActual;

            -- Devolver el número de filas actualizadas
            SELECT CAST(@@ROWCOUNT AS INT) AS RowsAffected;
        END
        ELSE
        BEGIN
            -- Si no existen los nuevos IDs, lanzar un error
            RAISERROR('El nuevo ID de Canción o Artista no existe', 16, 1);
        END
    END
    ELSE
    BEGIN
        -- Si no existe la relación actual, lanzar un error
        RAISERROR('La relación actual entre Canción y Artista no existe', 16, 1);
    END
END
GO

/* CANCIONARTISTA - ELIMINAR */
CREATE PROCEDURE USP_Eliminar_CancionArtista
    @nIdCancion INT,
    @nIdArtista INT
AS
BEGIN
    DELETE FROM CancionArtista
    WHERE nIdCancion = @nIdCancion 
      AND nIdArtista = @nIdArtista;

    -- Devolver el número de filas eliminadas
    SELECT CAST(@@ROWCOUNT AS INT) AS RowsAffected;
END
GO
