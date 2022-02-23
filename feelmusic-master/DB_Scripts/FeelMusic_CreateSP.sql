DROP PROCEDURE spGetVideoEmotions;  
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE spGetVideoEmotions
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    SELECT v.title, e.sadness, e.joy, e.fear, e.disgust, e.anger
    from VideoEmotions e
        left join Video v on e.idVideo = v.idVideo;
END
GO
