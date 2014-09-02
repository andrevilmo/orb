
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/29/2014 11:14:46
-- Generated from EDMX file: C:\orb\GoTrackerWS\Models\GoTracker.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [orb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClienteVeiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Veiculoes] DROP CONSTRAINT [FK_ClienteVeiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipamentoVeiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Veiculoes] DROP CONSTRAINT [FK_EquipamentoVeiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_SimCardEquipamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipamentoes] DROP CONSTRAINT [FK_SimCardEquipamento];
GO
IF OBJECT_ID(N'[dbo].[FK_MotoristaVeiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Veiculoes] DROP CONSTRAINT [FK_MotoristaVeiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_PerfilUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_ClienteCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_ClienteUsuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Equipamentoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipamentoes];
GO
IF OBJECT_ID(N'[dbo].[Motoristas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Motoristas];
GO
IF OBJECT_ID(N'[dbo].[Perfils]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfils];
GO
IF OBJECT_ID(N'[dbo].[SimCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SimCards];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Veiculoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Veiculoes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [ClienteId] nvarchar(max)  NULL,
    [CNPJ] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Telefone] nvarchar(max)  NULL,
    [Logradouro] nvarchar(max)  NULL,
    [Cidade] nvarchar(max)  NULL,
    [Estado] nvarchar(max)  NULL,
    [WebSite] nvarchar(max)  NULL,
    [Observacoes] nvarchar(max)  NULL,
    [ClienteFilhoDe_Id] int  NULL
);
GO

-- Creating table 'Equipamentoes'
CREATE TABLE [dbo].[Equipamentoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumeroSerie] nvarchar(max)  NOT NULL,
    [Modelo] nvarchar(max)  NOT NULL,
    [SimCardId] int  NOT NULL
);
GO

-- Creating table 'Motoristas'
CREATE TABLE [dbo].[Motoristas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [NumeroDOC] nvarchar(max)  NOT NULL,
    [CategoriaCNH] nvarchar(max)  NOT NULL,
    [Sobrenome] nvarchar(max)  NOT NULL,
    [VencimentoCNH] datetime  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Telefone] nvarchar(max)  NOT NULL,
    [Celular] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Perfils'
CREATE TABLE [dbo].[Perfils] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [AcessoClientes] int  NOT NULL,
    [AcessoMotoristas] int  NOT NULL,
    [AcessoEquipamentos] int  NOT NULL,
    [AcessoSimCard] int  NOT NULL,
    [AcessoUsuario] int  NOT NULL,
    [AcessoVeiculo] int  NOT NULL,
    [AcessoPerfil] int  NOT NULL
);
GO

-- Creating table 'SimCards'
CREATE TABLE [dbo].[SimCards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DDD] nvarchar(max)  NOT NULL,
    [Telefone] nvarchar(max)  NOT NULL,
    [PIN] nvarchar(max)  NULL,
    [PUK] nvarchar(max)  NULL,
    [ICCID] nvarchar(max)  NULL,
    [PlanoDados] nvarchar(max)  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [SobreNome] nvarchar(max)  NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Senha] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [Telefone] nvarchar(max)  NULL,
    [Celular] nvarchar(max)  NULL,
    [DataSuspensao] nvarchar(max)  NULL,
    [PerfilId] int  NOT NULL,
    [ClienteId] int  NOT NULL
);
GO

-- Creating table 'Veiculoes'
CREATE TABLE [dbo].[Veiculoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [MotoristaId] int  NOT NULL,
    [ClienteId] int  NOT NULL,
    [Equipamento_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Equipamentoes'
ALTER TABLE [dbo].[Equipamentoes]
ADD CONSTRAINT [PK_Equipamentoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Motoristas'
ALTER TABLE [dbo].[Motoristas]
ADD CONSTRAINT [PK_Motoristas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Perfils'
ALTER TABLE [dbo].[Perfils]
ADD CONSTRAINT [PK_Perfils]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SimCards'
ALTER TABLE [dbo].[SimCards]
ADD CONSTRAINT [PK_SimCards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Veiculoes'
ALTER TABLE [dbo].[Veiculoes]
ADD CONSTRAINT [PK_Veiculoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClienteId] in table 'Veiculoes'
ALTER TABLE [dbo].[Veiculoes]
ADD CONSTRAINT [FK_ClienteVeiculo]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteVeiculo'
CREATE INDEX [IX_FK_ClienteVeiculo]
ON [dbo].[Veiculoes]
    ([ClienteId]);
GO

-- Creating foreign key on [Equipamento_Id] in table 'Veiculoes'
ALTER TABLE [dbo].[Veiculoes]
ADD CONSTRAINT [FK_EquipamentoVeiculo]
    FOREIGN KEY ([Equipamento_Id])
    REFERENCES [dbo].[Equipamentoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipamentoVeiculo'
CREATE INDEX [IX_FK_EquipamentoVeiculo]
ON [dbo].[Veiculoes]
    ([Equipamento_Id]);
GO

-- Creating foreign key on [SimCardId] in table 'Equipamentoes'
ALTER TABLE [dbo].[Equipamentoes]
ADD CONSTRAINT [FK_SimCardEquipamento]
    FOREIGN KEY ([SimCardId])
    REFERENCES [dbo].[SimCards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SimCardEquipamento'
CREATE INDEX [IX_FK_SimCardEquipamento]
ON [dbo].[Equipamentoes]
    ([SimCardId]);
GO

-- Creating foreign key on [MotoristaId] in table 'Veiculoes'
ALTER TABLE [dbo].[Veiculoes]
ADD CONSTRAINT [FK_MotoristaVeiculo]
    FOREIGN KEY ([MotoristaId])
    REFERENCES [dbo].[Motoristas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MotoristaVeiculo'
CREATE INDEX [IX_FK_MotoristaVeiculo]
ON [dbo].[Veiculoes]
    ([MotoristaId]);
GO

-- Creating foreign key on [PerfilId] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_PerfilUsuario]
    FOREIGN KEY ([PerfilId])
    REFERENCES [dbo].[Perfils]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilUsuario'
CREATE INDEX [IX_FK_PerfilUsuario]
ON [dbo].[Usuarios]
    ([PerfilId]);
GO

-- Creating foreign key on [ClienteFilhoDe_Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [FK_ClienteCliente]
    FOREIGN KEY ([ClienteFilhoDe_Id])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteCliente'
CREATE INDEX [IX_FK_ClienteCliente]
ON [dbo].[Clientes]
    ([ClienteFilhoDe_Id]);
GO

-- Creating foreign key on [ClienteId] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_ClienteUsuario]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteUsuario'
CREATE INDEX [IX_FK_ClienteUsuario]
ON [dbo].[Usuarios]
    ([ClienteId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------