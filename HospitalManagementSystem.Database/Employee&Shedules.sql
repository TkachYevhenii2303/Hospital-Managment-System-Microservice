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
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Hospital_title] [nvarchar](100) not null,
	[Address] [nvarchar](100) not null,
	[Details] [nvarchar](255) null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),
	
	Constraint [PK-Clinic] Primary key Clustered([ID] ASC)
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
	[Department_title] [nvarchar](100) not null,
	[Hospital_ID] UNIQUEIDENTIFIER not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Department] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Department-to-Hospital] Foreign key ([Hospital_ID]) references [Hospital]([ID])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Employees]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[First_title] [nvarchar](100) not null,
	[Last_title] [nvarchar](100) not null,
	[Password] [nvarchar](100) not null,
	[Email] [nvarchar](255) null,
	[Mobile] [nvarchar](255) null,
	[Active_is] [bit] not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Employees] Primary key Clustered([ID] ASC)
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
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Role_title] [nvarchar](100) not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),
	
	Constraint [PK-Roles] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [Unique_Role_title] unique ([Role_title])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Has_Role]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Employees_ID] UNIQUEIDENTIFIER not null,
	[Roles_ID] UNIQUEIDENTIFIER not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Has-Role] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Has-Role-to-Employees] Foreign key ([Employees_ID]) references [Employees]([ID]),
	
	Constraint [FK-Role-Has-to-Roles] Foreign key ([Roles_ID]) references [Roles]([ID]),

	Constraint [Unique_Values_Roles_Employees] Unique ([Employees_ID], [Roles_ID])
)
Go

alter table [Has_Role]
drop constraint [Unique_Values_Roles_Employees];
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [In_Departments]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[Employees_ID] UNIQUEIDENTIFIER not null,
	[Departments_ID] UNIQUEIDENTIFIER not null,
	[Time_from] [datetime] not null, 
	[Time_to] [datetime] null,
	[Active_is] [bit] not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-In-Department] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-In-Department-to-Employees] Foreign key ([Employees_ID]) references [Employees]([ID]),

	Constraint [FK-In-Department-to-Department] Foreign key ([Departments_ID]) references [Department]([ID]),

	Constraint [Unique_Values] Unique ([Employees_ID], [Departments_ID], [Time_from])
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go

Create table [Shedules]
(
	[ID] UNIQUEIDENTIFIER not null default NEWID(), 
	[In_Departments_ID] UNIQUEIDENTIFIER not null,
	[Time_start] [datetime] not null, 
	[Time_end] [datetime] not null,
	
	[Created_at] [datetime] null default GETDATE(),
	[Updated_at] [datetime] null default GETDATE(),

	Constraint [PK-Shedule] Primary key Clustered([ID] ASC)
	with (Pad_index = off, Statistics_norecompute = off, Ignore_dup_key = off,
	allow_row_locks = on, allow_page_locks = on) on [Primary],

	Constraint [FK-Shedule] Foreign key ([In_Departments_ID]) references [In_Departments]([ID]),

	Constraint [Unique_Values_Shedule] Unique ([In_Departments_ID], [Time_start]),
)
Go

Set ansi_nulls on
Go

Set quoted_identifier on
Go
