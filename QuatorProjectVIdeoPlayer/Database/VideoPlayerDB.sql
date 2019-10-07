USE master 
GO

DROP DATABASE IF EXISTS VideoPlayerDB

CREATE DATABASE VideoPlayerDB
GO

USE VideoPlayerDB
GO

CREATE TABLE  Account
(
	AccountId int PRIMARY KEY IDENTITY NOT NULL,
	 Username varchar(30) NOT NULL UNIQUE,
	 Password varchar(100) NOT NULL,
	 Email varchar(50) NOT NULL UNIQUE,
	 DarkMode bit NOT NULL



)

CREATE Table Video(
	VideoId int PRIMARY KEY IDENTITY NOT NULL,
	VideoLink varchar(60) NOT NULL,
	VideoTitle varchar(30) NOT NULL,
	Rating bit NULL,
	Thumbnail varchar(100) NULL,
	Comments varchar(500) NULL,
	AccountId int REFERENCES Account(AccountId) NOT NULL
    

)
