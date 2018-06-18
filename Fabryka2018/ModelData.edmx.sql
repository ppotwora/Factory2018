
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2018 22:31:00
-- Generated from EDMX file: C:\Users\Pawel\source\repos\Fabryka2018\Fabryka2018\ModelData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FabrykaSPTI];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Halas'
CREATE TABLE [dbo].[Halas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(max)  NOT NULL,
    [Adres] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Maszynas'
CREATE TABLE [dbo].[Maszynas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(max)  NOT NULL,
    [Data_uruchomienia] datetime  NULL,
    [HalaId] int  NOT NULL
);
GO

-- Creating table 'Operators'
CREATE TABLE [dbo].[Operators] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Imię] nvarchar(max)  NOT NULL,
    [Nazwisko] nvarchar(max)  NOT NULL,
    [Płaca] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MaszynaOperator'
CREATE TABLE [dbo].[MaszynaOperator] (
    [Maszynas_Id] int  NOT NULL,
    [Operators_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Halas'
ALTER TABLE [dbo].[Halas]
ADD CONSTRAINT [PK_Halas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Maszynas'
ALTER TABLE [dbo].[Maszynas]
ADD CONSTRAINT [PK_Maszynas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operators'
ALTER TABLE [dbo].[Operators]
ADD CONSTRAINT [PK_Operators]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Maszynas_Id], [Operators_Id] in table 'MaszynaOperator'
ALTER TABLE [dbo].[MaszynaOperator]
ADD CONSTRAINT [PK_MaszynaOperator]
    PRIMARY KEY CLUSTERED ([Maszynas_Id], [Operators_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HalaId] in table 'Maszynas'
ALTER TABLE [dbo].[Maszynas]
ADD CONSTRAINT [FK_HalaMaszyna]
    FOREIGN KEY ([HalaId])
    REFERENCES [dbo].[Halas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HalaMaszyna'
CREATE INDEX [IX_FK_HalaMaszyna]
ON [dbo].[Maszynas]
    ([HalaId]);
GO

-- Creating foreign key on [Maszynas_Id] in table 'MaszynaOperator'
ALTER TABLE [dbo].[MaszynaOperator]
ADD CONSTRAINT [FK_MaszynaOperator_Maszyna]
    FOREIGN KEY ([Maszynas_Id])
    REFERENCES [dbo].[Maszynas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Operators_Id] in table 'MaszynaOperator'
ALTER TABLE [dbo].[MaszynaOperator]
ADD CONSTRAINT [FK_MaszynaOperator_Operator]
    FOREIGN KEY ([Operators_Id])
    REFERENCES [dbo].[Operators]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaszynaOperator_Operator'
CREATE INDEX [IX_FK_MaszynaOperator_Operator]
ON [dbo].[MaszynaOperator]
    ([Operators_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------