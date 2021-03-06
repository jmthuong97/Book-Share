USE [master]
GO
/****** Object:  Database [BookShareProject]    Script Date: 7/29/2018 23:39:13 ******/
CREATE DATABASE [BookShareProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookShareProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BookShareProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookShareProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BookShareProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BookShareProject] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookShareProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookShareProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookShareProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookShareProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookShareProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookShareProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookShareProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookShareProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookShareProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookShareProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookShareProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookShareProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookShareProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookShareProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookShareProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookShareProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookShareProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookShareProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookShareProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookShareProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookShareProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookShareProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookShareProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookShareProject] SET RECOVERY FULL 
GO
ALTER DATABASE [BookShareProject] SET  MULTI_USER 
GO
ALTER DATABASE [BookShareProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookShareProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookShareProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookShareProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookShareProject] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookShareProject', N'ON'
GO
ALTER DATABASE [BookShareProject] SET QUERY_STORE = OFF
GO
USE [BookShareProject]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BookShareProject]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[author] [nvarchar](50) NOT NULL,
	[ISBN] [nvarchar](20) NOT NULL,
	[language] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[tag] [nvarchar](50) NULL,
	[status] [bit] NULL,
	[idUser] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImageBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageBook](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[urlImage] [nvarchar](500) NOT NULL,
	[idBook] [int] NOT NULL,
 CONSTRAINT [PK_ImageBook] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RateBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RateBook](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBook] [int] NOT NULL,
	[idUser] [int] NOT NULL,
	[rate] [int] NOT NULL,
 CONSTRAINT [PK_RateBook] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReviewBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReviewBook](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBook] [int] NOT NULL,
	[idUser] [int] NOT NULL,
	[content] [nvarchar](500) NULL,
	[createDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ReviewBook] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Trading]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trading](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idOwner] [int] NOT NULL,
	[idBorrower] [int] NOT NULL,
	[idBook] [int] NOT NULL,
	[statusBook] [int] NOT NULL,
	[statusComplete] [int] NULL,
	[createDate] [date] NOT NULL,
	[completeDate] [date] NULL,
 CONSTRAINT [PK_Trading] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fullName] [nvarchar](50) NOT NULL,
	[birthday] [date] NOT NULL,
	[avatar] [nvarchar](50) NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[address] [nvarchar](500) NULL,
	[phoneNumber] [nvarchar](15) NULL,
	[linkFacebook] [nvarchar](50) NULL,
	[userPoint] [int] NULL,
	[createDate] [date] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([id], [title], [author], [ISBN], [language], [description], [tag], [status], [idUser]) VALUES (47, N'How to Win Friends and Influence People', N'Dale Carnegie', N'561107', N'English', N'You can go after the job you want...and get it! You can take the job you have...and improve it! You can take any situation you''re in...and make it work for you!

Since its release in 1936, How to Win Friends and Influence People has sold more than 15 million copies. Dale Carnegie''s first book is a timeless bestseller, packed with rock-solid advice that has carried thousands of now famous people up the ladder of success in their business and personal lives.

As relevant as ever before, Dale Carnegie''s principles endure, and will help you achieve your maximum potential in the complex and competitive modern age.

Learn the six ways to make people like you, the twelve ways to win people to your way of thinking, and the nine ways to change people without arousing resentment.', N'Self-help Book', 1, 1)
INSERT [dbo].[Book] ([id], [title], [author], [ISBN], [language], [description], [tag], [status], [idUser]) VALUES (48, N'Nhà Giả Kim', N'Paulo Coelho', N'123456', N'Vietnamese', N'Nhà Giả Kim là cuốn sách được in nhiều nhất chỉ sau Kinh Thánh. Cuốn sách của Paulo Coelho có sự hấp dẫn ra sao khiến độc giả không chỉ các xứ dùng ngôn ngữ Bồ Đào Nha mà các ngôn ngữ khác say mê như vậy?

Tất cả những trải nghiệm trong chuyến phiêu du theo đuổi vận mệnh của mình đã giúp Santiago thấu hiểu được ý nghĩa sâu xa nhất của hạnh phúc, hòa hợp với vũ trụ và con người.', N'Văn Học - Tiểu Thuyết', 1, 1)
INSERT [dbo].[Book] ([id], [title], [author], [ISBN], [language], [description], [tag], [status], [idUser]) VALUES (49, N'Cà Phê Cùng Tony', N'Tony Buổi Sáng', N'456789', N'Vietnamese', N'…Thật ra Tony hiểu vì sao các bác giáo sư tiến sĩ soạn sách đã phải đưa vào nhiều nội dung như vậy. Rất là tâm huyết và đáng trân trọng. Vì ngày xưa, kiến thức rất khó tìm. Nhiều điều hữu ích chỉ nằm trong sách, trong thư viện các thành phố lớn, các trường các viện đại học lớn và người ta phải nhớ mọi thứ, nên phải cộng điểm cho học sinh nông thôn vì ít cơ hội tiếp cận kiến thức.

Nhưng, bây giờ kiến thức nằm hết trên mạng, trong file máy tính, truy cập là ra ngay, nên các nước đã phải thay đổi chương trình học phổ thông sau khi máy tính và internet ra đời. Học sinh chỉ cần nhớ những gì cốt lõi, và PHƯƠNG PHÁP tìm kiếm tài liệu. Vì chữ nghĩa rồi cũng sẽ rụng rơi theo thời gian, kiến thức mới lại bổ sung liên tục, nên phương pháp tìm kiếm thông tin tốt sẽ giúp ích cho các bạn trong cuộc sống sau này. Làm ngành nghề gì cũng phải cập nhật cái mới…', N'Sách Kỹ Năng Sống', 1, 1)
INSERT [dbo].[Book] ([id], [title], [author], [ISBN], [language], [description], [tag], [status], [idUser]) VALUES (50, N'Tuổi Trẻ Đáng Giá Bao Nhiêu', N'Rosie Nguyễn', N'147258', N'Vietnamese', N'Khi về già, người ta sẽ hối tiếc vì những việc họ không làm hơn là những việc họ đã làm.

Tuổi trẻ ngắn ngủi lắm, đừng vùi chân ở một chốn nào đó mà bạn không thích, cặm cụi sáng đi tối về và lặp lại vòng luẩn quẩn bán tuổi trẻ lấy chút tiền. Suy cho cùng Tuổi Trẻ Đáng Giá Bao Nhiêu để bạn phải đánh đổi?', N'Sách Kỹ Năng Sống', 1, 1)
INSERT [dbo].[Book] ([id], [title], [author], [ISBN], [language], [description], [tag], [status], [idUser]) VALUES (52, N'aaaaaaasdasd', N'asdsad', N'05061997', N'XXXXXXXXXXXX', N'ax', N'XXXXXXXXXXXXX', 1, 3)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[ImageBook] ON 

INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (106, N'47_1_cover1.jpg', 47)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (107, N'47_1_cover2.jpg', 47)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (108, N'coverbook.jpg', 47)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (109, N'coverbook.jpg', 47)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (110, N'coverbook.jpg', 47)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (111, N'48_1_cover1.jpg', 48)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (112, N'48_1_cover2.jpg', 48)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (113, N'48_1_cover3.jpg', 48)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (114, N'coverbook.jpg', 48)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (115, N'coverbook.jpg', 48)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (116, N'49_1_cover1.jpg', 49)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (117, N'49_1_cover2.jpg', 49)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (118, N'49_1_cover3.jpg', 49)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (119, N'49_1_cover4.jpg', 49)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (120, N'coverbook.jpg', 49)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (121, N'50_1_cover1.jpg', 50)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (122, N'50_1_cover2.jpg', 50)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (123, N'coverbook.jpg', 50)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (124, N'coverbook.jpg', 50)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (125, N'coverbook.jpg', 50)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (126, N'52_3_cover1.jpg', 52)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (127, N'coverbook.jpg', 52)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (128, N'coverbook.jpg', 52)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (129, N'coverbook.jpg', 52)
INSERT [dbo].[ImageBook] ([id], [urlImage], [idBook]) VALUES (130, N'coverbook.jpg', 52)
SET IDENTITY_INSERT [dbo].[ImageBook] OFF
SET IDENTITY_INSERT [dbo].[ReviewBook] ON 

INSERT [dbo].[ReviewBook] ([id], [idBook], [idUser], [content], [createDate]) VALUES (1078, 50, 1, N'Hay', CAST(N'2018-07-28T00:00:00.000' AS DateTime))
INSERT [dbo].[ReviewBook] ([id], [idBook], [idUser], [content], [createDate]) VALUES (1079, 47, 3, N'hay vay', CAST(N'2018-07-29T00:00:00.000' AS DateTime))
INSERT [dbo].[ReviewBook] ([id], [idBook], [idUser], [content], [createDate]) VALUES (1080, 48, 23, N'cung hay day', CAST(N'2018-07-29T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[ReviewBook] OFF
SET IDENTITY_INSERT [dbo].[Trading] ON 

INSERT [dbo].[Trading] ([id], [idOwner], [idBorrower], [idBook], [statusBook], [statusComplete], [createDate], [completeDate]) VALUES (2, 1, 0, 47, 0, 0, CAST(N'2018-07-28' AS Date), NULL)
INSERT [dbo].[Trading] ([id], [idOwner], [idBorrower], [idBook], [statusBook], [statusComplete], [createDate], [completeDate]) VALUES (3, 1, 3, 48, 2, 0, CAST(N'2018-07-28' AS Date), NULL)
INSERT [dbo].[Trading] ([id], [idOwner], [idBorrower], [idBook], [statusBook], [statusComplete], [createDate], [completeDate]) VALUES (4, 1, 0, 49, 0, 0, CAST(N'2018-07-28' AS Date), NULL)
INSERT [dbo].[Trading] ([id], [idOwner], [idBorrower], [idBook], [statusBook], [statusComplete], [createDate], [completeDate]) VALUES (5, 1, 3, 50, 3, 0, CAST(N'2018-07-28' AS Date), NULL)
INSERT [dbo].[Trading] ([id], [idOwner], [idBorrower], [idBook], [statusBook], [statusComplete], [createDate], [completeDate]) VALUES (6, 3, 1, 52, 2, 0, CAST(N'2018-07-29' AS Date), NULL)
INSERT [dbo].[Trading] ([id], [idOwner], [idBorrower], [idBook], [statusBook], [statusComplete], [createDate], [completeDate]) VALUES (7, 1, 0, 47, 0, 0, CAST(N'2018-07-29' AS Date), NULL)
INSERT [dbo].[Trading] ([id], [idOwner], [idBorrower], [idBook], [statusBook], [statusComplete], [createDate], [completeDate]) VALUES (8, 22, 3, 47, 1, 0, CAST(N'2018-07-29' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Trading] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [fullName], [birthday], [avatar], [username], [password], [email], [address], [phoneNumber], [linkFacebook], [userPoint], [createDate]) VALUES (1, N'Nguyen Nhu Thuong', CAST(N'1997-06-05' AS Date), N'admin.jpg', N'admin', N'admin', N'jmthuong97@gmail.com', N'Thai Binh', N'0986352227', N'https://www.facebook.com/jmthuong97', 10, CAST(N'2018-12-07' AS Date))
INSERT [dbo].[User] ([id], [fullName], [birthday], [avatar], [username], [password], [email], [address], [phoneNumber], [linkFacebook], [userPoint], [createDate]) VALUES (3, N'Nguyen Thi Kim Chi', CAST(N'1999-11-07' AS Date), N'nguyenchi1.png', N'nguyenchi1', N'Anhthuong1', N'chintkha@gmail.com', N'Quang Ninh', N'0123456789', N'https://www.facebook.com/chiimintk', 10, CAST(N'2018-07-12' AS Date))
INSERT [dbo].[User] ([id], [fullName], [birthday], [avatar], [username], [password], [email], [address], [phoneNumber], [linkFacebook], [userPoint], [createDate]) VALUES (20, N'Nguyen Duy Tri', CAST(N'1997-03-18' AS Date), NULL, N'duytry1', N'Anhthuong1', N'duytry@gmail.com', NULL, NULL, NULL, 10, CAST(N'2018-07-25' AS Date))
INSERT [dbo].[User] ([id], [fullName], [birthday], [avatar], [username], [password], [email], [address], [phoneNumber], [linkFacebook], [userPoint], [createDate]) VALUES (22, N'Pham Ba Tung', CAST(N'1997-10-05' AS Date), N'batung1.png', N'batung1', N'Anhthuong1', N'batung@gmail.com', N'Thai Binh', N'0986352227', N'', 10, CAST(N'2018-07-29' AS Date))
INSERT [dbo].[User] ([id], [fullName], [birthday], [avatar], [username], [password], [email], [address], [phoneNumber], [linkFacebook], [userPoint], [createDate]) VALUES (23, N'Hoang Duoc Su', CAST(N'1950-01-02' AS Date), N'DefaultAvatar.png', N'dongta1', N'Anhthuong1', N'dongta@gmail.com', NULL, NULL, NULL, 10, CAST(N'2018-07-29' AS Date))
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_status]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[RateBook] ADD  CONSTRAINT [DF_RateBook_rate]  DEFAULT ((5)) FOR [rate]
GO
ALTER TABLE [dbo].[Trading] ADD  CONSTRAINT [DF_Trading_idBorrower]  DEFAULT ((0)) FOR [idBorrower]
GO
ALTER TABLE [dbo].[Trading] ADD  CONSTRAINT [DF_Trading_statusBook]  DEFAULT ((0)) FOR [statusBook]
GO
ALTER TABLE [dbo].[Trading] ADD  CONSTRAINT [DF_Trading_statusComplete]  DEFAULT ((0)) FOR [statusComplete]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_avatar]  DEFAULT (N'DefaultAvatar.png') FOR [avatar]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_userPoint]  DEFAULT ((10)) FOR [userPoint]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_User] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_User]
GO
ALTER TABLE [dbo].[ImageBook]  WITH CHECK ADD  CONSTRAINT [FK_ImageBook_Book] FOREIGN KEY([idBook])
REFERENCES [dbo].[Book] ([id])
GO
ALTER TABLE [dbo].[ImageBook] CHECK CONSTRAINT [FK_ImageBook_Book]
GO
ALTER TABLE [dbo].[RateBook]  WITH CHECK ADD  CONSTRAINT [FK_RateBook_Book] FOREIGN KEY([idBook])
REFERENCES [dbo].[Book] ([id])
GO
ALTER TABLE [dbo].[RateBook] CHECK CONSTRAINT [FK_RateBook_Book]
GO
ALTER TABLE [dbo].[RateBook]  WITH CHECK ADD  CONSTRAINT [FK_RateBook_User] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[RateBook] CHECK CONSTRAINT [FK_RateBook_User]
GO
ALTER TABLE [dbo].[ReviewBook]  WITH CHECK ADD  CONSTRAINT [FK_ReviewBook_Book] FOREIGN KEY([idBook])
REFERENCES [dbo].[Book] ([id])
GO
ALTER TABLE [dbo].[ReviewBook] CHECK CONSTRAINT [FK_ReviewBook_Book]
GO
ALTER TABLE [dbo].[ReviewBook]  WITH CHECK ADD  CONSTRAINT [FK_ReviewBook_User] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[ReviewBook] CHECK CONSTRAINT [FK_ReviewBook_User]
GO
ALTER TABLE [dbo].[Trading]  WITH CHECK ADD  CONSTRAINT [FK_Trading_Book] FOREIGN KEY([idBook])
REFERENCES [dbo].[Book] ([id])
GO
ALTER TABLE [dbo].[Trading] CHECK CONSTRAINT [FK_Trading_Book]
GO
ALTER TABLE [dbo].[Trading]  WITH CHECK ADD  CONSTRAINT [FK_Trading_User] FOREIGN KEY([idOwner])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Trading] CHECK CONSTRAINT [FK_Trading_User]
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteBook]
	@id int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[Book]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteBooksDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteBooksDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteBooksDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteBooksDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[Book]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteImageBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteImageBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteImageBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteImageBook]
	@id int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ImageBook]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteImageBooksDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteImageBooksDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteImageBooksDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteImageBooksDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[ImageBook]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteRateBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteRateBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteRateBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteRateBook]
	@id int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[RateBook]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteRateBooksDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteRateBooksDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteRateBooksDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteRateBooksDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[RateBook]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteReviewBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteReviewBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteReviewBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteReviewBook]
	@id int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ReviewBook]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteReviewBooksDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteReviewBooksDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteReviewBooksDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteReviewBooksDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[ReviewBook]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteTrading]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteTrading]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteTrading]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteTrading]
	@id int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[Trading]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteTradingsDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteTradingsDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteTradingsDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteTradingsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[Trading]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteUser]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteUser]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteUser]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteUser]
	@id int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[User]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteUsersDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_DeleteUsersDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteUsersDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteUsersDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[User]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_InsertBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_InsertBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_InsertBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_InsertBook]
	@title nvarchar(50),
	@author nvarchar(50),
	@ISBN nvarchar(20),
	@language nvarchar(50),
	@description nvarchar(max),
	@tag nvarchar(50),
	@status bit,
	@idUser int,
	@id int OUTPUT
AS

SET NOCOUNT ON

INSERT INTO [dbo].[Book] (
	[title],
	[author],
	[ISBN],
	[language],
	[description],
	[tag],
	[status],
	[idUser]
) VALUES (
	@title,
	@author,
	@ISBN,
	@language,
	@description,
	@tag,
	@status,
	@idUser
)

SET @id = SCOPE_IDENTITY()

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_InsertImageBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_InsertImageBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_InsertImageBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_InsertImageBook]
	@urlImage nvarchar(50),
	@idBook int,
	@id int OUTPUT
AS

SET NOCOUNT ON

INSERT INTO [dbo].[ImageBook] (
	[urlImage],
	[idBook]
) VALUES (
	@urlImage,
	@idBook
)

SET @id = SCOPE_IDENTITY()

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_InsertRateBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_InsertRateBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_InsertRateBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_InsertRateBook]
	@idBook int,
	@idUser int,
	@rate int,
	@id int OUTPUT
AS

SET NOCOUNT ON

INSERT INTO [dbo].[RateBook] (
	[idBook],
	[idUser],
	[rate]
) VALUES (
	@idBook,
	@idUser,
	@rate
)

SET @id = SCOPE_IDENTITY()

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_InsertReviewBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_InsertReviewBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_InsertReviewBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_InsertReviewBook]
	@idBook int,
	@idUser int,
	@content nvarchar(500),
	@createDate datetime,
	@id int OUTPUT
AS

SET NOCOUNT ON

INSERT INTO [dbo].[ReviewBook] (
	[idBook],
	[idUser],
	[content],
	[createDate]
) VALUES (
	@idBook,
	@idUser,
	@content,
	@createDate
)

SET @id = SCOPE_IDENTITY()

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_InsertTrading]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_InsertTrading]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_InsertTrading]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_InsertTrading]
	@idOwner int,
	@idBorrower int,
	@idBook int,
	@statusBook bit,
	@statusComplete bit,
	@createDate date,
	@completeDate date,
	@id int OUTPUT
AS

SET NOCOUNT ON

INSERT INTO [dbo].[Trading] (
	[idOwner],
	[idBorrower],
	[idBook],
	[statusBook],
	[statusComplete],
	[createDate],
	[completeDate]
) VALUES (
	@idOwner,
	@idBorrower,
	@idBook,
	@statusBook,
	@statusComplete,
	@createDate,
	@completeDate
)

SET @id = SCOPE_IDENTITY()

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_InsertUser]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_InsertUser]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_InsertUser]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_InsertUser]
	@fullName nvarchar(50),
	@birthday date,
	@avatar nvarchar(50),
	@username nvarchar(50),
	@password nvarchar(50),
	@email nvarchar(50),
	@address nvarchar(500),
	@phoneNumber nvarchar(15),
	@linkFacebook nvarchar(50),
	@userPoint int,
	@createDate date,
	@id int OUTPUT
AS

SET NOCOUNT ON

INSERT INTO [dbo].[User] (
	[fullName],
	[birthday],
	[avatar],
	[username],
	[password],
	[email],
	[address],
	[phoneNumber],
	[linkFacebook],
	[userPoint],
	[createDate]
) VALUES (
	@fullName,
	@birthday,
	@avatar,
	@username,
	@password,
	@email,
	@address,
	@phoneNumber,
	@linkFacebook,
	@userPoint,
	@createDate
)

SET @id = SCOPE_IDENTITY()

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectBook]
	@id int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[title],
	[author],
	[ISBN],
	[language],
	[description],
	[tag],
	[status],
	[idUser]
FROM
	[dbo].[Book]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectBooksAll]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectBooksAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectBooksAll]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectBooksAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[title],
	[author],
	[ISBN],
	[language],
	[description],
	[tag],
	[status],
	[idUser]
FROM
	[dbo].[Book]

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectBooksDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectBooksDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectBooksDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectBooksDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[id],
	[title],
	[author],
	[ISBN],
	[language],
	[description],
	[tag],
	[status],
	[idUser]
FROM
	[dbo].[Book]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectImageBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectImageBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectImageBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectImageBook]
	@id int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[urlImage],
	[idBook]
FROM
	[dbo].[ImageBook]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectImageBooksAll]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectImageBooksAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectImageBooksAll]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectImageBooksAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[urlImage],
	[idBook]
FROM
	[dbo].[ImageBook]

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectImageBooksDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectImageBooksDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectImageBooksDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectImageBooksDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[id],
	[urlImage],
	[idBook]
FROM
	[dbo].[ImageBook]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectRateBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectRateBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectRateBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectRateBook]
	@id int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[idBook],
	[idUser],
	[rate]
FROM
	[dbo].[RateBook]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectRateBooksAll]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectRateBooksAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectRateBooksAll]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectRateBooksAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[idBook],
	[idUser],
	[rate]
FROM
	[dbo].[RateBook]

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectRateBooksDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectRateBooksDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectRateBooksDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectRateBooksDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[id],
	[idBook],
	[idUser],
	[rate]
FROM
	[dbo].[RateBook]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectReviewBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectReviewBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectReviewBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectReviewBook]
	@id int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[idBook],
	[idUser],
	[content],
	[createDate]
FROM
	[dbo].[ReviewBook]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectReviewBooksAll]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectReviewBooksAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectReviewBooksAll]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectReviewBooksAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[idBook],
	[idUser],
	[content],
	[createDate]
FROM
	[dbo].[ReviewBook]

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectReviewBooksDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectReviewBooksDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectReviewBooksDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectReviewBooksDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[id],
	[idBook],
	[idUser],
	[content],
	[createDate]
FROM
	[dbo].[ReviewBook]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectTrading]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectTrading]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectTrading]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectTrading]
	@id int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[idOwner],
	[idBorrower],
	[idBook],
	[statusBook],
	[statusComplete],
	[createDate],
	[completeDate]
FROM
	[dbo].[Trading]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectTradingsAll]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectTradingsAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectTradingsAll]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectTradingsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[idOwner],
	[idBorrower],
	[idBook],
	[statusBook],
	[statusComplete],
	[createDate],
	[completeDate]
FROM
	[dbo].[Trading]

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectTradingsDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectTradingsDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectTradingsDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectTradingsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[id],
	[idOwner],
	[idBorrower],
	[idBook],
	[statusBook],
	[statusComplete],
	[createDate],
	[completeDate]
FROM
	[dbo].[Trading]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUser]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectUser]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectUser]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectUser]
	@id int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[fullName],
	[birthday],
	[avatar],
	[username],
	[password],
	[email],
	[address],
	[phoneNumber],
	[linkFacebook],
	[userPoint],
	[createDate]
FROM
	[dbo].[User]
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUsersAll]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectUsersAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectUsersAll]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectUsersAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[id],
	[fullName],
	[birthday],
	[avatar],
	[username],
	[password],
	[email],
	[address],
	[phoneNumber],
	[linkFacebook],
	[userPoint],
	[createDate]
FROM
	[dbo].[User]

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUsersDynamic]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_SelectUsersDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectUsersDynamic]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectUsersDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[id],
	[fullName],
	[birthday],
	[avatar],
	[username],
	[password],
	[email],
	[address],
	[phoneNumber],
	[linkFacebook],
	[userPoint],
	[createDate]
FROM
	[dbo].[User]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_UpdateBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_UpdateBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_UpdateBook]
	@id int,
	@title nvarchar(50),
	@author nvarchar(50),
	@ISBN nvarchar(20),
	@language nvarchar(50),
	@description nvarchar(max),
	@tag nvarchar(50),
	@status bit,
	@idUser int
AS

SET NOCOUNT ON

UPDATE [dbo].[Book] SET
	[title] = @title,
	[author] = @author,
	[ISBN] = @ISBN,
	[language] = @language,
	[description] = @description,
	[tag] = @tag,
	[status] = @status,
	[idUser] = @idUser
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateImageBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_UpdateImageBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_UpdateImageBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_UpdateImageBook]
	@id int,
	@urlImage nvarchar(50),
	@idBook int
AS

SET NOCOUNT ON

UPDATE [dbo].[ImageBook] SET
	[urlImage] = @urlImage,
	[idBook] = @idBook
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateRateBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_UpdateRateBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_UpdateRateBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_UpdateRateBook]
	@id int,
	@idBook int,
	@idUser int,
	@rate int
AS

SET NOCOUNT ON

UPDATE [dbo].[RateBook] SET
	[idBook] = @idBook,
	[idUser] = @idUser,
	[rate] = @rate
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateReviewBook]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_UpdateReviewBook]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_UpdateReviewBook]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_UpdateReviewBook]
	@id int,
	@idBook int,
	@idUser int,
	@content nvarchar(500),
	@createDate datetime
AS

SET NOCOUNT ON

UPDATE [dbo].[ReviewBook] SET
	[idBook] = @idBook,
	[idUser] = @idUser,
	[content] = @content,
	[createDate] = @createDate
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTrading]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_UpdateTrading]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_UpdateTrading]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_UpdateTrading]
	@id int,
	@idOwner int,
	@idBorrower int,
	@idBook int,
	@statusBook bit,
	@statusComplete bit,
	@createDate date,
	@completeDate date
AS

SET NOCOUNT ON

UPDATE [dbo].[Trading] SET
	[idOwner] = @idOwner,
	[idBorrower] = @idBorrower,
	[idBook] = @idBook,
	[statusBook] = @statusBook,
	[statusComplete] = @statusComplete,
	[createDate] = @createDate,
	[completeDate] = @completeDate
WHERE
	[id] = @id

--endregion


GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateUser]    Script Date: 7/29/2018 23:39:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[usp_UpdateUser]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Administrator using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_UpdateUser]
-- Date Generated: Wednesday, July 18, 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_UpdateUser]
	@id int,
	@fullName nvarchar(50),
	@birthday date,
	@avatar nvarchar(50),
	@username nvarchar(50),
	@password nvarchar(50),
	@email nvarchar(50),
	@address nvarchar(500),
	@phoneNumber nvarchar(15),
	@linkFacebook nvarchar(50),
	@userPoint int,
	@createDate date
AS

SET NOCOUNT ON

UPDATE [dbo].[User] SET
	[fullName] = @fullName,
	[birthday] = @birthday,
	[avatar] = @avatar,
	[username] = @username,
	[password] = @password,
	[email] = @email,
	[address] = @address,
	[phoneNumber] = @phoneNumber,
	[linkFacebook] = @linkFacebook,
	[userPoint] = @userPoint,
	[createDate] = @createDate
WHERE
	[id] = @id

--endregion


GO
USE [master]
GO
ALTER DATABASE [BookShareProject] SET  READ_WRITE 
GO
