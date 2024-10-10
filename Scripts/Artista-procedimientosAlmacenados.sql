/*USP-ARTISTA*/

/*ARTISTA-SELECT*/
CREATE PROCEDURE USP_GET_Artista_Todos
AS 
BEGIN
Select * from Artista
end
GO

/*ARTISTA-INSERT*/
create procedure USP_Insert_Artista
@cNombreArtista varchar(100)
as
begin
insert into Artista
(cNombreArtista)
values
(@cNombreArtista)
select cast(SCOPE_IDENTITY() as int)
end
go

/*ARTISTA-ACTUALIZAR*/
create procedure USP_Actualizar_Artista
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
go

/*ARTISTA-ELIMINAR*/
create procedure USP_Eliminar_Artista (
@nIDArtista int
)
as
begin
delete from Artista
where nIdArtista = @nIdArtista
select cast(@@ROWCOUNT as int)
end
go