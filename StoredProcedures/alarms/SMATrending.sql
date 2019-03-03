CREATE DEFINER=`root`@`%` PROCEDURE `SMATrending`(
_market VARCHAR(20),
_coinpair VARCHAR(20)
)

BEGIN

	-- Variables to store state of the alarm (sensitive 0.5%). 3 values supported: buy,sell and neutral
	DECLARE _sma5min_trending VARCHAR(10) DEFAULT "neutral";
	DECLARE _sma20min_trending VARCHAR(10) DEFAULT "neutral";
	DECLARE _sma60min_trending VARCHAR(10) DEFAULT "neutral";
	DECLARE _sma24h_trending VARCHAR(10) DEFAULT "neutral";
	DECLARE _buysensor DOUBLE DEFAULT 1.003;
	DECLARE _sellsensor DOUBLE DEFAULT 0.997 ;
	
	SET time_zone='+01:00';

	SET @query = CONCAT('SELECT last FROM markets.',_market,'_quotes WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_lastquote := @query_output;
	
	
	SET @query = CONCAT('SELECT sma5min FROM analytics.',_market,'_indicators WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_lastsma5min := @query_output;
	
	SET @query = CONCAT('SELECT sma20min FROM analytics.',_market,'_indicators WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_lastsma20min := @query_output;
	
	SET @query = CONCAT('SELECT sma60min FROM analytics.',_market,'_indicators WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_lastsma60min := @query_output;
	
	SET @query = CONCAT('SELECT sma24h FROM analytics.',_market,'_indicators WHERE (coinpair = "',_coinpair, '") ORDER BY timestamp DESC LIMIT 1 INTO @query_output');
	PREPARE exec_query FROM @query;
	EXECUTE exec_query;
	SET @_lastsma24h := @query_output;

	
	-- sma5min
	IF  (@_lastsma5min > @_lastquote * _buysensor) THEN SET _sma5min_trending = "sell";
    END IF;
	IF  (@_lastsma5min < @_lastquote * _sellsensor) THEN SET _sma5min_trending = "buy";
	END IF;
	
	-- sma20min
	IF  (@_lastsma20min > @_lastquote * _buysensor) THEN SET _sma20min_trending = "sell";
    END IF;
	IF  (@_lastsma20min < @_lastquote * _sellsensor) THEN SET _sma20min_trending = "buy";
	END IF;
	
	-- sma60min
	IF  (@_lastsma60min > @_lastquote * _buysensor) THEN SET _sma60min_trending = "sell";
    END IF;
	IF  (@_lastsma60min < @_lastquote * _sellsensor) THEN SET _sma60min_trending = "buy";
	END IF;
	
	-- sma24h
	IF  (@_lastsma24h > @_lastquote * _buysensor) THEN SET _sma24h_trending = "sell";
    END IF;
	IF  (@_lastsma24h < @_lastquote * _sellsensor) THEN SET _sma24h_trending = "buy";
	END IF;
	
    
	-- SELECT MARKET TO INSERT DATA
	
	IF (_market = 'kraken') THEN
		INSERT INTO analytics.kraken_alarms (`coinpair`,`sma5min_trending`,`sma20min_trending`,`sma60min_trending`,`sma24h_trending`,`timestamp`)
		VALUES (_coinpair,_sma5min_trending,_sma20min_trending,_sma60min_trending,_sma24h_trending,NOW());
	END IF;
	
	IF (_market = 'binance') THEN
		INSERT INTO analytics.binance_alarms (`coinpair`,`sma5min_trending`,`sma20min_trending`,`sma60min_trending`,`sma24h_trending`,`timestamp`)
		VALUES (_coinpair,_sma5min_trending,_sma20min_trending,_sma60min_trending,_sma24h_trending,NOW());
	END IF;
	
	
END 