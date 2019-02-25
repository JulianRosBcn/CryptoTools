CREATE PROCEDURE `DeleteIndicatorsTableData` ()
BEGIN
	set sql_safe_updates=0;
	DELETE FROM indicators;
END