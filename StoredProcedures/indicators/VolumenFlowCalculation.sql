CREATE DEFINER=`root`@`%` PROCEDURE `VolumeFlowCalculation`(
_market VARCHAR(20),
_coinpair VARCHAR(20)
)

BEGIN

	SET time_zone='+01:00';
	
	SET @query = CONCAT('SELECT SUM(volume) FROM markets.',_market,'_quotes WHERE (timestamp > (NOW() - INTERVAL 5 minute))  AND (coinpair = "',_coinpair, '") INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volume5min := @query_output;
	
	SET @query = CONCAT('SELECT SUM(volume) FROM markets.',_market,'_quotes WHERE (timestamp > (now() - interval 65 minute)) AND (timestamp < (now() - interval 5 minute))  AND (coinpair = "',_coinpair, '") INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volume60min := @query_output;
	
	
	IF (_market = 'kraken') THEN
		UPDATE analytics.kraken_indicators
		SET `volume5min` = @_volume5min, 
			`volume60min` = @_volume60min
		WHERE `coinpair` = _coinpair
		ORDER BY timestamp DESC LIMIT 1;
	END IF;
	
	IF (_market = 'binance') THEN
		UPDATE analytics.binance_indicators
		SET `volume5min` = @_volume5min, 
			`volume60min` = @_volume60min
		WHERE `coinpair` = _coinpair
		ORDER BY timestamp DESC LIMIT 1;
	END IF;
	
END