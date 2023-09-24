IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [Telefone] bigint NULL,
    [Endereco] nvarchar(max) NOT NULL,
    [tipoEnum] int NOT NULL,
    [generoEnum] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Avaliacao] (
    [Id] int NOT NULL IDENTITY,
    [Comentario] nvarchar(max) NOT NULL,
    [Nota] float NOT NULL,
    [usuarioId] int NOT NULL,
    CONSTRAINT [PK_Avaliacao] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Avaliacao_Usuarios_usuarioId] FOREIGN KEY ([usuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Banda] (
    [Id] int NOT NULL IDENTITY,
    [nomeBanda] nvarchar(max) NOT NULL,
    [estilo] nvarchar(max) NOT NULL,
    [usuarioId] int NOT NULL,
    CONSTRAINT [PK_Banda] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Banda_Usuarios_usuarioId] FOREIGN KEY ([usuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Contrato] (
    [Id] int NOT NULL IDENTITY,
    [Dt_Cont] datetime2 NULL,
    [duracao] int NOT NULL,
    [Dt_Apresentacao] datetime2 NULL,
    [usuarioId] int NOT NULL,
    CONSTRAINT [PK_Contrato] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contrato_Usuarios_usuarioId] FOREIGN KEY ([usuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Instrumento] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NOT NULL,
    [usuarioId] int NOT NULL,
    CONSTRAINT [PK_Instrumento] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Instrumento_Usuarios_usuarioId] FOREIGN KEY ([usuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Endereco', N'Nome', N'Senha', N'Telefone', N'generoEnum', N'tipoEnum') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [Email], [Endereco], [Nome], [Senha], [Telefone], [generoEnum], [tipoEnum])
VALUES (1, N'PedroS@gmail.com', N'', N'Pedro Silva', N'pedrinho123', NULL, 0, 0),
(2, N'gHenrique@gmail.com', N'', N'Gustavo Henrique', N'henrique123', NULL, 0, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Endereco', N'Nome', N'Senha', N'Telefone', N'generoEnum', N'tipoEnum') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO

CREATE INDEX [IX_Avaliacao_usuarioId] ON [Avaliacao] ([usuarioId]);
GO

CREATE INDEX [IX_Banda_usuarioId] ON [Banda] ([usuarioId]);
GO

CREATE INDEX [IX_Contrato_usuarioId] ON [Contrato] ([usuarioId]);
GO

CREATE INDEX [IX_Instrumento_usuarioId] ON [Instrumento] ([usuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230924132515_InitialCreate', N'7.0.11');
GO

COMMIT;
GO

