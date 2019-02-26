CREATE DEFINER=`root`@`%` PROCEDURE `InsertQuoteInfo`(
_ask DOUBLE,
_bid DOUBLE,
_last DOUBLE,
_volume DOUBLE,
_volumetoday DOUBLE,
_volumeavgprice DOUBLE,
_numoftrades DOUBLE,
_timestamp DATETIME
)
BEGIN
	
	-- IF VOLUME REMAINS THE SAME THAN PREVIOUS THEN NO VOLUME HAS BEEN WAGERED
	SET @lastvolume := (SELECT volume FROM kraken.quotes WHERE volume <> 0 ORDER BY timestamp DESC LIMIT 1);
	IF  (_volume = @lastvolume) THEN SET _volume = 0;
	END IF;
	

	
	-- SET @_volume = (_volumetoday - @lastvolume);

	

	INSERT INTO quotes (`ask`,`bid`,`last`, `volume`, `volumetoday`,`volumeavgprice`,`numoftrades`,`timestamp`)
    VALUES (_ask,_bid,_last,_volume,_volumetoday,_volumeavgprice,_numoftrades,_timestamp);

	
	
END