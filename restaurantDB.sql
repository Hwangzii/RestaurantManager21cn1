USE [restaurantDB]
GO
/****** Object:  Table [dbo].[banan_TB]    Script Date: 3/1/2024 9:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[banan_TB](
	[banan_id] [nchar](10) NULL,
	[so_luong_khach] [nchar](10) NULL,
	[so_luong_mon] [nchar](10) NULL,
	[ten_nv_phuc_vu] [nchar](10) NULL,
	[loai_mon] [nchar](10) NULL,
	[tinh_trang] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitiethoadon_TB]    Script Date: 3/1/2024 9:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiethoadon_TB](
	[monan_id] [nchar](10) NULL,
	[hoadon_id] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoadon_TB]    Script Date: 3/1/2024 9:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoadon_TB](
	[hoadon_id] [nchar](10) NULL,
	[so_luong_khach] [nchar](10) NULL,
	[loai_mon] [nchar](10) NULL,
	[so_luong_mon] [nchar](10) NULL,
	[date] [nchar](10) NULL,
	[ten_nv_phuc_vu] [nchar](10) NULL,
	[danh_gia] [nchar](10) NULL,
	[tong_tien] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachhang_TB]    Script Date: 3/1/2024 9:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachhang_TB](
	[khachhang_id] [nchar](10) NULL,
	[ten_khach_hang] [nchar](10) NULL,
	[sdt] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanvien_TB]    Script Date: 3/1/2024 9:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanvien_TB](
	[nhanvien_id] [int] NULL,
	[ten_nhan_vien] [nchar](10) NULL,
	[sdt] [nchar](10) NULL,
	[chuc_vu] [nchar](10) NULL,
	[dia_chi] [nchar](10) NULL,
	[email] [nchar](10) NULL,
	[cccd] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[quanly_TB]    Script Date: 3/1/2024 9:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quanly_TB](
	[quanly_id] [nchar](10) NULL,
	[ten_quan_ly] [nchar](10) NULL,
	[sdt] [nchar](10) NULL,
	[chuc_vu] [nchar](10) NULL,
	[dia_chi] [nchar](10) NULL,
	[email] [nchar](10) NULL,
	[cccd] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taikhoan_TB]    Script Date: 3/1/2024 9:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taikhoan_TB](
	[taikhoan_id] [int] NOT NULL,
	[ten_tai_khoan] [nvarchar](50) NULL,
	[mat_khau] [nvarchar](50) NULL,
 CONSTRAINT [PK_taikhoan_TB] PRIMARY KEY CLUSTERED 
(
	[taikhoan_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thucdon_TB]    Script Date: 3/1/2024 9:15:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thucdon_TB](
	[monan_id] [nchar](10) NULL,
	[ten_mon] [nchar](10) NULL,
	[gia_tien] [nchar](10) NULL,
	[so_luong] [nchar](10) NULL
) ON [PRIMARY]
GO
