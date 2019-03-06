delimiter | 

DROP PROCEDURE IF EXISTS orderbook.DeleteOrdersTableData;

CREATE DEFINER=`root`@`%` PROCEDURE orderbook.DeleteOrdersTableData(
)
BEGIN
	set sql_safe_updates=0;
	DELETE FROM orders;
END

|



