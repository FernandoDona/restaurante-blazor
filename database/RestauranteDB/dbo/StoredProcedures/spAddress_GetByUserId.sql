CREATE PROCEDURE [dbo].[spAddresses_GetByUserId]
	@UserId int,
	@MainAddress bit = NULL
AS
	SET NOCOUNT ON;
	SELECT
		UserId,
		Id,
		Street,
		Number,
		Neighborhood,
		Complement,
		City,
		[State],
		Zipcode,
		MainAddress
	FROM Addresses
	WHERE 
		UserId = @UserId AND 
		(MainAddress = @MainAddress OR @MainAddress IS NULL)
GO