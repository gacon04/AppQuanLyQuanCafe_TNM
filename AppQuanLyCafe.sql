if exists ( select * from SYS.databases where name='QuanLyQuanCafe')
drop database QuanLyQuanCafe
go
create database QuanLyQuanCafe
go
use QuanLyQuanCafe
CREATE TABLE Account (
    ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) COLLATE Vietnamese_CI_AI,
    CCCD_Num NVARCHAR(20) COLLATE Vietnamese_CI_AI,
    PhoneNumber NVARCHAR(15),
    Sex NVARCHAR(10) COLLATE Vietnamese_CI_AI,
    Address NVARCHAR(255) COLLATE Vietnamese_CI_AI,
    Role NVARCHAR(50) COLLATE Vietnamese_CI_AI,
    Account NVARCHAR(50),
    Password NVARCHAR(50)
);
ALTER TABLE Account
ADD Status NVARCHAR(20) COLLATE Vietnamese_CI_AI;
-- Cập nhật thông tin cho cột Status (giả sử mọi tài khoản đều đang hoạt động)
UPDATE Account
SET Status = N'Hoạt động';
CREATE TABLE Category (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) COLLATE Vietnamese_CI_AI NOT NULL,
    Description NVARCHAR(MAX) COLLATE Vietnamese_CI_AI,
    CreatedDate DATETIME DEFAULT GETDATE()
); 
-- Chèn dữ liệu vào bảng Account
INSERT INTO Account (Name, CCCD_Num, PhoneNumber, Sex, Address, Role, Account, Password, Status)
VALUES
    (N'Trần Văn A', N'123456789', N'0123456789', N'Nam', N'123 Đường Lê Lợi, Quận 1, TP.HCM', N'Admin', N'admin123', N'password123', N'Hoạt động'),
    (N'Nguyễn Thị B', N'987654321', N'0987654321', N'Nữ', N'456 Đường Nguyễn Huệ, Quận 1, TP.HCM', N'Member', N'member456', N'password456', N'Hoạt động'),
    (N'Phạm Văn C', N'456123789', N'0369852147', N'Nam', N'789 Đường Đề Thám, Quận 3, TP.HCM', N'Member', N'member789', N'password789', N'Hoạt động'),
    (N'Đặng Thị D', N'789456123', N'0932145786', N'Nữ', N'101 Đường Hai Bà Trưng, Quận 1, TP.HCM', N'Admin', N'admin456', N'passwordabc', N'Hoạt động'),
    (N'Lê Văn E', N'852741963', N'0357924681', N'Nam', N'202 Đường Tôn Đức Thắng, Quận 1, TP.HCM', N'Member', N'member321', N'passworddef', N'Hoạt động'),
    (N'Trần Thị F', N'369852147', N'0947852369', N'Nữ', N'303 Đường Võ Thị Sáu, Quận 3, TP.HCM', N'Admin', N'admin789', N'passwordghi', N'Hoạt động'),
    (N'Hoàng Văn G', N'741258963', N'0963214785', N'Nam', N'404 Đường Phạm Ngũ Lão, Quận 1, TP.HCM', N'Member', N'memberabc', N'passwordjkl', N'Hoạt động'),
    (N'Nguyễn Văn H', N'159263487', N'0923658741', N'Nam', N'505 Đường Trần Hưng Đạo, Quận 1, TP.HCM', N'Member', N'memberdef', N'passwordmno', N'Hoạt động'),
    (N'Lê Thị I', N'357486912', N'0974123658', N'Nữ', N'606 Đường Nguyễn Du, Quận 1, TP.HCM', N'Admin', N'adminxyz', N'passwordpqr', N'Hoạt động'),
    (N'Phạm Thị K', N'258963147', N'0912345678', N'Nữ', N'707 Đường Lý Tự Trọng, Quận 1, TP.HCM', N'Member', N'memberghi', N'passwordstu', N'Hoạt động'),
    (N'Đặng Văn L', N'123789456', N'0358692471', N'Nam', N'808 Đường Hồ Tùng Mậu, Quận 1, TP.HCM', N'Member', N'memberjkl', N'passwordvwx', N'Hoạt động')


INSERT INTO Category (Name, Description)
VALUES
    (N'Cafe', N'Dòng nước uống chủ lực'),
    (N'Nước ngọt', N'Mô tả danh mục 2'),
    (N'Đồ ăn sáng', N'Mô tả danh mục 3'),
    (N'Sinh tố', N'Mô tả danh mục 4');

CREATE TABLE TableList (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) COLLATE Vietnamese_CI_AI NOT NULL,
    Status NVARCHAR(MAX) COLLATE Vietnamese_CI_AI NOT NULL,
    
);
CREATE TABLE Food (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) COLLATE Vietnamese_CI_AI NOT NULL,
    Description NVARCHAR(MAX) COLLATE Vietnamese_CI_AI,
	Status NVARCHAR(MAX) COLLATE Vietnamese_CI_AI NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CategoryID INT NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE() NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Category(ID)
);
CREATE TABLE Bill (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TableID INT NOT NULL,
    TotalPrice DECIMAL(18, 2) NOT NULL,
    Discount DECIMAL(18, 2) NOT NULL,
    DateCheckin DATETIME DEFAULT GETDATE() NOT NULL,
	DateCheckout  DATETIME,
	AccountID INT NOT NULL,
    Status INT NOT NULL,
	FOREIGN KEY (AccountID) REFERENCES Account(ID),
    FOREIGN KEY (TableID) REFERENCES TableList(ID)
);

CREATE TABLE BillInfo (
    ID INT PRIMARY KEY IDENTITY(1,1),
    BillID INT NOT NULL,
    FoodID INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (BillID) REFERENCES Bill(ID),
    FOREIGN KEY (FoodID) REFERENCES Food(ID)
);
go
CREATE PROC SP_GetTableList
AS SELECT * FROM dbo.TableList

ALTER PROC USP_InsertBillInfo
@BillID INT , @FoodID INT, @Quantity INT
AS
BEGIN
    Declare @isExistBillInfo INT
	Declare @foodCount INT=1;
	SELECT @isExistBillInfo= ID, @foodCount = Quantity FROM dbo.BillInfo WHERE BillID=@BillID AND FoodID=@FoodID
	IF (@isExistBillInfo>0)
	BEGIN
		DECLARE @newCount INT = @foodCount + @Quantity
		if (@newCount>0)
			UPDATE dbo.BillInfo SET Quantity= @foodCount+ @Quantity WHERE FoodID=@FoodID
		else 
			DELETE dbo.BillInfo WHERE BillID=@BillID AND FoodID=@FoodID
	END
	ELSE
		BEGIN
			IF (@Quantity>0)
			BEGIN
				INSERT BillInfo (BillID,FoodID,Quantity)
				VALUES (
				@BillID, @FoodID,@Quantity	
				)	
			END			 
		 END
 

END
go


UPDATE Bill SET Status=0, DateCheckout='2024-06-05 12:00:00.000' WHERE ID=3