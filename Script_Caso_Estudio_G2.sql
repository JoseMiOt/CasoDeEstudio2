USE [master]
GO
/****** Object:  Database [CasoEstudioJN]    Script Date: 18/8/2023 00:59:22 ******/
CREATE DATABASE [CasoEstudioJN]
GO

USE [CasoEstudioJN]
GO
/****** Object:  Table [dbo].[CasasSistema]    Script Date: 18/8/2023 00:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CasasSistema](
	[IdCasa] [bigint] IDENTITY(1,1) NOT NULL,
	[DescripcionCasa] [varchar](30) NOT NULL,
	[PrecioCasa] [decimal](10, 2) NOT NULL,
	[UsuarioAlquiler] [varchar](30) NULL,
	[FechaAlquiler] [datetime] NULL,
 CONSTRAINT [PK_CasasSistema] PRIMARY KEY CLUSTERED 
(
	[IdCasa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en San Jose',190000,null,null)

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Alajuela',145000,null,null)

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Cartago',115000,null,null)

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Heredia',122000,null,null)

INSERT INTO [dbo].[CasasSistema] ([DescripcionCasa],[PrecioCasa],[UsuarioAlquiler],[FechaAlquiler])
VALUES ('Casa en Guanacaste',105000,null,null)
GO
------------------------------
--Procedimientos Almacenados
------------------------------
CREATE OR ALTER PROCEDURE ConsultaCasas
AS
BEGIN
    SELECT
        DescripcionCasa AS Descripcion,
        PrecioCasa AS Precio,
        ISNULL(UsuarioAlquiler, 'Disponible') AS Usuario,
        CASE
            WHEN UsuarioAlquiler IS NULL THEN 'Disponible'
            ELSE 'Reservada'
        END AS Estado,
        FechaAlquiler AS Fecha
    FROM CasasSistema
    WHERE PrecioCasa BETWEEN 115000 AND 180000
    ORDER BY Estado;
END;
GO
------------------------------------------------------------------
CREATE OR ALTER PROCEDURE AlquilaCasas
    @IdCasa bigint,
    @Usuario varchar(30)
AS
BEGIN
    UPDATE CasasSistema
    SET UsuarioAlquiler = @Usuario,
        FechaAlquiler = GETDATE()
    WHERE IdCasa = @IdCasa;
END;
GO
------------------------------------------------------------------
CREATE OR ALTER PROCEDURE ConsultaCasasDisponibles
AS
BEGIN
    SELECT
		IdCasa,
        DescripcionCasa AS Descripcion,
		PrecioCasa AS Precio
    FROM CasasSistema
    WHERE UsuarioAlquiler IS NULL;
    
END;
GO

