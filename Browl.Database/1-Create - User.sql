﻿CREATE TABLE [dbo].[User]( 
	Id INT Identity PRIMARY KEY,
	Email VARCHAR(50) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	PasswordHash VARCHAR(100) NOT NULL
)