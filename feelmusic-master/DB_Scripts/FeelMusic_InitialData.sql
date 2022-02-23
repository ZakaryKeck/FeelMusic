SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
USE [CornHacks2019DB]
GO

INSERT INTO [Video] (title, videoUrl) VALUES ('All Star', 'allstarurl.com/test');
--SELECT * FROM Video;

INSERT INTO [VideoEmotions] (idVideo, sadness, joy, fear, disgust, anger) VALUES (1, 0.1, 0.2, 0.3, 0.4, 0.5);

SELECT v.title, e.sadness, e.joy, e.fear, e.disgust, e.anger 
from VideoEmotions e
left join Video v on e.idVideo = v.idVideo;

--EXEC spGetFamilyMembers;
--EXEC spGetServiceHours;
--EXEC spGetFamilyPoints;