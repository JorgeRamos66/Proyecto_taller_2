USE [master]
GO
/****** Object:  Database [Proyecto_Taller_2]    Script Date: 30/09/2024 23:49:23 ******/
CREATE DATABASE [Proyecto_Taller_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proyecto_Taller_2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Proyecto_Taller_2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Proyecto_Taller_2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Proyecto_Taller_2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Proyecto_Taller_2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Proyecto_Taller_2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Proyecto_Taller_2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Proyecto_Taller_2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Proyecto_Taller_2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Proyecto_Taller_2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Proyecto_Taller_2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Proyecto_Taller_2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Proyecto_Taller_2] SET  MULTI_USER 
GO
ALTER DATABASE [Proyecto_Taller_2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Proyecto_Taller_2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Proyecto_Taller_2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Proyecto_Taller_2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Proyecto_Taller_2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Proyecto_Taller_2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Proyecto_Taller_2] SET QUERY_STORE = ON
GO
ALTER DATABASE [Proyecto_Taller_2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Proyecto_Taller_2]
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre_categoria] [varchar](100) NOT NULL,
	[descripcion_categoria] [varchar](200) NULL,
	[estado_categoria] [int] NOT NULL,
 CONSTRAINT [PK_CATEGORIA] PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTE]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTE](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[id_persona] [int] NOT NULL,
	[id_nivel] [int] NOT NULL,
	[observaciones] [varchar](200) NULL,
 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC,
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOCALIDAD]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOCALIDAD](
	[id_localidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre_localidad] [varchar](100) NOT NULL,
	[id_provincia] [int] NOT NULL,
 CONSTRAINT [PK_LOCALIDAD] PRIMARY KEY CLUSTERED 
(
	[id_localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[METODO_PAGO]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[METODO_PAGO](
	[id_metodo] [int] IDENTITY(1,1) NOT NULL,
	[nombre_metodo] [varchar](100) NOT NULL,
	[descripcion_metodo] [varchar](200) NOT NULL,
 CONSTRAINT [PK_METODO_PAGO] PRIMARY KEY CLUSTERED 
(
	[id_metodo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NIVEL]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NIVEL](
	[id_nivel] [int] IDENTITY(1,1) NOT NULL,
	[descuento] [int] NOT NULL,
	[monto_total] [float] NOT NULL,
 CONSTRAINT [PK_NIVEL] PRIMARY KEY CLUSTERED 
(
	[id_nivel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERSONA]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSONA](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[nombre_persona] [varchar](100) NOT NULL,
	[apellido_persona] [varchar](100) NOT NULL,
	[dni] [int] NOT NULL,
	[email_persona] [varchar](100) NOT NULL,
	[direccion_persona] [varchar](200) NOT NULL,
	[id_localidad] [int] NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
 CONSTRAINT [PK_PERSONA] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_producto] [varchar](100) NOT NULL,
	[precio_producto] [float] NOT NULL,
	[descripcion_producto] [varchar](200) NULL,
	[stock_producto] [int] NOT NULL,
	[baja_producto] [int] NOT NULL,
	[id_categoria] [int] NOT NULL,
	[ruta_imagen] [varchar](255) NULL,
 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVINCIA]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVINCIA](
	[id_provincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre_provincia] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PROVINCIA] PRIMARY KEY CLUSTERED 
(
	[id_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre_rol] [varchar](100) NOT NULL,
	[descripcion_rol] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](100) NOT NULL,
	[pass] [varchar](100) NOT NULL,
	[baja_usuario] [int] NOT NULL,
	[id_persona] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC,
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTA_CABECERA]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTA_CABECERA](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[precio_total] [float] NOT NULL,
	[id_metodo] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_VENTA_CABECERA] PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VENTA_DETALLE]    Script Date: 30/09/2024 23:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VENTA_DETALLE](
	[cantidad] [int] IDENTITY(1,1) NOT NULL,
	[precio_subtotal] [float] NOT NULL,
	[id_producto] [int] NOT NULL,
	[id_venta] [int] NOT NULL,
 CONSTRAINT [PK_VENTA_DETALLE] PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC,
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CATEGORIA] ON 
GO
INSERT [dbo].[CATEGORIA] ([id_categoria], [nombre_categoria], [descripcion_categoria], [estado_categoria]) VALUES (1, N'Estaciones Totaless', N'Equipos de alta precisión para mediciones geodésicas y topográficas, esenciales en proyectos de ingeniería y construcción.', 1)
GO
INSERT [dbo].[CATEGORIA] ([id_categoria], [nombre_categoria], [descripcion_categoria], [estado_categoria]) VALUES (2, N'Niveles', N'Instrumentos para medir diferencias de altura y niveles en trabajos de nivelación y construcción, garantizando precisión en terrenos y estructuras.', 1)
GO
INSERT [dbo].[CATEGORIA] ([id_categoria], [nombre_categoria], [descripcion_categoria], [estado_categoria]) VALUES (3, N'GPS', N'Sistemas de posicionamiento global utilizados para navegación y seguimiento, ofreciendo datos de localización precisa en tiempo real.', 1)
GO
INSERT [dbo].[CATEGORIA] ([id_categoria], [nombre_categoria], [descripcion_categoria], [estado_categoria]) VALUES (4, N'Drones', N'Dispositivos aéreos no tripulados para capturas aéreas, inspecciones y mapeo, útiles en agricultura, cinematografía y monitoreo ambiental.', 1)
GO
INSERT [dbo].[CATEGORIA] ([id_categoria], [nombre_categoria], [descripcion_categoria], [estado_categoria]) VALUES (5, N'Otros', N'Categoría que abarca diversos productos relacionados con tecnología de medición y geoespacial que no se incluyen en las categorías principales.', 1)
GO
INSERT [dbo].[CATEGORIA] ([id_categoria], [nombre_categoria], [descripcion_categoria], [estado_categoria]) VALUES (6, N'Instrumentos', N'Instrumentos varios de campo, por lo general pequeños.', 1)
GO
SET IDENTITY_INSERT [dbo].[CATEGORIA] OFF
GO
SET IDENTITY_INSERT [dbo].[LOCALIDAD] ON 
GO
INSERT [dbo].[LOCALIDAD] ([id_localidad], [nombre_localidad], [id_provincia]) VALUES (11, N'La Plata', 13)
GO
INSERT [dbo].[LOCALIDAD] ([id_localidad], [nombre_localidad], [id_provincia]) VALUES (12, N'Córdoba', 14)
GO
INSERT [dbo].[LOCALIDAD] ([id_localidad], [nombre_localidad], [id_provincia]) VALUES (13, N'Rosario', 15)
GO
INSERT [dbo].[LOCALIDAD] ([id_localidad], [nombre_localidad], [id_provincia]) VALUES (14, N'Mar del Plata', 13)
GO
INSERT [dbo].[LOCALIDAD] ([id_localidad], [nombre_localidad], [id_provincia]) VALUES (15, N'Villa Carlos Paz', 14)
GO
INSERT [dbo].[LOCALIDAD] ([id_localidad], [nombre_localidad], [id_provincia]) VALUES (16, N'Santa Fe', 15)
GO
INSERT [dbo].[LOCALIDAD] ([id_localidad], [nombre_localidad], [id_provincia]) VALUES (17, N'Corrientes Capital', 16)
GO
SET IDENTITY_INSERT [dbo].[LOCALIDAD] OFF
GO
SET IDENTITY_INSERT [dbo].[PERSONA] ON 
GO
INSERT [dbo].[PERSONA] ([id_persona], [nombre_persona], [apellido_persona], [dni], [email_persona], [direccion_persona], [id_localidad], [fecha_nacimiento]) VALUES (11, N'Jorge', N'Ramos', 30111222, N'jorge.ramos@email.com', N'Calle Falsa 123', 16, CAST(N'1999-08-31' AS Date))
GO
INSERT [dbo].[PERSONA] ([id_persona], [nombre_persona], [apellido_persona], [dni], [email_persona], [direccion_persona], [id_localidad], [fecha_nacimiento]) VALUES (12, N'Juan', N'Pérez', 30111222, N'juan.perez@email.com', N'Calle Falsa 123', 14, CAST(N'1985-05-12' AS Date))
GO
INSERT [dbo].[PERSONA] ([id_persona], [nombre_persona], [apellido_persona], [dni], [email_persona], [direccion_persona], [id_localidad], [fecha_nacimiento]) VALUES (13, N'María', N'Gómez', 32455678, N'maria.gomez@email.com', N'Avenida Siempre Viva 742', 15, CAST(N'1990-03-22' AS Date))
GO
INSERT [dbo].[PERSONA] ([id_persona], [nombre_persona], [apellido_persona], [dni], [email_persona], [direccion_persona], [id_localidad], [fecha_nacimiento]) VALUES (14, N'Carlos', N'Rodríguez', 29877445, N'carlos.rodriguez@email.com', N'Calle Luna 555', 13, CAST(N'1982-11-15' AS Date))
GO
INSERT [dbo].[PERSONA] ([id_persona], [nombre_persona], [apellido_persona], [dni], [email_persona], [direccion_persona], [id_localidad], [fecha_nacimiento]) VALUES (15, N'Lucía', N'Martínez', 31566543, N'lucia.martinez@email.com', N'Calle Sol 123', 14, CAST(N'1995-07-30' AS Date))
GO
INSERT [dbo].[PERSONA] ([id_persona], [nombre_persona], [apellido_persona], [dni], [email_persona], [direccion_persona], [id_localidad], [fecha_nacimiento]) VALUES (16, N'Ana', N'Fernández', 27888999, N'ana.fernandez@email.com', N'Calle Estrella 789', 15, CAST(N'1988-09-10' AS Date))
GO
INSERT [dbo].[PERSONA] ([id_persona], [nombre_persona], [apellido_persona], [dni], [email_persona], [direccion_persona], [id_localidad], [fecha_nacimiento]) VALUES (17, N'Pedro', N'García', 30123456, N'pedro.garcia@email.com', N'Calle Río 456', 16, CAST(N'1979-01-25' AS Date))
GO
SET IDENTITY_INSERT [dbo].[PERSONA] OFF
GO
SET IDENTITY_INSERT [dbo].[PRODUCTO] ON 
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (31, N'Laptop HPp', 1200.5, N'Laptop HP 15 pulgadas', 50, 0, 1, N'Resources\imagenes_productos\dd7a016f-7e4e-4f7c-836a-4eecec0cfbae.jpeg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (32, N'Mouse Logitech', 25.99, N'Mouse inalámbrico Logitech de alta calidad y con unas de las mejores prestaciones en cuanto a sensor', 150, 1, 4, N'Resources\imagenes_productos\ff348782-8f37-4631-a8fe-6371f75622d3.png')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (33, N'Teclado Mecánico', 80, N'Teclado mecánico retroiluminado', 75, 1, 5, N'Resources\imagenes_productos\ecaf0bfd-be4f-4dce-8b8a-b480b3500ff4.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (34, N'Monitor Samsung', 300, N'Monitor Samsung 24 pulgadas', 35, 0, 3, N'imagenes/monitor_samsung.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (35, N'Impresora Epson', 150, N'Impresora multifuncional Epson', 20, 1, 4, N'imagenes/impresora_epson.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (36, N'Disco Duro Externo', 60, N'Disco duro externo 1TB', 100, 1, 5, N'imagenes/disco_duro_externo.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (37, N'Auriculares Sony', 45.5, N'Auriculares con micrófono Sony', 85, 1, 2, N'imagenes/auriculares_sony.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (38, N'Tablet Lenovo', 350, N'Tablet Lenovo 10 pulgadas', 40, 1, 3, N'imagenes/tablet_lenovo.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (39, N'Silla Gamer', 220, N'Silla ergonómica para gamers', 10, 1, 2, N'imagenes/silla_gamer.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (40, N'Smartphone Xiaomi', 400, N'Smartphone Xiaomi Redmi Note 10', 60, 1, 1, N'imagenes/smartphone_xiaomi.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (41, N'test', 233, N'dron', 3, 0, 4, N'Resources\imagenes_productos\33ce5374-8d92-4732-b9ba-a539bdf25ee5.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (42, N'Laptop HP', 1200.5, N'Laptop HP 15 pulgadas', 50, 1, 1, N'imagenes/laptop_hp.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (43, N'Mouse Logitech', 25.99, N'Mouse inalámbrico Logitech', 150, 1, 2, N'imagenes/mouse_logitech.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (44, N'Teclado Mecánico', 80, N'Teclado mecánico retroiluminado', 75, 1, 2, N'imagenes/teclado_mecanico.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (45, N'Monitor Samsung', 300, N'Monitor Samsung 24 pulgadas', 35, 1, 3, N'imagenes/monitor_samsung.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (46, N'Impresora Epson', 150, N'Impresora multifuncional Epson', 20, 1, 4, N'imagenes/impresora_epson.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (47, N'Disco Duro Externo', 60, N'Disco duro externo 1TB', 100, 1, 5, N'imagenes/disco_duro_externo.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (48, N'Auriculares Sony', 45.5, N'Auriculares con micrófono Sony', 85, 1, 2, N'imagenes/auriculares_sony.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (49, N'Tablet Lenovo', 350, N'Tablet Lenovo 10 pulgadas', 40, 1, 3, N'imagenes/tablet_lenovo.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (50, N'Silla Gamer', 220, N'Silla ergonómica para gamers', 10, 1, 2, N'imagenes/silla_gamer.jpg')
GO
INSERT [dbo].[PRODUCTO] ([id_producto], [nombre_producto], [precio_producto], [descripcion_producto], [stock_producto], [baja_producto], [id_categoria], [ruta_imagen]) VALUES (51, N'Smartphone Xiaomi', 400, N'Smartphone Xiaomi Redmi Note 10', 60, 1, 1, N'imagenes/smartphone_xiaomi.jpg')
GO
SET IDENTITY_INSERT [dbo].[PRODUCTO] OFF
GO
SET IDENTITY_INSERT [dbo].[PROVINCIA] ON 
GO
INSERT [dbo].[PROVINCIA] ([id_provincia], [nombre_provincia]) VALUES (13, N'Buenos Aires')
GO
INSERT [dbo].[PROVINCIA] ([id_provincia], [nombre_provincia]) VALUES (14, N'Córdoba')
GO
INSERT [dbo].[PROVINCIA] ([id_provincia], [nombre_provincia]) VALUES (15, N'Santa Fe')
GO
INSERT [dbo].[PROVINCIA] ([id_provincia], [nombre_provincia]) VALUES (16, N'Corrientes')
GO
SET IDENTITY_INSERT [dbo].[PROVINCIA] OFF
GO
SET IDENTITY_INSERT [dbo].[ROL] ON 
GO
INSERT [dbo].[ROL] ([id_rol], [nombre_rol], [descripcion_rol]) VALUES (1, N'admin', N'usuario de tipo admin')
GO
INSERT [dbo].[ROL] ([id_rol], [nombre_rol], [descripcion_rol]) VALUES (2, N'vendedor', N'usuario que realiza ventas')
GO
INSERT [dbo].[ROL] ([id_rol], [nombre_rol], [descripcion_rol]) VALUES (3, N'gerente', N'usuario con permisos de gerencia')
GO
SET IDENTITY_INSERT [dbo].[ROL] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIO] ON 
GO
INSERT [dbo].[USUARIO] ([id_usuario], [usuario], [pass], [baja_usuario], [id_persona], [id_rol]) VALUES (16, N'jorgeramos', N'ramos', 1, 11, 2)
GO
INSERT [dbo].[USUARIO] ([id_usuario], [usuario], [pass], [baja_usuario], [id_persona], [id_rol]) VALUES (17, N'jperez', N'password123', 1, 12, 1)
GO
INSERT [dbo].[USUARIO] ([id_usuario], [usuario], [pass], [baja_usuario], [id_persona], [id_rol]) VALUES (18, N'mgomez', N'password123', 0, 13, 2)
GO
INSERT [dbo].[USUARIO] ([id_usuario], [usuario], [pass], [baja_usuario], [id_persona], [id_rol]) VALUES (19, N'crodriguez', N'password123', 1, 14, 2)
GO
INSERT [dbo].[USUARIO] ([id_usuario], [usuario], [pass], [baja_usuario], [id_persona], [id_rol]) VALUES (20, N'lmartinez', N'password123', 1, 15, 3)
GO
INSERT [dbo].[USUARIO] ([id_usuario], [usuario], [pass], [baja_usuario], [id_persona], [id_rol]) VALUES (21, N'afernandez', N'password123', 1, 16, 2)
GO
INSERT [dbo].[USUARIO] ([id_usuario], [usuario], [pass], [baja_usuario], [id_persona], [id_rol]) VALUES (22, N'pgarcia', N'password123', 1, 17, 1)
GO
SET IDENTITY_INSERT [dbo].[USUARIO] OFF
GO
ALTER TABLE [dbo].[CATEGORIA] ADD  CONSTRAINT [DF_estado_categoria]  DEFAULT ((1)) FOR [estado_categoria]
GO
ALTER TABLE [dbo].[PRODUCTO] ADD  CONSTRAINT [DF_baja_producto]  DEFAULT ((0)) FOR [baja_producto]
GO
ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF_baja_usuario]  DEFAULT ((1)) FOR [baja_usuario]
GO
ALTER TABLE [dbo].[CLIENTE]  WITH CHECK ADD  CONSTRAINT [FK_CLIENTE_NIVEL] FOREIGN KEY([id_nivel])
REFERENCES [dbo].[NIVEL] ([id_nivel])
GO
ALTER TABLE [dbo].[CLIENTE] CHECK CONSTRAINT [FK_CLIENTE_NIVEL]
GO
ALTER TABLE [dbo].[LOCALIDAD]  WITH CHECK ADD  CONSTRAINT [FK_LOCALIDAD_PROVINCIA] FOREIGN KEY([id_provincia])
REFERENCES [dbo].[PROVINCIA] ([id_provincia])
GO
ALTER TABLE [dbo].[LOCALIDAD] CHECK CONSTRAINT [FK_LOCALIDAD_PROVINCIA]
GO
ALTER TABLE [dbo].[PERSONA]  WITH CHECK ADD  CONSTRAINT [FK_PERSONA_LOCALIDAD] FOREIGN KEY([id_localidad])
REFERENCES [dbo].[LOCALIDAD] ([id_localidad])
GO
ALTER TABLE [dbo].[PERSONA] CHECK CONSTRAINT [FK_PERSONA_LOCALIDAD]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_CATEGORIA] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[CATEGORIA] ([id_categoria])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_CATEGORIA]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_ROL] FOREIGN KEY([id_rol])
REFERENCES [dbo].[ROL] ([id_rol])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [FK_USUARIO_ROL]
GO
ALTER TABLE [dbo].[VENTA_CABECERA]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_CABECERA_METODO_PAGO] FOREIGN KEY([id_metodo])
REFERENCES [dbo].[METODO_PAGO] ([id_metodo])
GO
ALTER TABLE [dbo].[VENTA_CABECERA] CHECK CONSTRAINT [FK_VENTA_CABECERA_METODO_PAGO]
GO
ALTER TABLE [dbo].[VENTA_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_DETALLE_PRODUCTO] FOREIGN KEY([id_producto])
REFERENCES [dbo].[PRODUCTO] ([id_producto])
GO
ALTER TABLE [dbo].[VENTA_DETALLE] CHECK CONSTRAINT [FK_VENTA_DETALLE_PRODUCTO]
GO
ALTER TABLE [dbo].[VENTA_DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_VENTA_DETALLE_VENTA_CABECERA] FOREIGN KEY([id_venta])
REFERENCES [dbo].[VENTA_CABECERA] ([id_venta])
GO
ALTER TABLE [dbo].[VENTA_DETALLE] CHECK CONSTRAINT [FK_VENTA_DETALLE_VENTA_CABECERA]
GO
USE [master]
GO
ALTER DATABASE [Proyecto_Taller_2] SET  READ_WRITE 
GO
