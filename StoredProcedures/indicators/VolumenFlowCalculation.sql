CREATE DEFINER=`root`@`%` PROCEDURE `VolumeFlowCalculation`(
_market VARCHAR(20)
)

BEGIN

	SET time_zone='+01:00';
	
	SET @query = CONCAT('SELECT SUM(volume) FROM markets.',_market,'_quotes WHERE timestamp > (NOW() - INTERVAL 5 minute) INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volume5min := @query_output;
	
	SET @query = CONCAT('SELECT SUM(volume) FROM markets.',_market,'_quotes WHERE timestamp > (now() - interval 65 minute) and timestamp < (now() - interval 5 minute) INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_volume60min := @query_output;
	
	-- set @_volume5min := (select sum(volume) from kraken.quotes where timestamp > (now() - interval 5 minute));
	-- set @_volume60min := (select sum(volume) from kraken.quotes where timestamp > (now() - interval 65 minute) and timestamp < (now() - interval 5 minute) );
	-- TIMESTAMP VALUES ARE SHARED WITH THE SMA TIMESTAMP SP. TIMEDIFF IS MS SHOULDN´T BE RELEVANT
	
	IF (_market = 'kraken') THEN
		UPDATE kraken_indicators
		SET `volume5min` = @_volume5min, 
			`volume60min` = @_volume60min
		ORDER BY timestamp DESC LIMIT 1;
	END IF;
	
	IF (_market = 'binance') THEN
		UPDATE binance_indicators
		SET `volume5min` = @_volume5min, 
			`volume60min` = @_volume60min
		ORDER BY timestamp DESC LIMIT 1;
	END IF;
	
END