if exists ( select * from SYS.databases where name='QuanLyQuanCafe')
drop database QuanLyQuanCafe
go
create database QuanLyQuanCafe
go
USE [QuanLyQuanCafe]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[CCCD_Num] [nvarchar](20) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Sex] [nvarchar](10) NULL,
	[Address] [nvarchar](255) NULL,
	[Role] [nvarchar](50) NULL,
	[Account] [nvarchar](50) NULL,
	[Password] [nvarchar](1000) NULL,
	[Status] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableID] [int] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[DateCheckin] [datetime] NOT NULL,
	[DateCheckout] [datetime] NULL,
	[AccountID] [int] NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BillID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableList]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Status] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (34, N'Trần Ngọc Minh', N'062738927987', N'0337828173', N'Nam', N'Gia Lai', N'Admin', N'admin', N'B6589FC6AB0DC82CF12099D1C2D40AB994E8410C', N'Hoạt động')
INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (37, N'Trần Văn A', N'12345678977868', N'01234567898789', N'Nam', N'123 Đường Lê Lợi, Quận 1, TP.HCM', N'Member', N'admin123', N'B6589FC6AB0DC82CF12099D1C2D40AB994E8410C', N'Hoạt động')
INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (40, N'Đặng Thị D', N'12123789456123', N'21320932145786', N'Nữ', N'101 Đường Hai Bà Trưng, Quận 1, TP.HCM', N'Admin', N'jackbocon1', N'B6589FC6AB0DC82CF12099D1C2D40AB994E8410C', N'Hoạt động')
INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (44, N'Trịnh Trần Phương Tuấn', N'012381238283828', N'021312312939132', N'Nam', N'Bến Tre', N'Member', N'j97', N'B6589FC6AB0DC82CF12099D1C2D40AB994E8410C', N'Hoạt động')
INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (45, N'Hà Anh Tuấn', N'1239131231312', N'092838282832', N'Nam', N'Hà Nội', N'Admin', N'hatuan', N'B6589FC6AB0DC82CF12099D1C2D40AB994E8410C', N'Hoạt động')
INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (46, N'Trần Ngọc Minh', N'012383829322', N'0382838291', N'Nam', N'Dak Lak', N'Admin', N'minh', N'B6589FC6AB0DC82CF12099D1C2D40AB994E8410C', N'Hoạt động')
INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (47, N'Hà Nam', N'23123131231231321', N'123132131231321', N'Nam', N'KNak', N'Member', N'hanam1', N'12C6FC06C99A462375EEB3F43DFD832B08CA9E17', N'Hoạt động')
INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (48, N'Tuấn Ninh', N'123123132112313213', N'123123123132131', N'Nam', N'DAK', N'Member', N'tuanninh', N'8CB2237D0679CA88DB6464EAC60DA96345513964', N'Hoạt động')
INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (49, N'cô gái m52 - Ðã xoá', N'1241412412412', N'23123123123', N'Nam', N'HAHA', N'Member', N'adawd', N'D9B9D1CB329EAFC8912C3CEEFC017F10F7256C6D', N'Đã nghỉ')
INSERT [dbo].[Account] ([ID], [Name], [CCCD_Num], [PhoneNumber], [Sex], [Address], [Role], [Account], [Password], [Status]) VALUES (50, N'Xuân Tuyết', N'1213123123123', N'123123131312312', N'Nữ', N'Bình Dương', N'Member', N'tuyet', N'484C73CB14285116E9CF842DE22017CF8CD98414', N'Hoạt động')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (11, 1, CAST(86000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(N'2024-05-15T18:44:07.947' AS DateTime), CAST(N'2024-05-15T21:03:49.677' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (13, 2, CAST(25000.00 AS Decimal(18, 2)), CAST(5000.00 AS Decimal(18, 2)), CAST(N'2024-05-15T21:23:50.320' AS DateTime), CAST(N'2024-05-15T21:23:59.353' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (14, 5, CAST(100000.00 AS Decimal(18, 2)), CAST(43000.00 AS Decimal(18, 2)), CAST(N'2024-05-15T21:25:03.180' AS DateTime), CAST(N'2024-05-15T22:01:03.027' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (15, 3, CAST(36000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-15T21:28:33.737' AS DateTime), CAST(N'2024-05-15T21:31:37.363' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (16, 2, CAST(73778.00 AS Decimal(18, 2)), CAST(1222.00 AS Decimal(18, 2)), CAST(N'2024-05-15T22:01:42.687' AS DateTime), CAST(N'2024-05-15T22:01:49.747' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (17, 3, CAST(123000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T09:12:21.230' AS DateTime), CAST(N'2024-05-16T09:12:41.373' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (18, 11, CAST(44000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T09:12:32.467' AS DateTime), CAST(N'2024-05-16T09:12:36.557' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (19, 4, CAST(90000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-05-16T09:12:46.460' AS DateTime), CAST(N'2024-05-16T09:12:54.653' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (20, 16, CAST(70000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T09:13:02.197' AS DateTime), CAST(N'2024-05-16T09:13:10.907' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (21, 5, CAST(45000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T09:20:32.330' AS DateTime), CAST(N'2024-05-16T09:20:36.003' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (22, 16, CAST(90000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T09:20:39.297' AS DateTime), CAST(N'2024-05-16T09:24:43.027' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (23, 8, CAST(105000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T10:28:40.023' AS DateTime), CAST(N'2024-05-16T10:28:53.533' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (24, 6, CAST(75000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T10:29:10.863' AS DateTime), CAST(N'2024-05-16T10:29:15.500' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (25, 6, CAST(125000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-02-16T10:46:57.670' AS DateTime), CAST(N'2024-02-16T10:47:11.100' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (26, 6, CAST(63000.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), CAST(N'2024-02-16T10:47:14.233' AS DateTime), CAST(N'2024-02-16T10:47:28.747' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (27, 11, CAST(42000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-02-16T10:47:33.890' AS DateTime), CAST(N'2024-02-16T10:47:36.877' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (28, 5, CAST(45000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-10-16T10:49:25.440' AS DateTime), CAST(N'2024-10-16T10:49:44.467' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (29, 11, CAST(45000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-10-16T10:49:36.723' AS DateTime), CAST(N'2024-10-16T10:49:40.243' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (30, 6, CAST(120000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-10-16T10:50:08.650' AS DateTime), CAST(N'2024-10-16T10:50:19.567' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (31, 6, CAST(105000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-10-16T10:50:38.830' AS DateTime), CAST(N'2024-10-16T10:50:42.827' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (32, 11, CAST(54000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-10-16T10:50:47.483' AS DateTime), CAST(N'2024-10-16T10:50:49.717' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (33, 5, CAST(183000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T11:45:05.660' AS DateTime), CAST(N'2024-05-16T16:32:44.073' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (34, 19, CAST(56000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), CAST(N'2024-05-16T15:01:40.007' AS DateTime), CAST(N'2024-05-16T15:01:50.170' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (35, 20, CAST(32688.00 AS Decimal(18, 2)), CAST(12312.00 AS Decimal(18, 2)), CAST(N'2024-05-16T15:17:12.100' AS DateTime), CAST(N'2024-05-16T15:17:22.747' AS DateTime), 34, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (36, 2, CAST(60000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T21:07:03.530' AS DateTime), CAST(N'2024-05-16T21:07:05.957' AS DateTime), 48, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (37, 8, CAST(84000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T21:07:08.703' AS DateTime), CAST(N'2024-05-16T21:07:16.830' AS DateTime), 48, 1)
INSERT [dbo].[Bill] ([ID], [TableID], [TotalPrice], [Discount], [DateCheckin], [DateCheckout], [AccountID], [Status]) VALUES (38, 6, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-05-16T21:10:12.970' AS DateTime), CAST(N'2024-05-16T21:10:12.970' AS DateTime), 48, 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (27, 11, 16, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (28, 11, 5, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (29, 11, 7, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (30, 11, 3, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (39, 13, 11, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (40, 14, 17, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (41, 15, 13, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (43, 14, 24, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (44, 14, 26, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (45, 16, 23, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (46, 17, 6, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (47, 17, 26, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (48, 18, 22, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (49, 19, 25, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (50, 20, 25, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (51, 20, 29, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (52, 21, 17, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (53, 22, 17, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (54, 22, 30, 5)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (55, 23, 2, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (56, 23, 1, 1)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (57, 23, 21, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (58, 23, 12, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (59, 24, 20, 5)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (60, 25, 14, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (61, 25, 26, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (62, 25, 11, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (63, 26, 10, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (64, 26, 3, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (65, 27, 5, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (66, 28, 19, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (67, 29, 16, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (68, 30, 8, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (69, 30, 9, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (70, 30, 11, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (71, 31, 15, 7)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (72, 32, 13, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (73, 33, 5, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (74, 33, 14, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (75, 34, 5, 3)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (76, 34, 6, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (77, 35, 14, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (78, 33, 24, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (79, 36, 14, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (80, 37, 14, 4)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (81, 37, 6, 2)
INSERT [dbo].[BillInfo] ([ID], [BillID], [FoodID], [Quantity]) VALUES (82, 38, 1, 1)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Description], [CreatedDate]) VALUES (1, N'Cà phê ', N'Coffee', CAST(N'2024-05-04T10:30:03.000' AS DateTime))
INSERT [dbo].[Category] ([ID], [Name], [Description], [CreatedDate]) VALUES (2, N'Nước ép', N'hihi', CAST(N'2024-05-04T10:34:58.000' AS DateTime))
INSERT [dbo].[Category] ([ID], [Name], [Description], [CreatedDate]) VALUES (3, N'Nước ngọt', N'Đã quá pepsi ơi', CAST(N'2024-05-04T21:12:32.000' AS DateTime))
INSERT [dbo].[Category] ([ID], [Name], [Description], [CreatedDate]) VALUES (4, N'Trà', N'Dịuuuu', CAST(N'2024-05-05T10:33:12.000' AS DateTime))
INSERT [dbo].[Category] ([ID], [Name], [Description], [CreatedDate]) VALUES (5, N'Sữa chua', N'Nhà làm', CAST(N'2024-05-05T10:41:43.000' AS DateTime))
INSERT [dbo].[Category] ([ID], [Name], [Description], [CreatedDate]) VALUES (6, N'Kem mát', N'Icream', CAST(N'2024-05-05T21:00:20.000' AS DateTime))
INSERT [dbo].[Category] ([ID], [Name], [Description], [CreatedDate]) VALUES (7, N'Sinh tố', N'Smoothie', CAST(N'2024-05-05T21:32:30.000' AS DateTime))
INSERT [dbo].[Category] ([ID], [Name], [Description], [CreatedDate]) VALUES (8, N'Trà sữa', N'', CAST(N'2024-05-15T16:54:11.000' AS DateTime))
INSERT [dbo].[Category] ([ID], [Name], [Description], [CreatedDate]) VALUES (10, N'Đã xoá', N'Các món ăn, danh mục đã xoá sẽ lưu tại đây', CAST(N'2024-05-16T13:33:45.193' AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (1, N'Trà đào', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 4, CAST(N'2024-05-05T10:35:17.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (2, N'Trà đào cam sả', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 4, CAST(N'2024-05-05T10:35:35.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (3, N'Pepsi', N'Đã quá pepsi ơi', N'Còn ', CAST(12000.00 AS Decimal(18, 2)), 3, CAST(N'2024-05-05T10:41:47.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (4, N'Coca cola', N'', N'Còn ', CAST(12000.00 AS Decimal(18, 2)), 3, CAST(N'2024-05-05T10:42:22.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (5, N'Redbull', N'', N'Còn ', CAST(14000.00 AS Decimal(18, 2)), 3, CAST(N'2024-05-05T10:42:35.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (6, N'Sting vàng/dâu', N'', N'Còn ', CAST(12000.00 AS Decimal(18, 2)), 3, CAST(N'2024-05-05T10:43:18.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (7, N'Nước suối (Aquafina)', N'', N'Còn ', CAST(6000.00 AS Decimal(18, 2)), 3, CAST(N'2024-05-05T10:43:35.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (8, N'Cà phê sữa đá/nóng', N'', N'Còn ', CAST(12000.00 AS Decimal(18, 2)), 1, CAST(N'2024-05-05T10:44:00.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (9, N'Cà phê đen đá', N'', N'Còn ', CAST(12000.00 AS Decimal(18, 2)), 1, CAST(N'2024-05-05T10:44:37.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (10, N'Cà phê sữa SG', N'', N'Còn ', CAST(17000.00 AS Decimal(18, 2)), 1, CAST(N'2024-05-05T10:44:56.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (11, N'Bạc xỉu đá', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 1, CAST(N'2024-05-05T10:45:19.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (12, N'Nước chanh tươi', N'', N'Còn ', CAST(12000.00 AS Decimal(18, 2)), 2, CAST(N'2024-05-05T10:46:20.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (13, N'Nước cam nguyên chất', N'', N'Còn ', CAST(18000.00 AS Decimal(18, 2)), 2, CAST(N'2024-05-05T10:46:47.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (14, N'Nước ép cà rốt', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 2, CAST(N'2024-05-05T10:47:34.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (15, N'Nước ép thơm', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 2, CAST(N'2024-05-05T20:56:45.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (16, N'Nước ép cà chua', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 2, CAST(N'2024-05-05T20:57:13.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (17, N'Sữa chua đá bào', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 5, CAST(N'2024-05-05T20:57:39.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (18, N'Sữa chua dâu', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 5, CAST(N'2024-05-05T20:58:05.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (19, N'Sữa chua Việt quất', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 5, CAST(N'2024-05-05T20:58:18.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (20, N'Kem ly', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 6, CAST(N'2024-05-05T21:00:43.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (21, N'Kem cây', N'', N'Còn ', CAST(12000.00 AS Decimal(18, 2)), 6, CAST(N'2024-05-05T21:01:00.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (22, N'Sinh tố dừa', N'', N'Còn ', CAST(22000.00 AS Decimal(18, 2)), 7, CAST(N'2024-05-05T21:33:40.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (23, N'Sinh tố tắc', N'', N'Còn ', CAST(25000.00 AS Decimal(18, 2)), 7, CAST(N'2024-05-05T21:34:02.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (24, N'Sinh tố thơm', N'', N'Còn ', CAST(24000.00 AS Decimal(18, 2)), 7, CAST(N'2024-05-05T21:34:21.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (25, N'Sinh tố cà rốt', N'', N'Còn ', CAST(25000.00 AS Decimal(18, 2)), 7, CAST(N'2024-05-05T21:34:36.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (26, N'Sinh tố thập cẩm', N'', N'Còn ', CAST(25000.00 AS Decimal(18, 2)), 7, CAST(N'2024-05-05T21:34:53.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (27, N'Trà sữa Lisa', N'', N'Còn ', CAST(20000.00 AS Decimal(18, 2)), 8, CAST(N'2024-05-15T16:54:15.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (28, N'Trà sữa Thái Xanh', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 8, CAST(N'2024-05-15T16:54:42.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (29, N'Trà sữa Thái Đỏ', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 8, CAST(N'2024-05-15T16:58:07.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (30, N'Trà sữa Kiwi', N'', N'Còn ', CAST(15000.00 AS Decimal(18, 2)), 8, CAST(N'2024-05-15T16:58:46.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (31, N'Sữa tươi trân châu đường nâu', N'', N'Còn ', CAST(16000.00 AS Decimal(18, 2)), 8, CAST(N'2024-05-15T16:58:57.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (32, N'Đã xoá', N'', N'Đã hết', CAST(14000.00 AS Decimal(18, 2)), 10, CAST(N'2024-05-15T16:59:31.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (33, N'Chó dã cầy', N'12312313', N'Còn ', CAST(12.00 AS Decimal(18, 2)), 10, CAST(N'2024-05-16T13:52:30.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (34, N'cădada', N'213132', N'Còn ', CAST(123123.00 AS Decimal(18, 2)), 10, CAST(N'2024-05-16T13:52:40.000' AS DateTime))
INSERT [dbo].[Food] ([ID], [Name], [Description], [Status], [Price], [CategoryID], [CreatedDate]) VALUES (35, N'Nước ép thịt tó', N'', N'Đã hết', CAST(1231321.00 AS Decimal(18, 2)), 10, CAST(N'2024-05-16T14:02:50.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[TableList] ON 

INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (1, N'Bàn 1', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (2, N'Bàn 2', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (3, N'Bàn 3', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (4, N'Bàn 4', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (5, N'Bàn 5', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (6, N'Bàn 6', N'Có người')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (7, N'Bàn 7', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (8, N'Bàn 8 ', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (9, N'Bàn 9', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (10, N'Bàn 10', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (11, N'Bàn 11', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (12, N'Bàn 12', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (15, N'Bàn 13', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (16, N'Bàn 14 - Ðã xoá', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (19, N'Bàn 15  - Ðã xoá', N'Trống')
INSERT [dbo].[TableList] ([ID], [Name], [Status]) VALUES (20, N'Bàn 16 - Ðã xoá', N'Trống')
SET IDENTITY_INSERT [dbo].[TableList] OFF
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckin]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([TableID])
REFERENCES [dbo].[TableList] ([ID])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([ID])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([FoodID])
REFERENCES [dbo].[Food] ([ID])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[CalculateCategoryRevenue]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CalculateCategoryRevenue]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StartDate DATETIME;
    DECLARE @EndDate DATETIME;

    -- Lấy ngày đầu tiên của tháng hiện tại
    SET @StartDate = DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0);
    
    -- Lấy ngày cuối cùng của tháng hiện tại
    SET @EndDate = DATEADD(month, DATEDIFF(month, 0, GETDATE()) + 1, 0);

    SELECT c.Name AS 'Danh mục', SUM(bi.Quantity * f.Price) AS 'Doanh thu'
    FROM BillInfo bi
    INNER JOIN Food f ON bi.FoodID = f.ID
    INNER JOIN Category c ON f.CategoryID = c.ID
    INNER JOIN Bill b ON bi.BillID = b.ID
    WHERE b.Status = 1 -- Để chỉ tính các bill đã thanh toán (đã checkout)
    AND b.DateCheckin >= @StartDate AND b.DateCheckin < @EndDate
    GROUP BY c.Name;
END;
GO
/****** Object:  StoredProcedure [dbo].[CalculateTotalBillAmountInCurrentMonth]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CalculateTotalBillAmountInCurrentMonth]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @StartDate DATETIME;
    DECLARE @EndDate DATETIME;

    -- Lấy ngày đầu tiên của tháng hiện tại
    SET @StartDate = DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0);
    
    -- Lấy ngày cuối cùng của tháng hiện tại
    SET @EndDate = DATEADD(month, DATEDIFF(month, 0, GETDATE()) + 1, 0);

    SELECT SUM(TotalPrice)
    FROM Bill
    WHERE DateCheckin >= @StartDate AND DateCheckin < @EndDate;
END;
GO
/****** Object:  StoredProcedure [dbo].[CountBillsInCurrentMonth]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountBillsInCurrentMonth]
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @StartDate DATETIME;
    DECLARE @EndDate DATETIME;
    SET @StartDate = DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0);

    SET @EndDate = DATEADD(month, DATEDIFF(month, 0, GETDATE()) + 1, 0);

    SELECT COUNT(*) AS TotalBills
    FROM Bill
    WHERE DateCheckin >= @StartDate AND DateCheckin < @EndDate;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetBillDetailsByBillID]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBillDetailsByBillID]
    @BillID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        F.Name AS 'TenMon', 
        F.Price AS 'GiaTien', 
        BI.Quantity AS 'SoLuong', 
        F.Price * BI.Quantity AS 'ThanhTien'
    FROM 
        BillInfo BI
    INNER JOIN 
        Food F ON BI.FoodID = F.ID
    WHERE 
        BI.BillID = @BillID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetBillsByDateRange]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBillsByDateRange]
    @FromDate DATETIME,
    @ToDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        B.ID AS 'ID Bill',
        TL.Name AS 'Tên bàn',
        B.TotalPrice AS 'Tổng tiền',
        B.Discount AS 'Giảm giá',
        B.DateCheckin AS 'Giờ vào',
        B.DateCheckout AS 'Giờ ra',
        A.Name AS 'Thực hiện'
    FROM
        Bill B
    INNER JOIN
        TableList TL ON B.TableID = TL.ID
    INNER JOIN
        Account A ON B.AccountID = A.ID
    WHERE
		b.Status = 1 AND
        B.DateCheckin >= @FromDate
        AND B.DateCheckin <= @ToDate;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTableList]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GetTableList]
AS SELECT * FROM dbo.TableList
WHERE Name NOT LIKE '%Đã xoá%'
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 5/16/2024 10:43:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfo]
@BillID INT , @FoodID INT, @Quantity INT
AS
BEGIN
    Declare @isExistBillInfo INT
	Declare @foodCount INT=1;
	SELECT @isExistBillInfo= ID, @foodCount = Quantity FROM dbo.BillInfo WHERE BillID=@BillID AND FoodID=@FoodID
	IF (@isExistBillInfo>0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @Quantity
		if (@newCount>0)
			UPDATE dbo.BillInfo SET Quantity= @foodCount+ @Quantity WHERE FoodID=@FoodID
		else 
			DELETE dbo.BillInfo WHERE BillID=@BillID AND FoodID=@FoodID
	END
	ELSE
		BEGIN
			IF (@Quantity>0)
			BEGIN
				INSERT BillInfo (BillID,FoodID,Quantity)
				VALUES (
				@BillID, @FoodID,@Quantity	
				)	
			END			 
		 END
 

END
GO
