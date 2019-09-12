USE [kpi_students]
GO

/****** Object:  StoredProcedure [fedirpetrenko].[GetStudentsContracts]    Script Date: 5/11/2018 3:18:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [fedirpetrenko].[GetStudentsContracts]
	-- Add the parameters for the stored procedure here
	@StudentId INT NULL
	--<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT persons.Name AS StudentName, persons.Surname AS StudentSurname, 
	contrs.Contract_ID AS ContractId, contrkinds.Contract_kind_name AS ContractKindName, contrs.Contract_date AS ContractDate, contrs.Contract_sum AS ContractSum,
	payms.Payment_date AS PaymentDate, payms.Payment_sum AS PaymentSum 
	FROM fedirpetrenko.PERSON AS persons
	LEFT JOIN fedirpetrenko.STUDENT AS students ON students.Student_ID = persons.Student_ID
	LEFT JOIN fedirpetrenko.CONTRACT AS contrs ON contrs.Student_ID = students.Student_ID
	LEFT JOIN fedirpetrenko.SCONTRACT_KIND AS contrkinds ON contrkinds.Contract_kind_ID = contrs.Contract_kind_ID
	LEFT JOIN fedirpetrenko.PAYMENT AS payms ON payms.Contract_ID = contrs.Contract_ID
	WHERE students.Student_ID = @StudentId OR @StudentId  = -1
END
GO

