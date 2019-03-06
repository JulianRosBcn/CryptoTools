delimiter | 

DROP PROCEDURE IF EXISTS analytics.VolumeFlowTrending;

CREATE DEFINER=`root`@`%` PROCEDURE analytics.VolumeFlowTrending(
_market VARCHAR(20),
_coinpair VARCHAR(20)
)

BEGIN

	-- Variables to store state of the alarm 
	DECLARE volumeflow_trending VARCHAR(10) DEFAULT "neutral";
	
	-- SET time_zone='+01:00';
	
	SET @query = CONCAT('SELECT volume5min FROM analytics.',_market,'_indicators WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_last5minvolume := @query_output;
	
	SET @query = CONCAT('SELECT volume60min FROM analytics.',_market,'_indicators WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_last60minvolume := @query_output;
	
	-- volatile/neutral. Volatile means price can change, but not specific sell/buy. Trending depends on SMA
	IF  (@_last5minvolume > @_last60minvolume) THEN SET volumeflow_trending = "volatile";
    END IF;
	-- TIMESTAMP VALUES ARE SHARED WITH THE SMA TIMESTAMP SP FOR ALARMS. TIMEDIFF IS MS SHOULDN´T BE RELEVANT
	
	IF (_market = 'kraken') THEN
		UPDATE analytics.kraken_alarms
		SET `volumeflow_trending` = volumeflow_trending
		WHERE `coinpair` = _coinpair
		ORDER BY timestamp DESC LIMIT 1;
	END IF;
	
	IF (_market = 'binance') THEN
		UPDATE analytics.binance_alarms
		SET `volumeflow_trending` = volumeflow_trending
		WHERE `coinpair` = _coinpair
		ORDER BY timestamp DESC LIMIT 1;
	END IF;
	
	
END 

|