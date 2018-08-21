
CREATE TABLE Status(
StatusID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50) NOT NULL
)



CREATE TABLE Employee(
EmployeeID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
SecondLastName VARCHAR(50) NOT NULL,
Phone VARCHAR(50) NOT NULL,
Email VARCHAR(50) NOT NULL,
Address VARCHAR(50) NOT NULL,
StatusID INT NOT NULL,
FOREIGN KEY (StatusID) REFERENCES Status(StatusID) 
)

INSERT INTO Status(Name)
VALUES('Active')

INSERT INTO Status(Name)
VALUES('Inactive')


INSERT INTO Employee(FirstName,LastName,SecondLastName,Phone,Email,Address,StatusID)
VALUES ('Maria Del Pilar','Mireles','Mateo','849-867-4499','Pilar.2m@hotmail.com','Vista Hermosa','1')



INSERT INTO Employee(FirstName,LastName,SecondLastName,Phone,Email,Address,StatusID)
VALUES ('Kenji','Mukai','Salcedo','849-286-2110','kensuka21@gmail.com','Vista Hermosa','2')


CREATE PROCEDURE CreaterOrUpdateEmployee
@EmployeeID INT,
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@SecondLastName VARCHAR(50),
@Phone VARCHAR(50),
@Email VARCHAR(50),
@Address VARCHAR(50)
AS
IF(@EmployeeID=0)
	BEGIN
		INSERT INTO Employee(FirstName,LastName,SecondLastName,Phone,Email,Address,StatusID)
		VALUES (@FirstName,@LastName,@SecondLastName,@Phone,@Email,@Address,1)
	END
ELSE
	BEGIN
		UPDATE Employee SET FirstName=@FirstName, LastName=@LastName, SecondLastName=@SecondLastName,Phone=@Phone,Email=@Email,Address=@Address
		WHERE EmployeeID=@EmployeeID
	END

--Change Status to empleyee removed
CREATE PROCEDURE DeleteEmployeeByID
@EmployeeID INT
AS
BEGIN
UPDATE Employee SET StatusID=2
WHERE EmployeeID=@EmployeeID
END

--Procedure to get all employee
CREATE PROCEDURE ViewAllEmployee
AS
BEGIN
SELECT E.EmployeeID,E.FirstName ,E.LastName,E.SecondLastName,E.Phone,E.Email,E.Address,S.Name AS Status FROM Employee E
INNER JOIN Status S WITH(NOLOCK) ON  S.StatusID=E.StatusID
END

CREATE PROCEDURE GetEmployeeByID
@EmployeeID INT
AS
BEGIN
SELECT * FROM Employee
WHERE EmployeeID=@EmployeeID
END
