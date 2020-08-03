USE [master]
GO
/****** Object:  Database [aspnet-POS_Demo-20200727021008]    Script Date: 27-Jul-20 10:45:49 PM ******/
CREATE DATABASE [aspnet-POS_Demo-20200727021008]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [aspnet-POS_Demo-20200727021008].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET ARITHABORT OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET  ENABLE_BROKER 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET RECOVERY FULL 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET  MULTI_USER 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET DB_CHAINING OFF 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'aspnet-POS_Demo-20200727021008', N'ON'
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET QUERY_STORE = OFF
GO
USE [aspnet-POS_Demo-20200727021008]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 27-Jul-20 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 27-Jul-20 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 27-Jul-20 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 27-Jul-20 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 27-Jul-20 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 27-Jul-20 10:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Birthdate] [datetime] NULL,
	[FK_GenderId] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[UserPassword] [nvarchar](max) NULL,
	[UserImage] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202007271313447_InitialCreate', N'POS_Demo.ApplicationDbContext', 0x1F8B0800000000000400ED5DD96EEC36127D0F30FF20E8692670DCB62F12648CEE04BE6D7B62C41B6EFB06F366B025765B88442912E5D808F26579C827E517426AE52A514B2F9E3102046E913C552C1E52555455F2D71F7F4EBF7F097CEB19C68917A2997D7C78645B1039A1EBA1F5CC4EF1EAAB6FEDEFBFFBC717D30B3778B17E2AFB7DA0FDC84894CCEC278CA3D3C924719E600092C3C073E2300957F8D009830970C3C9C9D1D1BF27C7C71348206C826559D34F29C25E00B31FE4E73C440E8C700AFC9BD0857E523C272D8B0CD5BA05014C22E0C0997D7FB7783C8741685B67BE0788FC05F457B605100A31C044BBD3CF095CE03844EB45441E00FFE13582A4DF0AF8092CB43EADBB9B4EE0E8844E60520F2CA19C34C161D011F0F84361918938BC975DEDCA62C46617C4B6F895CE3AB3DBCCFE14FA64E2A2A0D3B91FD34EB5490F69C703ABFC7950AD37A105FDE7C09AA73E4E63384330C531F049DF74E97BCE8FF0F521FC19A2194A7D9FD5856843DAB807E4D17D1C4630C6AF9FE0AAD0F0CAB5AD093F6E220EAC86316372FDAF10FE70625BB7443858FAB05A6A66AE0B1CC6F03F10C11860E8DE038C618C2806CC8C25491764D17F97D208B7C8E6B0AD1BF0720DD11A3FCDEC93AFBFB1AD4BEF05BAE5934283CFC8237B890CC2710A151A0A526FC1B3B7CE1416E4134AC7896D7D827ED69A3C79514EFC6CC91E8BE6CB380CE8EF7CC5F3A78F8B308D1DAA7C28353D80780D31AFC57452D3A7915414C2985865E79D908B0A9709A6EC4A75ECC3C55244331F9B3956CAEE84A1654CBE340AC2944BF198F7A839C33548B4E15B55CC69E36FB336790F8536F40FBD3659EB201E9F45112159A657AE83019D8531EF47A642D6A51727B8E5DC247F1A9D9BCD92AEC196047DF462FCE4126B9492CEC9DF0F5ED03AF0F2C7476248577146348F3B73DD1826C9C62746497C0F92E4D73076B722EC2A00EBCDAFD745003C7F84D7B68114E2C1AEBC388095F93E86E47802A8F35BA05C861F40F2B471032DA093C6642F2F3008A28D4BBB7F0A11BC4D83253D65B7276BB4A579F835BC040E39152F101D3518EF3A747E0E537C815C7A8E7CC64ED763A50218459D33C72167CD25213374E72109D086B933749BEFDA6D9EFBC00BD47EB3F00A7F2CBBD61E88BA87E48A68BA75F590AEC3B587CC542DBBEA55CD7BB4AA5A74EBAA2A0533D3B4E8A95734EBD0AA67DE6B70B492AD8C71B892F57EF7EC343B7B68B0935997026CFC4D9049FA09F8E9D8A23A712FDB6AC6DCCB7AEF847B9964F2F8D973E95BDA20642E3B1378A3FEEA68BC9DE18266DAA53C3EF97694978AE850B0D3DCB6F0EE3B4E47CEB324091D2FE39E708F93DF07F06A10D7C46ABC1CC8EDC006F2C41C849A1E3DC089F899FDA534371D6879BE33A02AC0635BE4D81D3A873EC4D03A73F2FBD739481CE0CA56253671F927849630A6A71EA01E7C42B69287B0CC610F395E04FC26B5854186073B55AA82175BCE61448346849BD6C044AEFA568BCAAE4408866AB3CB74C210A9995F1A474BC78936AFAB26877471B3419EB4EAA7202FE372B46D895E346CB6D416F8D86C0A1305B437B3BB2066E1569B2EBCE863EF1B3105E75E2066E18F6C8598BCA576404CDE146F8E98791465BAEE4248B56FB4E463B95E0EC428A4E4CCB4034E7276D87B4AF29F695AFD39FE9BCD484E22F7A96747BC1EE62FB233D8A6BFC82EC7DE538DF9A0ADA384EAEBF6168306A522DB3FD1642B6C8153F28CF72C00C9C35E3206931130965FA9E74BDA085FB0E236864CACB890498A485D5C790ABE8098BF09AD436D8E82D291C60F2EE9A102A8A96300A202900E45039CF20A5CA94D11C918C094D7D34A98C2EF146098B594ED53242A307D94990C22B5DAEE2E2AD5B9959018DA765BC1C0282138A2926E0613D77D9A902D60125B7789AE059B34DBA3251216B0CA498C6E9D926EEDD65105785D42BC41D611C23101AB9CC4E8D62938D96E1C4590D121CC18641A3E2430D9973D0C23241A359C26B28B6BE0E4F63F4D38B7B6CD8E3D26CE2608CAB3D6795B6DFE56DBB1D7E6260D5CE5F27ABB7ACF576DD3499E325C3C984E34B9C5D31B10451E5A33B9C6C5136B91271ACFBF5A74CFC50D728C89C3D953F44A2A49388CC11A0AAD4434D134CB9F3A07182C01BDDC9FBB81D44DE9D5685ED0A548D6719157AC7C6397BDE9DFC5F70F364758E1F415232EC97C02EA2E66DF180596C8C32C9AE10D7C102B3E67CE433F0D90DE6BD58FCED30ED8F1F91319613A11F4961C54C9265274C01BD8C8FC35E57B2D41E51D765F06FD509D31CB609035A72E40D4A39411008BA28B0A76BA2C3D9744F4B7BBAF4C2BC266F60A93A6C982308FCDB1EA444C16AA7E6A8EC4645AB250CCE30E3364932FB939B20DE6785552268B553D34C7E1932EC5ED55B774432C322BA5DD9A3F36C72A7227599CE251470C26FD4E0263DACC51F90C4916936F314714D2205948A1A983966CB223A724DBD00B4F6351750F7309727A238B2EB7763817E44447EE80909B7B602B7416DB3AEC71391792DBED7273B75D2A9F92F5D3BD7A1D6A6F140CDD94FCDAA89F9FA219BB99F7E0386E0E93D6C602318F3B6215896B1258F17CAFB8A2BD5F31E44A7E37D88F2B9AB1FA53834B26E30F8DC60C383D269721C61DCC4D19727ABC6E8CDCE8BA4BE1B6D8A5925E85DD42783D2D42DDF6FA5E29F6CDBBD8566946F2527E4D300C0E6987C3C52FFEDCF7203D82CB0E3700792B98E03C13D23E393A3E118A85F7A770779224AEAFB82A10AB77F9B5DA421AB1472DDA9A28DC318F317FC1E502D033889D27A02AB8BB224EF9CBCCFE2D1B759A5D22D1BFB2C707D655F21979BFA4A4E1214EA1F5BB5C52D02B33B24B816BA5E0EF6FA21E355BCB362B5FFDF7311F7560DDC564179D5A47D4B6838A584D05E7A33A08EE5DDDF9BFB18FA4DACA7233FD33002FFF62E1FAD44F0E02936A24E9DF382B66EA06A4A899CC6CD90D45A8A01C34353E2C1F0990AB841C84C6553BD6A7ABFE70EC5FDCB8F4F028858D83E6AB2C5E1C84A828501C0B6F1413EA0A10FB60698B0FFBEE577531621FD5B48588C2FEEF558668EE76942377E0762822DF37FBAEDA992B2295980DDACB72195907B8514AC586399D6FACB04BF9FECAAAAB86D76D8D86BD256A8F5DCB950735BBC998AC83AAED264A6E33DF76DF5222C7AEC9DA83AA02262371771557DBE294EE0E7DCF12B787D553ED09A98A97EFEEAAA5B6452ADD65FB9E93AA532DD49E706ADBEFBB1D31CAF8D5B7534235A479BE13E99D48A3D729BD3BDAFF3F8EB6BAF6484EE615D74C2E2AD2D614E51F4367B6BB0CC9CAE621E35912DD42AC4EA1D6151D35D61CE985E873B54541D229D95EA2D42CD66C6E85FBDF54C2D42C4653A7A22D746AAE736A96A5A9FAD86C3514BBFA7566B649A982326BFF4DD53B7133682991D3C59BCA24A5B754D634C8081CE785EC9BB753BD34C8049BDC0ABC773AA04AE9AD4C78A4EAA4DD1C681DAA90E4F427E26730FF1304E2E324DEBA86A0FF4B04041DCEC3A8FA5CA155583A3A82466517E1A6FA0662E012F7E32CC6DE0A389834D36F6CD97FBE2CFBA841BFF42EA17B85EE521CA5984C19064B9FBBF8A70E5393FCACD48AD7797A17D15FC91853206A7AF4DBE41DFA987ABE5BE97DA9B830D740504FACF8B245D712D32F5CEBD70AE93644864085F92A07F20106914FC0923BB400CFB08F6E847ED7700D9CD7FA4B880EA47D2178B34FCF3DB08E41901418F578F29370D80D5EBEFB1B4140DEC00B640000, N'6.2.0-61023')
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [Birthdate], [FK_GenderId], [Address], [UserPassword], [UserImage], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (1, NULL, NULL, NULL, NULL, NULL, N'waled11', NULL, N'waled@mail.com', 0, N'AB/KDcK73+2VKENk/zotHqrsryoTRRVEYoXcQ/uVEH4iTfYPplEluV9nE0Tfrko6Gg==', N'7bb7c846-f502-4c14-b678-8de8e107bfa0', NULL, 0, 0, NULL, 0, 0, N'waled@mail.com')
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 27-Jul-20 10:45:50 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 27-Jul-20 10:45:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 27-Jul-20 10:45:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 27-Jul-20 10:45:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 27-Jul-20 10:45:50 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 27-Jul-20 10:45:50 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [aspnet-POS_Demo-20200727021008] SET  READ_WRITE 
GO
