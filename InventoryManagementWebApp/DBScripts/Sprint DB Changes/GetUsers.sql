CREATE PROCEDURE usp_GetUsers
AS
BEGIN

        SELECT U.Id, U.[Name], UT.Title,U.MobileNumber,U.EmailId,U.IsActive,U.IsDeleted FROM [User] U INNER JOIN [UserType] UT ON U.UserTypeId = UT.Id


		
END