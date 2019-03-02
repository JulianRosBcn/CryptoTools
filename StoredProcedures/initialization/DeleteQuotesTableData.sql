CREATE PROCEDURE `DeleteQuotesTableData`(
_market VARCHAR(20)
)

BEGIN
	set sql_safe_updates=0;
	IF (_market = 'kraken') THEN DELETE FROM kraken_quotes;
	END IF;
    IF (_market = 'binance') THEN DELETE FROM binance_quotes;
	END IF;
END
