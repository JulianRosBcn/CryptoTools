CREATE DEFINER=`root`@`%` PROCEDURE `OrderManager`(

)

BEGIN

	-- Variables to store order and order type when a position is opened/closed in the market
	DECLARE _order VARCHAR(10);
	DECLARE _type VARCHAR(10);
	
	SET time_zone='+01:00';
	
	SET @_sma5mintrending := (SELECT sma5min_trending FROM kraken.alarms ORDER BY timestamp DESC LIMIT 1);
	SET @_sma20mintrending := (SELECT sma20min_trending FROM kraken.alarms ORDER BY timestamp DESC LIMIT 1);
	SET @_sma60mintrending := (SELECT sma60min_trending FROM kraken.alarms ORDER BY timestamp DESC LIMIT 1);
	SET @_sma24htrending := (SELECT sma24h_trending FROM kraken.alarms ORDER BY timestamp DESC LIMIT 1);
	SET @_volumeflowtrending := (SELECT volumeflow_trending FROM kraken.alarms ORDER BY timestamp DESC LIMIT 1);
	
	-- buy standard
	IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24Htrending = "buy") THEN 
		SET _order = "buy";
		SET _type= "std";
    END IF;
	
	-- buy top
	IF  (@_sma5mintrending = "buy") AND (@_sma20mintrending = "buy") AND (@_sma60mintrending = "buy") AND (@_sma24Htrending = "buy") AND (@_volumeflowtrending = "volatile") THEN 
		SET _order = "buy";
		SET _type= "top";
	END IF;
	
	-- sell standard
	IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24Htrending = "sell") THEN 
		SET _order = "sell";
		SET _type= "std";
    END IF;
	
	-- sell top
	IF  (@_sma5mintrending = "sell") AND (@_sma20mintrending = "sell") AND (@_sma60mintrending = "sell") AND (@_sma24Htrending = "sell") AND (@_volumeflowtrending = "volatile") THEN 
		SET _order = "sell";
		SET _type= "top";
    END IF;
	
	-- Update values in orders table
	IF (_order IS NOT NULL) AND (_type IS NOT NULL) THEN
		INSERT INTO orders (`order`,`type`,`timestamp`)
		VALUES (_order,_type,NOW());
	END IF;
	
END	
	