DELETE FROM dbo.Segments

INSERT INTO dbo.Segments(l, r)
VALUES (1,5), (2,3), (4,6)

DECLARE @Test1 bit = 0
SELECT @Test1 = CASE WHEN dbo.Kalium2015() = 5 THEN 1 ELSE 0 END

DELETE FROM dbo.Segments

INSERT INTO dbo.Segments(l, r)
VALUES (0,10), (20,30)

DECLARE @Test2 bit = 0
SELECT @Test2 = CASE WHEN dbo.Kalium2015() = 20 THEN 1 ELSE 0 END

DELETE FROM dbo.Segments

INSERT INTO dbo.Segments(l, r)
VALUES (0,1), (0,2), (4,6), (8,11)

DECLARE @Test3 bit = 0
SELECT @Test3 = CASE WHEN dbo.Kalium2015() = 7 THEN 1 ELSE 0 END

DELETE FROM dbo.Segments

INSERT INTO dbo.Segments(l, r)
VALUES (0,2),(1,3),(5,10)

DECLARE @Test4 bit = 0
SELECT @Test4 = CASE WHEN dbo.Kalium2015() = 8 THEN 1 ELSE 0 END

DELETE FROM dbo.Segments

INSERT INTO dbo.Segments(l, r)
VALUES (0,10)

DECLARE @Test5 bit = 0
SELECT @Test5 = CASE WHEN dbo.Kalium2015() = 10 THEN 1 ELSE 0 END

DELETE FROM dbo.Segments

DECLARE @Test6 bit = 0
SELECT @Test6 = CASE WHEN dbo.Kalium2015() = 0 THEN 1 ELSE 0 END

DELETE FROM dbo.Segments

INSERT INTO dbo.Segments(l, r)
VALUES (0,20), (0,3), (15,20)

DECLARE @Test7 bit = 0
SELECT @Test7 = CASE WHEN dbo.Kalium2015() = 20 THEN 1 ELSE 0 END

DELETE FROM dbo.Segments

SELECT 'Example', @Test1
UNION ALL
SELECT 'Simple 1', @Test2
UNION ALL
SELECT 'Simple 4', @Test3
UNION ALL
SELECT 'Simple 5', @Test4
UNION ALL
SELECT 'Extreme Single', @Test5
UNION ALL
SELECT 'Extreme Empty', @Test6
UNION ALL
SELECT 'Extreme Common Endpoints', @Test7