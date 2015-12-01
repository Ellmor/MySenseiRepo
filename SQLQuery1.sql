CREATE TABLE dbo.[User] (
	UserId INT PRIMARY KEY,
	UserName VARCHAR(50),
	[Password] VARCHAR(100),
	FirstName VARCHAR(100),
	LastName VARCHAR(100),
	Email VARCHAR(100),
	Phone VARCHAR(50),
	ProfilePicture VARCHAR(255),
	[Description] VARCHAR(255),
	AspNetUserId INT
);

CREATE TABLE dbo.Course (
	CourseID INT PRIMARY KEY,
	Titlte VARCHAR(255),
	[Description] VARCHAR(255),
	Location VARCHAR(255),
	Picture VARCHAR(255),
	Price VARCHAR(20)
);

CREATE TABLE dbo.UserCourse (
	UserCourseId INT PRIMARY KEY,
	CourseId INT FOREIGN KEY REFERENCES dbo.Course(CourseId),
	UserId INT FOREIGN KEY REFERENCES dbo.[User](UserId),
	[Level] VARCHAR(255)
);

CREATE TABLE dbo.Participation (
	ParticipationId INT PRIMARY KEY,
	UserId INT FOREIGN KEY REFERENCES dbo.[User](UserId),
	CourseId INT FOREIGN KEY REFERENCES dbo.Course(CourseId)
);

CREATE TABLE dbo.Tag (
	TagId INT PRIMARY KEY,
	[Tag] VARCHAR(255)
);

CREATE TABLE dbo.CourseTag (
	CourseTagId INT PRIMARY KEY,
	TagId INT FOREIGN KEY REFERENCES dbo.Tag(TagId),
	CourseId INT FOREIGN KEY REFERENCES dbo.Course(CourseId)
);