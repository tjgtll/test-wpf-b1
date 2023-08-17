use tase

DECLARE @SumInt BIGINT;
SELECT @SumInt = SUM(CAST(IntRandom AS BIGINT)) FROM random_date;

DECLARE @MedianDouble FLOAT;
SELECT @MedianDouble = PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY DoubleRandom) OVER() FROM random_date;

SELECT @SumInt AS TotalSumIntegers, @MedianDouble AS MedianDoubles;