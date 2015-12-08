CREATE PROCEDURE spFindCourse
	@Phrase varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT c.CourseID, c.[Description], c.Title, c.Location, c.Picture, c.Price 
	FROM Courses c 
		LEFT JOIN CourseTag ct ON ct.CourseId = c.CourseID
	LEFT JOIN Tags t ON ct.TagId = t.TagId
		GROUP BY c.CourseID, c.[Description], c.Title, c.Location, c.Picture, c.Price 
			HAVING
				c.Title LIKE ('%'+@Phrase+'%') 
				OR 
				c.[Description] LIKE ('%'+@Phrase+'%');
END