CREATE DEFINER=`root`@`%` PROCEDURE `SMACalculation`(
_market VARCHAR(20)
)

BEGIN

	SET time_zone='+01:00';
	
	SET @query = CONCAT('SELECT AVG(last) FROM markets.',_market,'_quotes WHERE timestamp > (NOW() - INTERVAL 5 minute) INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma5min := @query_output;
	
	SET @query = CONCAT('SELECT AVG(last) FROM markets.',_market,'_quotes WHERE timestamp > (NOW() - INTERVAL 20 minute) INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma20min := @query_output;
	
	SET @query = CONCAT('SELECT AVG(last) FROM markets.',_market,'_quotes WHERE timestamp > (NOW() - INTERVAL 60 minute) INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma60min := @query_output;
	
	SET @query = CONCAT('SELECT AVG(last) FROM markets.',_market,'_quotes WHERE timestamp > (NOW() - INTERVAL 24 hour) INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_sma24h := @query_output;
	
	
	SET @_timestamp := (NOW());

	
	-- SET @_sma5min := (SELECT AVG(last) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 5 minute));
	-- SET @_sma20min := (SELECT AVG(last) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 20 minute));
	-- SET @_sma60min := (SELECT AVG(last) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 60 minute));
	-- SET @_sma24h := (SELECT AVG(last) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 24 hour));
	-- SET @_timestamp := (NOW());
	
	
	IF (_market = 'kraken') THEN INSERT INTO kraken_indicators (`sma5min`,`sma20min`,`sma60min`,`sma24h`,`timestamp`) VALUES (@_sma5min,@_sma20min,@_sma60min,@_sma24h,@_timestamp);
	END IF;
    IF (_market = 'binance') THEN INSERT INTO binance_indicators (`sma5min`,`sma20min`,`sma60min`,`sma24h`,`timestamp`) VALUES (@_sma5min,@_sma20min,@_sma60min,@_sma24h,@_timestamp);
	END IF;
	
END