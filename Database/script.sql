USE [Megamind]

select * from INFORMATION_SCHEMA.TABLES

if not exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='T_DomainBank')
begin
	create table dbo.T_DomainBank(
		ID int identity(1, 1) not null,
		Domain nvarchar(250) not null,
		Info nvarchar(250) null,
		constraint PK_T_DomainBank primary key clustered
		([ID] asc)
) on [PRIMARY]
end

go

if not exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='T_QuestionBank')
begin
	create table dbo.T_QuestionBank(
		QUID int identity(1, 1) not null,
		DomainID Int not null,
		Question nvarchar(250) null,
		QType int null,
		stscd int null,
		foreign key (DomainID) references [T_DomainBank]([ID]),
		constraint [PK_T_QuestionBank] primary key clustered
		(
			[QUID] asc
		) with (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) on [PRIMARY]
end

go

if not exists 
(
    SELECT * FROM sys.foreign_key_columns fk 
    INNER JOIN sys.columns pc ON pc.object_id = fk.parent_object_id AND pc.column_id = fk.parent_column_id 
    INNER JOIN sys.columns rc ON rc.object_id = fk.referenced_object_id AND rc.column_id = fk.referenced_column_id
    WHERE fk.parent_object_id = object_id('T_QuestionBank') AND pc.name = 'DomainID'
    AND fk.referenced_object_id = object_id('T_DomainBank') AND rc.NAME = 'ID'
)
alter table T_QuestionBank
add constraint FK_T_QuestionBank_TO_DomainID foreign key (DomainID)
references T_DomainBank(ID)

go

if not exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='T_AnswerBank')
begin
	create table dbo.T_AnswerBank(
		AID int identity(1, 1) not null,
		QUID Int not null,
		QType [int] not null,
		Rnk int null,
		Correct int null,
		Message nvarchar(100) null,
		AnswerCT int null,
		MatchDegree float null,
		StsCD int null,
		foreign key (QUID) references T_QuestionBank(QUID),
		constraint PK_T_AnswerBank primary key clustered
		([AID] asc)
) on [PRIMARY]
end

go

if not exists 
(
    SELECT * FROM sys.foreign_key_columns fk 
    INNER JOIN sys.columns pc ON pc.object_id = fk.parent_object_id AND pc.column_id = fk.parent_column_id 
    INNER JOIN sys.columns rc ON rc.object_id = fk.referenced_object_id AND rc.column_id = fk.referenced_column_id
    WHERE fk.parent_object_id = object_id('T_AnswerBank') AND pc.name = 'QUID'
    AND fk.referenced_object_id = object_id('T_QuestionBank') AND rc.NAME = 'QUID'
)
alter table T_AnswerBank
add constraint FK_T_AnswerBank_TO_QuestionID foreign key (QUID)
references T_QuestionBank(QUID)

if not exists(select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='T_LogAnswer')
begin
	create table dbo.T_LogAnswer(
		ID int identity(1, 1) not null,
		QUID Int not null,
		AID Int not null,
		Rnk int not null,
		foreign key (QUID) references T_QuestionBank(QUID),
		foreign key (AID) references T_AnswerBank(AID),
		constraint PK_T_LogAnswer primary key clustered
		([ID] asc)
) on [PRIMARY]
end

go

if not exists 
(
    SELECT * FROM sys.foreign_key_columns fk 
    INNER JOIN sys.columns pc ON pc.object_id = fk.parent_object_id AND pc.column_id = fk.parent_column_id 
    INNER JOIN sys.columns rc ON rc.object_id = fk.referenced_object_id AND rc.column_id = fk.referenced_column_id
    WHERE fk.parent_object_id = object_id('T_LogAnswer') AND pc.name = 'QUID'
    AND fk.referenced_object_id = object_id('T_QuestionBank') AND rc.NAME = 'QUID'
)
alter table T_LogAnswer
add constraint FK_T_LogAnswer_TO_QuestionID foreign key (QUID)
references T_QuestionBank(QUID)

if not exists 
(
    SELECT * FROM sys.foreign_key_columns fk 
    INNER JOIN sys.columns pc ON pc.object_id = fk.parent_object_id AND pc.column_id = fk.parent_column_id 
    INNER JOIN sys.columns rc ON rc.object_id = fk.referenced_object_id AND rc.column_id = fk.referenced_column_id
    WHERE fk.parent_object_id = object_id('T_LogAnswer') AND pc.name = 'AID'
    AND fk.referenced_object_id = object_id('T_AnswerBank') AND rc.NAME = 'AID'
)
alter table T_LogAnswer
add constraint FK_T_LogAnswer_TO_AnswerID foreign key (AID)
references T_QuestionBank(AID)