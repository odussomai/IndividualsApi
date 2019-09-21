IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Individuals] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(150) NOT NULL,
    [LastName] nvarchar(150) NOT NULL,
    [Sex] int NOT NULL,
    [PersonalId] nvarchar(11) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [City] nvarchar(max) NULL,
    CONSTRAINT [PK_Individuals] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190919182431_Initial', N'2.2.6-servicing-10079');

GO

