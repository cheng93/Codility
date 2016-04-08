CREATE FUNCTION Kalium2015()
RETURNS int
AS
BEGIN
	DECLARE @output int;

	WITH cte AS (
		SELECT s1.l, s1.r 
		FROM Segments s1
		WHERE 
			NOT EXISTS (
				SELECT NULL
				FROM Segments s2
				WHERE (s2.l <= s1.l AND s2.r > s1.r)
					OR (s2.l < s1.l AND s2.r >= s1.r)
			)
	)
	SELECT @output = COALESCE(SUM(n), 0)
	FROM (
		SELECT c1.r - MAX(COALESCE(c2.r, c1.l)) n
		FROM cte c1
			LEFT JOIN cte c2
				ON c2.l < c1.l AND c2.r > c1.l 
		GROUP BY c1.r
	) T;
	
	RETURN @output;
END