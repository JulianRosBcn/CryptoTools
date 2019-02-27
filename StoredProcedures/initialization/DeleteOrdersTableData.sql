CREATE PROCEDURE `DeleteOrdersTableData` ()
BEGIN
	set sql_safe_updates=0;
	DELETE FROM orders;
END
