-- Bảng User: Lưu thông tin tài khoản người dùng trong hệ thống
CREATE TABLE [dbo].[User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(255),
    RoleGroupId INT,  -- Nhóm quyền của người dùng, có thể ràng buộc qua code
    IsDel bit,
);

-- Bảng RoleGroup: Lưu thông tin nhóm quyền (có thể là quản trị viên, nhân viên,...) của hệ thống
CREATE TABLE [dbo].[RoleGroup] (
    RoleGroupId INT PRIMARY KEY IDENTITY(1,1),
    RoleGroupName NVARCHAR(255) NOT NULL
);

-- Bảng Role: Lưu thông tin chi tiết về các vai trò trong hệ thống
CREATE TABLE [dbo].[Role] (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX)
);

-- Bảng Permission: Lưu quyền truy cập (xem, thêm, sửa, xóa) của các nhóm quyền cho từng vai trò
CREATE TABLE [dbo].[Permission] (
    PermissionId INT PRIMARY KEY IDENTITY(1,1),
    TableName NVARCHAR(255) NOT NULL,
    RoleGroupId INT,  -- Nhóm quyền áp dụng, ràng buộc qua code
    RoleId INT,       -- Vai trò áp dụng, ràng buộc qua code
    CanView BIT NOT NULL,
    CanAdd BIT NOT NULL,
    CanEdit BIT NOT NULL,
    CanDelete BIT NOT NULL
);

-- Bảng Menu: Lưu thông tin về menu trong giao diện người dùng
CREATE TABLE [dbo].[Menu] (
    MenuId INT PRIMARY KEY IDENTITY(1,1),
    MenuName NVARCHAR(255) NOT NULL,
    MenuUrl NVARCHAR(255),
    ParentMenuId INT NULL, -- Menu cha nếu có
    IsVisible BIT NOT NULL
);

-- Bảng RoleMenuAccess: Xác định quyền truy cập vào các menu của từng nhóm quyền
CREATE TABLE [dbo].[RoleMenuAccess] (
    AccessId INT PRIMARY KEY IDENTITY(1,1),
    RoleGroupId INT,  -- Nhóm quyền được áp dụng, ràng buộc qua code
    MenuId INT,       -- Menu được áp dụng, ràng buộc qua code
    CanAccess BIT NOT NULL
);

-- Bảng Project: Lưu thông tin về các dự án trong công ty
CREATE TABLE [dbo].[Project] (
    ProjectId INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME,
    Status INT NOT NULL,
    CreatedBy INT,    -- Người tạo dự án, ràng buộc qua code
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Bảng Task: Lưu thông tin về các công việc thuộc dự án
CREATE TABLE [dbo].[Task] (
    TaskId INT PRIMARY KEY IDENTITY(1,1),
    ProjectId INT,    -- Dự án chứa công việc, ràng buộc qua code
    AssignedTo INT,   -- Người được giao công việc, ràng buộc qua code
    TaskName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    DueDate DATETIME,
    Status INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME
);

-- Bảng Request: Lưu các yêu cầu liên quan đến dự án, ví dụ như yêu cầu thay đổi hoặc phê duyệt
CREATE TABLE [dbo].[Request] (
    RequestId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,       -- Người tạo yêu cầu, ràng buộc qua code
    ProjectId INT,    -- Dự án liên quan, ràng buộc qua code
    RequestType NVARCHAR(100),
    Description NVARCHAR(MAX),
    Status INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME
);

-- Bảng ProjectUser: Lưu thông tin người dùng tham gia vào từng dự án và vai trò của họ trong dự án
CREATE TABLE [dbo].[ProjectUser] (
    ProjectUserId INT PRIMARY KEY IDENTITY(1,1),
    ProjectId INT,    -- Dự án, ràng buộc qua code
    UserId INT,       -- Người tham gia, ràng buộc qua code
    Role NVARCHAR(50),
    JoinedAt DATETIME DEFAULT GETDATE()
);

-- Bảng Comment: Lưu các bình luận của người dùng trên từng công việc
CREATE TABLE [dbo].[Comment] (
    CommentId INT PRIMARY KEY IDENTITY(1,1),
    TaskId INT,       -- Công việc liên quan, ràng buộc qua code
    UserId INT,       -- Người tạo bình luận, ràng buộc qua code
    Content NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Bảng RefreshTokens: Lưu thông tin về mã refresh token cho xác thực
CREATE TABLE [dbo].[RefreshTokens] (
    Token NVARCHAR(255) PRIMARY KEY,
    ExpiryDate DATETIME NOT NULL,
    IsRevoked BIT NOT NULL,
    UserId NVARCHAR(255) NOT NULL  -- Người dùng sở hữu token, không ràng buộc
);

-- Bảng ProjectUserInvite: Lưu thông tin về lời mời tham gia dự án của người dùng
CREATE TABLE [dbo].[ProjectUserInvite] (
    InviteId INT PRIMARY KEY IDENTITY(1,1),
    ProjectId INT,    -- Dự án, ràng buộc qua code
    UserId INT,       -- Người được mời, ràng buộc qua code
    Status INT,
    SentAt DATETIME DEFAULT GETDATE(),
    AcceptedAt DATETIME
);
