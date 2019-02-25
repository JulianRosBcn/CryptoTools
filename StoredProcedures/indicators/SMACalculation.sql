CREATE DEFINER=`root`@`%` PROCEDURE `SMACalculation`(

)

BEGIN

	SET time_zone='+01:00';
	
	SET @_sma5min := (SELECT AVG(last) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 5 minute));
	SET @_sma20min := (SELECT AVG(last) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 20 minute));
	SET @_sma60min := (SELECT AVG(last) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 60 minute));
	SET @_sma24h := (SELECT AVG(last) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 24 hour));
	SET @_timestamp := (NOW());
	
	
	
	INSERT INTO kraken.indicators (`sma5min`,`sma20min`,`sma60min`,`sma24h`,`timestamp`)
    VALUES (@_sma5min,@_sma20min,@_sma60min,@_sma24h,@_timestamp);
	
END