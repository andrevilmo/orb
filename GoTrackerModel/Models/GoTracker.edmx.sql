
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/09/2014 01:18:25
-- Generated from EDMX file: C:\orb\GoTrackerModel\Models\GoTracker.edmx
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

IF OBJECT_ID(N'[dbo].[FK_ClienteCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_ClienteCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteMotorista]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Motoristas] DROP CONSTRAINT [FK_ClienteMotorista];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientePerfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfils] DROP CONSTRAINT [FK_ClientePerfil];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteSimCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SimCards] DROP CONSTRAINT [FK_ClienteSimCard];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_ClienteUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteVeiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Veiculoes] DROP CONSTRAINT [FK_ClienteVeiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_DadoAcessorio_x_DadoLido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DadoAcessorio] DROP CONSTRAINT [FK_DadoAcessorio_x_DadoLido];
GO
IF OBJECT_ID(N'[dbo].[FK_DadoAdicional_x_DadoLido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DadoAdicional_MXT] DROP CONSTRAINT [FK_DadoAdicional_x_DadoLido];
GO
IF OBJECT_ID(N'[dbo].[FK_DadoGSM_x_DadoLido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DadoGSM] DROP CONSTRAINT [FK_DadoGSM_x_DadoLido];
GO
IF OBJECT_ID(N'[dbo].[FK_DadoLivre_x_DadoLido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DadoLivre] DROP CONSTRAINT [FK_DadoLivre_x_DadoLido];
GO
IF OBJECT_ID(N'[dbo].[FK_DadoSatelite_x_DadoLido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DadoSatelite] DROP CONSTRAINT [FK_DadoSatelite_x_DadoLido];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipamentoVeiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Veiculoes] DROP CONSTRAINT [FK_EquipamentoVeiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_MotoristaVeiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Veiculoes] DROP CONSTRAINT [FK_MotoristaVeiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_PerfilUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_SimCardEquipamento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipamentoes] DROP CONSTRAINT [FK_SimCardEquipamento];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[DadoAcessorio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DadoAcessorio];
GO
IF OBJECT_ID(N'[dbo].[DadoAdicional_MXT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DadoAdicional_MXT];
GO
IF OBJECT_ID(N'[dbo].[DadoGSM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DadoGSM];
GO
IF OBJECT_ID(N'[dbo].[DadoLido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DadoLido];
GO
IF OBJECT_ID(N'[dbo].[DadoLivre]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DadoLivre];
GO
IF OBJECT_ID(N'[dbo].[DadoSatelite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DadoSatelite];
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
IF OBJECT_ID(N'[dbo].[Ultimo_DadoLido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ultimo_DadoLido];
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
    [SimCardId] int  NOT NULL,
    [ClienteId] int  NULL
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
    [Celular] nvarchar(max)  NOT NULL,
    [ClienteId] int  NULL
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
    [AcessoPerfil] int  NOT NULL,
    [ClienteId] int  NULL,
    [PlanoDados] nvarchar(max)  NOT NULL
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
    [PlanoDados] nvarchar(max)  NULL,
    [ClienteId] int  NULL,
    [Cliente_Id] int  NULL
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

-- Creating table 'DadoAcessorios'
CREATE TABLE [dbo].[DadoAcessorios] (
    [idDadoAcessorio] int IDENTITY(1,1) NOT NULL,
    [idDadoLido] int  NOT NULL,
    [DadoSerial] int  NOT NULL,
    [AcessorioSerial] int  NOT NULL,
    [AcessorioBatteryLevel] int  NULL,
    [AcessorioButtonStatus] int  NULL,
    [AcessorioInternalTemperature] int  NULL
);
GO

-- Creating table 'DadoAdicional_MXT'
CREATE TABLE [dbo].[DadoAdicional_MXT] (
    [idDadoAdicional] int IDENTITY(1,1) NOT NULL,
    [idDadoLido] int  NOT NULL,
    [LifeTime] int  NULL,
    [PositionInformation] int  NULL,
    [AccelerometerEvent] int  NULL,
    [AccelerometerValue] int  NULL,
    [CellPresent] tinyint  NULL,
    [VoiceCall] tinyint  NULL,
    [LatitudeSad69] float  NULL,
    [LongitudeSad69] float  NULL,
    [Utm] varchar(45)  NULL,
    [Easting] float  NULL,
    [Northing] float  NULL,
    [TamperingIsOpen] tinyint  NULL,
    [InternalAlarm] tinyint  NULL,
    [AccessoryMissing] tinyint  NULL,
    [DetailedSupply] float  NULL,
    [Ad4] float  NULL,
    [DriverId] int  NULL,
    [RouteId] int  NULL,
    [PointAnalise] tinyint  NULL,
    [AccessoryCount] int  NULL,
    [BatteryCharging] tinyint  NULL,
    [BatteryFailure] tinyint  NULL,
    [PointId] int  NULL,
    [PointIn] tinyint  NULL,
    [PointOut] tinyint  NULL
);
GO

-- Creating table 'DadoGSMs'
CREATE TABLE [dbo].[DadoGSMs] (
    [idDadoGSM] int  NOT NULL,
    [idDadoLido] int  NOT NULL,
    [DadoSerial] int  NOT NULL,
    [DadoLAC] varchar(45)  NOT NULL,
    [DadoMNC] varchar(45)  NOT NULL,
    [DadoMCC] varchar(45)  NOT NULL,
    [DadoCellId] varchar(45)  NOT NULL
);
GO

-- Creating table 'DadoLidoes'
CREATE TABLE [dbo].[DadoLidoes] (
    [idDadoLido] int  NOT NULL,
    [Serial] int  NOT NULL,
    [Protocol] int  NOT NULL,
    [MemoryIndex] int  NOT NULL,
    [Hourmeter] int  NOT NULL,
    [PacketReason] int  NULL,
    [Date] datetime  NOT NULL,
    [SystemDate] datetime  NOT NULL,
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL,
    [Course] int  NULL,
    [Speed] int  NULL,
    [GprsConn] tinyint  NULL,
    [GpsSignal] tinyint  NULL,
    [GpsAntFail] tinyint  NULL,
    [GpsAntDisc] tinyint  NULL,
    [GpsSleep] tinyint  NULL,
    [GsmJamming] tinyint  NULL,
    [Moving] tinyint  NULL,
    [Temperature] float  NULL,
    [PowerSupply] float  NULL,
    [Ignition] tinyint  NULL,
    [Panic] tinyint  NULL,
    [Inputs] int  NULL,
    [Outputs] int  NULL,
    [AnalogInputs] int  NULL,
    [BatteryUsed] float  NULL,
    [AntiTheftStatus] int  NULL,
    [Hodometer] bigint  NULL,
    [Rpm] int  NULL,
    [DriverId] int  NULL,
    [AccessoryExists] tinyint  NULL,
    [OpenDataExists] tinyint  NULL,
    [Ipv4] varchar(45)  NULL,
    [GenerationDate] datetime  NULL,
    [PacketSize] int  NULL
);
GO

-- Creating table 'DadoLivres'
CREATE TABLE [dbo].[DadoLivres] (
    [idDadoLivre] int  NOT NULL,
    [idDadoLido] int  NOT NULL,
    [DadoSerial] int  NOT NULL,
    [DadoString] varchar(45)  NOT NULL,
    [DadoDH] datetime  NOT NULL,
    [DadoDHS] datetime  NOT NULL
);
GO

-- Creating table 'DadoSatelites'
CREATE TABLE [dbo].[DadoSatelites] (
    [idDadoSatelite] int  NOT NULL,
    [idDadoLido] int  NOT NULL,
    [DadoSerial] int  NOT NULL,
    [DadoCSQ] int  NOT NULL,
    [DadoSVN] int  NOT NULL,
    [DadoSNR] int  NOT NULL,
    [DadoHDOP] int  NOT NULL
);
GO

-- Creating table 'Ultimo_DadoLido'
CREATE TABLE [dbo].[Ultimo_DadoLido] (
    [idUltimoDadoLido] int  NOT NULL,
    [Serial] int  NOT NULL,
    [Protocol] int  NOT NULL,
    [MemoryIndex] int  NOT NULL,
    [Hourmeter] int  NOT NULL,
    [PacketReason] int  NULL,
    [Date] datetime  NOT NULL,
    [SystemDate] datetime  NOT NULL,
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL,
    [Course] int  NULL,
    [Speed] int  NULL,
    [GprsConn] tinyint  NULL,
    [GpsSignal] tinyint  NULL,
    [GpsAntFail] tinyint  NULL,
    [GpsAntDisc] tinyint  NULL,
    [GpsSleep] tinyint  NULL,
    [GsmJamming] tinyint  NULL,
    [Moving] tinyint  NULL,
    [Temperature] float  NULL,
    [PowerSupply] float  NULL,
    [Ignition] tinyint  NULL,
    [Panic] tinyint  NULL,
    [Inputs] int  NULL,
    [Outputs] int  NULL,
    [AnalogInputs] int  NULL,
    [BatteryUsed] float  NULL,
    [AntiTheftStatus] int  NULL,
    [Hodometer] bigint  NULL,
    [Rpm] int  NULL,
    [DriverId] int  NULL,
    [AccessoryExists] tinyint  NULL,
    [OpenDataExists] tinyint  NULL,
    [Ipv4] varchar(45)  NULL,
    [GenerationDate] datetime  NULL,
    [PacketSize] int  NULL
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

-- Creating primary key on [idDadoAcessorio] in table 'DadoAcessorios'
ALTER TABLE [dbo].[DadoAcessorios]
ADD CONSTRAINT [PK_DadoAcessorios]
    PRIMARY KEY CLUSTERED ([idDadoAcessorio] ASC);
GO

-- Creating primary key on [idDadoAdicional] in table 'DadoAdicional_MXT'
ALTER TABLE [dbo].[DadoAdicional_MXT]
ADD CONSTRAINT [PK_DadoAdicional_MXT]
    PRIMARY KEY CLUSTERED ([idDadoAdicional] ASC);
GO

-- Creating primary key on [idDadoGSM] in table 'DadoGSMs'
ALTER TABLE [dbo].[DadoGSMs]
ADD CONSTRAINT [PK_DadoGSMs]
    PRIMARY KEY CLUSTERED ([idDadoGSM] ASC);
GO

-- Creating primary key on [idDadoLido] in table 'DadoLidoes'
ALTER TABLE [dbo].[DadoLidoes]
ADD CONSTRAINT [PK_DadoLidoes]
    PRIMARY KEY CLUSTERED ([idDadoLido] ASC);
GO

-- Creating primary key on [idDadoLivre] in table 'DadoLivres'
ALTER TABLE [dbo].[DadoLivres]
ADD CONSTRAINT [PK_DadoLivres]
    PRIMARY KEY CLUSTERED ([idDadoLivre] ASC);
GO

-- Creating primary key on [idDadoSatelite] in table 'DadoSatelites'
ALTER TABLE [dbo].[DadoSatelites]
ADD CONSTRAINT [PK_DadoSatelites]
    PRIMARY KEY CLUSTERED ([idDadoSatelite] ASC);
GO

-- Creating primary key on [idUltimoDadoLido] in table 'Ultimo_DadoLido'
ALTER TABLE [dbo].[Ultimo_DadoLido]
ADD CONSTRAINT [PK_Ultimo_DadoLido]
    PRIMARY KEY CLUSTERED ([idUltimoDadoLido] ASC);
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

-- Creating foreign key on [Cliente_Id] in table 'SimCards'
ALTER TABLE [dbo].[SimCards]
ADD CONSTRAINT [FK_ClienteSimCard]
    FOREIGN KEY ([Cliente_Id])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteSimCard'
CREATE INDEX [IX_FK_ClienteSimCard]
ON [dbo].[SimCards]
    ([Cliente_Id]);
GO

-- Creating foreign key on [ClienteId] in table 'Motoristas'
ALTER TABLE [dbo].[Motoristas]
ADD CONSTRAINT [FK_ClienteMotorista]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteMotorista'
CREATE INDEX [IX_FK_ClienteMotorista]
ON [dbo].[Motoristas]
    ([ClienteId]);
GO

-- Creating foreign key on [ClienteId] in table 'Perfils'
ALTER TABLE [dbo].[Perfils]
ADD CONSTRAINT [FK_ClientePerfil]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientePerfil'
CREATE INDEX [IX_FK_ClientePerfil]
ON [dbo].[Perfils]
    ([ClienteId]);
GO

-- Creating foreign key on [idDadoLido] in table 'DadoAcessorios'
ALTER TABLE [dbo].[DadoAcessorios]
ADD CONSTRAINT [FK_DadoAcessorio_x_DadoLido]
    FOREIGN KEY ([idDadoLido])
    REFERENCES [dbo].[DadoLidoes]
        ([idDadoLido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DadoAcessorio_x_DadoLido'
CREATE INDEX [IX_FK_DadoAcessorio_x_DadoLido]
ON [dbo].[DadoAcessorios]
    ([idDadoLido]);
GO

-- Creating foreign key on [idDadoLido] in table 'DadoAdicional_MXT'
ALTER TABLE [dbo].[DadoAdicional_MXT]
ADD CONSTRAINT [FK_DadoAdicional_x_DadoLido]
    FOREIGN KEY ([idDadoLido])
    REFERENCES [dbo].[DadoLidoes]
        ([idDadoLido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DadoAdicional_x_DadoLido'
CREATE INDEX [IX_FK_DadoAdicional_x_DadoLido]
ON [dbo].[DadoAdicional_MXT]
    ([idDadoLido]);
GO

-- Creating foreign key on [idDadoLido] in table 'DadoGSMs'
ALTER TABLE [dbo].[DadoGSMs]
ADD CONSTRAINT [FK_DadoGSM_x_DadoLido]
    FOREIGN KEY ([idDadoLido])
    REFERENCES [dbo].[DadoLidoes]
        ([idDadoLido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DadoGSM_x_DadoLido'
CREATE INDEX [IX_FK_DadoGSM_x_DadoLido]
ON [dbo].[DadoGSMs]
    ([idDadoLido]);
GO

-- Creating foreign key on [idDadoLido] in table 'DadoLivres'
ALTER TABLE [dbo].[DadoLivres]
ADD CONSTRAINT [FK_DadoLivre_x_DadoLido]
    FOREIGN KEY ([idDadoLido])
    REFERENCES [dbo].[DadoLidoes]
        ([idDadoLido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DadoLivre_x_DadoLido'
CREATE INDEX [IX_FK_DadoLivre_x_DadoLido]
ON [dbo].[DadoLivres]
    ([idDadoLido]);
GO

-- Creating foreign key on [idDadoLido] in table 'DadoSatelites'
ALTER TABLE [dbo].[DadoSatelites]
ADD CONSTRAINT [FK_DadoSatelite_x_DadoLido]
    FOREIGN KEY ([idDadoLido])
    REFERENCES [dbo].[DadoLidoes]
        ([idDadoLido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DadoSatelite_x_DadoLido'
CREATE INDEX [IX_FK_DadoSatelite_x_DadoLido]
ON [dbo].[DadoSatelites]
    ([idDadoLido]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------