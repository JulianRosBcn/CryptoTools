CREATE DEFINER=`root`@`%` PROCEDURE `DeleteAnalyticsTableData`(
_market VARCHAR(20)
)
BEGIN
	set sql_safe_updates=0;
	IF (_market = 'kraken') THEN 
		DELETE FROM kraken_indicators;
		DELETE FROM kraken_alarms;
	END IF;
    IF (_market = 'binance') THEN 
		DELETE FROM binance_indicators;
		DELETE FROM binance_alarms;
	END IF;
END