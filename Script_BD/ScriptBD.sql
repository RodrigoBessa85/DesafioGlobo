--==================================================
--============== Script de Criação =================
--==================================================

USE [master]
GO

/****** Object:  Database [EmissoraGLOBO]    Script Date: 22/01/2019 22:22:23 ******/
CREATE DATABASE [EmissoraGLOBO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmissoraGLOBO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmissoraGLOBO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmissoraGLOBO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EmissoraGLOBO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [EmissoraGLOBO] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmissoraGLOBO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EmissoraGLOBO] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET ARITHABORT OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [EmissoraGLOBO] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EmissoraGLOBO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EmissoraGLOBO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET  ENABLE_BROKER 
GO

ALTER DATABASE [EmissoraGLOBO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EmissoraGLOBO] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EmissoraGLOBO] SET  MULTI_USER 
GO

ALTER DATABASE [EmissoraGLOBO] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EmissoraGLOBO] SET DB_CHAINING OFF 
GO

ALTER DATABASE [EmissoraGLOBO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EmissoraGLOBO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [EmissoraGLOBO] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [EmissoraGLOBO] SET QUERY_STORE = OFF
GO

ALTER DATABASE [EmissoraGLOBO] SET  READ_WRITE 
GO

--==============================================
--============== CREATE TABLES =================
--==============================================

CREATE TABLE [dbo].[Emissora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Emissora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Audiencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pontos_audiencia] [float] NOT NULL,
	[Data_hora_audiencia] [datetime] NULL,
	[Emissora_audiencia] [int] NOT NULL,
 CONSTRAINT [PK_Audiencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


--========================================
--============== Incluir =================
--========================================

CREATE PROCEDURE [dbo].[Emissora_Incluir]
	@Nome VARCHAR(100) = NULL
AS
BEGIN
	INSERT INTO Emissora
	( 
		Nome
	)
	VALUES(
		@Nome
	)

	SELECT
        Id, Nome
	FROM Emissora
	WHERE Id = CONVERT(INT,SCOPE_IDENTITY())
END


--========================================
--============== EXCLUIR =================
--========================================

CREATE PROCEDURE [dbo].[Emissora_Excluir]
	@Id int
AS
BEGIN

	DELETE FROM Emissora
	WHERE Id = @Id
	

END

--========================================
--============== ALTERAR =================
--========================================

CREATE PROCEDURE [dbo].[Emissora_Alterar]
	@Id Int,
	@Nome VARCHAR(100) = NULL
AS
BEGIN
	UPDATE Emissora
	set
		Nome = @Nome
		WHERE Id = @Id
	
	SELECT
	    Id,
        Nome
	FROM Emissora
	WHERE Id = @Id
END

--========================================
--============== LISTAR =================
--========================================


CREATE PROCEDURE [dbo].[Emissora_Listar]
	@Id int = NULL,
    @Nome varchar(255) = NULL
AS
BEGIN

	SELECT 
		Id, Nome
	FROM Emissora
	WHERE Id = ISNULL(@Id, Id) AND 
	      Nome = ISNULL(@Nome, Nome)
END

--==========================================================================================================
--==========================================================================================================

--========================================
--============== Incluir =================
--========================================

CREATE PROCEDURE [dbo].[Audiencia_Incluir]
    @Pontos_audiencia float, 
    @Data_hora_audiencia Datetime = NULL,
    @Emissora_audiencia int = NULL
AS
BEGIN
	INSERT INTO Audiencia
	( 
		Pontos_audiencia,
		Data_hora_audiencia,
		Emissora_audiencia
	)
	VALUES(
		@Pontos_audiencia, 
		@Data_hora_audiencia,
		@Emissora_audiencia
	)

	SELECT
        Id, Pontos_audiencia, Data_hora_audiencia, Emissora_audiencia
	FROM Audiencia
	WHERE Id = CONVERT(INT,SCOPE_IDENTITY())
END

--========================================
--============== EXCLUIR =================
--========================================

CREATE PROCEDURE [dbo].[Audiencia_Excluir]
	@Id int
AS
BEGIN

	DELETE FROM Audiencia
	WHERE Id = @Id

END


--========================================
--============== ALTERAR =================
--========================================

CREATE PROCEDURE [dbo].[Audiencia_Alterar]
	@Id Int,
    @Pontos_audiencia float, 
    @Data_hora_audiencia Datetime = NULL,
    @Emissora_audiencia int = NULL
AS
BEGIN
	UPDATE Audiencia
	set
		Pontos_audiencia = @Pontos_audiencia,
		Data_hora_audiencia = @Data_hora_audiencia,
		Emissora_audiencia = @Emissora_audiencia 
		WHERE Id = @Id
	
	SELECT
	     Id, Pontos_audiencia, Data_hora_audiencia, Emissora_audiencia
	FROM Audiencia
	WHERE Id = @Id
END


--========================================
--============== LISTAR =================
--========================================

CREATE PROCEDURE [dbo].[Audiencia_Listar]
	@Id int = NULL,
    @Pontos_audiencia float, 
    @Data_hora_audiencia Datetime = NULL,
    @Emissora_audiencia int = NULL
AS
BEGIN

	SELECT 
		Id, Pontos_audiencia, Data_hora_audiencia, Emissora_audiencia
	FROM Audiencia
	WHERE Id = ISNULL(@Id, Id) AND 
	      Pontos_audiencia = ISNULL(@Pontos_audiencia, Pontos_audiencia) AND 
		  Data_hora_audiencia = ISNULL(@Data_hora_audiencia, Data_hora_audiencia) AND 
		  Emissora_audiencia = ISNULL(@Emissora_audiencia, Emissora_audiencia)
END

--=================================================
--============== LISTAR Emissoras =================
--=================================================

CREATE PROCEDURE [dbo].[Audiencia_ListarComboEmissora]
	@Id int = NULL,
    @Nome varchar(255) = NULL
AS
BEGIN

	SELECT 
		 Id, Nome
	FROM Emissora	
	ORDER BY Id
END





