
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2015 11:07:52
-- Generated from EDMX file: C:\Users\MARIA JUDITH QUEZADA\Desktop\CartagenaGourmet\MVC\Models\Modelos.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_68219_gourmet];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CategoriasComidas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comidas] DROP CONSTRAINT [FK_CategoriasComidas];
GO
IF OBJECT_ID(N'[dbo].[FK_CocinaRestaurantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Restaurantes] DROP CONSTRAINT [FK_CocinaRestaurantes];
GO
IF OBJECT_ID(N'[dbo].[FK_ComidasFoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comidas] DROP CONSTRAINT [FK_ComidasFoto];
GO
IF OBJECT_ID(N'[dbo].[FK_ComidasPrecios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comidas] DROP CONSTRAINT [FK_ComidasPrecios];
GO
IF OBJECT_ID(N'[dbo].[FK_FotoCategorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categorias] DROP CONSTRAINT [FK_FotoCategorias];
GO
IF OBJECT_ID(N'[dbo].[FK_MesasFoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mesas] DROP CONSTRAINT [FK_MesasFoto];
GO
IF OBJECT_ID(N'[dbo].[FK_Pedidos_Restaurantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidos] DROP CONSTRAINT [FK_Pedidos_Restaurantes];
GO
IF OBJECT_ID(N'[dbo].[FK_Pedidos_Servicios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidos] DROP CONSTRAINT [FK_Pedidos_Servicios];
GO
IF OBJECT_ID(N'[dbo].[FK_Pedidos_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidos] DROP CONSTRAINT [FK_Pedidos_User];
GO
IF OBJECT_ID(N'[dbo].[FK_PedidosDetalles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Detalles] DROP CONSTRAINT [FK_PedidosDetalles];
GO
IF OBJECT_ID(N'[dbo].[FK_ReservaRestaurante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_ReservaRestaurante];
GO
IF OBJECT_ID(N'[dbo].[FK_Reservas_Mesas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_Reservas_Mesas];
GO
IF OBJECT_ID(N'[dbo].[FK_Reservas_Salas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_Reservas_Salas];
GO
IF OBJECT_ID(N'[dbo].[FK_Reservas_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservas] DROP CONSTRAINT [FK_Reservas_User];
GO
IF OBJECT_ID(N'[dbo].[FK_RestauranteCategorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Categorias] DROP CONSTRAINT [FK_RestauranteCategorias];
GO
IF OBJECT_ID(N'[dbo].[FK_Restaurantes_Zona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Restaurantes] DROP CONSTRAINT [FK_Restaurantes_Zona];
GO
IF OBJECT_ID(N'[dbo].[FK_RestaurantesImegenes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Imegenes] DROP CONSTRAINT [FK_RestaurantesImegenes];
GO
IF OBJECT_ID(N'[dbo].[FK_Salas_Ambiente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Salas] DROP CONSTRAINT [FK_Salas_Ambiente];
GO
IF OBJECT_ID(N'[dbo].[FK_Salas_Restaurantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Salas] DROP CONSTRAINT [FK_Salas_Restaurantes];
GO
IF OBJECT_ID(N'[dbo].[FK_SalasFoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Salas] DROP CONSTRAINT [FK_SalasFoto];
GO
IF OBJECT_ID(N'[dbo].[FK_SalasMesas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mesas] DROP CONSTRAINT [FK_SalasMesas];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiciosRestaurantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servicios] DROP CONSTRAINT [FK_ServiciosRestaurantes];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Restaurantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Restaurantes] DROP CONSTRAINT [FK_User_Restaurantes];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Rol]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Rol];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Ambiente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ambiente];
GO
IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[Cocina]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cocina];
GO
IF OBJECT_ID(N'[dbo].[Comidas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comidas];
GO
IF OBJECT_ID(N'[dbo].[Detalles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Detalles];
GO
IF OBJECT_ID(N'[dbo].[Foto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Foto];
GO
IF OBJECT_ID(N'[dbo].[Imegenes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Imegenes];
GO
IF OBJECT_ID(N'[dbo].[Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Login];
GO
IF OBJECT_ID(N'[dbo].[Mesas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mesas];
GO
IF OBJECT_ID(N'[dbo].[Pedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedidos];
GO
IF OBJECT_ID(N'[dbo].[Precios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Precios];
GO
IF OBJECT_ID(N'[dbo].[Reservas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservas];
GO
IF OBJECT_ID(N'[dbo].[Restaurantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restaurantes];
GO
IF OBJECT_ID(N'[dbo].[Rol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rol];
GO
IF OBJECT_ID(N'[dbo].[Salas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Salas];
GO
IF OBJECT_ID(N'[dbo].[Servicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servicios];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Zona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zona];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [id_categoria] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [nit] int  NOT NULL,
    [fotoid] int  NOT NULL
);
GO

-- Creating table 'Comidas'
CREATE TABLE [dbo].[Comidas] (
    [id_comida] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [id_categoria] int  NOT NULL,
    [Idprecio] int  NOT NULL,
    [id_foto] int  NOT NULL
);
GO

-- Creating table 'Detalles'
CREATE TABLE [dbo].[Detalles] (
    [id_detalle] int IDENTITY(1,1) NOT NULL,
    [id_comida] int  NOT NULL,
    [valor] decimal(18,0)  NOT NULL,
    [cantidad] smallint  NOT NULL,
    [id_pedido] int  NOT NULL
);
GO

-- Creating table 'Foto'
CREATE TABLE [dbo].[Foto] (
    [id_foto] int IDENTITY(1,1) NOT NULL,
    [img_foto] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Imegenes'
CREATE TABLE [dbo].[Imegenes] (
    [nit] int IDENTITY(1,1) NOT NULL,
    [logo] nvarchar(max)  NOT NULL,
    [foto_perfil] nvarchar(max)  NOT NULL,
    [foto1] nvarchar(max)  NULL,
    [foto2] nvarchar(max)  NULL,
    [foto3] nvarchar(max)  NULL
);
GO

-- Creating table 'Mesas'
CREATE TABLE [dbo].[Mesas] (
    [id_mesa] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [sillas] nvarchar(max)  NOT NULL,
    [tipo] nvarchar(max)  NOT NULL,
    [id_sala] int  NOT NULL,
    [id_foto] int  NOT NULL
);
GO

-- Creating table 'Pedidos'
CREATE TABLE [dbo].[Pedidos] (
    [id_pedido] int IDENTITY(1,1) NOT NULL,
    [id_servicio] int  NOT NULL,
    [estado] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [iva] decimal(18,0)  NOT NULL,
    [total] decimal(18,0)  NOT NULL,
    [subtotal] decimal(18,0)  NOT NULL,
    [nit] int  NOT NULL,
    [cedula] int  NOT NULL
);
GO

-- Creating table 'Precios'
CREATE TABLE [dbo].[Precios] (
    [id_precio] int IDENTITY(1,1) NOT NULL,
    [precio] decimal(18,0)  NOT NULL,
    [iva] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Reservas'
CREATE TABLE [dbo].[Reservas] (
    [id_reserva] int IDENTITY(1,1) NOT NULL,
    [id_sala] int  NOT NULL,
    [id_mesa] int  NOT NULL,
    [facha] datetime  NOT NULL,
    [estado] nvarchar(max)  NOT NULL,
    [cedula] int  NOT NULL,
    [nit] int  NOT NULL
);
GO

-- Creating table 'Restaurantes'
CREATE TABLE [dbo].[Restaurantes] (
    [nit] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [direccion] nvarchar(max)  NOT NULL,
    [slogan] nvarchar(max)  NOT NULL,
    [puntuacion] decimal(18,0)  NOT NULL,
    [tenedor] smallint  NULL,
    [fecha] datetime  NOT NULL,
    [user_cedula] int  NOT NULL,
    [zona] int  NOT NULL,
    [id_cocina] int  NOT NULL
);
GO

-- Creating table 'Rol'
CREATE TABLE [dbo].[Rol] (
    [id_rol] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Salas'
CREATE TABLE [dbo].[Salas] (
    [id_sala] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [ambiente] int  NULL,
    [estado] nvarchar(max)  NOT NULL,
    [nit] int  NOT NULL,
    [Foto_id_foto] int  NOT NULL
);
GO

-- Creating table 'Servicios'
CREATE TABLE [dbo].[Servicios] (
    [id_servicio] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [nit] int  NOT NULL
);
GO

-- Creating table 'Zona'
CREATE TABLE [dbo].[Zona] (
    [id_zona] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Cocina'
CREATE TABLE [dbo].[Cocina] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(max)  NOT NULL
);
GO

-- Creating table 'Ambiente'
CREATE TABLE [dbo].[Ambiente] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(max)  NULL,
    [desclipcion] varchar(max)  NULL
);
GO

-- Creating table 'Login'
CREATE TABLE [dbo].[Login] (
    [codigo] int  NOT NULL,
    [usuario] varchar(20)  NOT NULL,
    [password] varchar(max)  NOT NULL,
    [confirma] varchar(max)  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [cedula] int  NOT NULL,
    [nombre] varchar(50)  NOT NULL,
    [apellidos] varchar(50)  NOT NULL,
    [telefono] varchar(50)  NOT NULL,
    [rol] int  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [Celular] varchar(15)  NULL,
    [fecha] datetime  NOT NULL,
    [nickname] varchar(50)  NULL,
    [password] varchar(50)  NULL,
    [confirme] varchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_categoria] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([id_categoria] ASC);
GO

-- Creating primary key on [id_comida] in table 'Comidas'
ALTER TABLE [dbo].[Comidas]
ADD CONSTRAINT [PK_Comidas]
    PRIMARY KEY CLUSTERED ([id_comida] ASC);
GO

-- Creating primary key on [id_detalle] in table 'Detalles'
ALTER TABLE [dbo].[Detalles]
ADD CONSTRAINT [PK_Detalles]
    PRIMARY KEY CLUSTERED ([id_detalle] ASC);
GO

-- Creating primary key on [id_foto] in table 'Foto'
ALTER TABLE [dbo].[Foto]
ADD CONSTRAINT [PK_Foto]
    PRIMARY KEY CLUSTERED ([id_foto] ASC);
GO

-- Creating primary key on [nit] in table 'Imegenes'
ALTER TABLE [dbo].[Imegenes]
ADD CONSTRAINT [PK_Imegenes]
    PRIMARY KEY CLUSTERED ([nit] ASC);
GO

-- Creating primary key on [id_mesa] in table 'Mesas'
ALTER TABLE [dbo].[Mesas]
ADD CONSTRAINT [PK_Mesas]
    PRIMARY KEY CLUSTERED ([id_mesa] ASC);
GO

-- Creating primary key on [id_pedido] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [PK_Pedidos]
    PRIMARY KEY CLUSTERED ([id_pedido] ASC);
GO

-- Creating primary key on [id_precio] in table 'Precios'
ALTER TABLE [dbo].[Precios]
ADD CONSTRAINT [PK_Precios]
    PRIMARY KEY CLUSTERED ([id_precio] ASC);
GO

-- Creating primary key on [id_reserva] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [PK_Reservas]
    PRIMARY KEY CLUSTERED ([id_reserva] ASC);
GO

-- Creating primary key on [nit] in table 'Restaurantes'
ALTER TABLE [dbo].[Restaurantes]
ADD CONSTRAINT [PK_Restaurantes]
    PRIMARY KEY CLUSTERED ([nit] ASC);
GO

-- Creating primary key on [id_rol] in table 'Rol'
ALTER TABLE [dbo].[Rol]
ADD CONSTRAINT [PK_Rol]
    PRIMARY KEY CLUSTERED ([id_rol] ASC);
GO

-- Creating primary key on [id_sala] in table 'Salas'
ALTER TABLE [dbo].[Salas]
ADD CONSTRAINT [PK_Salas]
    PRIMARY KEY CLUSTERED ([id_sala] ASC);
GO

-- Creating primary key on [id_servicio] in table 'Servicios'
ALTER TABLE [dbo].[Servicios]
ADD CONSTRAINT [PK_Servicios]
    PRIMARY KEY CLUSTERED ([id_servicio] ASC);
GO

-- Creating primary key on [id_zona] in table 'Zona'
ALTER TABLE [dbo].[Zona]
ADD CONSTRAINT [PK_Zona]
    PRIMARY KEY CLUSTERED ([id_zona] ASC);
GO

-- Creating primary key on [id] in table 'Cocina'
ALTER TABLE [dbo].[Cocina]
ADD CONSTRAINT [PK_Cocina]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Ambiente'
ALTER TABLE [dbo].[Ambiente]
ADD CONSTRAINT [PK_Ambiente]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [codigo] in table 'Login'
ALTER TABLE [dbo].[Login]
ADD CONSTRAINT [PK_Login]
    PRIMARY KEY CLUSTERED ([codigo] ASC);
GO

-- Creating primary key on [cedula] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([cedula] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_categoria] in table 'Comidas'
ALTER TABLE [dbo].[Comidas]
ADD CONSTRAINT [FK_CategoriasComidas]
    FOREIGN KEY ([id_categoria])
    REFERENCES [dbo].[Categorias]
        ([id_categoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriasComidas'
CREATE INDEX [IX_FK_CategoriasComidas]
ON [dbo].[Comidas]
    ([id_categoria]);
GO

-- Creating foreign key on [fotoid] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [FK_FotoCategorias]
    FOREIGN KEY ([fotoid])
    REFERENCES [dbo].[Foto]
        ([id_foto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FotoCategorias'
CREATE INDEX [IX_FK_FotoCategorias]
ON [dbo].[Categorias]
    ([fotoid]);
GO

-- Creating foreign key on [nit] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [FK_RestauranteCategorias]
    FOREIGN KEY ([nit])
    REFERENCES [dbo].[Restaurantes]
        ([nit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestauranteCategorias'
CREATE INDEX [IX_FK_RestauranteCategorias]
ON [dbo].[Categorias]
    ([nit]);
GO

-- Creating foreign key on [id_foto] in table 'Comidas'
ALTER TABLE [dbo].[Comidas]
ADD CONSTRAINT [FK_ComidasFoto]
    FOREIGN KEY ([id_foto])
    REFERENCES [dbo].[Foto]
        ([id_foto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComidasFoto'
CREATE INDEX [IX_FK_ComidasFoto]
ON [dbo].[Comidas]
    ([id_foto]);
GO

-- Creating foreign key on [Idprecio] in table 'Comidas'
ALTER TABLE [dbo].[Comidas]
ADD CONSTRAINT [FK_ComidasPrecios]
    FOREIGN KEY ([Idprecio])
    REFERENCES [dbo].[Precios]
        ([id_precio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComidasPrecios'
CREATE INDEX [IX_FK_ComidasPrecios]
ON [dbo].[Comidas]
    ([Idprecio]);
GO

-- Creating foreign key on [id_pedido] in table 'Detalles'
ALTER TABLE [dbo].[Detalles]
ADD CONSTRAINT [FK_PedidosDetalles]
    FOREIGN KEY ([id_pedido])
    REFERENCES [dbo].[Pedidos]
        ([id_pedido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidosDetalles'
CREATE INDEX [IX_FK_PedidosDetalles]
ON [dbo].[Detalles]
    ([id_pedido]);
GO

-- Creating foreign key on [id_foto] in table 'Mesas'
ALTER TABLE [dbo].[Mesas]
ADD CONSTRAINT [FK_MesasFoto]
    FOREIGN KEY ([id_foto])
    REFERENCES [dbo].[Foto]
        ([id_foto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MesasFoto'
CREATE INDEX [IX_FK_MesasFoto]
ON [dbo].[Mesas]
    ([id_foto]);
GO

-- Creating foreign key on [Foto_id_foto] in table 'Salas'
ALTER TABLE [dbo].[Salas]
ADD CONSTRAINT [FK_SalasFoto]
    FOREIGN KEY ([Foto_id_foto])
    REFERENCES [dbo].[Foto]
        ([id_foto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalasFoto'
CREATE INDEX [IX_FK_SalasFoto]
ON [dbo].[Salas]
    ([Foto_id_foto]);
GO

-- Creating foreign key on [nit] in table 'Imegenes'
ALTER TABLE [dbo].[Imegenes]
ADD CONSTRAINT [FK_RestaurantesImegenes]
    FOREIGN KEY ([nit])
    REFERENCES [dbo].[Restaurantes]
        ([nit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_mesa] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK_Reservas_Mesas]
    FOREIGN KEY ([id_mesa])
    REFERENCES [dbo].[Mesas]
        ([id_mesa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservas_Mesas'
CREATE INDEX [IX_FK_Reservas_Mesas]
ON [dbo].[Reservas]
    ([id_mesa]);
GO

-- Creating foreign key on [nit] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_Pedidos_Restaurantes]
    FOREIGN KEY ([nit])
    REFERENCES [dbo].[Restaurantes]
        ([nit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pedidos_Restaurantes'
CREATE INDEX [IX_FK_Pedidos_Restaurantes]
ON [dbo].[Pedidos]
    ([nit]);
GO

-- Creating foreign key on [id_servicio] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_Pedidos_Servicios]
    FOREIGN KEY ([id_servicio])
    REFERENCES [dbo].[Servicios]
        ([id_servicio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pedidos_Servicios'
CREATE INDEX [IX_FK_Pedidos_Servicios]
ON [dbo].[Pedidos]
    ([id_servicio]);
GO

-- Creating foreign key on [nit] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK_ReservaRestaurante]
    FOREIGN KEY ([nit])
    REFERENCES [dbo].[Restaurantes]
        ([nit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReservaRestaurante'
CREATE INDEX [IX_FK_ReservaRestaurante]
ON [dbo].[Reservas]
    ([nit]);
GO

-- Creating foreign key on [id_sala] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK_Reservas_Salas]
    FOREIGN KEY ([id_sala])
    REFERENCES [dbo].[Salas]
        ([id_sala])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservas_Salas'
CREATE INDEX [IX_FK_Reservas_Salas]
ON [dbo].[Reservas]
    ([id_sala]);
GO

-- Creating foreign key on [zona] in table 'Restaurantes'
ALTER TABLE [dbo].[Restaurantes]
ADD CONSTRAINT [FK_Restaurantes_Zona]
    FOREIGN KEY ([zona])
    REFERENCES [dbo].[Zona]
        ([id_zona])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Restaurantes_Zona'
CREATE INDEX [IX_FK_Restaurantes_Zona]
ON [dbo].[Restaurantes]
    ([zona]);
GO

-- Creating foreign key on [nit] in table 'Salas'
ALTER TABLE [dbo].[Salas]
ADD CONSTRAINT [FK_Salas_Restaurantes]
    FOREIGN KEY ([nit])
    REFERENCES [dbo].[Restaurantes]
        ([nit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Salas_Restaurantes'
CREATE INDEX [IX_FK_Salas_Restaurantes]
ON [dbo].[Salas]
    ([nit]);
GO

-- Creating foreign key on [nit] in table 'Servicios'
ALTER TABLE [dbo].[Servicios]
ADD CONSTRAINT [FK_ServiciosRestaurantes]
    FOREIGN KEY ([nit])
    REFERENCES [dbo].[Restaurantes]
        ([nit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiciosRestaurantes'
CREATE INDEX [IX_FK_ServiciosRestaurantes]
ON [dbo].[Servicios]
    ([nit]);
GO

-- Creating foreign key on [id_cocina] in table 'Restaurantes'
ALTER TABLE [dbo].[Restaurantes]
ADD CONSTRAINT [FK_CocinaRestaurantes]
    FOREIGN KEY ([id_cocina])
    REFERENCES [dbo].[Cocina]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CocinaRestaurantes'
CREATE INDEX [IX_FK_CocinaRestaurantes]
ON [dbo].[Restaurantes]
    ([id_cocina]);
GO

-- Creating foreign key on [id_sala] in table 'Mesas'
ALTER TABLE [dbo].[Mesas]
ADD CONSTRAINT [FK_SalasMesas]
    FOREIGN KEY ([id_sala])
    REFERENCES [dbo].[Salas]
        ([id_sala])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalasMesas'
CREATE INDEX [IX_FK_SalasMesas]
ON [dbo].[Mesas]
    ([id_sala]);
GO

-- Creating foreign key on [ambiente] in table 'Salas'
ALTER TABLE [dbo].[Salas]
ADD CONSTRAINT [FK_Salas_Ambiente]
    FOREIGN KEY ([ambiente])
    REFERENCES [dbo].[Ambiente]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Salas_Ambiente'
CREATE INDEX [IX_FK_Salas_Ambiente]
ON [dbo].[Salas]
    ([ambiente]);
GO

-- Creating foreign key on [cedula] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_Pedidos_User]
    FOREIGN KEY ([cedula])
    REFERENCES [dbo].[User]
        ([cedula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pedidos_User'
CREATE INDEX [IX_FK_Pedidos_User]
ON [dbo].[Pedidos]
    ([cedula]);
GO

-- Creating foreign key on [cedula] in table 'Reservas'
ALTER TABLE [dbo].[Reservas]
ADD CONSTRAINT [FK_Reservas_User]
    FOREIGN KEY ([cedula])
    REFERENCES [dbo].[User]
        ([cedula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reservas_User'
CREATE INDEX [IX_FK_Reservas_User]
ON [dbo].[Reservas]
    ([cedula]);
GO

-- Creating foreign key on [user_cedula] in table 'Restaurantes'
ALTER TABLE [dbo].[Restaurantes]
ADD CONSTRAINT [FK_User_Restaurantes]
    FOREIGN KEY ([user_cedula])
    REFERENCES [dbo].[User]
        ([cedula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Restaurantes'
CREATE INDEX [IX_FK_User_Restaurantes]
ON [dbo].[Restaurantes]
    ([user_cedula]);
GO

-- Creating foreign key on [rol] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_User_Rol]
    FOREIGN KEY ([rol])
    REFERENCES [dbo].[Rol]
        ([id_rol])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Rol'
CREATE INDEX [IX_FK_User_Rol]
ON [dbo].[User]
    ([rol]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------