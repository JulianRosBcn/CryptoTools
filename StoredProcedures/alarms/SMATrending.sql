CREATE DEFINER=`root`@`%` PROCEDURE `SMATrending`(

)

BEGIN

	-- Variables to store state of the alarm (sensitive 0.5%). 3 values supported: buy,sell and neutral
	DECLARE _sma5min_trending VARCHAR(10) DEFAULT "neutral";
	DECLARE _sma20min_trending VARCHAR(10) DEFAULT "neutral";
	DECLARE _sma60min_trending VARCHAR(10) DEFAULT "neutral";
	DECLARE _sma24h_trending VARCHAR(10) DEFAULT "neutral";
	DECLARE _buysensor DOUBLE DEFAULT 1.0001;
	DECLARE _sellsensor DOUBLE DEFAULT 0.9999 ;
	
	SET time_zone='+01:00';

	SET @_lastquote := (SELECT last FROM kraken.quotes ORDER BY timestamp DESC LIMIT 1);
	
	SET @_lastsma5min := (SELECT sma5min FROM kraken.indicators ORDER BY timestamp DESC LIMIT 1);
	SET @_lastsma20min := (SELECT sma20min FROM kraken.indicators ORDER BY timestamp DESC LIMIT 1);
	SET @_lastsma60min := (SELECT sma60min FROM kraken.indicators ORDER BY timestamp DESC LIMIT 1);
	SET @_lastsma24h := (SELECT sma24h FROM kraken.indicators ORDER BY timestamp DESC LIMIT 1);
	
	-- sma5min
	IF  (@_lastsma5min > @_lastquote * _buysensor) THEN SET _sma5min_trending = "buy";
    END IF;
	IF  (@_lastsma5min < @_lastquote * _sellsensor) THEN SET _sma5min_trending = "sell";
	END IF;
	
	-- sma20min
	IF  (@_lastsma20min > @_lastquote * _buysensor) THEN SET _sma20min_trending = "buy";
    END IF;
	IF  (@_lastsma20min < @_lastquote * _sellsensor) THEN SET _sma20min_trending = "sell";
	END IF;
	
	-- sma60min
	IF  (@_lastsma60min > @_lastquote * _buysensor) THEN SET _sma60min_trending = "buy";
    END IF;
	IF  (@_lastsma60min < @_lastquote * _sellsensor) THEN SET _sma60min_trending = "sell";
	END IF;
	
	-- sma24h
	IF  (@_lastsma24h > @_lastquote * _buysensor) THEN SET _sma24h_trending = "buy";
    END IF;
	IF  (@_lastsma24h < @_lastquote * _sellsensor) THEN SET _sma24h_trending = "sell";
	END IF;

    
	-- SELECT @_lastsma5min, @_lastquote, _sma5min_trending;
	
	INSERT INTO kraken.alarms (`sma5min_trending`,`sma20min_trending`,`sma60min_trending`,`sma24h_trending`,`timestamp`)
    VALUES (_sma5min_trending,_sma20min_trending,_sma60min_trending,_sma24h_trending,NOW());

END 