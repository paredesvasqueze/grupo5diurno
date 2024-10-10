
/*CANCION-SELECT*/
create procedure USP_GET_Cancion_Todos
as
begin
select 
nIdCancion,	cTitulo,dFechaPublicacion,cGenero,cUrlArchivo,cast(dDuracion as datetime) as dDuracion
from Cancion
end



/*CANCION-INSERT*/
alter procedure USP_Insert_Cancion
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


/*CANCION-ACTUALIZAR*/
create procedure USP_Actualizar_Cancion
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


/*CANCION-ELIMINAR*/
alter procedure USP_Eliminar_Cancion
@nIdCancion INT
as
begin
delete from Cancion where nIdCancion=@nIdCancion
select cast(@@ROWCOUNT as int)
end