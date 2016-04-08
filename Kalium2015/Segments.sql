CREATE TABLE Segments (
	l int NOT NULL,
	r int NOT NULL,

	CONSTRAINT Segments_PK
		PRIMARY KEY (l,r),
	CONSTRAINT Segments_CHK
		CHECK (l <= r)
)