CREATE DATABASE Real_Music;
GO
USE Real_Music;
GO

-- Tabla Rol: Define los diferentes roles de los usuarios (admin, usuario, etc.)
CREATE TABLE Rol (
    nIdRol INT PRIMARY KEY IDENTITY(1,1),
    cNombreRol VARCHAR(50) NOT NULL
);
GO

-- Tabla Plan: Define los diferentes planes de suscripción (gratis, premium, etc.).
CREATE TABLE Pla (
    nIdPlan INT PRIMARY KEY IDENTITY(1,1),
    cNombrePlan VARCHAR(50) NOT NULL,
    nCosto DECIMAL(10, 2) NOT NULL,
    cDescripcion VARCHAR(255)
);
GO

-- Tabla Usuario
CREATE TABLE Usuario (
    nIdUsuario INT PRIMARY KEY IDENTITY(1,1),
    cNombre VARCHAR(100) NOT NULL,
    cEmail VARCHAR(150) NOT NULL UNIQUE,
    cContraseña VARCHAR(255) NOT NULL,
    dFechaRegistro DATETIME DEFAULT GETDATE(),
    cTipoCuenta VARCHAR(50) CHECK (cTipoCuenta IN ('gratis', 'premium')) NOT NULL,
    nIdRol INT, -- Relación con la tabla Rol
    FOREIGN KEY (nIdRol) REFERENCES Rol(nIdRol)
);
GO

-- Tabla Artista: Almacena la información de los artistas.
CREATE TABLE Artista (
    nIdArtista INT PRIMARY KEY IDENTITY(1,1),
    cNombreArtista VARCHAR(100) NOT NULL
);
GO

-- Tabla Cancion: Almacena la información de las canciones, incluyendo la URL del archivo en la nube.
CREATE TABLE Cancion (
    nIdCancion INT PRIMARY KEY IDENTITY(1,1),
    cTitulo VARCHAR(150) NOT NULL,
    nDuracion TIME NOT NULL,
    dFechaPublicacion DATE NOT NULL,
    cGenero VARCHAR(50),
    cUrlArchivo VARCHAR(255) NOT NULL -- URL donde está almacenada la canción en la nube
);
GO

-- Tabla CancionArtista: Relaciona artistas con canciones (muchos a muchos).
CREATE TABLE CancionArtista (
    nIdCancion INT,
    nIdArtista INT,
    PRIMARY KEY (nIdCancion, nIdArtista),
    FOREIGN KEY (nIdCancion) REFERENCES Cancion(nIdCancion),
    FOREIGN KEY (nIdArtista) REFERENCES Artista(nIdArtista)
);
GO

-- Tabla Reproduccion: Registra las reproducciones de canciones por parte de los usuarios.
CREATE TABLE Reproduccion (
    nIdReproduccion INT PRIMARY KEY IDENTITY(1,1),
    nIdUsuario INT,
    nIdCancion INT,
    dFechaReproduccion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (nIdUsuario) REFERENCES Usuario(nIdUsuario),
    FOREIGN KEY (nIdCancion) REFERENCES Cancion(nIdCancion)
);
GO

-- Tabla Suscripcion: Almacena las suscripciones de los usuarios premium.
CREATE TABLE Suscripcion (
    nIdSuscripcion INT PRIMARY KEY IDENTITY(1,1),
    nIdUsuario INT,
    nIdPlan INT,
    dFechaInicio DATETIME NOT NULL,
    dFechaFin DATETIME NOT NULL,
    FOREIGN KEY (nIdUsuario) REFERENCES Usuario(nIdUsuario),
    FOREIGN KEY (nIdPlan) REFERENCES Pla(nIdPlan)
);
GO

-- Tabla Pago: Almacena los pagos realizados por los usuarios por suscripciones.
CREATE TABLE Pago (
    nIdPago INT PRIMARY KEY IDENTITY(1,1),
    nIdUsuario INT,
    nIdSuscripcion INT,
    nMonto DECIMAL(10, 2) NOT NULL,
    dFechaPago DATETIME DEFAULT GETDATE(),
    cMetodoPago VARCHAR(50),
    FOREIGN KEY (nIdUsuario) REFERENCES Usuario(nIdUsuario),
    FOREIGN KEY (nIdSuscripcion) REFERENCES Suscripcion(nIdSuscripcion)
);
GO

-- Tabla Playlist: Permite a los usuarios crear listas de reproducción.
CREATE TABLE Playlist (
    nIdPlaylist INT PRIMARY KEY IDENTITY(1,1),
    nIdUsuario INT,
    cNombre VARCHAR(100) NOT NULL,
    dFechaCreacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (nIdUsuario) REFERENCES Usuario(nIdUsuario)
);
GO

-- Tabla PlaylistCancion: Relaciona canciones con listas de reproducción, permitiendo varias canciones por playlist.
CREATE TABLE PlaylistCancion (
    nIdPlaylist INT,
    nIdCancion INT,
    PRIMARY KEY (nIdPlaylist, nIdCancion),
    FOREIGN KEY (nIdPlaylist) REFERENCES Playlist(nIdPlaylist),
    FOREIGN KEY (nIdCancion) REFERENCES Cancion(nIdCancion)
);
GO

/********DOCUMENTACION********
Usuario: Almacena información sobre los usuarios (nombre, correo, contraseña, tipo de cuenta, y el rol asociado).
Rol: Define los roles de los usuarios (como 'admin', 'usuario', etc.).
Pla: Define los diferentes planes de suscripción (como 'gratis', 'premium', etc.).
Artista: Almacena información sobre los artistas de las canciones.
Cancion: Contiene información sobre las canciones, incluyendo el título, género y la URL del archivo de la canción en la nube.
CancionArtista: Relaciona los artistas con las canciones.
Reproduccion: Registra cuándo y qué canciones escucha cada usuario.
Suscripcion: Almacena	las suscripciones de usuarios, con fechas de inicio, fin y el plan asociado.
Pago: Registra los pagos que hacen los usuarios por suscripciones.
Playlist: Permite a los usuarios crear playlists (listas de reproducción).
PlaylistCancion: Relaciona canciones con playlists, permitiendo que una canción esté en varias listas de reproducción.
*/