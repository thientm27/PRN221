USE master
GO

CREATE DATABASE AuthorInstitution2023DB
GO

USE AuthorInstitution2023DB
GO

CREATE TABLE MemberAccount 
(
 MemberID nvarchar(50) PRIMARY KEY,
 FullName nvarchar(50) NOT NULL,
 EmailAddress nvarchar(50) NOT NULL, 
 MemberPassword nvarchar(50), 
 MemberRole int
);
GO

INSERT INTO MemberAccount VALUES ('MB0005', 'Admin', 'admin@ScienceDirect.com','@abc',0);
INSERT INTO MemberAccount VALUES ('MB0006', 'HR Manager', 'manager@ScienceDirect.com','@1',1);
INSERT INTO MemberAccount VALUES ('MB0007', 'Member 1', 'member1@ScienceDirect.com','123@',2);
INSERT INTO MemberAccount VALUES ('MB0008', 'Member 2', 'member2@ScienceDirect.com','123@',2);
GO

CREATE TABLE InstitutionInformation(
  InstitutionID int PRIMARY KEY,
  InstitutionName nvarchar(120) NOT NULL,
  Area nvarchar(150) NOT NULL, 
  Country nvarchar(100) NOT NULL, 
  TelephoneNumber nvarchar(20) NOT NULL, 
  InstitutionDescription nvarchar(250)
)
GO

INSERT INTO InstitutionInformation VALUES (4440, 'Computational Vision and Robotics Institute', 'Computer Science', 'United States','1880903914555','Computational Vision and Robotics Institute');
INSERT INTO InstitutionInformation VALUES (4451, 'Network Science Institute', 'Network Communication', 'United States','1880903914666','Network Science Institute');
INSERT INTO InstitutionInformation VALUES (4461, 'Networking and Security Institute', 'Network Communication', 'United States','1880903914777','Networking and Security Institute');
INSERT INTO InstitutionInformation VALUES (4473, 'Bio-Inspired Computation Institute', 'Bio-Information', 'United States','1880903914444','Bio-Inspired Computation Institute');
INSERT INTO InstitutionInformation VALUES (4484, 'Social Network Mining Institute', 'Data Mining', 'United Kingdom','5680903914888','Social Network Mining Institute');
INSERT INTO InstitutionInformation VALUES (4495, 'Space Science and Engineering Institute', 'Space Science', 'Norway','4580903919999','Space Science and Engineering Institute');
GO

CREATE TABLE CorrespondingAuthor(
 AuthorID nvarchar(20) PRIMARY KEY,
 AuthorName nvarchar(100) NOT NULL,
 AuthorBirthday Datetime NOT NULL,
 Bio nvarchar(250) NOT NULL,
 Skills nvarchar(200),
 InstitutionID int REFERENCES InstitutionInformation(InstitutionID) ON DELETE CASCADE ON UPDATE CASCADE)
GO


INSERT INTO CorrespondingAuthor VALUES (N'AU0001',N'Ronghua Du',CAST(N'1960-05-18' AS DateTime), N'Researcher at Micro/Nano Satellite Research Center, Nanjing University of Science and Technology, Nanjing, 210094, China', N'Communication Techniques', 4440);
GO

INSERT INTO CorrespondingAuthor VALUES (N'AU0002',N'Alexander Swearingen',CAST(N'1970-07-21' AS DateTime), N'PhD Candidate at Department of Nuclear Engineering and Radiation Sciences, Missouri University of Science and Technology, 301 W 14th St, Rolla, MO, 65401, USA', N'Artificial Intellegent', 4451);
GO

INSERT INTO CorrespondingAuthor VALUES (N'AU0003',N'T. Sean Drewry',CAST(N'1971-09-26' AS DateTime), N'Researcher at Department of Nuclear Engineering and Radiation Sciences, Missouri University of Science and Technology, 301 W 14th St, Rolla, MO, 65401, USA', N'Computer Science, Data Mining', 4461);
GO

INSERT INTO CorrespondingAuthor VALUES (N'AU0004',N'P. Neelamegam',CAST(N'1972-10-22' AS DateTime), N'Researcher at Department of Nuclear Engineering and Radiation Sciences, Missouri University of Science and Technology, 301 W 14th St, Rolla, MO, 65401, USA', N'Data Analysis', 4484);
GO

INSERT INTO CorrespondingAuthor VALUES (N'AU0015',N'Mohamed Maher Ata',CAST(N'1980-11-21' AS DateTime), N'PhD. Candidate at Hamburg University of Technology, Hamburg, Germany', N'Robotics, AI', 4484);
GO

INSERT INTO CorrespondingAuthor VALUES (N'AU0016',N'Mohamed El-Darieby',CAST(N'1983-07-23' AS DateTime), N'Researcher at Hamburg University of Technology, Hamburg, Germany', N'Mechanical Engineering, AI', 4484);
GO

INSERT INTO CorrespondingAuthor VALUES (N'AU0017',N'Mustafa Abdelnabi',CAST(N'1991-03-29' AS DateTime), N'Researcher at School of Advanced Technologies, Iran University of Science and Technology, Narmak, Tehran, 16844, Iran', N'Automotive Engineering, AI', 4495);
GO

INSERT INTO CorrespondingAuthor VALUES (N'AU0018',N'Praveen Kumar Rajendran',CAST(N'1992-02-13' AS DateTime), N'PhD. Candidate Aerospace Group, Faculty of New Sciences and Technologies, University of Tehran, North Kargar Street, Tehran, Iran', N'Electrical Engineering', 4495);
GO

INSERT INTO CorrespondingAuthor VALUES (N'AU0019',N'Majid Bakhtiari',CAST(N'1986-01-21' AS DateTime), N'PhD. Candidate School of Advanced Technologies, Iran University of Science and Technology, Narmak, Tehran, 16844, Iran', N'Automotive Engineering', 4495);
GO