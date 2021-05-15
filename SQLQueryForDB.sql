DROP TABLE IF EXISTS MsEmployee;
DROP TABLE IF EXISTS MsMember;
DROP TABLE IF EXISTS MsFlower;
DROP TABLE IF EXISTS MsFlowerType;
DROP TABLE IF EXISTS TrTransaction;
DROP TABLE IF EXISTS TrDetail;
CREATE TABLE MsEmployee
(EmployeeID       UNIQUEIDENTIFIER, 
 EmployeeName     VARCHAR(MAX), 
 EmployeeDOB      DATE, 
 EmployeeGender   VARCHAR(MAX), 
 EmployeeAddress  VARCHAR(MAX), 
 EmployeePhone    VARCHAR(MAX), 
 EmployeeEmail    VARCHAR(MAX), 
 EmployeeSalary   NUMERIC, 
 EmployeePassword VARCHAR(MAX), 
 CONSTRAINT PK_MSEmployee_EmployeeID PRIMARY KEY(EmployeeID)
);
CREATE TABLE MsMember
(MemberID       UNIQUEIDENTIFIER, 
 MemberName     VARCHAR(MAX), 
 MemberDOB      DATETIME, 
 MemberGender   VARCHAR(MAX), 
 MemberAddress  VARCHAR(MAX), 
 MemberPhone    VARCHAR(MAX), 
 MemberEmail    VARCHAR(MAX), 
 MemberPassword VARCHAR(MAX), 
 CONSTRAINT PK_MSMember_MemberID PRIMARY KEY(MemberID)
);
CREATE TABLE MsFlowerType
(FlowerTypeID   UNIQUEIDENTIFIER, 
 FlowerTypeName VARCHAR(MAX), 
 CONSTRAINT PK_MSFlowerType_FlowerTypeID PRIMARY KEY(FlowerTypeID)
);
CREATE TABLE MsFlower
(FlowerID          UNIQUEIDENTIFIER, 
 FlowerName        VARCHAR(MAX), 
 FlowerTypeID      UNIQUEIDENTIFIER, 
 FlowerDescription VARCHAR(MAX), 
 FlowerPrice       NUMERIC, 
 FlowerImage       VARCHAR(MAX), 
 CONSTRAINT PK_MSFlower_FlowerID PRIMARY KEY(FlowerID), 
 CONSTRAINT FK_MsFlower_MsFlowerType_FlowerTypeID FOREIGN KEY(FlowerTypeID) REFERENCES MsFlowerType(FlowerTypeID),
);
CREATE TABLE TrHeader
(TransactionID      UNIQUEIDENTIFIER, 
 MemberID           UNIQUEIDENTIFIER, 
 EmployeeID         UNIQUEIDENTIFIER, 
 TransactionDate    DATETIME, 
 DiscountPercentage NUMERIC, 
 CONSTRAINT FK_TrHeader_MsMember_MemberID FOREIGN KEY(MemberID) REFERENCES MsMember(MemberID), 
 CONSTRAINT FK_TrHeader_MsEmployee_EmployeeID FOREIGN KEY(EmployeeID) REFERENCES MsEmployee(EmployeeID)
);
CREATE TABLE TrDetail
(TransactionID UNIQUEIDENTIFIER, 
 FlowerID      UNIQUEIDENTIFIER, 
 Quantity      NUMERIC, 
 CONSTRAINT FK_TrDetail_MsFlower_FlowerID FOREIGN KEY(FlowerID) REFERENCES MsFlower(FlowerID),
);