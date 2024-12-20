USE [Real_Music]
GO
/****** Object:  Table [dbo].[Artista]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artista](
	[nIdArtista] [int] IDENTITY(1,1) NOT NULL,
	[cNombreArtista] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdArtista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancion](
	[nIdCancion] [int] IDENTITY(1,1) NOT NULL,
	[cTitulo] [varchar](150) NOT NULL,
	[dFechaPublicacion] [date] NOT NULL,
	[cGenero] [varchar](50) NULL,
	[cUrlArchivo] [varchar](255) NOT NULL,
	[dDuracion] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdCancion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CancionArtista]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CancionArtista](
	[nIdCancionArtista] [int] IDENTITY(1,1) NOT NULL,
	[nIdCancion] [int] NULL,
	[nIdArtista] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdCancionArtista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[nIdPago] [int] IDENTITY(1,1) NOT NULL,
	[nIdUsuario] [int] NULL,
	[nIdSuscripcion] [int] NULL,
	[nMonto] [decimal](10, 2) NOT NULL,
	[dFechaPago] [datetime] NULL,
	[cMetodoPago] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pla]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pla](
	[nIdPlan] [int] IDENTITY(1,1) NOT NULL,
	[cNombrePlan] [varchar](50) NOT NULL,
	[nCosto] [decimal](10, 2) NOT NULL,
	[cDescripcion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[nIdPlaylist] [int] IDENTITY(1,1) NOT NULL,
	[nIdUsuario] [int] NULL,
	[cNombre] [varchar](100) NOT NULL,
	[dFechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdPlaylist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistCancion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistCancion](
	[nIdPlaylistCancion] [int] IDENTITY(1,1) NOT NULL,
	[nIdPlaylist] [int] NULL,
	[nIdCancion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdPlaylistCancion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reproduccion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reproduccion](
	[nIdReproduccion] [int] IDENTITY(1,1) NOT NULL,
	[nIdUsuario] [int] NULL,
	[nIdCancion] [int] NULL,
	[dFechaReproduccion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdReproduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[nIdRol] [int] IDENTITY(1,1) NOT NULL,
	[cNombreRol] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suscripcion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suscripcion](
	[nIdSuscripcion] [int] IDENTITY(1,1) NOT NULL,
	[nIdUsuario] [int] NULL,
	[nIdPlan] [int] NULL,
	[dFechaInicio] [datetime] NOT NULL,
	[dFechaFin] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdSuscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[nIdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[cNombre] [varchar](100) NOT NULL,
	[cEmail] [varchar](150) NOT NULL,
	[cContrasenia] [varchar](255) NOT NULL,
	[dFechaRegistro] [datetime] NULL,
	[cTipoCuenta] [varchar](50) NOT NULL,
	[nIdRol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[nIdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[cEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pago] ADD  DEFAULT (getdate()) FOR [dFechaPago]
GO
ALTER TABLE [dbo].[Playlist] ADD  DEFAULT (getdate()) FOR [dFechaCreacion]
GO
ALTER TABLE [dbo].[Reproduccion] ADD  DEFAULT (getdate()) FOR [dFechaReproduccion]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [dFechaRegistro]
GO
ALTER TABLE [dbo].[CancionArtista]  WITH CHECK ADD FOREIGN KEY([nIdArtista])
REFERENCES [dbo].[Artista] ([nIdArtista])
GO
ALTER TABLE [dbo].[CancionArtista]  WITH CHECK ADD FOREIGN KEY([nIdCancion])
REFERENCES [dbo].[Cancion] ([nIdCancion])
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD FOREIGN KEY([nIdSuscripcion])
REFERENCES [dbo].[Suscripcion] ([nIdSuscripcion])
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD FOREIGN KEY([nIdUsuario])
REFERENCES [dbo].[Usuario] ([nIdUsuario])
GO
ALTER TABLE [dbo].[Playlist]  WITH CHECK ADD FOREIGN KEY([nIdUsuario])
REFERENCES [dbo].[Usuario] ([nIdUsuario])
GO
ALTER TABLE [dbo].[PlaylistCancion]  WITH CHECK ADD FOREIGN KEY([nIdCancion])
REFERENCES [dbo].[Cancion] ([nIdCancion])
GO
ALTER TABLE [dbo].[PlaylistCancion]  WITH CHECK ADD FOREIGN KEY([nIdPlaylist])
REFERENCES [dbo].[Playlist] ([nIdPlaylist])
GO
ALTER TABLE [dbo].[Reproduccion]  WITH CHECK ADD FOREIGN KEY([nIdCancion])
REFERENCES [dbo].[Cancion] ([nIdCancion])
GO
ALTER TABLE [dbo].[Reproduccion]  WITH CHECK ADD FOREIGN KEY([nIdUsuario])
REFERENCES [dbo].[Usuario] ([nIdUsuario])
GO
ALTER TABLE [dbo].[Suscripcion]  WITH CHECK ADD FOREIGN KEY([nIdPlan])
REFERENCES [dbo].[Pla] ([nIdPlan])
GO
ALTER TABLE [dbo].[Suscripcion]  WITH CHECK ADD FOREIGN KEY([nIdUsuario])
REFERENCES [dbo].[Usuario] ([nIdUsuario])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([nIdRol])
REFERENCES [dbo].[Rol] ([nIdRol])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD CHECK  (([cTipoCuenta]='premium' OR [cTipoCuenta]='gratis'))
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Artista]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*ARTISTA-ACTUALIZAR*/
create procedure [dbo].[USP_Actualizar_Artista]
@nIDArtista int,
@cNombreArtista varchar(100)
as
begin
update Artista
set
cNombreArtista = @cNombreArtista
where nIdArtista = @nIDArtista

select cast(@@ROWCOUNT as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Cancion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_Actualizar_Cancion]
@nIdCancion INT,
@cTitulo VARCHAR(150),
@dFechaPublicacion DATE,
@cGenero VARCHAR(50),
@cUrlArchivo VARCHAR(255),
@dDuracion TIME
as
begin
update  Cancion
set 
cTitulo=@cTitulo,
dFechaPublicacion=@dFechaPublicacion,
cGenero=@cGenero,
cUrlArchivo=@cUrlArchivo,
dDuracion=@dDuracion
where nIdCancion=@nIdCancion
select cast(@@ROWCOUNT as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_CancionArtista]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* CANCIONARTISTA - ACTUALIZAR */
CREATE PROCEDURE [dbo].[USP_Actualizar_CancionArtista]
@nIdCancionArtista int,
       @nIdCancion INT,
    @nIdArtista INT
AS
BEGIN
    UPDATE CancionArtista
    SET
	 nIdCancion= @nIdCancion,
        nIdArtista = @nIdArtista
    WHERE nIdCancionArtista = @nIdCancion AND nIdArtista = @nIdArtista

    SELECT CAST(@@ROWCOUNT AS INT)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Pago]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_Actualizar_Pago]
    @nIdPago INT,
    @nIdUsuario INT,
    @nIdSuscripcion INT,
    @nMonto INT,
    @dFechaPago DATETIME,
    @cMetodoPago VARCHAR(50) 
AS
BEGIN
    UPDATE Pago
    SET nIdUsuario = @nIdUsuario,
        nIdSuscripcion = @nIdSuscripcion,
        nMonto = @nMonto,
        dFechaPago = @dFechaPago,
        cMetodoPago = @cMetodoPago
    WHERE nIdPago = @nIdPago;
	select cast(@@ROWCOUNT as int)
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Pla]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[USP_Actualizar_Pla]
@nIdPlan int,
@cNombrePlan varchar(50),
@nCosto decimal(10,2),
@cDescripcion varchar(255)
AS
BEGIN
    UPDATE Pla SET
		cNombrePlan = @cNombrePlan,
		nCosto = @nCosto,
		cDescripcion = @cDescripcion
    WHERE nIdPlan = @nIdPlan;
	select cast(@@ROWCOUNT as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Playlist]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_Actualizar_Playlist]
@nIdPlaylist int,
@nIdUsuario int,
@cNombre varchar(100),
@dFechaCreacion datetime
as
begin
update Playlist set
nIdUsuario = @nIdUsuario,
cNombre = @cNombre,
dFechaCreacion = @dFechaCreacion
where nIdPlaylist = @nIdPlaylist;
select cast(@@ROWCOUNT as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_PlaylistCancion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Actualizar_PlaylistCancion]
    @nIdPlaylistCancion INT,
    @nIdPlaylist INT,
    @nIdCancion INT
AS
BEGIN
    UPDATE PlaylistCancion
    SET
        nIdPlaylist = @nIdPlaylist,
        nIdCancion = @nIdCancion
    WHERE nIdPlaylistCancion = @nIdPlaylistCancion

    SELECT CAST(@@ROWCOUNT AS INT)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Reproduccion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*USP_ DE REPRODUCCION*/

/*UPDATE-REPRODUCCION*/
CREATE PROCEDURE [dbo].[USP_Actualizar_Reproduccion]
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
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Rol]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_Actualizar_Rol]
@nIdRol INT,
@cNombreRol VARCHAR(50)
as
begin
update Rol
set 
cNombreRol=@cNombreRol
where nIdRol= @nIdRol
select cast(@@ROWCOUNT as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Suscripcion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*SUSCRIPCION-ACTUALIZAR*/
create procedure [dbo].[USP_Actualizar_Suscripcion]
@nIdSuscripcion int,
@nIdUsuario int,
@nIdPlan int,
@dFechaInicio datetime,
@dFechaFin datetime
AS
BEGIN
    UPDATE Suscripcion SET
		nIdUsuario = @nIdUsuario,
		nIdPlan = @nIdPlan,
		dFechaInicio = @dFechaInicio,
		dFechaFin = @dFechaFin
    WHERE nIdSuscripcion = @nIdSuscripcion;
	select cast(@@ROWCOUNT as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Usuario]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*USUARIO-ACTUALIZAR*/
create procedure [dbo].[USP_Actualizar_Usuario]
@nIdUsuario INT,
@cNombre VARCHAR(100),
@cEmail VARCHAR(150),
@cContrasenia VARCHAR(255),
@cTipoCuenta VARCHAR(50),
@nIdRol INT
AS
BEGIN
UPDATE Usuario
SET 
cNombre = COALESCE(@cNombre, cNombre),
cEmail = COALESCE(@cEmail, cEmail),
cContrasenia = COALESCE(@cContrasenia, cContrasenia),
cTipoCuenta = COALESCE(@cTipoCuenta, cTipoCuenta),
nIdRol = COALESCE(@nIdRol, nIdRol)
WHERE nIdUsuario = @nIdUsuario;

select cast(@@ROWCOUNT as int) 
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Artista]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*ARTISTA-ELIMINAR*/
create procedure [dbo].[USP_Eliminar_Artista] (
@nIDArtista int
)
as
begin
delete from Artista
where nIdArtista = @nIdArtista
select cast(@@ROWCOUNT as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Cancion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_Eliminar_Cancion]
@nIdCancion INT
as
begin
delete from Cancion where nIdCancion=@nIdCancion
select cast(@@ROWCOUNT as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_CancionArtista]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* CANCIONARTISTA - ELIMINAR */
CREATE PROCEDURE [dbo].[USP_Eliminar_CancionArtista]
    @nIdCancionArtista int
AS
BEGIN
    DELETE FROM CancionArtista
    WHERE nIdCancionArtista=@nIdCancionArtista

    SELECT CAST(@@ROWCOUNT AS INT)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Pago]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_Eliminar_Pago]
 @nIdPago INT
AS
BEGIN
    DELETE FROM Pago
    WHERE nIdPago = @nIdPago;
	select cast(@@ROWCOUNT as int)
END;


GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Pla]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*PLA-ELIMINAR*/
create procedure [dbo].[USP_Eliminar_Pla]
    @nIdPlan int
AS
BEGIN
    DELETE FROM Pla
    WHERE nIdPlan = @nIdPlan
	select cast(@@ROWCOUNT as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Playlist]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_Eliminar_Playlist]
    @nIdPlaylist int
as
begin
    delete from  Playlist
    where nIdPlaylist = @nIdPlaylist
	select cast(@@ROWCOUNT as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_PlaylistCancion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Eliminar_PlaylistCancion]
    @nIdPlaylistCancion INT
AS
BEGIN
    DELETE FROM PlaylistCancion
    WHERE nIdPlaylistCancion = @nIdPlaylistCancion

    SELECT CAST(@@ROWCOUNT AS INT)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Reproduccion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*ELIMINAR- REPRODUCCION*/
CREATE PROCEDURE [dbo].[USP_Eliminar_Reproduccion]
    @nIdReproduccion INT
AS
BEGIN
    DELETE FROM Reproduccion
    WHERE nIdReproduccion = @nIdReproduccion;
	select cast(@@ROWCOUNT as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Rol]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_Eliminar_Rol]
@nIdRol INT
as
begin
delete from Rol where nIdRol=@nIdRol
select cast(@@ROWCOUNT as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Suscripcion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*SUSCRIPCION-ELIMINAR*/
create procedure [dbo].[USP_Eliminar_Suscripcion]
    @nIdSuscripcion int
AS
BEGIN
    DELETE FROM Suscripcion
    WHERE nIdSuscripcion = @nIdSuscripcion
	select cast(@@ROWCOUNT as int)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Usuario]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*USUARIO-ELIMINAR*/
create procedure [dbo].[USP_Eliminar_Usuario]
@nIdUsuario INT
AS
BEGIN
DELETE FROM Usuario WHERE nIdUsuario = @nIdUsuario;
select cast(@@ROWCOUNT as int) 
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Artista_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*USP-ARTISTA*/

/*ARTISTA-SELECT*/
CREATE PROCEDURE [dbo].[USP_GET_Artista_Todos]
AS 
BEGIN
Select * from Artista
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Cancion_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_GET_Cancion_Todos]
as
begin
select 
nIdCancion,	cTitulo,	dFechaPublicacion,	cGenero,	cUrlArchivo	,cast(dDuracion as datetime) as dDuracion

from Cancion
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_CancionArtista_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* CANCIONARTISTA - SELECT - TODOS */
CREATE PROCEDURE [dbo].[USP_GET_CancionArtista_Todos]
AS 
BEGIN
SELECT  
    ca.*, c.cTitulo as cNombreCancion, a.cNombreArtista
FROM 
    dbo.CancionArtista ca
INNER JOIN 
    dbo.Cancion c ON ca.nIdCancion = c.nIdCancion
INNER JOIN 
    dbo.Artista a ON ca.nIdArtista = a.nIdArtista;END
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Pago_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GET_Pago_Todos]
AS
BEGIN
    SELECT  
    pago.nIdPago, 
    usuario.cNombre AS cNombreUsuario, 
    pla.cNombrePlan, 
    pago.nMonto, 
    pago.dFechaPago, 
    pago.cMetodoPago
FROM 
    dbo.Pago pago
INNER JOIN 
    dbo.Usuario usuario ON usuario.nIdUsuario = pago.nIdUsuario
INNER JOIN 
    dbo.Suscripcion sus ON sus.nIdSuscripcion = pago.nIdSuscripcion
INNER JOIN 
    dbo.Pla pla ON pla.nIdPlan = sus.nIdPlan;

END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Pla_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_GET_Pla_Todos]
as
begin
select * from Pla
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Playlist_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[USP_GET_Playlist_Todos]
AS 
BEGIN
SELECT 
    pl.nIdPlaylist, 
    u.cNombre AS cNombreUsuario, 
    pl.cNombre AS cNombrePlaylist, 
    pl.dFechaCreacion
FROM 
    Playlist pl
INNER JOIN 
    Usuario u ON pl.nIdUsuario = u.nIdUsuario;
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_PlaylistCancion_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  PROCEDURE [dbo].[USP_GET_PlaylistCancion_Todos]
AS 
BEGIN
    SELECT * FROM PlaylistCancion
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Reproduccion_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*SELECCIONAR-TODOS-REPRODUCCION*/
CREATE PROCEDURE [dbo].[USP_GET_Reproduccion_Todos]
AS
BEGIN
   SELECT  
	r.*,
    u.cNombre as cNombreUsuario,
    c.cTitulo as cNombreCancion
FROM 
    dbo.Reproduccion r
INNER JOIN 
    dbo.Usuario u ON r.nIdUsuario = u.nIdUsuario
INNER JOIN 
    dbo.Cancion c ON r.nIdCancion = c.nIdCancion;

END
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Rol_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_GET_Rol_Todos]
as
begin
select 
nIdRol,
cNombreRol
from Rol
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Suscripcion_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_GET_Suscripcion_Todos]
as
begin
SELECT 
    s.nIdSuscripcion, 
    u.cNombre AS cNombreUsuario, 
    p.cNombrePlan AS cNombrePlan, 
    s.dFechaInicio, 
    s.dFechaFin
FROM 
    Suscripcion s
INNER JOIN 
    Usuario u ON s.nIdUsuario = u.nIdUsuario
INNER JOIN 
    Pla p ON s.nIdPlan = p.nIdPlan;
end	 

GO
/****** Object:  StoredProcedure [dbo].[USP_GET_Usuario_Todos]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*USP-USUARIO*/

/*USUARIO-SELECT-TODOS*/
create procedure [dbo].[USP_GET_Usuario_Todos]
as
begin
select * from Usuario
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetArtistaById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetArtistaById]
    @nIdArtista INT
AS
BEGIN
    SELECT *
    FROM Artista
    WHERE nIdArtista = @nIdArtista;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetCancionArtistaById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetCancionArtistaById]
    @nIdCancionArtista INT
AS
BEGIN
    SELECT *
    FROM CancionArtista
    WHERE nIdCancionArtista = @nIdCancionArtista;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetCancionById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetCancionById]
    @nIdCancion INT
AS
BEGIN
    SELECT *
    FROM Cancion
    WHERE nIdCancion = @nIdCancion;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPagoById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetPagoById]
    @nIdPago INT
AS
BEGIN
    SELECT *
    FROM Pago
    WHERE nIdPago = @nIdPago;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPlanById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetPlanById]
    @nIdPlan INT
AS
BEGIN
    SELECT *
    FROM Pla
    WHERE nIdPlan = @nIdPlan;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPlaylistById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetPlaylistById]
    @nIdPlaylist INT
AS
BEGIN
    SELECT *
    FROM Playlist
    WHERE nIdPlaylist = @nIdPlaylist;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPlaylistCancionById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetPlaylistCancionById]
    @nIdPlaylistCancion INT
AS
BEGIN
    SELECT *
    FROM PlaylistCancion
    WHERE nIdPlaylistCancion = @nIdPlaylistCancion;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetReproduccionById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetReproduccionById]
    @nIdReproduccion INT
AS
BEGIN
    SELECT *
    FROM Reproduccion
    WHERE nIdReproduccion = @nIdReproduccion;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetRolById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetRolById]
    @nIdRol INT
AS
BEGIN
    SELECT *
    FROM Rol
    WHERE nIdRol = @nIdRol;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetSuscripcionById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetSuscripcionById]
    @nIdSuscripcion INT
AS
BEGIN
    SELECT *
    FROM Suscripcion
    WHERE nIdSuscripcion = @nIdSuscripcion;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_GetUsuarioById]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetUsuarioById]
    @nIdUsuario INT
AS
BEGIN
    SELECT *
    FROM Usuario
    WHERE nIdUsuario = @nIdUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Artista]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*ARTISTA-INSERT*/
create procedure [dbo].[USP_Insert_Artista]
@cNombreArtista varchar(100)
as
begin
insert into Artista
(cNombreArtista)
values
(@cNombreArtista)
select cast(SCOPE_IDENTITY() as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Cancion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_Insert_Cancion]
@cTitulo VARCHAR(150),
@dFechaPublicacion DATE,
@cGenero VARCHAR(50),
@cUrlArchivo VARCHAR(255),
@dDuracion TIME
as
begin
insert into Cancion
(cTitulo,dFechaPublicacion,cGenero,cUrlArchivo,dDuracion)
values
(@cTitulo,@dFechaPublicacion,@cGenero,@cUrlArchivo,@dDuracion)
select cast(SCOPE_IDENTITY() as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_CancionArtista]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* CANCIONARTISTA - INSERT */
CREATE PROCEDURE [dbo].[USP_Insert_CancionArtista]
    @nIdCancion INT,
    @nIdArtista INT
AS
BEGIN
    INSERT INTO CancionArtista
        (nIdCancion, nIdArtista)
    VALUES
        (@nIdCancion, @nIdArtista)

    SELECT CAST(SCOPE_IDENTITY() AS INT)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Pago]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Insert_Pago]
    @nIdUsuario INT,
    @nIdSuscripcion INT,
    @nMonto INT,
    @dFechaPago DATETIME,
    @cMetodoPago VARCHAR(50)
AS
BEGIN
    INSERT INTO Pago (nIdUsuario, nIdSuscripcion, nMonto, dFechaPago, cMetodoPago)
    VALUES (@nIdUsuario, @nIdSuscripcion, @nMonto, @dFechaPago, @cMetodoPago);
END;
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Pla]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*PLA-INSERT*/
create procedure [dbo].[USP_Insert_Pla]
@cNombrePlan varchar(50),
@nCosto decimal(10,2),
@cDescripcion varchar(255)
as
BEGIN
INSERT INTO Pla
(cNombrePlan, nCosto, cDescripcion)
VALUES 
(@cNombrePlan, @nCosto, @cDescripcion)
select cast(SCOPE_IDENTITY() as int)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Playlist]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*ROL-INSERT*/
create  procedure [dbo].[USP_Insert_Playlist]
@cNombre varchar(100),
@dFechaCreacion datetime
as
begin
insert into Playlist
([cNombre], [dFechaCreacion])
values
( @cNombre, @dFechaCreacion)
select cast(SCOPE_IDENTITY() as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_PlaylistCancion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_Insert_PlaylistCancion]
    @nIdPlaylist INT,
    @nIdCancion INT
AS
BEGIN
    INSERT INTO PlaylistCancion
        (nIdPlaylist, nIdCancion)
    VALUES
        (@nIdPlaylist, @nIdCancion)

    SELECT CAST(SCOPE_IDENTITY() AS INT)
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Reproduccion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*INSERTAR-REPRODUCCION*/
CREATE PROCEDURE [dbo].[USP_Insert_Reproduccion]
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
/****** Object:  StoredProcedure [dbo].[USP_Insert_Rol]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*ROL-INSERT*/
create procedure [dbo].[USP_Insert_Rol]
@cNombreRol VARCHAR(50)
as
begin
insert into Rol
(cNombreRol)
values
(@cNombreRol)
select cast(SCOPE_IDENTITY() as int)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Suscripcion]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*SUSCRIPCION-INSERT*/
create procedure [dbo].[USP_Insert_Suscripcion]
@nIdUsuario int,
@nIdPlan int,
@dFechaInicio datetime,
@dFechaFin datetime
as
BEGIN
INSERT INTO Suscripcion
(nIdUsuario, nIdPlan, dFechaInicio, dFechaFin)
VALUES 
(@nIdUsuario, @nIdPlan, @dFechaInicio, @dFechaFin)
select cast(SCOPE_IDENTITY() as int)
END

GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Usuario]    Script Date: 8/12/2024 12:13:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*USUARIO-INSERT*/
create procedure [dbo].[USP_Insert_Usuario]
@cNombre VARCHAR(100),
@cEmail VARCHAR(150),
@cContrasenia VARCHAR(255),
@cTipoCuenta VARCHAR(50),
@nIdRol INT
AS
BEGIN
    INSERT INTO Usuario (cNombre, cEmail, cContrasenia, cTipoCuenta, nIdRol)
    VALUES (@cNombre, @cEmail, @cContrasenia, @cTipoCuenta, @nIdRol);

select cast(SCOPE_IDENTITY() as int)
END;
GO
