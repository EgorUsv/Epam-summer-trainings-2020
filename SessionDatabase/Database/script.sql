CREATE TABLE Groups
(GroupId BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 GroupName NVARCHAR (30) NOT NULL 
 );

 CREATE TABLE Disciplines
(DisciplineId BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 DisciplineName NVARCHAR (30) NOT NULL 
 );

 CREATE TABLE Students
(StudentId BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 GroupId BIGINT NOT NULL,
 LastName NVARCHAR (30) NOT NULL,
 FirstName NVARCHAR (30) NOT NULL,
 Patronymic NVARCHAR (30) NOT NULL,
 Gender NVARCHAR (3) NOT NULL,
 DateOfBirth Date NOT NULL,
 FOREIGN KEY (GroupId) REFERENCES Groups (GroupId)
 );
 
 CREATE TABLE Exams
(ExamId BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 GroupId BIGINT NOT NULL,
 DisciplineId BIGINT NOT NULL,
 Term INT CHECK (Term >=1 and Term <= 2) NOT NULL,
 ExamDate Datetime NOT NULL,
 FOREIGN KEY (GroupId) REFERENCES Groups (GroupId),
 FOREIGN KEY (DisciplineId) REFERENCES Disciplines (DisciplineId)
 );

 CREATE TABLE Credits
(CreditId BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 GroupId BIGINT NOT NULL,
 DisciplineId BIGINT NOT NULL,
 Term INT CHECK (Term >=1 and Term <= 2) NOT NULL,
 CreditDate Datetime NOT NULL,
 FOREIGN KEY (GroupId) REFERENCES Groups (GroupId),
 FOREIGN KEY (DisciplineId) REFERENCES Disciplines (DisciplineId)
 );

 CREATE TABLE ExamMarks
(ExamMarkId BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 StudentId BIGINT NOT NULL,
 ExamId BIGINT NOT NULL,
 Mark INT CHECK (Mark >= 1 and Mark <= 10) NOT NULL,
 FOREIGN KEY (StudentId) REFERENCES Students (StudentId),
 FOREIGN KEY (ExamId) REFERENCES Exams (ExamId)
 );

 CREATE TABLE CreditResults
(CreditMarkId BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
 StudentId BIGINT NOT NULL,
 CreditId BIGINT NOT NULL,
 Result BIT NOT NULL,
 FOREIGN KEY (StudentId) REFERENCES Students (StudentId),
 FOREIGN KEY (CreditId) REFERENCES Credits (CreditId)
 );

 --------------------------------------------------------------------------

 INSERT INTO Groups VALUES 
 ('IP11'),
 ('IP21'),
 ('ITP11');

 INSERT INTO Disciplines VALUES 
 ('Fizika'),
 ('Fizkyltyra'),
 ('TViMS'),
 ('YAPVY'),
 ('AVS'),
 ('MCHA'),
 ('MMA'),
 ('TivPO'),
 ('PGZ'),
 ('Ks'),
 ('Wow'),
 ('MDSYBD');

INSERT INTO Students VALUES
 --IP11--
 (1,'Chistakov','Vzcheslav','Timurovich','M',convert(date,'04-10-2000')),
 (1,'Bogdanova','Nina','Valeryevna','Z',convert(date,'07-21-1997')),
 (1,'Pavlov','Arseniy','Davidovich','Z',convert(date,'02-01-1999')),
 (1,'Ponomarev','Nikita','Sergeevich','M',convert(date,'04-10-2000')),
 --IP21--
 (2,'Zhukaev','Eduard', 'Dmitreivich','M',convert(date,'05-13-1999')),
 (2,'Gerasimov','Bogdan','Konstantinovich','M',convert(date,'06-20-2000')),
 (2,'Pokrovskii','Karl','Mihailovich','M',convert(date,'07-25-2000')),
 (2,'Andreev','Ilya','Sergeevich','M',convert(date,'08-14-2000')),
 --ITP11--
 (3,'Matveev','Rostislav','Denisovich','M',convert(date,'05-14-2002')),
 (3,'Fedorov','Miron','Maksimovich','M',convert(date,'03-13-2001')),
 (3,'Baranov','Timur','Timurocich','M',convert(date,'07-15-2003')),
 (3,'Titov','Anton','Kirillovich','M',convert(date,'10-21-1995'));

  INSERT INTO Credits VALUES
 --IP11--
 (1,1,1,convert(datetime,'11-12-2019 9:00')),
 (1,2,1,convert(datetime,'11-17-2019 9:00')),
 (1,4,1,convert(datetime,'11-27-2019 9:00')),
 (1,5,2,convert(datetime,'05-09-2020 9:00')),
 (1,6,2,convert(datetime,'05-02-2020 9:00')),
 (1,8,2,convert(datetime,'05-15-2020 9:00')),
 --IP21--
 (2,10,1,convert(datetime,'11-12-2019 9:00')),
 (2,9,1,convert(datetime,'11-17-2019 9:00')),
 (2,7,1,convert(datetime,'11-13-2019 9:00')),
 (2,6,2,convert(datetime,'05-08-2020 9:00')),
 (2,5,2,convert(datetime,'05-10-2020 9:00')),
 (2,3,2,convert(datetime,'05-10-2020 9:00')),
 --ITP11--
 (3,1,1,convert(datetime,'11-11-2019 9:00')),
 (3,3,1,convert(datetime,'11-11-2019 9:00')),
 (3,4,1,convert(datetime,'11-08-2019 9:00')),
 (3,5,2,convert(datetime,'05-14-2020 9:00')),
 (3,6,2,convert(datetime,'05-22-2020 9:00')),
 (3,9,2,convert(datetime,'05-22-2020 9:00'));


 INSERT INTO Exams VALUES
 --IP11--
 (1,12,1,convert(datetime,'12-17-2019 9:00')),
 (1,11,1,convert(datetime,'12-15-2019 9:00')),
 (1,10,1,convert(datetime,'12-17-2019 9:00')),
 (1,2,2,convert(datetime,'06-19-2020 9:00')),
 (1,3,2,convert(datetime,'06-21-2020 9:00')),
 (1,4,2,convert(datetime,'06-19-2020 9:00')),
 --IP21--
 (2,1,1,convert(datetime,'12-17-2019 9:00')),
 (2,2,1,convert(datetime,'12-15-2019 9:00')),
 (2,4,1,convert(datetime,'12-15-2019 9:00')),
 (2,5,2,convert(datetime,'06-21-2020 9:00')),
 (2,7,2,convert(datetime,'06-21-2020 9:00')),
 (2,8,2,convert(datetime,'06-19-2020 9:00')),
 --ITP11--
 (3,11,1,convert(datetime,'12-17-2019 9:00')),
 (3,10,1,convert(datetime,'12-15-2019 9:00')),
 (3,8,1,convert(datetime,'12-15-2019 9:00')),
 (3,2,2,convert(datetime,'06-21-2020 9:00')),
 (3,3,2,convert(datetime,'06-19-2020 9:00')),
 (3,1,2,convert(datetime,'06-19-2020 9:00'));

 INSERT INTO ExamMarks VALUES
 --IP11		--IP21		--ITP11
 (1,1,8),	(5,7,6),	(9,13,7),
 (1,2,5),	(5,8,7),	(9,14,7),
 (1,3,4),	(5,9,2),	(9,15,7),
 (1,4,8),	(5,10,5),	(9,16,6),
 (1,5,5),	(5,11,9),	(9,17,6),
 (1,6,7),	(5,12,9),	(9,18,6),

 (2,1,8),	(6,7,5),	(10,13,8),
 (2,2,5),	(6,8,6),	(10,14,8),
 (2,3,4),	(6,9,7),	(10,15,6),
 (2,4,8),	(6,10,8),	(10,16,6),
 (2,5,5),	(6,11,6),	(10,17,5),
 (2,6,7),	(6,12,7),	(10,18,5),

 (3,1,8),	(7,7,8),	(11,13,3),
 (3,2,5),	(7,8,6),	(11,14,4),
 (3,3,3),	(7,9,7),	(11,15,4),
 (3,4,8),	(7,10,4),	(11,16,4),
 (3,5,5),	(7,11,4),	(11,17,5),
 (3,6,7),	(7,12,5),	(11,18,6),

 (4,1,8),	(8,7,9),	(12,13,7),
 (4,2,5),	(8,8,9),	(12,14,7),
 (4,3,4),	(8,9,8),	(12,15,7),
 (4,4,8),	(8,10,7),	(12,16,6),
 (4,5,3),	(8,11,3),	(12,17,6),
 (4,6,7),	(8,12,7),	(12,18,6);

  INSERT INTO CreditResults VALUES 
 --IP11		--IP21		--ITP11
 (1,1,1),	(5,7,1),	(9,13,1),
 (1,2,1),	(5,8,1),	(9,14,1),
 (1,3,1),	(5,9,1),	(9,15,1),
 (1,4,1),	(5,10,1),	(9,16,1),
 (1,5,1),	(5,11,1),	(9,17,1),
 (1,6,1),	(5,12,1),	(9,18,1),

 (2,1,1),	(6,7,1),	(10,13,1),
 (2,2,1),	(6,8,1),	(10,14,1),
 (2,3,1),	(6,9,1),	(10,15,1),
 (2,4,1),	(6,10,1),	(10,16,1),
 (2,5,1),	(6,11,1),	(10,17,1),
 (2,6,1),	(6,12,1),	(10,18,1),

 (3,1,1),	(7,7,1),	(11,13,1),
 (3,2,0),	(7,8,1),	(11,14,1),
 (3,3,1),	(7,9,1),	(11,15,1),
 (3,4,1),	(7,10,1),	(11,16,1),
 (3,5,1),	(7,11,0),	(11,17,1),
 (3,6,1),	(7,12,1),	(11,18,1),

 (4,1,1),	(8,7,1),	(12,13,1),
 (4,2,1),	(8,8,1),	(12,14,1),
 (4,3,1),	(8,9,1),	(12,15,1),
 (4,4,1),	(8,10,1),	(12,16,1),
 (4,5,0),	(8,11,1),	(12,17,0),
 (4,6,1),	(8,12,1),	(12,18,1);