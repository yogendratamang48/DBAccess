USE [EmployeeMGR]
GO
/****** Object:  StoredProcedure [dbo].[sp_Authenticate_User]    Script Date: 13-05-2016 11:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Authenticate_User]
@UserName nvarchar(100),
@password nvarchar(100)
as 
begin
Declare @Count int
select @Count=COUNT(fldUsername) from tblUser
where [fldUsername]=@UserName and [fldPassword]=@Password and [fldIsActive]=1
if(@Count=1)
Begin
select 1 as ReturnCode
end
Else
begin
select -1 as ReturnCode
end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Check_User]    Script Date: 13-05-2016 11:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Check_User]
@UserName nvarchar(100)
as 
begin
Declare @Count int
select @Count=COUNT(fldUsername) from tblUser
where [fldUsername]=@UserName
if(@Count=0)
Begin
select 1 as ReturnCode
end
Else
begin
select -1 as ReturnCode
end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_User]    Script Date: 13-05-2016 11:39:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_Insert_User]
 (
		   @fldEmployeeId int
           ,@fldLoginName varchar(200)
           ,@fldUsername varchar(50)
           ,@fldPassword varchar(MAX)
           ,@fldUserType nvarchar(50)
           ,@fldIsActive bit=1
           ,@fldCreatedBy nvarchar(100)
           ,@fldCreatedDate datetime
           ,@fldUpdatedBy nvarchar(100)
           ,@fldUpdatedDate datetime=null
           ,@fldNote nvarchar(500)=null
)
AS
BEGIN
INSERT INTO [dbo].[tblUser]
           ([fldEmployeeId]
           ,[fldLoginName]
           ,[fldUsername]
           ,[fldPassword]
           ,[fldUserType]
           ,[fldIsActive]
           ,[fldCreatedBy]
           ,[fldCreatedDate]
           ,[fldUpdatedBy]
           ,[fldUpdatedDate]
           ,[fldNote])
     VALUES
               (
		   @fldEmployeeId
           ,@fldLoginName
           ,@fldUsername
           ,@fldPassword
           ,@fldUserType 
           ,@fldIsActive
           ,@fldCreatedBy 
           ,@fldCreatedDate
           ,@fldUpdatedBy 
           ,@fldUpdatedDate
           ,@fldNote
		   )
SELECT SCOPE_IDENTITY() As InsertedID
END

GO
