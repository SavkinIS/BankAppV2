Пример банковского приложения учета клиентов и перевода средств



1 Создать БД с именем SkillDB.mdf

2 Необходимо создать таблицы используя скрипты : 
(Так же они прописаны в файле SQLQuery1.sql)
	Таблица счетов 
	CREATE TABLE [dbo].[CashAccounts] (
    	[NumCashAcc]        NVARCHAR (16) NOT NULL,
    	[NumClientPassport] NVARCHAR (12) NULL,
    	[NumClientINN]      NVARCHAR (12) NULL,
    	[AccFinance]        MONEY         NOT NULL,
    	[TypeAcc]           NCHAR (15)    NOT NULL,
   	 [PeriodAcc]         DATETIME      NOT NULL,
    	[Active]            BIT           NOT NULL,
    	PRIMARY KEY CLUSTERED ([NumCashAcc] ASC)
	);
	
	Таблица Клиетнов 
	CREATE TABLE [dbo].[Client] (
    	[FName]      NVARCHAR (15)  NOT NULL,
    	[LName]      NVARCHAR (20)  NOT NULL,
    	[BrthDay]    DATE           NOT NULL,
    	[Passport]   NVARCHAR (12)  NOT NULL,
  	  [Finance]    MONEY          NULL,
   	 [BankRating] INT            NOT NULL,
    	[ClStatus]   NVARCHAR (10)  NOT NULL,
    	[Adress]     NVARCHAR (MAX) NOT NULL,
   	 [WorkPlace]  NVARCHAR (MAX) NOT NULL,
    	[ActivLevel] INT            NOT NULL,
    	[FrstTrans]  TIME (7)       NOT NULL,
   	 PRIMARY KEY CLUSTERED ([Passport] ASC)
	);

	Таблица Компаний
	CREATE TABLE [dbo].[Company] (
   	 [CompName]   NVARCHAR (50)  NOT NULL,
  	  [CreateDay]  DATE           NOT NULL,
   	 [INN]        NVARCHAR (12)  NOT NULL,
  	  [Finance]    MONEY          NULL,
   	 [BankRating] INT            NOT NULL,
   	 [ClStatus]   NVARCHAR (10)  NOT NULL,
   	 [Adress]     NVARCHAR (MAX) NOT NULL,
    	[ActivLevel] INT            NOT NULL,
    	[FirstTrans] TIME (7)       NULL,
   	 PRIMARY KEY CLUSTERED ([INN] ASC)
);

3 Заполнить тестывыми значениями:
	Insert Client(FName, LName,BrthDay, Passport, Finance, BankRating, ClStatus, Adress, WorkPlace, ActivLevel, FrstTrans) VALUES (N'TestName', N'TestLName', '1990-01-20', N'222222222222', '100,00', 5 , 'STANDART', 'Adress1 street1 1 1', 'Work 1 Adress2 ', 0, '00:00:00')

	Insert Client(FName, LName,BrthDay, Passport, Finance, BankRating, ClStatus, Adress, WorkPlace, ActivLevel, FrstTrans) VALUES (N'TestName2', N'TestLName2', '1990-01-20', N'333333333333', '100,00', 5 , 'VIP', 'Adress1 street1 12 1', 'Work 2 Adress3', 0, '00:00:00')

	Insert Company(CompName, CreateDay, INN, Finance, BankRating, ClStatus, Adress,  ActivLevel, FirstTrans) VALUES (N'TestComp1', '2000-01-20', N'555555555555', '200,00', 5 , 'COMPANY', 'Adress1 street1 12 1',  0, '00:00:00')

	Insert CashAccounts(NumCashAcc, NumClientPassport, NumClientINN,AccFinance, TypeAcc, PeriodAcc, Active) VALUES (N'1111111111111111', '222222222222', N'', '0,00', 'DEPOSITE', '2025-02-05', 1)

	Insert CashAccounts(NumCashAcc, NumClientPassport, NumClientINN,AccFinance, TypeAcc, PeriodAcc, Active) VALUES (N'2222222222222222', '333333333333', N'', '0,00', 'DEPOSITE', '2025-02-05', 1)
	Insert CashAccounts(NumCashAcc, NumClientPassport, NumClientINN,AccFinance, TypeAcc, PeriodAcc, Active) VALUES (N'5555555555555555', '', N'555555555555', '1000', 'DEPOSITE', '2025-02-05', 1)	


4 В Файле App.Config изменить строку подключенияю указав путь к  базе данных. SkillDB.mdf
