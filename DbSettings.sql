USE master;
GO

IF DB_ID('AuditDB') IS NULL
CREATE DATABASE AuditDB;
GO

USE AuditDB
GO

IF OBJECT_ID('dbo.Contact', 'U') IS NULL 
CREATE TABLE dbo.Contact (
  [Id] bigint IDENTITY(1,1) PRIMARY KEY,
  [Name] varchar(500) null,
  [Email] varchar(500) null
)
GO

EXEC sys.sp_cdc_enable_db

EXEC sp_changedbowner 'sa'

EXEC sys.sp_cdc_enable_table
@source_schema = N'dbo',
@source_name   = N'Contact',
@role_name     = N'sa',
@supports_net_changes = 1
GO

EXEC sys.sp_cdc_help_change_data_capture
GO