USE [kpi_students]
GO

/****** Object:  StoredProcedure [fedirpetrenko].[GetDiplomas]    Script Date: 5/11/2018 3:18:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [fedirpetrenko].[GetDiplomas]
	-- Add the parameters for the stored procedure here
	@GroupId INT NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT groups.Group_code AS GroupCode, 
	person.Name AS StudentName, person.Surname AS StudentSurname,
	diplomas.Diploma_name AS DiplomaName,
	marks.Mark_name AS MarkName
	FROM fedirpetrenko.GROUPS AS groups
	LEFT JOIN fedirpetrenko.STUDENT_GROUP AS stdgroup ON stdgroup.Group_ID = groups.Group_ID
	LEFT JOIN fedirpetrenko.STUDENT AS student ON student.Student_ID = stdgroup.Student_ID
	LEFT JOIN fedirpetrenko.PERSON AS person ON person.Student_ID = stdgroup.Student_ID
	LEFT JOIN fedirpetrenko.SDIPLOMA AS diplomas ON diplomas.Diploma_ID = student.Diploma_ID
	LEFT JOIN fedirpetrenko.STUDENT_MARKS AS stdmarks ON stdmarks.Student_ID = student.Student_ID
	LEFT JOIN fedirpetrenko.SMARK AS marks ON marks.Mark_ID = stdmarks.Mark_ID
	WHERE groups.Group_ID = @GroupId OR @GroupId  = -1
END
GO

