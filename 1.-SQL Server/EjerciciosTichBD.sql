USE [master]
GO
/****** Object:  Database [EjerciciosTich]    Script Date: 20/11/2024 12:35:07 p. m. ******/
CREATE DATABASE [EjerciciosTich]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EjerciciosTich', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EjerciciosTich.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EjerciciosTich_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EjerciciosTich_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EjerciciosTich] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EjerciciosTich].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EjerciciosTich] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EjerciciosTich] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EjerciciosTich] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EjerciciosTich] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EjerciciosTich] SET ARITHABORT OFF 
GO
ALTER DATABASE [EjerciciosTich] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EjerciciosTich] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EjerciciosTich] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EjerciciosTich] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EjerciciosTich] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EjerciciosTich] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EjerciciosTich] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EjerciciosTich] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EjerciciosTich] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EjerciciosTich] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EjerciciosTich] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EjerciciosTich] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EjerciciosTich] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EjerciciosTich] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EjerciciosTich] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EjerciciosTich] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EjerciciosTich] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EjerciciosTich] SET RECOVERY FULL 
GO
ALTER DATABASE [EjerciciosTich] SET  MULTI_USER 
GO
ALTER DATABASE [EjerciciosTich] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EjerciciosTich] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EjerciciosTich] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EjerciciosTich] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EjerciciosTich] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EjerciciosTich] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EjerciciosTich', N'ON'
GO
ALTER DATABASE [EjerciciosTich] SET QUERY_STORE = OFF
GO
USE [EjerciciosTich]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 20/11/2024 12:35:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](60) NOT NULL,
	[primerApellido] [nvarchar](50) NOT NULL,
	[segundoApellido] [nvarchar](50) NULL,
	[correo] [varchar](80) NOT NULL,
	[telefono] [nchar](10) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[curp] [char](18) NOT NULL,
	[sueldo] [decimal](9, 2) NULL,
	[idEstadoOrigen] [int] NOT NULL,
	[idEstatus] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlumnosBaja]    Script Date: 20/11/2024 12:35:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnosBaja](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](60) NOT NULL,
	[primerApellido] [nvarchar](50) NOT NULL,
	[segundoApellido] [nvarchar](50) NULL,
	[fechaBaja] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatCursos]    Script Date: 20/11/2024 12:35:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatCursos](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[clave] [nvarchar](15) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[descripcion] [nvarchar](1000) NULL,
	[horas] [tinyint] NOT NULL,
	[idPreRequisito] [smallint] NULL,
	[activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 20/11/2024 12:35:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idCatCurso] [smallint] NULL,
	[fechaInicio] [date] NULL,
	[fechaTermino] [date] NULL,
	[activo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursosAlumnos]    Script Date: 20/11/2024 12:35:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursosAlumnos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCurso] [smallint] NOT NULL,
	[idAlumno] [int] NOT NULL,
	[fechaInscripcion] [date] NOT NULL,
	[fechaBaja] [date] NULL,
	[calificacion] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursosInstructores]    Script Date: 20/11/2024 12:35:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursosInstructores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCurso] [smallint] NOT NULL,
	[idInstructor] [smallint] NULL,
	[fechaContratacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 20/11/2024 12:35:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstatusAlumnos]    Script Date: 20/11/2024 12:35:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstatusAlumnos](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[clave] [char](10) NOT NULL,
	[nombre] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructores]    Script Date: 20/11/2024 12:35:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructores](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](60) NOT NULL,
	[primerApellido] [nvarchar](50) NOT NULL,
	[segundoApellido] [nvarchar](50) NULL,
	[correo] [varchar](80) NOT NULL,
	[telefono] [nchar](10) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[rfc] [char](13) NOT NULL,
	[curp] [char](18) NOT NULL,
	[cuotaHora] [decimal](9, 2) NOT NULL,
	[activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [fk_Estado] FOREIGN KEY([idEstadoOrigen])
REFERENCES [dbo].[Estados] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [fk_Estado]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [fk_Estatus] FOREIGN KEY([idEstatus])
REFERENCES [dbo].[EstatusAlumnos] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [fk_Estatus]
GO
ALTER TABLE [dbo].[CatCursos]  WITH CHECK ADD  CONSTRAINT [fk_PreRequisito] FOREIGN KEY([idPreRequisito])
REFERENCES [dbo].[CatCursos] ([id])
GO
ALTER TABLE [dbo].[CatCursos] CHECK CONSTRAINT [fk_PreRequisito]
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [fk_CatCurso] FOREIGN KEY([idCatCurso])
REFERENCES [dbo].[CatCursos] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [fk_CatCurso]
GO
ALTER TABLE [dbo].[CursosAlumnos]  WITH CHECK ADD  CONSTRAINT [fk_Alumno] FOREIGN KEY([idAlumno])
REFERENCES [dbo].[Alumnos] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CursosAlumnos] CHECK CONSTRAINT [fk_Alumno]
GO
ALTER TABLE [dbo].[CursosAlumnos]  WITH CHECK ADD  CONSTRAINT [fk_Curso] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CursosAlumnos] CHECK CONSTRAINT [fk_Curso]
GO
ALTER TABLE [dbo].[CursosInstructores]  WITH CHECK ADD  CONSTRAINT [fk_Curso_CI] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CursosInstructores] CHECK CONSTRAINT [fk_Curso_CI]
GO
ALTER TABLE [dbo].[CursosInstructores]  WITH CHECK ADD  CONSTRAINT [fk_Instructor_CI] FOREIGN KEY([idInstructor])
REFERENCES [dbo].[Instructores] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CursosInstructores] CHECK CONSTRAINT [fk_Instructor_CI]
GO
USE [master]
GO
ALTER DATABASE [EjerciciosTich] SET  READ_WRITE 
GO
