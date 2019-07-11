USE [master]
GO
/****** Object:  Database [internship]    Script Date: 11/07/2019 17:10:39 ******/
CREATE DATABASE [internship]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'internship', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\internship.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'internship_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\internship_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [internship] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [internship].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [internship] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [internship] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [internship] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [internship] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [internship] SET ARITHABORT OFF 
GO
ALTER DATABASE [internship] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [internship] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [internship] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [internship] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [internship] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [internship] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [internship] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [internship] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [internship] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [internship] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [internship] SET  DISABLE_BROKER 
GO
ALTER DATABASE [internship] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [internship] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [internship] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [internship] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [internship] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [internship] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [internship] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [internship] SET RECOVERY FULL 
GO
ALTER DATABASE [internship] SET  MULTI_USER 
GO
ALTER DATABASE [internship] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [internship] SET DB_CHAINING OFF 
GO
ALTER DATABASE [internship] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [internship] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [internship]
GO
/****** Object:  Table [dbo].[convention]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[convention](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created] [datetime2](7) NULL,
	[end_date] [datetime2](7) NULL,
	[start_date] [datetime2](7) NULL,
	[updated] [datetime2](7) NULL,
	[valid] [bit] NOT NULL,
	[university_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[department]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[chief_id] [bigint] NULL,
	[university_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[document]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[document](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[date_fichier_alf] [datetime2](7) NULL,
	[fichier_alfresco] [varbinary](255) NULL,
	[format_fichier_alf] [varchar](255) NULL,
	[id_fichier_alf] [varchar](255) NULL,
	[nom_fichier_alf] [varchar](255) NULL,
	[path_fichier_alf] [varchar](255) NULL,
	[present] [bit] NULL,
	[size_fichier_alf] [bigint] NULL,
	[final_project_assignment_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[eclass]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eclass](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[year] [varchar](255) NULL,
	[university_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[eclass_students]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eclass_students](
	[class_id] [bigint] NOT NULL,
	[students_id] [bigint] NOT NULL,
 CONSTRAINT [UK_rx4d1tgtap57644koaegqhar0] UNIQUE NONCLUSTERED 
(
	[students_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[enterprise]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[enterprise](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[address1] [varchar](255) NULL,
	[address2] [varchar](255) NULL,
	[city] [varchar](255) NULL,
	[state] [varchar](255) NULL,
	[street] [varchar](255) NULL,
	[zip_code] [bigint] NOT NULL,
	[domain] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[email_supervisor] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[web_site] [varchar](255) NULL,
	[representative_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[final_project_assignment]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[final_project_assignment](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[convention_name] [bigint] NOT NULL,
	[sheet_id] [bigint] NOT NULL,
	[student_id] [bigint] NOT NULL,
	[validation_group_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[grade]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[grade](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[level] [varchar](255) NULL,
	[note] [varchar](255) NULL,
	[number] [float] NOT NULL,
	[maker_id] [bigint] NOT NULL,
	[sheet_id] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[notification]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[notification](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[message] [varchar](255) NULL,
	[mobile] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[state] [int] NULL,
	[sys_notif_date] [datetime2](7) NULL,
	[owner_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[options]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[options](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created] [datetime2](7) NULL,
	[label] [varchar](255) NULL,
	[updated] [datetime2](7) NULL,
	[department_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[role]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sheet]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sheet](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[categorie] [varchar](255) NULL,
	[created] [datetime2](7) NULL,
	[description] [varchar](255) NULL,
	[enterprise] [varbinary](255) NULL,
	[problematique] [varchar](255) NULL,
	[project_title] [varchar](255) NULL,
	[student_name] [varchar](255) NULL,
	[updated] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[university]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[university](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[email] [varchar](255) NULL,
	[address1] [varchar](255) NULL,
	[address2] [varchar](255) NULL,
	[city] [varchar](255) NULL,
	[state] [varchar](255) NULL,
	[street] [varchar](255) NULL,
	[zip_code] [bigint] NOT NULL,
	[fax] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[registration_number] [varchar](255) NULL,
	[tel] [varchar](255) NULL,
	[web_site] [varchar](255) NULL,
	[representative_id] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user_role]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_role](
	[userid] [bigint] NOT NULL,
	[roleid] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[users]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[activated] [bit] NOT NULL,
	[email] [varchar](255) NULL,
	[first_name] [varchar](255) NULL,
	[lang_key] [varchar](255) NULL,
	[last_name] [varchar](255) NULL,
	[login] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[reset_key] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_ow0gan20590jrb00upg3va2fn] UNIQUE NONCLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[validation_group]    Script Date: 11/07/2019 17:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[validation_group](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[valid_internship_director] [bit] NOT NULL,
	[valid_pre_validator] [bit] NOT NULL,
	[valid_president] [bit] NOT NULL,
	[valid_reporter] [bit] NOT NULL,
	[valid_supervisor] [bit] NOT NULL,
	[internship_director_id] [bigint] NULL,
	[pre_validator_id] [bigint] NULL,
	[president_id] [bigint] NULL,
	[reporter_id] [bigint] NULL,
	[supervisor_id] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[convention]  WITH CHECK ADD  CONSTRAINT [FKpstlcgfat2y6jgcksv5tmxknn] FOREIGN KEY([university_id])
REFERENCES [dbo].[university] ([id])
GO
ALTER TABLE [dbo].[convention] CHECK CONSTRAINT [FKpstlcgfat2y6jgcksv5tmxknn]
GO
ALTER TABLE [dbo].[department]  WITH CHECK ADD  CONSTRAINT [FKh2ap9lv99txektaou64wpx8b2] FOREIGN KEY([university_id])
REFERENCES [dbo].[university] ([id])
GO
ALTER TABLE [dbo].[department] CHECK CONSTRAINT [FKh2ap9lv99txektaou64wpx8b2]
GO
ALTER TABLE [dbo].[department]  WITH CHECK ADD  CONSTRAINT [FKrp6rnku7qccll4ya2wg2x9rvw] FOREIGN KEY([chief_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[department] CHECK CONSTRAINT [FKrp6rnku7qccll4ya2wg2x9rvw]
GO
ALTER TABLE [dbo].[document]  WITH CHECK ADD  CONSTRAINT [FK2hhq5u1h4wfm4u3bj061kcpwd] FOREIGN KEY([final_project_assignment_id])
REFERENCES [dbo].[final_project_assignment] ([id])
GO
ALTER TABLE [dbo].[document] CHECK CONSTRAINT [FK2hhq5u1h4wfm4u3bj061kcpwd]
GO
ALTER TABLE [dbo].[eclass]  WITH CHECK ADD  CONSTRAINT [FKkgqhrf7yrhlp7tjtjtib8nfdb] FOREIGN KEY([university_id])
REFERENCES [dbo].[university] ([id])
GO
ALTER TABLE [dbo].[eclass] CHECK CONSTRAINT [FKkgqhrf7yrhlp7tjtjtib8nfdb]
GO
ALTER TABLE [dbo].[eclass_students]  WITH CHECK ADD  CONSTRAINT [FK2ddw41wqqiilmi5oj69nwxbaa] FOREIGN KEY([class_id])
REFERENCES [dbo].[eclass] ([id])
GO
ALTER TABLE [dbo].[eclass_students] CHECK CONSTRAINT [FK2ddw41wqqiilmi5oj69nwxbaa]
GO
ALTER TABLE [dbo].[eclass_students]  WITH CHECK ADD  CONSTRAINT [FKd47duvgyqi6groqu8tkw3tt79] FOREIGN KEY([students_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[eclass_students] CHECK CONSTRAINT [FKd47duvgyqi6groqu8tkw3tt79]
GO
ALTER TABLE [dbo].[enterprise]  WITH CHECK ADD  CONSTRAINT [FKcfr4xftsx6tk9c8f542yti6a2] FOREIGN KEY([representative_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[enterprise] CHECK CONSTRAINT [FKcfr4xftsx6tk9c8f542yti6a2]
GO
ALTER TABLE [dbo].[final_project_assignment]  WITH CHECK ADD  CONSTRAINT [FK4vqmdu5ow4ird0gkwwo57lcie] FOREIGN KEY([validation_group_id])
REFERENCES [dbo].[validation_group] ([id])
GO
ALTER TABLE [dbo].[final_project_assignment] CHECK CONSTRAINT [FK4vqmdu5ow4ird0gkwwo57lcie]
GO
ALTER TABLE [dbo].[final_project_assignment]  WITH CHECK ADD  CONSTRAINT [FKgw1enp8l447c2ubeua711s19a] FOREIGN KEY([student_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[final_project_assignment] CHECK CONSTRAINT [FKgw1enp8l447c2ubeua711s19a]
GO
ALTER TABLE [dbo].[final_project_assignment]  WITH CHECK ADD  CONSTRAINT [FKh8qeui2uegxspmt7p02wxboe5] FOREIGN KEY([convention_name])
REFERENCES [dbo].[convention] ([id])
GO
ALTER TABLE [dbo].[final_project_assignment] CHECK CONSTRAINT [FKh8qeui2uegxspmt7p02wxboe5]
GO
ALTER TABLE [dbo].[final_project_assignment]  WITH CHECK ADD  CONSTRAINT [FKlf5qmfq74idjjtme0muhe6fmq] FOREIGN KEY([sheet_id])
REFERENCES [dbo].[sheet] ([id])
GO
ALTER TABLE [dbo].[final_project_assignment] CHECK CONSTRAINT [FKlf5qmfq74idjjtme0muhe6fmq]
GO
ALTER TABLE [dbo].[grade]  WITH CHECK ADD  CONSTRAINT [FKlgg742djk2axv0obw83p4qy89] FOREIGN KEY([maker_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[grade] CHECK CONSTRAINT [FKlgg742djk2axv0obw83p4qy89]
GO
ALTER TABLE [dbo].[grade]  WITH CHECK ADD  CONSTRAINT [FKprh543ojiisyrixk2ux1b0dyg] FOREIGN KEY([sheet_id])
REFERENCES [dbo].[sheet] ([id])
GO
ALTER TABLE [dbo].[grade] CHECK CONSTRAINT [FKprh543ojiisyrixk2ux1b0dyg]
GO
ALTER TABLE [dbo].[notification]  WITH CHECK ADD  CONSTRAINT [FK9vcyt49k18m4eyt8c08j7hnl2] FOREIGN KEY([owner_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[notification] CHECK CONSTRAINT [FK9vcyt49k18m4eyt8c08j7hnl2]
GO
ALTER TABLE [dbo].[options]  WITH CHECK ADD  CONSTRAINT [FKt6rk5mawjxopraei71e4cs2v5] FOREIGN KEY([department_id])
REFERENCES [dbo].[department] ([id])
GO
ALTER TABLE [dbo].[options] CHECK CONSTRAINT [FKt6rk5mawjxopraei71e4cs2v5]
GO
ALTER TABLE [dbo].[university]  WITH CHECK ADD  CONSTRAINT [FKk6djikn2qjki5slvcf8apa2l5] FOREIGN KEY([representative_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[university] CHECK CONSTRAINT [FKk6djikn2qjki5slvcf8apa2l5]
GO
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD  CONSTRAINT [FKbo5ik0bthje7hum554xb17ry6] FOREIGN KEY([roleid])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[user_role] CHECK CONSTRAINT [FKbo5ik0bthje7hum554xb17ry6]
GO
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD  CONSTRAINT [FKl4qqtaxj0v5ikodha3v2pmfl] FOREIGN KEY([userid])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[user_role] CHECK CONSTRAINT [FKl4qqtaxj0v5ikodha3v2pmfl]
GO
ALTER TABLE [dbo].[validation_group]  WITH CHECK ADD  CONSTRAINT [FK20deodjvx0vjtwipu1ah1k5p] FOREIGN KEY([president_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[validation_group] CHECK CONSTRAINT [FK20deodjvx0vjtwipu1ah1k5p]
GO
ALTER TABLE [dbo].[validation_group]  WITH CHECK ADD  CONSTRAINT [FK5a978kgynj1c8ctsmijfi5mgk] FOREIGN KEY([reporter_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[validation_group] CHECK CONSTRAINT [FK5a978kgynj1c8ctsmijfi5mgk]
GO
ALTER TABLE [dbo].[validation_group]  WITH CHECK ADD  CONSTRAINT [FK77b1vomsrpc0j0oku26hy9vsr] FOREIGN KEY([internship_director_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[validation_group] CHECK CONSTRAINT [FK77b1vomsrpc0j0oku26hy9vsr]
GO
ALTER TABLE [dbo].[validation_group]  WITH CHECK ADD  CONSTRAINT [FKgt7e5w3duycr51oibx5oqwwrj] FOREIGN KEY([pre_validator_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[validation_group] CHECK CONSTRAINT [FKgt7e5w3duycr51oibx5oqwwrj]
GO
ALTER TABLE [dbo].[validation_group]  WITH CHECK ADD  CONSTRAINT [FKkt87io0mf60axiv0uu7a11wik] FOREIGN KEY([supervisor_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[validation_group] CHECK CONSTRAINT [FKkt87io0mf60axiv0uu7a11wik]
GO
USE [master]
GO
ALTER DATABASE [internship] SET  READ_WRITE 
GO
