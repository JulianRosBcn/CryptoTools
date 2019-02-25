CREATE PROCEDURE `DeleteAlarmsTableData` ()
BEGIN
	set sql_safe_updates=0;
	DELETE FROM alarms;
END
