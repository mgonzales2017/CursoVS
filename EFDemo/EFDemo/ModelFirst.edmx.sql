
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/02/2017 14:55:32
-- Generated from EDMX file: C:\WorkS\LourtecVS\EFDemo\EFDemo\ModelFirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MenusCafes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bebidas_Cafes] DROP CONSTRAINT [FK_MenusCafes];
GO
IF OBJECT_ID(N'[dbo].[FK_Cafes_inherits_Bebidas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bebidas_Cafes] DROP CONSTRAINT [FK_Cafes_inherits_Bebidas];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bebidas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bebidas];
GO
IF OBJECT_ID(N'[dbo].[Menus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menus];
GO
IF OBJECT_ID(N'[dbo].[Bebidas_Cafes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bebidas_Cafes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bebidas'
CREATE TABLE [dbo].[Bebidas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Temperatura] float  NOT NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Teas'
CREATE TABLE [dbo].[Teas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bebidas_Cafes'
CREATE TABLE [dbo].[Bebidas_Cafes] (
    [Grano] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [Menu_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Bebidas'
ALTER TABLE [dbo].[Bebidas]
ADD CONSTRAINT [PK_Bebidas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Teas'
ALTER TABLE [dbo].[Teas]
ADD CONSTRAINT [PK_Teas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bebidas_Cafes'
ALTER TABLE [dbo].[Bebidas_Cafes]
ADD CONSTRAINT [PK_Bebidas_Cafes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Menu_Id] in table 'Bebidas_Cafes'
ALTER TABLE [dbo].[Bebidas_Cafes]
ADD CONSTRAINT [FK_MenusCafes]
    FOREIGN KEY ([Menu_Id])
    REFERENCES [dbo].[Menus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenusCafes'
CREATE INDEX [IX_FK_MenusCafes]
ON [dbo].[Bebidas_Cafes]
    ([Menu_Id]);
GO

-- Creating foreign key on [Id] in table 'Bebidas_Cafes'
ALTER TABLE [dbo].[Bebidas_Cafes]
ADD CONSTRAINT [FK_Cafes_inherits_Bebidas]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Bebidas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------