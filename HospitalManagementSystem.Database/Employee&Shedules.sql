Create database [Employee&Shedules] 
Go

Use [Employee&Shedules]
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Hospital]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Title] [nvarchar](100) not null,
	[Address] [nvarchar](100) not null,
	[Details] [nvarchar](255) null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default null,
	
	Constraint [PK-Clinic] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table Department
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Title] [nvarchar](100) not null,
	[HospitalId] UNIQUEIDENTIFIER not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default null,

	Constraint [PK-Department] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Department-to-Hospital] Foreign key ([HospitalId]) references [Hospital]([Id])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Employees]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[FirstName] [nvarchar](100) not null,
	[LastName] [nvarchar](100) not null,
	[Password] [nvarchar](100) not null,
	[Email] [nvarchar](255) null,
	[Mobile] [nvarchar](255) null,
	[ActiveIs] [bit] not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default null,

	Constraint [PK-Employees] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Roles]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[Title] [nvarchar](100) not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default null,
	
	Constraint [PK-Roles] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [Unique_Role_title] unique ([Title])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Has_Role]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[EmployeesId] UNIQUEIDENTIFIER not null,
	[RolesId] UNIQUEIDENTIFIER not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default null,

	Constraint [PK-Has-Role] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Has-Role-to-Employees] Foreign key ([EmployeesId]) references [Employees]([Id]),
	
	Constraint [FK-Role-Has-to-Roles] Foreign key ([RolesId]) references [Roles]([Id]),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [InDepartments]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[EmployeesId] UNIQUEIDENTIFIER not null,
	[DepartmentsId] UNIQUEIDENTIFIER not null,
	[TimeFrom] [datetime] not null, 
	[TimeTo] [datetime] null,
	[ActiveIs] [bit] not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default null,

	Constraint [PK-In-Department] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-In-Department-to-Employees] Foreign key ([EmployeesId]) references [Employees]([Id]),

	Constraint [FK-In-Department-to-Department] Foreign key ([DepartmentsId]) references [Department]([Id]),

	Constraint [Unique_Values] Unique ([EmployeesId], [DepartmentsId], [TimeFrom])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Shedules]
(
	[Id] UNIQUEIDENTIFIER not null default NEWID(), 
	[InDepartmentsId] UNIQUEIDENTIFIER not null,
	[TimeStart] [datetime] not null, 
	[TimeEnd] [datetime] not null,
	
	[CreatedDateTime] [datetime] null default GETDATE(),
	[UpdatedDateTime] [datetime] null default null,

	Constraint [PK-Shedule] Primary key Clustered([Id] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Shedule] Foreign key ([InDepartmentsId]) references [InDepartments]([Id]),

	Constraint [Unique_Values_Shedule] Unique ([InDepartmentsId], [TimeStart]),
)
Go