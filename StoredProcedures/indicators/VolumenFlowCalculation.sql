CREATE DEFINER=`root`@`%` PROCEDURE `VolumeFlowCalculation`(

)

BEGIN

	SET time_zone='+01:00';
	
	SET @_volume5min := (SELECT SUM(volume) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 5 minute));
	SET @_volume60min := (SELECT SUM(volume) FROM kraken.quotes WHERE timestamp > (NOW() - INTERVAL 65 minute) AND timestamp < (NOW() - INTERVAL 5 minute) );
	-- TIMESTAMP VALUES ARE SHARED WITH THE SMA TIMESTAMP SP. TIMEDIFF IS MS SHOULDN´T BE RELEVANT
	
	UPDATE kraken.indicators
    SET `volume5min` = @_volume5min, 
		`volume60min` = @_volume60min
    ORDER BY timestamp DESC LIMIT 1;
	
END