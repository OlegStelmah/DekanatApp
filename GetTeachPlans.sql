USE [kpi_students]
GO

/****** Object:  StoredProcedure [fedirpetrenko].[GetTeachPlans]    Script Date: 5/11/2018 3:18:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [fedirpetrenko].[GetTeachPlans]
	-- Add the parameters for the stored procedure here
	@FacultyId INT NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT faculty.Faculty_name AS Faculty, cafedra.Cafedra_name AS Cafedra, speciality.Speciality_name AS Speciality,
	testkind.Test_kind_name AS TestKindName, subj.Subject_name AS SubjectName, subj.Subject_shifr AS SubjectShifr,
	semestr.Teach_begin_date AS TeachBegindDate, semestr.Teach_end_date AS TeachEndDate
	FROM fedirpetrenko.FACULTY AS faculty
	LEFT JOIN fedirpetrenko.CAFEDRA AS cafedra ON cafedra.Faculty_ID = faculty.Faculty_ID
	LEFT JOIN fedirpetrenko.SPECIALITY AS speciality ON speciality.Cafedra_ID = cafedra.Cafedra_ID
	LEFT JOIN fedirpetrenko.GROUPS AS groups ON groups.Speciality_ID = speciality.Speciality_ID
	LEFT JOIN fedirpetrenko.TEACH_PLAN AS teachplan ON teachplan.Group_ID = groups.Group_ID
	LEFT JOIN fedirpetrenko.STEST_KIND AS testkind ON testkind.Test_kind_ID = teachplan.Test_kind_ID
	LEFT JOIN fedirpetrenko.SUBJECT AS subj ON subj.Subject_ID = teachplan.Subject_ID
	LEFT JOIN fedirpetrenko.SEMESTER AS semestr ON semestr.Semester_ID = teachplan.Semester_ID
	WHERE faculty.Faculty_ID = @FacultyId OR @FacultyId  = -1
END
GO

