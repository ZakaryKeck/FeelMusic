use CornHacks2019DB;


DROP TABLE IF EXISTS VideoEmotions;
DROP TABLE IF EXISTS Video;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE Video (
  idVideo INT IDENTITY(1,1) NOT NULL,
  title VARCHAR(45) NOT NULL,
  videoUrl VARCHAR(100) NOT NULL,
  sadness FLOAT NOT NULL, 
  joy FLOAT NOT NULL,
  fear FLOAT NOT NULL,
  disgust FLOAT NOT NULL,
  anger FLOAT NOT NULL,
  CONSTRAINT UC_Video UNIQUE (title, videoUrl),
  CONSTRAINT pk_idVideo PRIMARY KEY CLUSTERED (idVideo)
  );

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
USE [CornHacks2019DB]
GO

INSERT INTO [Video] (title, videoUrl, sadness, joy, fear, disgust, anger) VALUES ('All Star', 'allstarurl.com/test', 0.1, 0.2, 0.3, 0.4, 0.5);
--SELECT * FROM Video;

SELECT v.title, v.sadness, v.joy, v.fear, v.disgust, v.anger 
from Video v;