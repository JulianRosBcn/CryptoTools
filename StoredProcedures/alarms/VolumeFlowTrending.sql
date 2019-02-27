CREATE DEFINER=`root`@`%` PROCEDURE `VolumeFlowTrending`(

)

BEGIN

	-- Variables to store state of the alarm 
	DECLARE volumeflow_trending VARCHAR(10) DEFAULT "neutral";
	
	SET time_zone='+01:00';

	SET @_last5minvolume:= (SELECT volume5min FROM kraken.indicators ORDER BY timestamp DESC LIMIT 1);
	SET @_last60minvolume:= (SELECT volume60min FROM kraken.indicators ORDER BY timestamp DESC LIMIT 1);
	
	-- volatile/neutral. Volatile means price can change, but not specific sell/buy. Trending depends on SMA
	IF  (@_last5minvolume > @_last60minvolume) THEN SET volumeflow_trending = "volatile";
    END IF;
	-- TIMESTAMP VALUES ARE SHARED WITH THE SMA TIMESTAMP SP FOR ALARMS. TIMEDIFF IS MS SHOULDN´T BE RELEVANT
	
	UPDATE kraken.alarms
    SET `volumeflow_trending` = volumeflow_trending
    ORDER BY timestamp DESC LIMIT 1;
	
	
END 