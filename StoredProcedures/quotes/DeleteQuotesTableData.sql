CREATE PROCEDURE `DeleteQuotesTableData` ()
BEGIN
	set sql_safe_updates=0;
	DELETE FROM quotes;
END
