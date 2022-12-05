use PagosObras2022

select * from Detalle_Nota
sp_help Detalle_Nota;

select * from Material
sp_help Material;

select * from Nota
sp_help Nota;

select * from Obra
sp_help Obra;

select * from Proveedor
sp_help Proveedor

ALTER PROCEDURE LISTAR_DETALLE_NOTA
AS
BEGIN
	SELECT Detalle_Nota.id_Detalle, Obra.Nombre_Obra, Proveedor.RazonSoc, Material.Nombre_Mat, Nota.Fecha, Detalle_Nota.Cantidad, Detalle_Nota.PrecioUnitario, Detalle_Nota.Extra
	FROM Detalle_Nota inner join Obra on (Detalle_Nota.Obra = Obra.id_Obra) inner join Nota on (Detalle_Nota.Nota = Nota.id_Nota)
	inner join Material on (Detalle_Nota.Material = Material.Id_Mate) inner join Proveedor on (Detalle_Nota.Prove = Proveedor.Id_Prove);
END

exec LISTAR_DETALLE_NOTA

SELECT Obra.Nombre_Obra, Proveedor.RazonSoc, Material.Nombre_Mat, Nota.Fecha, Detalle_Nota.Cantidad, Detalle_Nota.PrecioUnitario, Detalle_Nota.Extra
FROM Detalle_Nota inner join Obra on (Detalle_Nota.Obra = Obra.id_Obra) inner join Nota on (Detalle_Nota.Nota = Nota.id_Nota)
inner join Material on (Detalle_Nota.Material = Material.Id_Mate) inner join Proveedor on (Detalle_Nota.Prove = Proveedor.Id_Prove);



CREATE PROCEDURE DETALLE_NOTA_ID
@ID int
AS
BEGIN
	SELECT Detalle_Nota.id_Detalle, Obra.Nombre_Obra, Proveedor.RazonSoc, Material.Nombre_Mat, Nota.Fecha, Detalle_Nota.Cantidad, Detalle_Nota.PrecioUnitario, Detalle_Nota.Extra
	FROM Detalle_Nota inner join Obra on (Detalle_Nota.Obra = Obra.id_Obra) inner join Nota on (Detalle_Nota.Nota = Nota.id_Nota)
	inner join Material on (Detalle_Nota.Material = Material.Id_Mate) inner join Proveedor on (Detalle_Nota.Prove = Proveedor.Id_Prove)
	WHERE Detalle_Nota.id_Detalle = @ID
END

exec DETALLE_NOTA_ID 3




select * from Detalle_Nota
select * from Proveedor
select * from Material
select * from Nota

sp_help Detalle_Nota

ALTER PROCEDURE CREAR_DETALLE_NOTA
@Obra int,
@Prove int,
@Material int,
@Nota int,
@Cant int,
@PrecioUn float,
@Extra varchar(50)
AS
BEGIN
	INSERT Detalle_Nota VALUES (@Obra, @Prove, @Material, @Nota, @Cant, @PrecioUn, @Extra)
END

sp_help Nota




EXEC CREAR_DETALLE_NOTA 'Residencia Sergio', 'Construrama', 'Armex', '2022-10-17', 20, 300, null
EXEC CREAR_DETALLE_NOTA 1, 1, 4, 1, 20, 300, null

select * from Detalle_Nota
select * from Material

CREATE PROCEDURE LISTA_MATERIAL
AS
BEGIN
	SELECT Material.Id_Mate, Material.Nombre_Mat, Material.Marca, Material.Categoria, Material.UnidadMedida
	FROM Material;
END

CREATE PROCEDURE LISTA_MATERIAL_ID
@ID int
AS
BEGIN
	SELECT Material.Id_Mate, Material.Nombre_Mat, Material.Marca, Material.Categoria, Material.UnidadMedida
	FROM Material WHERE Material.Id_Mate = @ID;
END

CREATE PROCEDURE CREAR_MATERIAL
@Nombre_Mat VARCHAR(80),
@Marca VARCHAR(80),
@Categoria VARCHAR(80),
@UnidadMedida VARCHAR(80)
AS
BEGIN
	INSERT Material VALUES (@Nombre_Mat, @Marca, @Categoria, @UnidadMedida)
END

select * from Material

CREATE PROCEDURE LISTA_NOTA
AS
BEGIN
	SELECT Nota.id_Nota, Nota.Fecha, Nota.Extra FROM Nota
END

EXEC LISTA_NOTA

CREATE PROCEDURE LISTA_NOTA_ID
@ID int
AS
BEGIN
	SELECT Nota.id_Nota, Nota.Fecha, Nota.Extra FROM Nota WHERE Nota.id_Nota = @ID
END

EXEC LISTA_NOTA_ID 1

CREATE PROCEDURE CREAR_NOTA
@Fecha DATE,
@Extra VARCHAR(120)
AS
BEGIN
	INSERT Nota VALUES(@Fecha, @Extra)
END

EXEC CREAR_NOTA '2022-11-26', 'Se creó la NOTA de HOY'

CREATE PROCEDURE LISTA_OBRA
AS
BEGIN
	SELECT Obra.id_Obra, Obra.Nombre_Obra, Obra.Direccion, Obra.Fecha_ini, Obra.fecha_fin, Obra.Dueño, Obra.Responsable, Obra.Tel_resp, Obra.Correo_res FROM OBRA
END

EXEC LISTA_OBRA

CREATE PROCEDURE LISTA_OBRA_ID
@ID int
AS
BEGIN
	SELECT Obra.id_Obra, Obra.Nombre_Obra, Obra.Direccion, Obra.Fecha_ini, Obra.fecha_fin, Obra.Dueño, Obra.Responsable, Obra.Tel_resp, Obra.Correo_res FROM OBRA
	WHERE Obra.id_Obra = @ID
END

EXEC LISTA_OBRA_ID 1

sp_help Obra

CREATE PROCEDURE CREAR_OBRA
@Nombre_Obra varchar(120),
@Direccion varchar(120),
@Fecha_ini DATE,
@fecha_fin DATE,
@Dueño varchar(120),
@Responsable varchar(120),
@Tel_resp varchar(20),
@Correo_res varchar(150)
AS
BEGIN
	INSERT Obra VALUES (@Nombre_Obra, @Direccion, @Fecha_ini, @fecha_fin, @Dueño, @Responsable, @Tel_resp, @Correo_res);
END

EXEC CREAR_OBRA 'UTP', '20 de Noviembre', '2022-01-01', '2022-11-11', 'Julio Andrei', 'Mena de la rosa', '22225669899', 'prueba@live.com'

