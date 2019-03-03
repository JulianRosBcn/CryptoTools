CREATE DEFINER=`root`@`%` PROCEDURE `SMACalculation`(
_market VARCHAR(20),
_coinpair VARCHAR(20)
)

BEGIN

	SET time_zone='+01:00';
	
	SET @query = CONCAT('SELECT AVG(last) FROM markets.',_market,'_quotes WHERE (timestamp > (NOW() - INTERVAL 5 minute))  AND (coinpair = "' + _coinpair + '") INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5min := @query_output;
	
	SET @query = CONCAT('SELECT AVG(last) FROM markets.',_market,'_quotes WHERE timestamp > (NOW() - INTERVAL 20 minute) AND coinpair = "' + _coinpair + '") INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20min := @query_output;
	
	SET @query = CONCAT('SELECT AVG(last) FROM markets.',_market,'_quotes WHERE timestamp > (NOW() - INTERVAL 60 minute) AND coinpair = "' + _coinpair + '") INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60min := @query_output;
	
	SET @query = CONCAT('SELECT AVG(last) FROM markets.',_market,'_quotes WHERE timestamp > (NOW() - INTERVAL 24 hour) AND coinpair = "' + _coinpair +'") INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24h := @query_output;
	
	
	SET @_timestamp := (NOW());
	
	
	IF (_market = 'kraken') THEN INSERT INTO markets.kraken_indicators (`coinpair`,`sma5min`,`sma20min`,`sma60min`,`sma24h`,`timestamp`) VALUES (_coinpair,@_sma5min,@_sma20min,@_sma60min,@_sma24h,@_timestamp);
	END IF;
    IF (_market = 'binance') THEN INSERT INTO markets.binance_indicators (`coinpair`,`sma5min`,`sma20min`,`sma60min`,`sma24h`,`timestamp`) VALUES (_coinpair,@_sma5min,@_sma20min,@_sma60min,@_sma24h,@_timestamp);
	END IF;
	
END