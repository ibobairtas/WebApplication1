USE [master]
GO
/****** Object:  Database [DBMahasiswa]    Script Date: 17/07/2020 3:36:29 ******/
CREATE DATABASE [DBMahasiswa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBMahasiswa', FILENAME = N'D:\DBMahasiswa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBMahasiswa_log', FILENAME = N'D:\DBMahasiswa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DBMahasiswa] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBMahasiswa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBMahasiswa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBMahasiswa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBMahasiswa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBMahasiswa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBMahasiswa] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBMahasiswa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBMahasiswa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBMahasiswa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBMahasiswa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBMahasiswa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBMahasiswa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBMahasiswa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBMahasiswa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBMahasiswa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBMahasiswa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBMahasiswa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBMahasiswa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBMahasiswa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBMahasiswa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBMahasiswa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBMahasiswa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBMahasiswa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBMahasiswa] SET RECOVERY FULL 
GO
ALTER DATABASE [DBMahasiswa] SET  MULTI_USER 
GO
ALTER DATABASE [DBMahasiswa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBMahasiswa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBMahasiswa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBMahasiswa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBMahasiswa] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBMahasiswa', N'ON'
GO
ALTER DATABASE [DBMahasiswa] SET QUERY_STORE = OFF
GO
USE [DBMahasiswa]
GO
/****** Object:  Table [dbo].[tabel_mahasiswa]    Script Date: 17/07/2020 3:36:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tabel_mahasiswa](
	[id_mahasiswa] [int] NOT NULL,
	[nama_mahasiswa] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tabel_mahasiswa] PRIMARY KEY CLUSTERED 
(
	[id_mahasiswa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tabel_matakuliah]    Script Date: 17/07/2020 3:36:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tabel_matakuliah](
	[id_matakuliah] [int] NOT NULL,
	[nama_matakuliah] [varchar](255) NOT NULL,
 CONSTRAINT [PK_tabel_matakuliah] PRIMARY KEY CLUSTERED 
(
	[id_matakuliah] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tabel_nilai]    Script Date: 17/07/2020 3:36:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tabel_nilai](
	[id_nilai] [int] NOT NULL,
	[id_mahasiswa] [int] NOT NULL,
	[id_matakuliah] [int] NOT NULL,
	[nilai] [int] NOT NULL,
 CONSTRAINT [PK_tabel_nilai] PRIMARY KEY CLUSTERED 
(
	[id_nilai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tabel_nilai]  WITH CHECK ADD  CONSTRAINT [FK_tabel_nilai_tabel_mahasiswa] FOREIGN KEY([id_mahasiswa])
REFERENCES [dbo].[tabel_mahasiswa] ([id_mahasiswa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tabel_nilai] CHECK CONSTRAINT [FK_tabel_nilai_tabel_mahasiswa]
GO
ALTER TABLE [dbo].[tabel_nilai]  WITH CHECK ADD  CONSTRAINT [FK_tabel_nilai_tabel_matakuliah] FOREIGN KEY([id_matakuliah])
REFERENCES [dbo].[tabel_matakuliah] ([id_matakuliah])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tabel_nilai] CHECK CONSTRAINT [FK_tabel_nilai_tabel_matakuliah]
GO
USE [master]
GO
ALTER DATABASE [DBMahasiswa] SET  READ_WRITE 
GO
