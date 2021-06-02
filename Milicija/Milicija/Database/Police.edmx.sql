
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/02/2021 20:10:51
-- Generated from EDMX file: C:\Users\Bogdan\Desktop\Milicija\Milicija\Milicija\Database\Police.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Police];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CopRank]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Cop] DROP CONSTRAINT [FK_CopRank];
GO
IF OBJECT_ID(N'[dbo].[FK_ClerkSpecialty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Clerk] DROP CONSTRAINT [FK_ClerkSpecialty];
GO
IF OBJECT_ID(N'[dbo].[FK_OfficialStation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Official] DROP CONSTRAINT [FK_OfficialStation];
GO
IF OBJECT_ID(N'[dbo].[FK_DivisionStation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Divisions] DROP CONSTRAINT [FK_DivisionStation];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentStation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipments] DROP CONSTRAINT [FK_EquipmentStation];
GO
IF OBJECT_ID(N'[dbo].[FK_WarrantCop_Warrant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WarrantCop] DROP CONSTRAINT [FK_WarrantCop_Warrant];
GO
IF OBJECT_ID(N'[dbo].[FK_WarrantCop_Cop]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WarrantCop] DROP CONSTRAINT [FK_WarrantCop_Cop];
GO
IF OBJECT_ID(N'[dbo].[FK_WarrantClerk_Warrant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WarrantClerk] DROP CONSTRAINT [FK_WarrantClerk_Warrant];
GO
IF OBJECT_ID(N'[dbo].[FK_WarrantClerk_Clerk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WarrantClerk] DROP CONSTRAINT [FK_WarrantClerk_Clerk];
GO
IF OBJECT_ID(N'[dbo].[FK_WarrantStation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Warrants] DROP CONSTRAINT [FK_WarrantStation];
GO
IF OBJECT_ID(N'[dbo].[FK_Official_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Official] DROP CONSTRAINT [FK_Official_inherits_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Cop_inherits_Official]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Cop] DROP CONSTRAINT [FK_Cop_inherits_Official];
GO
IF OBJECT_ID(N'[dbo].[FK_Clerk_inherits_Official]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Clerk] DROP CONSTRAINT [FK_Clerk_inherits_Official];
GO
IF OBJECT_ID(N'[dbo].[FK_Support_inherits_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees_Support] DROP CONSTRAINT [FK_Support_inherits_Employee];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Ranks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ranks];
GO
IF OBJECT_ID(N'[dbo].[Specialties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Specialties];
GO
IF OBJECT_ID(N'[dbo].[Stations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stations];
GO
IF OBJECT_ID(N'[dbo].[Divisions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Divisions];
GO
IF OBJECT_ID(N'[dbo].[Equipments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipments];
GO
IF OBJECT_ID(N'[dbo].[Warrants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Warrants];
GO
IF OBJECT_ID(N'[dbo].[Employees_Official]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Official];
GO
IF OBJECT_ID(N'[dbo].[Employees_Cop]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Cop];
GO
IF OBJECT_ID(N'[dbo].[Employees_Clerk]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Clerk];
GO
IF OBJECT_ID(N'[dbo].[Employees_Support]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees_Support];
GO
IF OBJECT_ID(N'[dbo].[WarrantCop]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WarrantCop];
GO
IF OBJECT_ID(N'[dbo].[WarrantClerk]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WarrantClerk];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [JMBG] nvarchar(450)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Type] int  NOT NULL
);
GO

-- Creating table 'Ranks'
CREATE TABLE [dbo].[Ranks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Specialties'
CREATE TABLE [dbo].[Specialties] (
    [SpecialtyId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Stations'
CREATE TABLE [dbo].[Stations] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Divisions'
CREATE TABLE [dbo].[Divisions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Station_Id] int  NOT NULL
);
GO

-- Creating table 'Equipments'
CREATE TABLE [dbo].[Equipments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StationId] int  NOT NULL
);
GO

-- Creating table 'Warrants'
CREATE TABLE [dbo].[Warrants] (
    [DateOfWarrant] datetime  NOT NULL,
    [Station_Id] int  NOT NULL
);
GO

-- Creating table 'Employees_Official'
CREATE TABLE [dbo].[Employees_Official] (
    [StationId] int  NOT NULL,
    [OfficialType] int  NOT NULL,
    [JMBG] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'Employees_Cop'
CREATE TABLE [dbo].[Employees_Cop] (
    [RankId] int  NOT NULL,
    [JMBG] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'Employees_Clerk'
CREATE TABLE [dbo].[Employees_Clerk] (
    [License] nvarchar(max)  NOT NULL,
    [SpecialtySpecialtyId] int  NULL,
    [JMBG] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'Employees_Support'
CREATE TABLE [dbo].[Employees_Support] (
    [JMBG] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'WarrantCop'
CREATE TABLE [dbo].[WarrantCop] (
    [Warrants_DateOfWarrant] datetime  NOT NULL,
    [Cops_JMBG] nvarchar(450)  NOT NULL
);
GO

-- Creating table 'WarrantClerk'
CREATE TABLE [dbo].[WarrantClerk] (
    [Warrants_DateOfWarrant] datetime  NOT NULL,
    [Clerks_JMBG] nvarchar(450)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [JMBG] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Id] in table 'Ranks'
ALTER TABLE [dbo].[Ranks]
ADD CONSTRAINT [PK_Ranks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SpecialtyId] in table 'Specialties'
ALTER TABLE [dbo].[Specialties]
ADD CONSTRAINT [PK_Specialties]
    PRIMARY KEY CLUSTERED ([SpecialtyId] ASC);
GO

-- Creating primary key on [Id] in table 'Stations'
ALTER TABLE [dbo].[Stations]
ADD CONSTRAINT [PK_Stations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [PK_Divisions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [PK_Equipments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [DateOfWarrant] in table 'Warrants'
ALTER TABLE [dbo].[Warrants]
ADD CONSTRAINT [PK_Warrants]
    PRIMARY KEY CLUSTERED ([DateOfWarrant] ASC);
GO

-- Creating primary key on [JMBG] in table 'Employees_Official'
ALTER TABLE [dbo].[Employees_Official]
ADD CONSTRAINT [PK_Employees_Official]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Employees_Cop'
ALTER TABLE [dbo].[Employees_Cop]
ADD CONSTRAINT [PK_Employees_Cop]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Employees_Clerk'
ALTER TABLE [dbo].[Employees_Clerk]
ADD CONSTRAINT [PK_Employees_Clerk]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Employees_Support'
ALTER TABLE [dbo].[Employees_Support]
ADD CONSTRAINT [PK_Employees_Support]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Warrants_DateOfWarrant], [Cops_JMBG] in table 'WarrantCop'
ALTER TABLE [dbo].[WarrantCop]
ADD CONSTRAINT [PK_WarrantCop]
    PRIMARY KEY CLUSTERED ([Warrants_DateOfWarrant], [Cops_JMBG] ASC);
GO

-- Creating primary key on [Warrants_DateOfWarrant], [Clerks_JMBG] in table 'WarrantClerk'
ALTER TABLE [dbo].[WarrantClerk]
ADD CONSTRAINT [PK_WarrantClerk]
    PRIMARY KEY CLUSTERED ([Warrants_DateOfWarrant], [Clerks_JMBG] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RankId] in table 'Employees_Cop'
ALTER TABLE [dbo].[Employees_Cop]
ADD CONSTRAINT [FK_CopRank]
    FOREIGN KEY ([RankId])
    REFERENCES [dbo].[Ranks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CopRank'
CREATE INDEX [IX_FK_CopRank]
ON [dbo].[Employees_Cop]
    ([RankId]);
GO

-- Creating foreign key on [SpecialtySpecialtyId] in table 'Employees_Clerk'
ALTER TABLE [dbo].[Employees_Clerk]
ADD CONSTRAINT [FK_ClerkSpecialty]
    FOREIGN KEY ([SpecialtySpecialtyId])
    REFERENCES [dbo].[Specialties]
        ([SpecialtyId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClerkSpecialty'
CREATE INDEX [IX_FK_ClerkSpecialty]
ON [dbo].[Employees_Clerk]
    ([SpecialtySpecialtyId]);
GO

-- Creating foreign key on [StationId] in table 'Employees_Official'
ALTER TABLE [dbo].[Employees_Official]
ADD CONSTRAINT [FK_OfficialStation]
    FOREIGN KEY ([StationId])
    REFERENCES [dbo].[Stations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OfficialStation'
CREATE INDEX [IX_FK_OfficialStation]
ON [dbo].[Employees_Official]
    ([StationId]);
GO

-- Creating foreign key on [Station_Id] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [FK_DivisionStation]
    FOREIGN KEY ([Station_Id])
    REFERENCES [dbo].[Stations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DivisionStation'
CREATE INDEX [IX_FK_DivisionStation]
ON [dbo].[Divisions]
    ([Station_Id]);
GO

-- Creating foreign key on [StationId] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_EquipmentStation]
    FOREIGN KEY ([StationId])
    REFERENCES [dbo].[Stations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentStation'
CREATE INDEX [IX_FK_EquipmentStation]
ON [dbo].[Equipments]
    ([StationId]);
GO

-- Creating foreign key on [Warrants_DateOfWarrant] in table 'WarrantCop'
ALTER TABLE [dbo].[WarrantCop]
ADD CONSTRAINT [FK_WarrantCop_Warrant]
    FOREIGN KEY ([Warrants_DateOfWarrant])
    REFERENCES [dbo].[Warrants]
        ([DateOfWarrant])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Cops_JMBG] in table 'WarrantCop'
ALTER TABLE [dbo].[WarrantCop]
ADD CONSTRAINT [FK_WarrantCop_Cop]
    FOREIGN KEY ([Cops_JMBG])
    REFERENCES [dbo].[Employees_Cop]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WarrantCop_Cop'
CREATE INDEX [IX_FK_WarrantCop_Cop]
ON [dbo].[WarrantCop]
    ([Cops_JMBG]);
GO

-- Creating foreign key on [Warrants_DateOfWarrant] in table 'WarrantClerk'
ALTER TABLE [dbo].[WarrantClerk]
ADD CONSTRAINT [FK_WarrantClerk_Warrant]
    FOREIGN KEY ([Warrants_DateOfWarrant])
    REFERENCES [dbo].[Warrants]
        ([DateOfWarrant])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Clerks_JMBG] in table 'WarrantClerk'
ALTER TABLE [dbo].[WarrantClerk]
ADD CONSTRAINT [FK_WarrantClerk_Clerk]
    FOREIGN KEY ([Clerks_JMBG])
    REFERENCES [dbo].[Employees_Clerk]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WarrantClerk_Clerk'
CREATE INDEX [IX_FK_WarrantClerk_Clerk]
ON [dbo].[WarrantClerk]
    ([Clerks_JMBG]);
GO

-- Creating foreign key on [Station_Id] in table 'Warrants'
ALTER TABLE [dbo].[Warrants]
ADD CONSTRAINT [FK_WarrantStation]
    FOREIGN KEY ([Station_Id])
    REFERENCES [dbo].[Stations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WarrantStation'
CREATE INDEX [IX_FK_WarrantStation]
ON [dbo].[Warrants]
    ([Station_Id]);
GO

-- Creating foreign key on [JMBG] in table 'Employees_Official'
ALTER TABLE [dbo].[Employees_Official]
ADD CONSTRAINT [FK_Official_inherits_Employee]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Employees]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Employees_Cop'
ALTER TABLE [dbo].[Employees_Cop]
ADD CONSTRAINT [FK_Cop_inherits_Official]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Employees_Official]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Employees_Clerk'
ALTER TABLE [dbo].[Employees_Clerk]
ADD CONSTRAINT [FK_Clerk_inherits_Official]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Employees_Official]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Employees_Support'
ALTER TABLE [dbo].[Employees_Support]
ADD CONSTRAINT [FK_Support_inherits_Employee]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Employees]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------