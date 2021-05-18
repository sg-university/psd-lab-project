DROP TABLE IF EXISTS TrDetail;
DROP TABLE IF EXISTS TrHeader;
DROP TABLE IF EXISTS MsFlowerType;
DROP TABLE IF EXISTS MsEmployee;
DROP TABLE IF EXISTS MsMember;
DROP TABLE IF EXISTS MsFlower;

CREATE TABLE MsUser
(UserID       UNIQUEIDENTIFIER primary key, 
 UserName     VARCHAR(MAX), 
 UserDOB      DATE, 
 UserGender   VARCHAR(MAX), 
 UserAddress  VARCHAR(MAX), 
 UserPhone    VARCHAR(MAX), 
 UserEmail    VARCHAR(MAX), 
 UserPassword VARCHAR(MAX),
 RoleID UNIQUEIDENTIFIER foreign key references MsUserRole(RoleID)
);
CREATE TABLE MsRole(
 RoleID UNIQUEIDENTIFIER primary key,
 RoleName varchar(max)
)
CREATE TABLE MsEmployee
(EmployeeID       UNIQUEIDENTIFIER, 
 EmployeeSalary   NUMERIC, 
 UserID UNIQUEIDENTIFIER foreign key references MsUser(UserID),
 CONSTRAINT PK_MSEmployee_EmployeeID PRIMARY KEY(EmployeeID)
)
CREATE TABLE MsMember
(MemberID       UNIQUEIDENTIFIER, 
 UserID UNIQUEIDENTIFIER foreign key references MsUser(UserID),
 CONSTRAINT PK_MSMember_MemberID PRIMARY KEY(MemberID)
);

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
 EmployeeRole	  VARCHAR(MAX) default 'staff',
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
 CONSTRAINT PK_TrHeader_TransactionID PRIMARY KEY(TransactionID), 
 CONSTRAINT FK_TrHeader_MsMember_MemberID FOREIGN KEY(MemberID) REFERENCES MsMember(MemberID), 
 CONSTRAINT FK_TrHeader_MsEmployee_EmployeeID FOREIGN KEY(EmployeeID) REFERENCES MsEmployee(EmployeeID)
);
CREATE TABLE TrDetail
(DetailID      UNIQUEIDENTIFIER, 
 TransactionID UNIQUEIDENTIFIER, 
 FlowerID      UNIQUEIDENTIFIER, 
 Quantity      NUMERIC, 
 CONSTRAINT PK_TrHeader_DetailID PRIMARY KEY(DetailID), 
 CONSTRAINT FK_TrDetail_TrHeader_TransactionID FOREIGN KEY(TransactionID) REFERENCES TrHeader(TransactionID), 
 CONSTRAINT FK_TrDetail_MsFlower_FlowerID FOREIGN KEY(FlowerID) REFERENCES MsFlower(FlowerID),
);