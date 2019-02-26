CREATE DEFINER=`root`@`%` PROCEDURE `InsertQuoteInfo`(
_ask DOUBLE,
_bid DOUBLE,
_last DOUBLE,
_volumetoday DOUBLE,
_volumeavgprice DOUBLE,
_numoftrades DOUBLE,
_timestamp DATETIME
)
BEGIN
	
	SET @lastvolume := (SELECT volumetoday FROM kraken.quotes ORDER BY timestamp DESC LIMIT 1);
	SET @_volume = (_volumetoday - @lastvolume);

	

	INSERT INTO quotes (`ask`,`bid`,`last`, `volume`, `volumetoday`,`volumeavgprice`,`numoftrades`,`timestamp`)
    VALUES (_ask,_bid,_last,@_volume,_volumetoday,_volumeavgprice,_numoftrades,_timestamp);

	
	
END