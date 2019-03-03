CREATE DEFINER=`root`@`%` PROCEDURE `InsertQuoteInfo`(
_market VARCHAR(20),
_coinpair VARCHAR(20),
_ask DOUBLE,
_bid DOUBLE,
_last DOUBLE,
_volume DOUBLE,
_timestamp DATETIME
)
BEGIN
	
	SET @query_output = '';
	
	
	SET @query = CONCAT('SELECT volume FROM ',_market,'_quotes WHERE (volume <> 0) AND (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	-- IF VOLUME REMAINS THE SAME THAN PREVIOUS THEN NO VOLUME HAS BEEN WAGERED
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @lastvolume := @query_output;
	IF  (_volume = @lastvolume) THEN SET _volume = 0;
	END IF;
	

	-- SET @_volume = (_volumetoday - @lastvolume);
	
	IF (_market = 'kraken') THEN INSERT INTO markets.kraken_quotes (`coinpair`,`ask`,`bid`,`last`, `volume`,`timestamp`) VALUES (_coinpair,_ask,_bid,_last,_volume,_timestamp);
	END IF;
    IF (_market = 'binance') THEN INSERT INTO markets.binance_quotes (`coinpair`,`ask`,`bid`,`last`, `volume`,`timestamp`) VALUES (_coinpair,_ask,_bid,_last,_volume,_timestamp);
	END IF;
END